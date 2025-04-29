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
    /// Gets the balance of a specific token, including native tokens, for a given address
    /// (wallet or contract) on the blockchain.
    /// 
    ///  <note><para>
    /// Only the native tokens BTC and ETH, and the ERC-20, ERC-721, and ERC 1155 token standards
    /// are supported.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQTokenBalance")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query GetTokenBalance API operation.", Operation = new[] {"GetTokenBalance"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse",
        "This cmdlet returns an Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse object containing multiple properties."
    )]
    public partial class GetMBCQTokenBalanceCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OwnerIdentifier_Address
        /// <summary>
        /// <para>
        /// <para>The contract or wallet address for the owner.</para>
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
        public System.String OwnerIdentifier_Address { get; set; }
        #endregion
        
        #region Parameter TokenIdentifier_ContractAddress
        /// <summary>
        /// <para>
        /// <para>This is the token's contract address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenIdentifier_ContractAddress { get; set; }
        #endregion
        
        #region Parameter TokenIdentifier_Network
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
        public Amazon.ManagedBlockchainQuery.QueryNetwork TokenIdentifier_Network { get; set; }
        #endregion
        
        #region Parameter AtBlockchainInstant_Time
        /// <summary>
        /// <para>
        /// <para>The container of the <c>Timestamp</c> of the blockchain instant.</para><note><para>This <c>timestamp</c> will only be recorded up to the second.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AtBlockchainInstant_Time { get; set; }
        #endregion
        
        #region Parameter TokenIdentifier_TokenId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the token.</para><note><para>For native tokens, use the 3 character abbreviation that best matches your token.
        /// For example, btc for Bitcoin, eth for Ether, etc. For all other token types you must
        /// specify the <c>tokenId</c> in the 64 character hexadecimal <c>tokenid</c> format.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenIdentifier_TokenId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse, GetMBCQTokenBalanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AtBlockchainInstant_Time = this.AtBlockchainInstant_Time;
            context.OwnerIdentifier_Address = this.OwnerIdentifier_Address;
            #if MODULAR
            if (this.OwnerIdentifier_Address == null && ParameterWasBound(nameof(this.OwnerIdentifier_Address)))
            {
                WriteWarning("You are passing $null as a value for parameter OwnerIdentifier_Address which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenIdentifier_ContractAddress = this.TokenIdentifier_ContractAddress;
            context.TokenIdentifier_Network = this.TokenIdentifier_Network;
            #if MODULAR
            if (this.TokenIdentifier_Network == null && ParameterWasBound(nameof(this.TokenIdentifier_Network)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenIdentifier_Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenIdentifier_TokenId = this.TokenIdentifier_TokenId;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceRequest();
            
            
             // populate AtBlockchainInstant
            var requestAtBlockchainInstantIsNull = true;
            request.AtBlockchainInstant = new Amazon.ManagedBlockchainQuery.Model.BlockchainInstant();
            System.DateTime? requestAtBlockchainInstant_atBlockchainInstant_Time = null;
            if (cmdletContext.AtBlockchainInstant_Time != null)
            {
                requestAtBlockchainInstant_atBlockchainInstant_Time = cmdletContext.AtBlockchainInstant_Time.Value;
            }
            if (requestAtBlockchainInstant_atBlockchainInstant_Time != null)
            {
                request.AtBlockchainInstant.Time = requestAtBlockchainInstant_atBlockchainInstant_Time.Value;
                requestAtBlockchainInstantIsNull = false;
            }
             // determine if request.AtBlockchainInstant should be set to null
            if (requestAtBlockchainInstantIsNull)
            {
                request.AtBlockchainInstant = null;
            }
            
             // populate OwnerIdentifier
            var requestOwnerIdentifierIsNull = true;
            request.OwnerIdentifier = new Amazon.ManagedBlockchainQuery.Model.OwnerIdentifier();
            System.String requestOwnerIdentifier_ownerIdentifier_Address = null;
            if (cmdletContext.OwnerIdentifier_Address != null)
            {
                requestOwnerIdentifier_ownerIdentifier_Address = cmdletContext.OwnerIdentifier_Address;
            }
            if (requestOwnerIdentifier_ownerIdentifier_Address != null)
            {
                request.OwnerIdentifier.Address = requestOwnerIdentifier_ownerIdentifier_Address;
                requestOwnerIdentifierIsNull = false;
            }
             // determine if request.OwnerIdentifier should be set to null
            if (requestOwnerIdentifierIsNull)
            {
                request.OwnerIdentifier = null;
            }
            
             // populate TokenIdentifier
            var requestTokenIdentifierIsNull = true;
            request.TokenIdentifier = new Amazon.ManagedBlockchainQuery.Model.TokenIdentifier();
            System.String requestTokenIdentifier_tokenIdentifier_ContractAddress = null;
            if (cmdletContext.TokenIdentifier_ContractAddress != null)
            {
                requestTokenIdentifier_tokenIdentifier_ContractAddress = cmdletContext.TokenIdentifier_ContractAddress;
            }
            if (requestTokenIdentifier_tokenIdentifier_ContractAddress != null)
            {
                request.TokenIdentifier.ContractAddress = requestTokenIdentifier_tokenIdentifier_ContractAddress;
                requestTokenIdentifierIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.QueryNetwork requestTokenIdentifier_tokenIdentifier_Network = null;
            if (cmdletContext.TokenIdentifier_Network != null)
            {
                requestTokenIdentifier_tokenIdentifier_Network = cmdletContext.TokenIdentifier_Network;
            }
            if (requestTokenIdentifier_tokenIdentifier_Network != null)
            {
                request.TokenIdentifier.Network = requestTokenIdentifier_tokenIdentifier_Network;
                requestTokenIdentifierIsNull = false;
            }
            System.String requestTokenIdentifier_tokenIdentifier_TokenId = null;
            if (cmdletContext.TokenIdentifier_TokenId != null)
            {
                requestTokenIdentifier_tokenIdentifier_TokenId = cmdletContext.TokenIdentifier_TokenId;
            }
            if (requestTokenIdentifier_tokenIdentifier_TokenId != null)
            {
                request.TokenIdentifier.TokenId = requestTokenIdentifier_tokenIdentifier_TokenId;
                requestTokenIdentifierIsNull = false;
            }
             // determine if request.TokenIdentifier should be set to null
            if (requestTokenIdentifierIsNull)
            {
                request.TokenIdentifier = null;
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
        
        private Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "GetTokenBalance");
            try
            {
                return client.GetTokenBalanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? AtBlockchainInstant_Time { get; set; }
            public System.String OwnerIdentifier_Address { get; set; }
            public System.String TokenIdentifier_ContractAddress { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork TokenIdentifier_Network { get; set; }
            public System.String TokenIdentifier_TokenId { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.GetTokenBalanceResponse, GetMBCQTokenBalanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
