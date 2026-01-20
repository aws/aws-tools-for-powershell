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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Creates a policy store. A policy store is a container for policy resources.
    /// 
    ///  <note><para>
    /// Although <a href="https://docs.cedarpolicy.com/schema/schema.html#namespace">Cedar
    /// supports multiple namespaces</a>, Verified Permissions currently supports only one
    /// namespace per policy store.
    /// </para></note><note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AVPPolicyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions CreatePolicyStore API operation.", Operation = new[] {"CreatePolicyStore"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse object containing multiple properties."
    )]
    public partial class NewAVPPolicyStoreCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EncryptionSettings_Default
        /// <summary>
        /// <para>
        /// <para>Use AWS owned encryption keys for encrypting policy store data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.VerifiedPermissions.Model.Unit EncryptionSettings_Default { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy store can be deleted. If enabled, the policy store can't
        /// be deleted.</para><para>The default state is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VerifiedPermissions.DeletionProtection")]
        public Amazon.VerifiedPermissions.DeletionProtection DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Descriptive text that you can provide to help with identification of the current policy
        /// store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EncryptionSettings_KmsEncryptionSettings_EncryptionContext
        /// <summary>
        /// <para>
        /// <para>User-defined, additional context to be added to encryption processes. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionSettings_KmsEncryptionSettings_EncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionSettings_KmsEncryptionSettings_Key
        /// <summary>
        /// <para>
        /// <para>The customer-managed KMS key <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a>, alias or ID to be used for encryption processes. </para><para>Users can provide the full KMS key ARN, a KMS key alias, or a KMS key ID, but it will
        /// be mapped to the full KMS key ARN after policy store creation, and referenced when
        /// encrypting child resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSettings_KmsEncryptionSettings_Key { get; set; }
        #endregion
        
        #region Parameter ValidationSettings_Mode
        /// <summary>
        /// <para>
        /// <para>The validation mode currently configured for this policy store. The valid values are:</para><ul><li><para><b>OFF</b> – Neither Verified Permissions nor Cedar perform any validation on policies.
        /// No validation errors are reported by either service.</para></li><li><para><b>STRICT</b> – Requires a schema to be present in the policy store. Cedar performs
        /// validation on all submitted new or updated static policies and policy templates. Any
        /// that fail validation are rejected and Cedar doesn't store them in the policy store.</para></li></ul><important><para>If <c>Mode=STRICT</c> and the policy store doesn't contain a schema, Verified Permissions
        /// rejects all static policies and policy templates because there is no schema to validate
        /// against. </para><para>To submit a static policy or policy template without a schema, you must turn off validation.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.VerifiedPermissions.ValidationMode")]
        public Amazon.VerifiedPermissions.ValidationMode ValidationSettings_Mode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value pairs to associate with the policy store.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>ConflictException</c> error.</para><para>Verified Permissions recognizes a <c>ClientToken</c> for eight hours. After eight
        /// hours, the next request with the same parameters performs the operation again regardless
        /// of the value of <c>ClientToken</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ValidationSettings_Mode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AVPPolicyStore (CreatePolicyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse, NewAVPPolicyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeletionProtection = this.DeletionProtection;
            context.Description = this.Description;
            context.EncryptionSettings_Default = this.EncryptionSettings_Default;
            if (this.EncryptionSettings_KmsEncryptionSettings_EncryptionContext != null)
            {
                context.EncryptionSettings_KmsEncryptionSettings_EncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionSettings_KmsEncryptionSettings_EncryptionContext.Keys)
                {
                    context.EncryptionSettings_KmsEncryptionSettings_EncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionSettings_KmsEncryptionSettings_EncryptionContext[hashKey]));
                }
            }
            context.EncryptionSettings_KmsEncryptionSettings_Key = this.EncryptionSettings_KmsEncryptionSettings_Key;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.ValidationSettings_Mode = this.ValidationSettings_Mode;
            #if MODULAR
            if (this.ValidationSettings_Mode == null && ParameterWasBound(nameof(this.ValidationSettings_Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter ValidationSettings_Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.CreatePolicyStoreRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EncryptionSettings
            var requestEncryptionSettingsIsNull = true;
            request.EncryptionSettings = new Amazon.VerifiedPermissions.Model.EncryptionSettings();
            Amazon.VerifiedPermissions.Model.Unit requestEncryptionSettings_encryptionSettings_Default = null;
            if (cmdletContext.EncryptionSettings_Default != null)
            {
                requestEncryptionSettings_encryptionSettings_Default = cmdletContext.EncryptionSettings_Default;
            }
            if (requestEncryptionSettings_encryptionSettings_Default != null)
            {
                request.EncryptionSettings.Default = requestEncryptionSettings_encryptionSettings_Default;
                requestEncryptionSettingsIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.KmsEncryptionSettings requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings = null;
            
             // populate KmsEncryptionSettings
            var requestEncryptionSettings_encryptionSettings_KmsEncryptionSettingsIsNull = true;
            requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings = new Amazon.VerifiedPermissions.Model.KmsEncryptionSettings();
            Dictionary<System.String, System.String> requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_EncryptionContext = null;
            if (cmdletContext.EncryptionSettings_KmsEncryptionSettings_EncryptionContext != null)
            {
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_EncryptionContext = cmdletContext.EncryptionSettings_KmsEncryptionSettings_EncryptionContext;
            }
            if (requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_EncryptionContext != null)
            {
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings.EncryptionContext = requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_EncryptionContext;
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettingsIsNull = false;
            }
            System.String requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_Key = null;
            if (cmdletContext.EncryptionSettings_KmsEncryptionSettings_Key != null)
            {
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_Key = cmdletContext.EncryptionSettings_KmsEncryptionSettings_Key;
            }
            if (requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_Key != null)
            {
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings.Key = requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings_encryptionSettings_KmsEncryptionSettings_Key;
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettingsIsNull = false;
            }
             // determine if requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings should be set to null
            if (requestEncryptionSettings_encryptionSettings_KmsEncryptionSettingsIsNull)
            {
                requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings = null;
            }
            if (requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings != null)
            {
                request.EncryptionSettings.KmsEncryptionSettings = requestEncryptionSettings_encryptionSettings_KmsEncryptionSettings;
                requestEncryptionSettingsIsNull = false;
            }
             // determine if request.EncryptionSettings should be set to null
            if (requestEncryptionSettingsIsNull)
            {
                request.EncryptionSettings = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate ValidationSettings
            var requestValidationSettingsIsNull = true;
            request.ValidationSettings = new Amazon.VerifiedPermissions.Model.ValidationSettings();
            Amazon.VerifiedPermissions.ValidationMode requestValidationSettings_validationSettings_Mode = null;
            if (cmdletContext.ValidationSettings_Mode != null)
            {
                requestValidationSettings_validationSettings_Mode = cmdletContext.ValidationSettings_Mode;
            }
            if (requestValidationSettings_validationSettings_Mode != null)
            {
                request.ValidationSettings.Mode = requestValidationSettings_validationSettings_Mode;
                requestValidationSettingsIsNull = false;
            }
             // determine if request.ValidationSettings should be set to null
            if (requestValidationSettingsIsNull)
            {
                request.ValidationSettings = null;
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
        
        private Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.CreatePolicyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "CreatePolicyStore");
            try
            {
                return client.CreatePolicyStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.VerifiedPermissions.DeletionProtection DeletionProtection { get; set; }
            public System.String Description { get; set; }
            public Amazon.VerifiedPermissions.Model.Unit EncryptionSettings_Default { get; set; }
            public Dictionary<System.String, System.String> EncryptionSettings_KmsEncryptionSettings_EncryptionContext { get; set; }
            public System.String EncryptionSettings_KmsEncryptionSettings_Key { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.VerifiedPermissions.ValidationMode ValidationSettings_Mode { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.CreatePolicyStoreResponse, NewAVPPolicyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
