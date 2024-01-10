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
    /// Gets the information about a specific contract deployed on the blockchain.
    /// 
    ///  <note><ul><li><para>
    /// The Bitcoin blockchain networks do not support this operation.
    /// </para></li><li><para>
    /// Metadata is currently only available for some <c>ERC-20</c> contracts. Metadata will
    /// be available for additional contracts in the future.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "MBCQAssetContract")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query GetAssetContract API operation.", Operation = new[] {"GetAssetContract"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse",
        "This cmdlet returns an Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMBCQAssetContractCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContractIdentifier_ContractAddress
        /// <summary>
        /// <para>
        /// <para>Container for the blockchain address about a contract.</para>
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
        public System.String ContractIdentifier_ContractAddress { get; set; }
        #endregion
        
        #region Parameter ContractIdentifier_Network
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
        public Amazon.ManagedBlockchainQuery.QueryNetwork ContractIdentifier_Network { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse, GetMBCQAssetContractCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContractIdentifier_ContractAddress = this.ContractIdentifier_ContractAddress;
            #if MODULAR
            if (this.ContractIdentifier_ContractAddress == null && ParameterWasBound(nameof(this.ContractIdentifier_ContractAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractIdentifier_ContractAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContractIdentifier_Network = this.ContractIdentifier_Network;
            #if MODULAR
            if (this.ContractIdentifier_Network == null && ParameterWasBound(nameof(this.ContractIdentifier_Network)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractIdentifier_Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.GetAssetContractRequest();
            
            
             // populate ContractIdentifier
            var requestContractIdentifierIsNull = true;
            request.ContractIdentifier = new Amazon.ManagedBlockchainQuery.Model.ContractIdentifier();
            System.String requestContractIdentifier_contractIdentifier_ContractAddress = null;
            if (cmdletContext.ContractIdentifier_ContractAddress != null)
            {
                requestContractIdentifier_contractIdentifier_ContractAddress = cmdletContext.ContractIdentifier_ContractAddress;
            }
            if (requestContractIdentifier_contractIdentifier_ContractAddress != null)
            {
                request.ContractIdentifier.ContractAddress = requestContractIdentifier_contractIdentifier_ContractAddress;
                requestContractIdentifierIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.QueryNetwork requestContractIdentifier_contractIdentifier_Network = null;
            if (cmdletContext.ContractIdentifier_Network != null)
            {
                requestContractIdentifier_contractIdentifier_Network = cmdletContext.ContractIdentifier_Network;
            }
            if (requestContractIdentifier_contractIdentifier_Network != null)
            {
                request.ContractIdentifier.Network = requestContractIdentifier_contractIdentifier_Network;
                requestContractIdentifierIsNull = false;
            }
             // determine if request.ContractIdentifier should be set to null
            if (requestContractIdentifierIsNull)
            {
                request.ContractIdentifier = null;
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
        
        private Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.GetAssetContractRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "GetAssetContract");
            try
            {
                #if DESKTOP
                return client.GetAssetContract(request);
                #elif CORECLR
                return client.GetAssetContractAsync(request).GetAwaiter().GetResult();
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
            public System.String ContractIdentifier_ContractAddress { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork ContractIdentifier_Network { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.GetAssetContractResponse, GetMBCQAssetContractCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
