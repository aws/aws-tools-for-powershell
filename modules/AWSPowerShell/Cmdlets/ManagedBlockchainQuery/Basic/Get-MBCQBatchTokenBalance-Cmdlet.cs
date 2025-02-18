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

namespace Amazon.PowerShell.Cmdlets.MBCQ
{
    /// <summary>
    /// Gets the token balance for a batch of tokens by using the <c>BatchGetTokenBalance</c>
    /// action for every token in the request.
    /// 
    ///  <note><para>
    /// Only the native tokens BTC and ETH, and the ERC-20, ERC-721, and ERC 1155 token standards
    /// are supported.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQBatchTokenBalance")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query BatchGetTokenBalance API operation.", Operation = new[] {"BatchGetTokenBalance"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse",
        "This cmdlet returns an Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse object containing multiple properties."
    )]
    public partial class GetMBCQBatchTokenBalanceCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GetTokenBalanceInput
        /// <summary>
        /// <para>
        /// <para>An array of <c>BatchGetTokenBalanceInputItem</c> objects whose balance is being requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GetTokenBalanceInputs")]
        public Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceInputItem[] GetTokenBalanceInput { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse, GetMBCQBatchTokenBalanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GetTokenBalanceInput != null)
            {
                context.GetTokenBalanceInput = new List<Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceInputItem>(this.GetTokenBalanceInput);
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
            var request = new Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceRequest();
            
            if (cmdletContext.GetTokenBalanceInput != null)
            {
                request.GetTokenBalanceInputs = cmdletContext.GetTokenBalanceInput;
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
        
        private Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "BatchGetTokenBalance");
            try
            {
                return client.BatchGetTokenBalanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceInputItem> GetTokenBalanceInput { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.BatchGetTokenBalanceResponse, GetMBCQBatchTokenBalanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
