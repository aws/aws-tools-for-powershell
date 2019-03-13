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
    /// Use the <code>NewCustomKeyStoreName</code> parameter to change the friendly name of
    /// the custom key store to the value that you specify.
    /// </para><para>
    /// Use the <code>KeyStorePassword</code> parameter tell AWS KMS the current password
    /// of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user (CU)</a> in the associated AWS CloudHSM cluster.
    /// You can use this parameter to fix connection failures that occur when AWS KMS cannot
    /// log into the associated cluster because the <code>kmsuser</code> password has changed.
    /// This value does not change the password in the AWS CloudHSM cluster.
    /// </para><para>
    /// Use the <code>CloudHsmClusterId</code> parameter to associate the custom key store
    /// with a related AWS CloudHSM cluster, that is, a cluster that shares a backup history
    /// with the original cluster. You can use this parameter to repair a custom key store
    /// if its AWS CloudHSM cluster becomes corrupted or is deleted, or when you need to create
    /// or restore a cluster from a backup.
    /// </para><para>
    /// The cluster ID must identify a AWS CloudHSM cluster with the following requirements.
    /// </para><ul><li><para>
    /// The cluster must be active and be in the same AWS account and Region as the custom
    /// key store.
    /// </para></li><li><para>
    /// The cluster must have the same cluster certificate as the original cluster. You cannot
    /// use this parameter to associate the custom key store with an unrelated cluster. To
    /// view the cluster certificate, use the AWS CloudHSM <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
    /// operation. Clusters that share a backup history have the same cluster certificate.
    /// </para></li><li><para>
    /// The cluster must be configured with subnets in at least two different Availability
    /// Zones in the Region. Because AWS CloudHSM is not supported in all Availability Zones,
    /// we recommend that the cluster have subnets in all Availability Zones in the Region.
    /// </para></li><li><para>
    /// The cluster must contain at least two active HSMs, each in a different Availability
    /// Zone.
    /// </para></li></ul><para>
    /// If the operation succeeds, it returns a JSON object with no properties.
    /// </para><para>
    /// This operation is part of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
    /// Key Store feature</a> feature in AWS KMS, which combines the convenience and extensive
    /// integration of AWS KMS with the isolation and control of a single-tenant key store.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Key Management Service UpdateCustomKeyStore API operation.", Operation = new[] {"UpdateCustomKeyStore"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CustomKeyStoreId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CloudHsmClusterId
        /// <summary>
        /// <para>
        /// <para>Associates the custom key store with a related AWS CloudHSM cluster. </para><para>Enter the cluster ID of the cluster that you used to create the custom key store or
        /// a cluster that shares a backup history with the original cluster. You cannot use this
        /// parameter to associate a custom key store with a different cluster.</para><para>Clusters that share a backup history have the same cluster certificate. To view the
        /// cluster certificate of a cluster, use the <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter KeyStorePassword
        /// <summary>
        /// <para>
        /// <para>Enter the current password of the <code>kmsuser</code> crypto user (CU) in the AWS
        /// CloudHSM cluster that is associated with the custom key store.</para><para>This parameter tells AWS KMS the current password of the <code>kmsuser</code> crypto
        /// user (CU). It does not set or change the password of any users in the AWS CloudHSM
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyStorePassword { get; set; }
        #endregion
        
        #region Parameter NewCustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Changes the friendly name of the custom key store to the value that you specify. The
        /// custom key store name must be unique in the AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewCustomKeyStoreName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KMSCustomKeyStore (UpdateCustomKeyStore)"))
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
            
            context.CloudHsmClusterId = this.CloudHsmClusterId;
            context.CustomKeyStoreId = this.CustomKeyStoreId;
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
        }
        
    }
}
