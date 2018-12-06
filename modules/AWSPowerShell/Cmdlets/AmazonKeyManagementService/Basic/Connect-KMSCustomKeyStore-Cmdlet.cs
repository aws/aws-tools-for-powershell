/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Connects or reconnects a <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a> to its associated AWS CloudHSM cluster.
    /// 
    ///  
    /// <para>
    /// The custom key store must be connected before you can create customer master keys
    /// (CMKs) in the key store or use the CMKs it contains. You can disconnect and reconnect
    /// a custom key store at any time.
    /// </para><para>
    /// To connect a custom key store, its associated AWS CloudHSM cluster must have at least
    /// one active HSM. To get the number of active HSMs in a cluster, use the <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters">DescribeClusters</a>
    /// operation. To add HSMs to the cluster, use the <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_CreateHsm">CreateHsm</a>
    /// operation.
    /// </para><para>
    /// The connection process can take an extended amount of time to complete; up to 20 minutes.
    /// This operation starts the connection process, but it does not wait for it to complete.
    /// When it succeeds, this operation quickly returns an HTTP 200 response and a JSON object
    /// with no properties. However, this response does not indicate that the custom key store
    /// is connected. To get the connection state of the custom key store, use the <a>DescribeCustomKeyStores</a>
    /// operation.
    /// </para><para>
    /// During the connection process, AWS KMS finds the AWS CloudHSM cluster that is associated
    /// with the custom key store, creates the connection infrastructure, connects to the
    /// cluster, logs into the AWS CloudHSM client as the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user</a> (CU), and rotates its password.
    /// </para><para>
    /// The <code>ConnectCustomKeyStore</code> operation might fail for various reasons. To
    /// find the reason, use the <a>DescribeCustomKeyStores</a> operation and see the <code>ConnectionErrorCode</code>
    /// in the response. For help interpreting the <code>ConnectionErrorCode</code>, see <a>CustomKeyStoresListEntry</a>.
    /// </para><para>
    /// To fix the failure, use the <a>DisconnectCustomKeyStore</a> operation to disconnect
    /// the custom key store, correct the error, use the <a>UpdateCustomKeyStore</a> operation
    /// if necessary, and then use <code>ConnectCustomKeyStore</code> again.
    /// </para><para>
    /// If you are having trouble connecting or disconnecting a custom key store, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshooting
    /// a Custom Key Store</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Connect", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Key Management Service ConnectCustomKeyStore API operation.", Operation = new[] {"ConnectCustomKeyStore"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CustomKeyStoreId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KeyManagementService.Model.ConnectCustomKeyStoreResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConnectKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Enter the key store ID of the custom key store that you want to connect. To find the
        /// ID of a custom key store, use the <a>DescribeCustomKeyStores</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CustomKeyStoreId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CustomKeyStoreId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-KMSCustomKeyStore (ConnectCustomKeyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.CustomKeyStoreId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.ConnectCustomKeyStore(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ConnectCustomKeyStoreAsync(request);
                return task.Result;
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
            public System.String CustomKeyStoreId { get; set; }
        }
        
    }
}
