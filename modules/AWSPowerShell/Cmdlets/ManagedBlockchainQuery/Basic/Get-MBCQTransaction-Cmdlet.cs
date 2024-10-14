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
    /// Gets the details of a transaction.
    /// 
    ///  <note><para>
    /// This action will return transaction details for all transactions that are <i>confirmed</i>
    /// on the blockchain, even if they have not reached <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ambq-dg/key-concepts.html#finality">finality</a>.
    /// 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQTransaction")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.Transaction")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query GetTransaction API operation.", Operation = new[] {"GetTransaction"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.Transaction or Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse",
        "This cmdlet returns an Amazon.ManagedBlockchainQuery.Model.Transaction object.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMBCQTransactionCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network where the transaction occurred.</para>
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
        public Amazon.ManagedBlockchainQuery.QueryNetwork Network { get; set; }
        #endregion
        
        #region Parameter TransactionHash
        /// <summary>
        /// <para>
        /// <para>The hash of a transaction. It is generated when a transaction is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionHash { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The identifier of a Bitcoin transaction. It is generated when a transaction is created.</para><note><para><c>transactionId</c> is only supported on the Bitcoin networks.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Transaction'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Transaction";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse, GetMBCQTransactionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Network = this.Network;
            #if MODULAR
            if (this.Network == null && ParameterWasBound(nameof(this.Network)))
            {
                WriteWarning("You are passing $null as a value for parameter Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransactionHash = this.TransactionHash;
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.GetTransactionRequest();
            
            if (cmdletContext.Network != null)
            {
                request.Network = cmdletContext.Network;
            }
            if (cmdletContext.TransactionHash != null)
            {
                request.TransactionHash = cmdletContext.TransactionHash;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.GetTransactionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "GetTransaction");
            try
            {
                #if DESKTOP
                return client.GetTransaction(request);
                #elif CORECLR
                return client.GetTransactionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ManagedBlockchainQuery.QueryNetwork Network { get; set; }
            public System.String TransactionHash { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.GetTransactionResponse, GetMBCQTransactionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Transaction;
        }
        
    }
}
