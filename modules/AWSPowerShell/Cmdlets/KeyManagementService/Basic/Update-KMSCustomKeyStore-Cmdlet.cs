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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Changes the properties of a custom key store. Use the <code>CustomKeyStoreId</code>
    /// parameter to identify the custom key store you want to edit. Use the remaining parameters
    /// to change the properties of the custom key store.
    /// 
    ///  
    /// <para>
    /// You can only update a custom key store that is disconnected. To disconnect the custom
    /// key store, use <a>DisconnectCustomKeyStore</a>. To reconnect the custom key store
    /// after the update completes, use <a>ConnectCustomKeyStore</a>. To find the connection
    /// state of a custom key store, use the <a>DescribeCustomKeyStores</a> operation.
    /// </para><para>
    /// The <code>CustomKeyStoreId</code> parameter is required in all commands. Use the other
    /// parameters of <code>UpdateCustomKeyStore</code> to edit your key store settings.
    /// </para><ul><li><para>
    /// Use the <code>NewCustomKeyStoreName</code> parameter to change the friendly name of
    /// the custom key store to the value that you specify.
    /// </para><para></para></li><li><para>
    /// Use the <code>KeyStorePassword</code> parameter tell KMS the current password of the
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user (CU)</a> in the associated CloudHSM cluster. You
    /// can use this parameter to <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html#fix-keystore-password">fix
    /// connection failures</a> that occur when KMS cannot log into the associated cluster
    /// because the <code>kmsuser</code> password has changed. This value does not change
    /// the password in the CloudHSM cluster.
    /// </para><para></para></li><li><para>
    /// Use the <code>CloudHsmClusterId</code> parameter to associate the custom key store
    /// with a different, but related, CloudHSM cluster. You can use this parameter to repair
    /// a custom key store if its CloudHSM cluster becomes corrupted or is deleted, or when
    /// you need to create or restore a cluster from a backup. 
    /// </para></li></ul><para>
    /// If the operation succeeds, it returns a JSON object with no properties.
    /// </para><para>
    /// This operation is part of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
    /// Key Store feature</a> feature in KMS, which combines the convenience and extensive
    /// integration of KMS with the isolation and control of a single-tenant key store.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a custom key store
    /// in a different Amazon Web Services account. 
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:UpdateCustomKeyStore</a>
    /// (IAM policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ConnectCustomKeyStore</a></para></li><li><para><a>CreateCustomKeyStore</a></para></li><li><para><a>DeleteCustomKeyStore</a></para></li><li><para><a>DescribeCustomKeyStores</a></para></li><li><para><a>DisconnectCustomKeyStore</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service UpdateCustomKeyStore API operation.", Operation = new[] {"UpdateCustomKeyStore"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CloudHsmClusterId
        /// <summary>
        /// <para>
        /// <para>Associates the custom key store with a related CloudHSM cluster. </para><para>Enter the cluster ID of the cluster that you used to create the custom key store or
        /// a cluster that shares a backup history and has the same cluster certificate as the
        /// original cluster. You cannot use this parameter to associate a custom key store with
        /// an unrelated cluster. In addition, the replacement cluster must <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keystore.html#before-keystore">fulfill
        /// the requirements</a> for a cluster associated with a custom key store. To view the
        /// cluster certificate of a cluster, use the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudHsmClusterId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Identifies the custom key store that you want to update. Enter the ID of the custom
        /// key store. To find the ID of a custom key store, use the <a>DescribeCustomKeyStores</a>
        /// operation.</para>
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
        
        #region Parameter KeyStorePassword
        /// <summary>
        /// <para>
        /// <para>Enter the current password of the <code>kmsuser</code> crypto user (CU) in the CloudHSM
        /// cluster that is associated with the custom key store.</para><para>This parameter tells KMS the current password of the <code>kmsuser</code> crypto user
        /// (CU). It does not set or change the password of any users in the CloudHSM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyStorePassword { get; set; }
        #endregion
        
        #region Parameter NewCustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Changes the friendly name of the custom key store to the value that you specify. The
        /// custom key store name must be unique in the Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewCustomKeyStoreName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomKeyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomKeyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KMSCustomKeyStore (UpdateCustomKeyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse, UpdateKMSCustomKeyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomKeyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudHsmClusterId = this.CloudHsmClusterId;
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            #if MODULAR
            if (this.CustomKeyStoreId == null && ParameterWasBound(nameof(this.CustomKeyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomKeyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyStorePassword = this.KeyStorePassword;
            context.NewCustomKeyStoreName = this.NewCustomKeyStoreName;
            
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
            var request = new Amazon.KeyManagementService.Model.UpdateCustomKeyStoreRequest();
            
            if (cmdletContext.CloudHsmClusterId != null)
            {
                request.CloudHsmClusterId = cmdletContext.CloudHsmClusterId;
            }
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
            }
            if (cmdletContext.KeyStorePassword != null)
            {
                request.KeyStorePassword = cmdletContext.KeyStorePassword;
            }
            if (cmdletContext.NewCustomKeyStoreName != null)
            {
                request.NewCustomKeyStoreName = cmdletContext.NewCustomKeyStoreName;
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
        
        private Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.UpdateCustomKeyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "UpdateCustomKeyStore");
            try
            {
                #if DESKTOP
                return client.UpdateCustomKeyStore(request);
                #elif CORECLR
                return client.UpdateCustomKeyStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudHsmClusterId { get; set; }
            public System.String CustomKeyStoreId { get; set; }
            public System.String KeyStorePassword { get; set; }
            public System.String NewCustomKeyStoreName { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse, UpdateKMSCustomKeyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
