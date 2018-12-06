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
    /// Creates a customer master key (CMK) in the caller's AWS account.
    /// 
    ///  
    /// <para>
    /// You can use a CMK to encrypt small amounts of data (4 KiB or less) directly, but CMKs
    /// are more commonly used to encrypt data keys, which are used to encrypt raw data. For
    /// more information about data keys and the difference between CMKs and data keys, see
    /// the following:
    /// </para><ul><li><para>
    /// The <a>GenerateDataKey</a> operation
    /// </para></li><li><para><a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html">AWS
    /// Key Management Service Concepts</a> in the <i>AWS Key Management Service Developer
    /// Guide</i></para></li></ul><para>
    /// If you plan to <a href="http://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">import
    /// key material</a>, use the <code>Origin</code> parameter with a value of <code>EXTERNAL</code>
    /// to create a CMK with no key material.
    /// </para><para>
    /// To create a CMK in a <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a>, use <code>CustomKeyStoreId</code> parameter to specify the custom key
    /// store. You must also use the <code>Origin</code> parameter with a value of <code>AWS_CLOUDHSM</code>.
    /// The AWS CloudHSM cluster that is associated with the custom key store must have at
    /// least two active HSMs, each in a different Availability Zone in the Region.
    /// </para><para>
    /// You cannot use this operation to create a CMK in a different AWS account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.KeyMetadata")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateKey API operation.", Operation = new[] {"CreateKey"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.KeyMetadata",
        "This cmdlet returns a KeyMetadata object.",
        "The service call response (type Amazon.KeyManagementService.Model.CreateKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>A flag to indicate whether to bypass the key policy lockout safety check.</para><important><para>Setting this value to true increases the risk that the CMK becomes unmanageable. Do
        /// not set this value to true indiscriminately.</para><para>For more information, refer to the scenario in the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default-allow-root-enable-iam">Default
        /// Key Policy</a> section in the <i>AWS Key Management Service Developer Guide</i>.</para></important><para>Use this parameter only when you include a policy in the request and you intend to
        /// prevent the principal that is making the request from making a subsequent <a>PutKeyPolicy</a>
        /// request on the CMK.</para><para>The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Creates the CMK in the specified <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
        /// key store</a> and the key material in its associated AWS CloudHSM cluster. To create
        /// a CMK in a custom key store, you must also specify the <code>Origin</code> parameter
        /// with a value of <code>AWS_CLOUDHSM</code>. The AWS CloudHSM cluster that is associated
        /// with the custom key store must have at least two active HSMs, each in a different
        /// Availability Zone in the Region.</para><para>To find the ID of a custom key store, use the <a>DescribeCustomKeyStores</a> operation.</para><para>The response includes the custom key store ID and the ID of the AWS CloudHSM cluster.</para><para>This operation is part of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
        /// Key Store feature</a> feature in AWS KMS, which combines the convenience and extensive
        /// integration of AWS KMS with the isolation and control of a single-tenant key store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the CMK.</para><para>Use a description that helps you decide whether the CMK is appropriate for a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KeyUsage
        /// <summary>
        /// <para>
        /// <para>The intended use of the CMK.</para><para>You can use CMKs only for symmetric encryption and decryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyUsageType")]
        public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>The source of the CMK's key material. You cannot change the origin after you create
        /// the CMK.</para><para>The default is <code>AWS_KMS</code>, which means AWS KMS creates the key material
        /// in its own key store.</para><para>When the parameter value is <code>EXTERNAL</code>, AWS KMS creates a CMK without key
        /// material so that you can import key material from your existing key management infrastructure.
        /// For more information about importing key material into AWS KMS, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
        /// Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.</para><para>When the parameter value is <code>AWS_CLOUDHSM</code>, AWS KMS creates the CMK in
        /// a AWS KMS <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
        /// key store</a> and creates its key material in the associated AWS CloudHSM cluster.
        /// You must also use the <code>CustomKeyStoreId</code> parameter to identify the custom
        /// key store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.OriginType")]
        public Amazon.KeyManagementService.OriginType Origin { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The key policy to attach to the CMK.</para><para>If you provide a key policy, it must meet the following criteria:</para><ul><li><para>If you don't set <code>BypassPolicyLockoutSafetyCheck</code> to true, the key policy
        /// must allow the principal that is making the <code>CreateKey</code> request to make
        /// a subsequent <a>PutKeyPolicy</a> request on the CMK. This reduces the risk that the
        /// CMK becomes unmanageable. For more information, refer to the scenario in the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default-allow-root-enable-iam">Default
        /// Key Policy</a> section of the <i>AWS Key Management Service Developer Guide</i>.</para></li><li><para>Each statement in the key policy must contain one or more principals. The principals
        /// in the key policy must exist and be visible to AWS KMS. When you create a new AWS
        /// principal (for example, an IAM user or role), you might need to enforce a delay before
        /// including the new principal in a key policy because the new principal might not be
        /// immediately visible to AWS KMS. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/troubleshoot_general.html#troubleshoot_general_eventual-consistency">Changes
        /// that I make are not always immediately visible</a> in the <i>AWS Identity and Access
        /// Management User Guide</i>.</para></li></ul><para>If you do not provide a key policy, AWS KMS attaches a default key policy to the CMK.
        /// For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default">Default
        /// Key Policy</a> in the <i>AWS Key Management Service Developer Guide</i>.</para><para>The key policy size limit is 32 kilobytes (32768 bytes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags. Each tag consists of a tag key and a tag value. Tag keys and tag
        /// values are both required, but tag values can be empty (null) strings.</para><para>Use this parameter to tag the CMK when it is created. Alternately, you can omit this
        /// parameter and instead tag the CMK after it is created using <a>TagResource</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.KeyManagementService.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSKey (CreateKey)"))
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
            
            if (ParameterWasBound("BypassPolicyLockoutSafetyCheck"))
                context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.Description = this.Description;
            context.KeyUsage = this.KeyUsage;
            context.Origin = this.Origin;
            context.Policy = this.Policy;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.KeyManagementService.Model.Tag>(this.Tag);
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.KeyMetadata;
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
        
        private Amazon.KeyManagementService.Model.CreateKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateKey");
            try
            {
                #if DESKTOP
                return client.CreateKey(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateKeyAsync(request);
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
            public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
            public System.String CustomKeyStoreId { get; set; }
            public System.String Description { get; set; }
            public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
            public Amazon.KeyManagementService.OriginType Origin { get; set; }
            public System.String Policy { get; set; }
            public List<Amazon.KeyManagementService.Model.Tag> Tags { get; set; }
        }
        
    }
}
