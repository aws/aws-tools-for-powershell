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
using Amazon.ManagedBlockchainQuery;
using Amazon.ManagedBlockchainQuery.Model;

namespace Amazon.PowerShell.Cmdlets.MBCQ
{
    /// <summary>
    /// This action returns the following for a given blockchain network:
    /// 
    ///  <ul><li><para>
    /// Lists all token balances owned by an address (either a contract address or a wallet
    /// address).
    /// </para></li><li><para>
    /// Lists all token balances for all tokens created by a contract.
    /// </para></li><li><para>
    /// Lists all token balances for a given token.
    /// </para></li></ul><note><para>
    /// You must always specify the network property of the <code>tokenFilter</code> when
    /// using this operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQTokenBalanceList")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.TokenBalance")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query ListTokenBalances API operation.", Operation = new[] {"ListTokenBalances"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.TokenBalance or Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse",
        "This cmdlet returns a collection of Amazon.ManagedBlockchainQuery.Model.TokenBalance objects.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMBCQTokenBalanceListCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OwnerFilter_Address
        /// <summary>
        /// <para>
        /// <para>The contract or wallet address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerFilter_Address { get; set; }
        #endregion
        
        #region Parameter TokenFilter_ContractAddress
        /// <summary>
        /// <para>
        /// <para>This is the address of the contract.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenFilter_ContractAddress { get; set; }
        #endregion
        
        #region Parameter TokenFilter_Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network of the token.</para>
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
        public Amazon.ManagedBlockchainQuery.QueryNetwork TokenFilter_Network { get; set; }
        #endregion
        
        #region Parameter TokenFilter_TokenId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenFilter_TokenId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of token balances to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TokenBalances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TokenBalances";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse, GetMBCQTokenBalanceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwnerFilter_Address = this.OwnerFilter_Address;
            context.TokenFilter_ContractAddress = this.TokenFilter_ContractAddress;
            context.TokenFilter_Network = this.TokenFilter_Network;
            #if MODULAR
            if (this.TokenFilter_Network == null && ParameterWasBound(nameof(this.TokenFilter_Network)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenFilter_Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenFilter_TokenId = this.TokenFilter_TokenId;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate OwnerFilter
            var requestOwnerFilterIsNull = true;
            request.OwnerFilter = new Amazon.ManagedBlockchainQuery.Model.OwnerFilter();
            System.String requestOwnerFilter_ownerFilter_Address = null;
            if (cmdletContext.OwnerFilter_Address != null)
            {
                requestOwnerFilter_ownerFilter_Address = cmdletContext.OwnerFilter_Address;
            }
            if (requestOwnerFilter_ownerFilter_Address != null)
            {
                request.OwnerFilter.Address = requestOwnerFilter_ownerFilter_Address;
                requestOwnerFilterIsNull = false;
            }
             // determine if request.OwnerFilter should be set to null
            if (requestOwnerFilterIsNull)
            {
                request.OwnerFilter = null;
            }
            
             // populate TokenFilter
            var requestTokenFilterIsNull = true;
            request.TokenFilter = new Amazon.ManagedBlockchainQuery.Model.TokenFilter();
            System.String requestTokenFilter_tokenFilter_ContractAddress = null;
            if (cmdletContext.TokenFilter_ContractAddress != null)
            {
                requestTokenFilter_tokenFilter_ContractAddress = cmdletContext.TokenFilter_ContractAddress;
            }
            if (requestTokenFilter_tokenFilter_ContractAddress != null)
            {
                request.TokenFilter.ContractAddress = requestTokenFilter_tokenFilter_ContractAddress;
                requestTokenFilterIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.QueryNetwork requestTokenFilter_tokenFilter_Network = null;
            if (cmdletContext.TokenFilter_Network != null)
            {
                requestTokenFilter_tokenFilter_Network = cmdletContext.TokenFilter_Network;
            }
            if (requestTokenFilter_tokenFilter_Network != null)
            {
                request.TokenFilter.Network = requestTokenFilter_tokenFilter_Network;
                requestTokenFilterIsNull = false;
            }
            System.String requestTokenFilter_tokenFilter_TokenId = null;
            if (cmdletContext.TokenFilter_TokenId != null)
            {
                requestTokenFilter_tokenFilter_TokenId = cmdletContext.TokenFilter_TokenId;
            }
            if (requestTokenFilter_tokenFilter_TokenId != null)
            {
                request.TokenFilter.TokenId = requestTokenFilter_tokenFilter_TokenId;
                requestTokenFilterIsNull = false;
            }
             // determine if request.TokenFilter should be set to null
            if (requestTokenFilterIsNull)
            {
                request.TokenFilter = null;
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
        
        private Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "ListTokenBalances");
            try
            {
                #if DESKTOP
                return client.ListTokenBalances(request);
                #elif CORECLR
                return client.ListTokenBalancesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwnerFilter_Address { get; set; }
            public System.String TokenFilter_ContractAddress { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork TokenFilter_Network { get; set; }
            public System.String TokenFilter_TokenId { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.ListTokenBalancesResponse, GetMBCQTokenBalanceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TokenBalances;
        }
        
    }
}
