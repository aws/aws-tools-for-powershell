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
    /// Creates a <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a> that is associated with an <a href="http://docs.aws.amazon.com/cloudhsm/latest/userguide/clusters.html">AWS
    /// CloudHSM cluster</a> that you own and manage.
    /// 
    ///  
    /// <para>
    /// This operation is part of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
    /// Key Store feature</a> feature in AWS KMS, which combines the convenience and extensive
    /// integration of AWS KMS with the isolation and control of a single-tenant key store.
    /// </para><para>
    /// When the operation completes successfully, it returns the ID of the new custom key
    /// store. Before you can use your new custom key store, you need to use the <a>ConnectCustomKeyStore</a>
    /// operation to connect the new key store to its AWS CloudHSM cluster.
    /// </para><para>
    /// The <code>CreateCustomKeyStore</code> operation requires the following elements.
    /// </para><ul><li><para>
    /// You must specify an active AWS CloudHSM cluster in the same account and AWS Region
    /// as the custom key store. You can use an existing cluster or <a href="http://docs.aws.amazon.com/cloudhsm/latest/userguide/create-cluster.html">create
    /// and activate a new AWS CloudHSM cluster</a> for the key store. AWS KMS does not require
    /// exclusive use of the cluster.
    /// </para></li><li><para>
    /// You must include the content of the <i>trust anchor certificate</i> for the cluster.
    /// You created this certificate, and saved it in the <code>customerCA.crt</code> file,
    /// when you <a href="http://docs.aws.amazon.com/cloudhsm/latest/userguide/initialize-cluster.html#sign-csr">initialized
    /// the cluster</a>.
    /// </para></li><li><para>
    /// You must provide the password of the dedicated <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user</a> (CU) account in the cluster.
    /// </para><para>
    /// Before you create the custom key store, use the <a href="http://docs.aws.amazon.com/cloudhsm/latest/userguide/cloudhsm_mgmt_util-createUser.html">createUser</a>
    /// command in <code>cloudhsm_mgmt_util</code> to create <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser">a
    /// crypto user (CU) named <code>kmsuser</code></a>in specified AWS CloudHSM cluster.
    /// AWS KMS uses the <code>kmsuser</code> CU account to create and manage key material
    /// on your behalf. For instructions, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/create-keystore.html#before-keystore">Create
    /// the kmsuser Crypto User</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para></li></ul><para>
    /// The AWS CloudHSM cluster that you specify must meet the following requirements.
    /// </para><ul><li><para>
    /// The cluster must be active and be in the same AWS account and Region as the custom
    /// key store.
    /// </para></li><li><para>
    /// Each custom key store must be associated with a different AWS CloudHSM cluster. The
    /// cluster cannot be associated with another custom key store or have the same cluster
    /// certificate as a cluster that is associated with another custom key store. To view
    /// the cluster certificate, use the AWS CloudHSM <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
    /// operation. Clusters that share a backup history have the same cluster certificate.
    /// </para></li><li><para>
    /// The cluster must be configured with subnets in at least two different Availability
    /// Zones in the Region. Because AWS CloudHSM is not supported in all Availability Zones,
    /// we recommend that the cluster have subnets in all Availability Zones in the Region.
    /// </para></li><li><para>
    /// The cluster must contain at least two active HSMs, each in a different Availability
    /// Zone.
    /// </para></li></ul><para>
    /// New custom key stores are not automatically connected. After you create your custom
    /// key store, use the <a>ConnectCustomKeyStore</a> operation to connect the custom key
    /// store to its associated AWS CloudHSM cluster. Even if you are not going to use your
    /// custom key store immediately, you might want to connect it to verify that all settings
    /// are correct and then disconnect it until you are ready to use it.
    /// </para><para>
    /// If this operation succeeds, it returns the ID of the new custom key store. For help
    /// with failures, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshoot
    /// a Custom Key Store</a> in the <i>AWS KMS Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateCustomKeyStore API operation.", Operation = new[] {"CreateCustomKeyStore"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CloudHsmClusterId
        /// <summary>
        /// <para>
        /// <para>Identifies the AWS CloudHSM cluster for the custom key store. Enter the cluster ID
        /// of any active AWS CloudHSM cluster that is not already associated with a custom key
        /// store. To find the cluster ID, use the <a href="http://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudHsmClusterId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Specifies a friendly name for the custom key store. The name must be unique in your
        /// AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CustomKeyStoreName { get; set; }
        #endregion
        
        #region Parameter KeyStorePassword
        /// <summary>
        /// <para>
        /// <para>Enter the password of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user (CU) account</a> in the specified AWS CloudHSM cluster.
        /// AWS KMS logs into the cluster as this user to manage key material on your behalf.</para><para>This parameter tells AWS KMS the <code>kmsuser</code> account password; it does not
        /// change the password in the AWS CloudHSM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyStorePassword { get; set; }
        #endregion
        
        #region Parameter TrustAnchorCertificate
        /// <summary>
        /// <para>
        /// <para>Enter the content of the trust anchor certificate for the cluster. This is the content
        /// of the <code>customerCA.crt</code> file that you created when you <a href="http://docs.aws.amazon.com/cloudhsm/latest/userguide/initialize-cluster.html">initialized
        /// the cluster</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrustAnchorCertificate { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CustomKeyStoreName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSCustomKeyStore (CreateCustomKeyStore)"))
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
            context.CustomKeyStoreName = this.CustomKeyStoreName;
            context.KeyStorePassword = this.KeyStorePassword;
            context.TrustAnchorCertificate = this.TrustAnchorCertificate;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateCustomKeyStoreRequest();
            
            if (cmdletContext.CloudHsmClusterId != null)
            {
                request.CloudHsmClusterId = cmdletContext.CloudHsmClusterId;
            }
            if (cmdletContext.CustomKeyStoreName != null)
            {
                request.CustomKeyStoreName = cmdletContext.CustomKeyStoreName;
            }
            if (cmdletContext.KeyStorePassword != null)
            {
                request.KeyStorePassword = cmdletContext.KeyStorePassword;
            }
            if (cmdletContext.TrustAnchorCertificate != null)
            {
                request.TrustAnchorCertificate = cmdletContext.TrustAnchorCertificate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CustomKeyStoreId;
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
        
        private Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateCustomKeyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateCustomKeyStore");
            try
            {
                #if DESKTOP
                return client.CreateCustomKeyStore(request);
                #elif CORECLR
                return client.CreateCustomKeyStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomKeyStoreName { get; set; }
            public System.String KeyStorePassword { get; set; }
            public System.String TrustAnchorCertificate { get; set; }
        }
        
    }
}
