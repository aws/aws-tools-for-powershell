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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Use <c>GetCustomerAccountStatistics</c> to count your customer accounts and group
    /// them by fields such as industry, geography, or enrichment status. You can use the
    /// same filters as <c>SearchCustomerAccounts</c>.
    /// </summary>
    [Cmdlet("Get", "PCCustomerAccountStatistic")]
    [OutputType("Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API GetCustomerAccountStatistics API operation.", Operation = new[] {"GetCustomerAccountStatistics"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse object containing multiple properties."
    )]
    public partial class GetPCCustomerAccountStatisticCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Aggregation
        /// <summary>
        /// <para>
        /// <para>Specifies how to group the customer accounts. Each aggregation returns the number
        /// of accounts for each value of a field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Aggregations")]
        public Amazon.PartnerCentralSelling.Model.AggregationRequest[] Aggregation { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog for the request. Valid values:</para><ul><li><para><c>AWS</c>: Production.</para></li><li><para><c>Sandbox</c>: Testing environments.</para></li></ul>
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
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Specifies a filter tree that narrows the customer accounts. Each node either combines
        /// child filters or compares a single field to a value. If you omit this field, the statistics
        /// cover all of your customer accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PartnerCentralSelling.Model.Filter Filter { get; set; }
        #endregion
        
        #region Parameter IncludeMissing
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include a group for customer accounts that have no value for
        /// the grouped field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeMissing { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse, GetPCCustomerAccountStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Aggregation != null)
            {
                context.Aggregation = new List<Amazon.PartnerCentralSelling.Model.AggregationRequest>(this.Aggregation);
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filter = this.Filter;
            context.IncludeMissing = this.IncludeMissing;
            
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
            var request = new Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsRequest();
            
            if (cmdletContext.Aggregation != null)
            {
                request.Aggregations = cmdletContext.Aggregation;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeMissing != null)
            {
                request.IncludeMissing = cmdletContext.IncludeMissing.Value;
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
        
        private Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "GetCustomerAccountStatistics");
            try
            {
                return client.GetCustomerAccountStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.PartnerCentralSelling.Model.AggregationRequest> Aggregation { get; set; }
            public System.String Catalog { get; set; }
            public Amazon.PartnerCentralSelling.Model.Filter Filter { get; set; }
            public System.Boolean? IncludeMissing { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.GetCustomerAccountStatisticsResponse, GetPCCustomerAccountStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
