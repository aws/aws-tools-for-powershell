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
using Amazon.ManagedBlockchainQuery;
using Amazon.ManagedBlockchainQuery.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MBCQ
{
    /// <summary>
    /// Lists all the contracts for a given contract type deployed by an address (either a
    /// contract address or a wallet address).
    /// 
    ///  
    /// <para>
    /// The Bitcoin blockchain networks do not support this operation.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "MBCQAssetContractList")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.AssetContract")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query ListAssetContracts API operation.", Operation = new[] {"ListAssetContracts"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.AssetContract or Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse",
        "This cmdlet returns a collection of Amazon.ManagedBlockchainQuery.Model.AssetContract objects.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMBCQAssetContractListCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContractFilter_DeployerAddress
        /// <summary>
        /// <para>
        /// <para>The network address of the deployer.</para>
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
        public System.String ContractFilter_DeployerAddress { get; set; }
        #endregion
        
        #region Parameter ContractFilter_Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network of the contract.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.QueryNetwork")]
        public Amazon.ManagedBlockchainQuery.QueryNetwork ContractFilter_Network { get; set; }
        #endregion
        
        #region Parameter ContractFilter_TokenStandard
        /// <summary>
        /// <para>
        /// <para>The container for the token standard.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.QueryTokenStandard")]
        public Amazon.ManagedBlockchainQuery.QueryTokenStandard ContractFilter_TokenStandard { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of contracts to list.</para><para>Default: <c>100</c></para><note><para>Even if additional results can be retrieved, the request can return less results than
        /// <c>maxResults</c> or an empty array of results.</para><para>To retrieve the next set of results, make another request with the returned <c>nextToken</c>
        /// value. The value of <c>nextToken</c> is <c>null</c> when there are no more results
        /// to return</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token that indicates the next set of results to retrieve.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Contracts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Contracts";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse, GetMBCQAssetContractListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContractFilter_DeployerAddress = this.ContractFilter_DeployerAddress;
            #if MODULAR
            if (this.ContractFilter_DeployerAddress == null && ParameterWasBound(nameof(this.ContractFilter_DeployerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractFilter_DeployerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContractFilter_Network = this.ContractFilter_Network;
            #if MODULAR
            if (this.ContractFilter_Network == null && ParameterWasBound(nameof(this.ContractFilter_Network)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractFilter_Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContractFilter_TokenStandard = this.ContractFilter_TokenStandard;
            #if MODULAR
            if (this.ContractFilter_TokenStandard == null && ParameterWasBound(nameof(this.ContractFilter_TokenStandard)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractFilter_TokenStandard which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
            var request = new Amazon.ManagedBlockchainQuery.Model.ListAssetContractsRequest();
            
            
             // populate ContractFilter
            var requestContractFilterIsNull = true;
            request.ContractFilter = new Amazon.ManagedBlockchainQuery.Model.ContractFilter();
            System.String requestContractFilter_contractFilter_DeployerAddress = null;
            if (cmdletContext.ContractFilter_DeployerAddress != null)
            {
                requestContractFilter_contractFilter_DeployerAddress = cmdletContext.ContractFilter_DeployerAddress;
            }
            if (requestContractFilter_contractFilter_DeployerAddress != null)
            {
                request.ContractFilter.DeployerAddress = requestContractFilter_contractFilter_DeployerAddress;
                requestContractFilterIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.QueryNetwork requestContractFilter_contractFilter_Network = null;
            if (cmdletContext.ContractFilter_Network != null)
            {
                requestContractFilter_contractFilter_Network = cmdletContext.ContractFilter_Network;
            }
            if (requestContractFilter_contractFilter_Network != null)
            {
                request.ContractFilter.Network = requestContractFilter_contractFilter_Network;
                requestContractFilterIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.QueryTokenStandard requestContractFilter_contractFilter_TokenStandard = null;
            if (cmdletContext.ContractFilter_TokenStandard != null)
            {
                requestContractFilter_contractFilter_TokenStandard = cmdletContext.ContractFilter_TokenStandard;
            }
            if (requestContractFilter_contractFilter_TokenStandard != null)
            {
                request.ContractFilter.TokenStandard = requestContractFilter_contractFilter_TokenStandard;
                requestContractFilterIsNull = false;
            }
             // determine if request.ContractFilter should be set to null
            if (requestContractFilterIsNull)
            {
                request.ContractFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.ListAssetContractsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "ListAssetContracts");
            try
            {
                return client.ListAssetContractsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContractFilter_DeployerAddress { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork ContractFilter_Network { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryTokenStandard ContractFilter_TokenStandard { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.ListAssetContractsResponse, GetMBCQAssetContractListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Contracts;
        }
        
    }
}
