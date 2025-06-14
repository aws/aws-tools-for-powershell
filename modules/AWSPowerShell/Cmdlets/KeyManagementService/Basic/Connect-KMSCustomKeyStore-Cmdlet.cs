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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Connects or reconnects a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a> to its backing key store. For an CloudHSM key store, <c>ConnectCustomKeyStore</c>
    /// connects the key store to its associated CloudHSM cluster. For an external key store,
    /// <c>ConnectCustomKeyStore</c> connects the key store to the external key store proxy
    /// that communicates with your external key manager.
    /// 
    ///  
    /// <para>
    /// The custom key store must be connected before you can create KMS keys in the key store
    /// or use the KMS keys it contains. You can disconnect and reconnect a custom key store
    /// at any time.
    /// </para><para>
    /// The connection process for a custom key store can take an extended amount of time
    /// to complete. This operation starts the connection process, but it does not wait for
    /// it to complete. When it succeeds, this operation quickly returns an HTTP 200 response
    /// and a JSON object with no properties. However, this response does not indicate that
    /// the custom key store is connected. To get the connection state of the custom key store,
    /// use the <a>DescribeCustomKeyStores</a> operation.
    /// </para><para>
    ///  This operation is part of the custom key stores feature in KMS, which combines the
    /// convenience and extensive integration of KMS with the isolation and control of a key
    /// store that you own and manage.
    /// </para><para>
    /// The <c>ConnectCustomKeyStore</c> operation might fail for various reasons. To find
    /// the reason, use the <a>DescribeCustomKeyStores</a> operation and see the <c>ConnectionErrorCode</c>
    /// in the response. For help interpreting the <c>ConnectionErrorCode</c>, see <a>CustomKeyStoresListEntry</a>.
    /// </para><para>
    /// To fix the failure, use the <a>DisconnectCustomKeyStore</a> operation to disconnect
    /// the custom key store, correct the error, use the <a>UpdateCustomKeyStore</a> operation
    /// if necessary, and then use <c>ConnectCustomKeyStore</c> again.
    /// </para><para><b>CloudHSM key store</b></para><para>
    /// During the connection process for an CloudHSM key store, KMS finds the CloudHSM cluster
    /// that is associated with the custom key store, creates the connection infrastructure,
    /// connects to the cluster, logs into the CloudHSM client as the <c>kmsuser</c> CU, and
    /// rotates its password.
    /// </para><para>
    /// To connect an CloudHSM key store, its associated CloudHSM cluster must have at least
    /// one active HSM. To get the number of active HSMs in a cluster, use the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
    /// operation. To add HSMs to the cluster, use the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_CreateHsm.html">CreateHsm</a>
    /// operation. Also, the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-cloudhsm.html#concept-kmsuser"><c>kmsuser</c> crypto user</a> (CU) must not be logged into the cluster. This prevents
    /// KMS from using this account to log in.
    /// </para><para>
    /// If you are having trouble connecting or disconnecting a CloudHSM key store, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshooting
    /// an CloudHSM key store</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>External key store</b></para><para>
    /// When you connect an external key store that uses public endpoint connectivity, KMS
    /// tests its ability to communicate with your external key manager by sending a request
    /// via the external key store proxy.
    /// </para><para>
    /// When you connect to an external key store that uses VPC endpoint service connectivity,
    /// KMS establishes the networking elements that it needs to communicate with your external
    /// key manager via the external key store proxy. This includes creating an interface
    /// endpoint to the VPC endpoint service and a private hosted zone for traffic between
    /// KMS and the VPC endpoint service.
    /// </para><para>
    /// To connect an external key store, KMS must be able to connect to the external key
    /// store proxy, the external key store proxy must be able to communicate with your external
    /// key manager, and the external key manager must be available for cryptographic operations.
    /// </para><para>
    /// If you are having trouble connecting or disconnecting an external key store, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/xks-troubleshooting.html">Troubleshooting
    /// an external key store</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a custom key store
    /// in a different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ConnectCustomKeyStore</a>
    /// (IAM policy)
    /// </para><para><b>Related operations</b></para><ul><li><para><a>CreateCustomKeyStore</a></para></li><li><para><a>DeleteCustomKeyStore</a></para></li><li><para><a>DescribeCustomKeyStores</a></para></li><li><para><a>DisconnectCustomKeyStore</a></para></li><li><para><a>UpdateCustomKeyStore</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Connect", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service ConnectCustomKeyStore API operation.", Operation = new[] {"ConnectCustomKeyStore"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse) be returned by specifying '-Select *'."
    )]
    public partial class ConnectKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Enter the key store ID of the custom key store that you want to connect. To find the
        /// ID of a custom key store, use the <a>DescribeCustomKeyStores</a> operation.</para>
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
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomKeyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-KMSCustomKeyStore (ConnectCustomKeyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse, ConnectKMSCustomKeyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            #if MODULAR
            if (this.CustomKeyStoreId == null && ParameterWasBound(nameof(this.CustomKeyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomKeyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.ConnectCustomKeyStoreRequest();
            
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
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
        
        private Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ConnectCustomKeyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ConnectCustomKeyStore");
            try
            {
                return client.ConnectCustomKeyStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomKeyStoreId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse, ConnectKMSCustomKeyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
