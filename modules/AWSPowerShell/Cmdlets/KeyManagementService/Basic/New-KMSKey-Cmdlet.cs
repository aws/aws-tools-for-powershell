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
    /// Creates a unique customer managed <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#master-keys">customer
    /// master key</a> (CMK) in your AWS account and Region. You cannot use this operation
    /// to create a CMK in a different AWS account.
    /// 
    ///  
    /// <para>
    /// You can use the <code>CreateKey</code> operation to create symmetric or asymmetric
    /// CMKs.
    /// </para><ul><li><para><b>Symmetric CMKs</b> contain a 256-bit symmetric key that never leaves AWS KMS unencrypted.
    /// To use the CMK, you must call AWS KMS. You can use a symmetric CMK to encrypt and
    /// decrypt small amounts of data, but they are typically used to generate <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#data-keys">data
    /// keys</a> or data key pairs. For details, see <a>GenerateDataKey</a> and <a>GenerateDataKeyPair</a>.
    /// </para></li><li><para><b>Asymmetric CMKs</b> can contain an RSA key pair or an Elliptic Curve (ECC) key
    /// pair. The private key in an asymmetric CMK never leaves AWS KMS unencrypted. However,
    /// you can use the <a>GetPublicKey</a> operation to download the public key so it can
    /// be used outside of AWS KMS. CMKs with RSA key pairs can be used to encrypt or decrypt
    /// data or sign and verify messages (but not both). CMKs with ECC key pairs can be used
    /// only to sign and verify messages.
    /// </para></li></ul><para>
    /// For information about symmetric and asymmetric CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
    /// Symmetric and Asymmetric CMKs</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// To create different types of CMKs, use the following guidance:
    /// </para><dl><dt>Asymmetric CMKs</dt><dd><para>
    /// To create an asymmetric CMK, use the <code>CustomerMasterKeySpec</code> parameter
    /// to specify the type of key material in the CMK. Then, use the <code>KeyUsage</code>
    /// parameter to determine whether the CMK will be used to encrypt and decrypt or sign
    /// and verify. You can't change these properties after the CMK is created.
    /// </para><para></para></dd><dt>Symmetric CMKs</dt><dd><para>
    /// When creating a symmetric CMK, you don't need to specify the <code>CustomerMasterKeySpec</code>
    /// or <code>KeyUsage</code> parameters. The default value for <code>CustomerMasterKeySpec</code>,
    /// <code>SYMMETRIC_DEFAULT</code>, and the default value for <code>KeyUsage</code>, <code>ENCRYPT_DECRYPT</code>,
    /// are the only valid values for symmetric CMKs. 
    /// </para><para></para></dd><dt>Imported Key Material</dt><dd><para>
    /// To import your own key material, begin by creating a symmetric CMK with no key material.
    /// To do this, use the <code>Origin</code> parameter of <code>CreateKey</code> with a
    /// value of <code>EXTERNAL</code>. Next, use <a>GetParametersForImport</a> operation
    /// to get a public key and import token, and use the public key to encrypt your key material.
    /// Then, use <a>ImportKeyMaterial</a> with your import token to import the key material.
    /// For step-by-step instructions, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i><i>AWS Key Management Service Developer Guide</i></i>.
    /// You cannot import the key material into an asymmetric CMK.
    /// </para><para></para></dd><dt>Custom Key Stores</dt><dd><para>
    /// To create a symmetric CMK in a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a>, use the <code>CustomKeyStoreId</code> parameter to specify the custom
    /// key store. You must also use the <code>Origin</code> parameter with a value of <code>AWS_CLOUDHSM</code>.
    /// The AWS CloudHSM cluster that is associated with the custom key store must have at
    /// least two active HSMs in different Availability Zones in the AWS Region. 
    /// </para><para>
    /// You cannot create an asymmetric CMK in a custom key store. For information about custom
    /// key stores in AWS KMS see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Using
    /// Custom Key Stores</a> in the <i><i>AWS Key Management Service Developer Guide</i></i>.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "KMSKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.KeyMetadata")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateKey API operation.", Operation = new[] {"CreateKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.CreateKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.KeyMetadata or Amazon.KeyManagementService.Model.CreateKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.KeyMetadata object.",
        "The service call response (type Amazon.KeyManagementService.Model.CreateKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>A flag to indicate whether to bypass the key policy lockout safety check.</para><important><para>Setting this value to true increases the risk that the CMK becomes unmanageable. Do
        /// not set this value to true indiscriminately.</para><para>For more information, refer to the scenario in the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default-allow-root-enable-iam">Default
        /// Key Policy</a> section in the <i><i>AWS Key Management Service Developer Guide</i></i>.</para></important><para>Use this parameter only when you include a policy in the request and you intend to
        /// prevent the principal that is making the request from making a subsequent <a>PutKeyPolicy</a>
        /// request on the CMK.</para><para>The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter CustomerMasterKeySpec
        /// <summary>
        /// <para>
        /// <para>Specifies the type of CMK to create. The <code>CustomerMasterKeySpec</code> determines
        /// whether the CMK contains a symmetric key or an asymmetric key pair. It also determines
        /// the encryption algorithms or signing algorithms that the CMK supports. You can't change
        /// the <code>CustomerMasterKeySpec</code> after the CMK is created. To further restrict
        /// the algorithms that can be used with the CMK, use its key policy or IAM policy.</para><para>For help with choosing a key spec for your CMK, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html#cmk-key-spec">Selecting
        /// a Customer Master Key Spec</a> in the <i>AWS Key Management Service Developer Guide</i>.</para><para>The default value, <code>SYMMETRIC_DEFAULT</code>, creates a CMK with a 256-bit symmetric
        /// key.</para><para>AWS KMS supports the following key specs for CMKs:</para><ul><li><para>Symmetric key (default)</para><ul><li><para><code>SYMMETRIC_DEFAULT</code> (AES-256-GCM)</para></li></ul></li><li><para>Asymmetric RSA key pairs</para><ul><li><para><code>RSA_2048</code></para></li><li><para><code>RSA_3072</code></para></li><li><para><code>RSA_4096</code></para></li></ul></li><li><para>Asymmetric NIST-recommended elliptic curve key pairs</para><ul><li><para><code>ECC_NIST_P256</code> (secp256r1)</para></li><li><para><code>ECC_NIST_P384</code> (secp384r1)</para></li><li><para><code>ECC_NIST_P521</code> (secp521r1)</para></li></ul></li><li><para>Other asymmetric elliptic curve key pairs</para><ul><li><para><code>ECC_SECG_P256K1</code> (secp256k1), commonly used for cryptocurrencies.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.CustomerMasterKeySpec")]
        public Amazon.KeyManagementService.CustomerMasterKeySpec CustomerMasterKeySpec { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Creates the CMK in the specified <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
        /// key store</a> and the key material in its associated AWS CloudHSM cluster. To create
        /// a CMK in a custom key store, you must also specify the <code>Origin</code> parameter
        /// with a value of <code>AWS_CLOUDHSM</code>. The AWS CloudHSM cluster that is associated
        /// with the custom key store must have at least two active HSMs, each in a different
        /// Availability Zone in the Region.</para><para>This parameter is valid only for symmetric CMKs. You cannot create an asymmetric CMK
        /// in a custom key store.</para><para>To find the ID of a custom key store, use the <a>DescribeCustomKeyStores</a> operation.</para><para>The response includes the custom key store ID and the ID of the AWS CloudHSM cluster.</para><para>This operation is part of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
        /// Key Store feature</a> feature in AWS KMS, which combines the convenience and extensive
        /// integration of AWS KMS with the isolation and control of a single-tenant key store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the CMK.</para><para>Use a description that helps you decide whether the CMK is appropriate for a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KeyUsage
        /// <summary>
        /// <para>
        /// <para>Determines the cryptographic operations for which you can use the CMK. The default
        /// value is <code>ENCRYPT_DECRYPT</code>. This parameter is required only for asymmetric
        /// CMKs. You can't change the <code>KeyUsage</code> value after the CMK is created.</para><para>Select only one valid value.</para><ul><li><para>For symmetric CMKs, omit the parameter or specify <code>ENCRYPT_DECRYPT</code>.</para></li><li><para>For asymmetric CMKs with RSA key material, specify <code>ENCRYPT_DECRYPT</code> or
        /// <code>SIGN_VERIFY</code>.</para></li><li><para>For asymmetric CMKs with ECC key material, specify <code>SIGN_VERIFY</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyUsageType")]
        public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>The source of the key material for the CMK. You cannot change the origin after you
        /// create the CMK. The default is <code>AWS_KMS</code>, which means AWS KMS creates the
        /// key material.</para><para>When the parameter value is <code>EXTERNAL</code>, AWS KMS creates a CMK without key
        /// material so that you can import key material from your existing key management infrastructure.
        /// For more information about importing key material into AWS KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
        /// Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>. This value
        /// is valid only for symmetric CMKs.</para><para>When the parameter value is <code>AWS_CLOUDHSM</code>, AWS KMS creates the CMK in
        /// an AWS KMS <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
        /// key store</a> and creates its key material in the associated AWS CloudHSM cluster.
        /// You must also use the <code>CustomKeyStoreId</code> parameter to identify the custom
        /// key store. This value is valid only for symmetric CMKs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.OriginType")]
        public Amazon.KeyManagementService.OriginType Origin { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The key policy to attach to the CMK.</para><para>If you provide a key policy, it must meet the following criteria:</para><ul><li><para>If you don't set <code>BypassPolicyLockoutSafetyCheck</code> to true, the key policy
        /// must allow the principal that is making the <code>CreateKey</code> request to make
        /// a subsequent <a>PutKeyPolicy</a> request on the CMK. This reduces the risk that the
        /// CMK becomes unmanageable. For more information, refer to the scenario in the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default-allow-root-enable-iam">Default
        /// Key Policy</a> section of the <i><i>AWS Key Management Service Developer Guide</i></i>.</para></li><li><para>Each statement in the key policy must contain one or more principals. The principals
        /// in the key policy must exist and be visible to AWS KMS. When you create a new AWS
        /// principal (for example, an IAM user or role), you might need to enforce a delay before
        /// including the new principal in a key policy because the new principal might not be
        /// immediately visible to AWS KMS. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/troubleshoot_general.html#troubleshoot_general_eventual-consistency">Changes
        /// that I make are not always immediately visible</a> in the <i>AWS Identity and Access
        /// Management User Guide</i>.</para></li></ul><para>If you do not provide a key policy, AWS KMS attaches a default key policy to the CMK.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default">Default
        /// Key Policy</a> in the <i>AWS Key Management Service Developer Guide</i>.</para><para>The key policy size limit is 32 kilobytes (32768 bytes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags. Each tag consists of a tag key and a tag value. Both the tag key
        /// and the tag value are required, but the tag value can be an empty (null) string.</para><para>When you add tags to an AWS resource, AWS generates a cost allocation report with
        /// usage and costs aggregated by tags. For information about adding, changing, deleting
        /// and listing tags for CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/tagging-keys.html">Tagging
        /// Keys</a>.</para><para>Use this parameter to tag the CMK when it is created. To add tags to an existing CMK,
        /// use the <a>TagResource</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KeyManagementService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.CreateKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.CreateKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyMetadata";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSKey (CreateKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.CreateKeyResponse, NewKMSKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            context.CustomerMasterKeySpec = this.CustomerMasterKeySpec;
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.Description = this.Description;
            context.KeyUsage = this.KeyUsage;
            context.Origin = this.Origin;
            context.Policy = this.Policy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KeyManagementService.Model.Tag>(this.Tag);
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
            var request = new Amazon.KeyManagementService.Model.CreateKeyRequest();
            
            if (cmdletContext.BypassPolicyLockoutSafetyCheck != null)
            {
                request.BypassPolicyLockoutSafetyCheck = cmdletContext.BypassPolicyLockoutSafetyCheck.Value;
            }
            if (cmdletContext.CustomerMasterKeySpec != null)
            {
                request.CustomerMasterKeySpec = cmdletContext.CustomerMasterKeySpec;
            }
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KeyUsage != null)
            {
                request.KeyUsage = cmdletContext.KeyUsage;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.KeyManagementService.Model.CreateKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateKey");
            try
            {
                #if DESKTOP
                return client.CreateKey(request);
                #elif CORECLR
                return client.CreateKeyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
            public Amazon.KeyManagementService.CustomerMasterKeySpec CustomerMasterKeySpec { get; set; }
            public System.String CustomKeyStoreId { get; set; }
            public System.String Description { get; set; }
            public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
            public Amazon.KeyManagementService.OriginType Origin { get; set; }
            public System.String Policy { get; set; }
            public List<Amazon.KeyManagementService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.CreateKeyResponse, NewKMSKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyMetadata;
        }
        
    }
}
