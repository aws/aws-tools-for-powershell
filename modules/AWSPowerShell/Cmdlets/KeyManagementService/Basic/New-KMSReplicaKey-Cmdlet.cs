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
    /// Replicates a multi-Region key into the specified Region. This operation creates a
    /// multi-Region replica key based on a multi-Region primary key in a different Region
    /// of the same Amazon Web Services partition. You can create multiple replicas of a primary
    /// key, but each must be in a different Region. To create a multi-Region primary key,
    /// use the <a>CreateKey</a> operation.
    /// 
    ///  
    /// <para>
    /// This operation supports <i>multi-Region keys</i>, an KMS feature that lets you create
    /// multiple interoperable KMS keys in different Amazon Web Services Regions. Because
    /// these KMS keys have the same key ID, key material, and other metadata, you can use
    /// them interchangeably to encrypt data in one Amazon Web Services Region and decrypt
    /// it in a different Amazon Web Services Region without re-encrypting the data or making
    /// a cross-Region call. For more information about multi-Region keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Multi-Region
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// A <i>replica key</i> is a fully-functional KMS key that can be used independently
    /// of its primary and peer replica keys. A primary key and its replica keys share properties
    /// that make them interoperable. They have the same <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-id">key
    /// ID</a> and key material. They also have the same <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-spec">key
    /// spec</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-usage">key
    /// usage</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-origin">key
    /// material origin</a>, and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html">automatic
    /// key rotation status</a>. KMS automatically synchronizes these shared properties among
    /// related multi-Region keys. All other properties of a replica key can differ, including
    /// its <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">key
    /// policy</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/tagging-keys.html">tags</a>,
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-alias.html">aliases</a>,
    /// and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a>. KMS pricing and quotas for KMS keys apply to each primary
    /// key and replica key.
    /// </para><para>
    /// When this operation completes, the new replica key has a transient key state of <c>Creating</c>.
    /// This key state changes to <c>Enabled</c> (or <c>PendingImport</c>) after a few seconds
    /// when the process of creating the new replica key is complete. While the key state
    /// is <c>Creating</c>, you can manage key, but you cannot yet use it in cryptographic
    /// operations. If you are creating and using the replica key programmatically, retry
    /// on <c>KMSInvalidStateException</c> or call <c>DescribeKey</c> to check its <c>KeyState</c>
    /// value before using it. For details about the <c>Creating</c> key state, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// You cannot create more than one replica of a primary key in any Region. If the Region
    /// already includes a replica of the key you're trying to replicate, <c>ReplicateKey</c>
    /// returns an <c>AlreadyExistsException</c> error. If the key state of the existing replica
    /// is <c>PendingDeletion</c>, you can cancel the scheduled key deletion (<a>CancelKeyDeletion</a>)
    /// or wait for the key to be deleted. The new replica key you create will have the same
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html#mrk-sync-properties">shared
    /// properties</a> as the original replica key.
    /// </para><para>
    /// The CloudTrail log of a <c>ReplicateKey</c> operation records a <c>ReplicateKey</c>
    /// operation in the primary key's Region and a <a>CreateKey</a> operation in the replica
    /// key's Region.
    /// </para><para>
    /// If you replicate a multi-Region primary key with imported key material, the replica
    /// key is created with no key material. You must import the same key material that you
    /// imported into the primary key. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-import.html">Importing
    /// key material into multi-Region keys</a> in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para>
    /// To convert a replica key to a primary key, use the <a>UpdatePrimaryRegion</a> operation.
    /// </para><note><para><c>ReplicateKey</c> uses different default values for the <c>KeyPolicy</c> and <c>Tags</c>
    /// parameters than those used in the KMS console. For details, see the parameter descriptions.
    /// </para></note><para><b>Cross-account use</b>: No. You cannot use this operation to create a replica key
    /// in a different Amazon Web Services account. 
    /// </para><para><b>Required permissions</b>: 
    /// </para><ul><li><para><c>kms:ReplicateKey</c> on the primary key (in the primary key's Region). Include
    /// this permission in the primary key's key policy.
    /// </para></li><li><para><c>kms:CreateKey</c> in an IAM policy in the replica Region.
    /// </para></li><li><para>
    /// To use the <c>Tags</c> parameter, <c>kms:TagResource</c> in an IAM policy in the replica
    /// Region.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para><a>CreateKey</a></para></li><li><para><a>UpdatePrimaryRegion</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSReplicaKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReplicateKeyResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ReplicateKey API operation.", Operation = new[] {"ReplicateKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ReplicateKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReplicateKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ReplicateKeyResponse object containing multiple properties."
    )]
    public partial class NewKMSReplicaKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>Skips ("bypasses") the key policy lockout safety check. The default value is false.</para><important><para>Setting this value to true increases the risk that the KMS key becomes unmanageable.
        /// Do not set this value to true indiscriminately.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>.</para></important><para>Use this parameter only when you intend to prevent the principal that is making the
        /// request from making a subsequent <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_PutKeyPolicy.html">PutKeyPolicy</a>
        /// request on the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the KMS key. The default value is an empty string (no description).</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>The description is not a shared property of multi-Region keys. You can specify the
        /// same description or a different description for each key in a set of related multi-Region
        /// keys. KMS does not synchronize this property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the multi-Region primary key that is being replicated. To determine whether
        /// a KMS key is a multi-Region primary key, use the <a>DescribeKey</a> operation to check
        /// the value of the <c>MultiRegionKeyType</c> property.</para><para>Specify the key ID or key ARN of a multi-Region primary key.</para><para>For example:</para><ul><li><para>Key ID: <c>mrk-1234abcd12ab34cd56ef1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/mrk-1234abcd12ab34cd56ef1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The key policy to attach to the KMS key. This parameter is optional. If you do not
        /// provide a key policy, KMS attaches the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html#key-policy-default">default
        /// key policy</a> to the KMS key.</para><para>The key policy is not a shared property of multi-Region keys. You can specify the
        /// same key policy or a different key policy for each key in a set of related multi-Region
        /// keys. KMS does not synchronize this property.</para><para>If you provide a key policy, it must meet the following criteria:</para><ul><li><para>The key policy must allow the calling principal to make a subsequent <c>PutKeyPolicy</c>
        /// request on the KMS key. This reduces the risk that the KMS key becomes unmanageable.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>. (To omit this
        /// condition, set <c>BypassPolicyLockoutSafetyCheck</c> to true.)</para></li><li><para>Each statement in the key policy must contain one or more principals. The principals
        /// in the key policy must exist and be visible to KMS. When you create a new Amazon Web
        /// Services principal, you might need to enforce a delay before including the new principal
        /// in a key policy because the new principal might not be immediately visible to KMS.
        /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/troubleshoot_general.html#troubleshoot_general_eventual-consistency">Changes
        /// that I make are not always immediately visible</a> in the <i>Amazon Web Services Identity
        /// and Access Management User Guide</i>.</para></li></ul><para>A key policy document can include only the following characters:</para><ul><li><para>Printable ASCII characters from the space character (<c>\u0020</c>) through the end
        /// of the ASCII character range.</para></li><li><para>Printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// <c>\u00FF</c>).</para></li><li><para>The tab (<c>\u0009</c>), line feed (<c>\u000A</c>), and carriage return (<c>\u000D</c>)
        /// special characters</para></li></ul><para>For information about key policies, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Key
        /// policies in KMS</a> in the <i>Key Management Service Developer Guide</i>. For help
        /// writing and formatting a JSON policy document, see the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html">IAM
        /// JSON Policy Reference</a> in the <i><i>Identity and Access Management User Guide</i></i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter ReplicaRegion
        /// <summary>
        /// <para>
        /// <para>The Region ID of the Amazon Web Services Region for this replica key. </para><para>Enter the Region ID, such as <c>us-east-1</c> or <c>ap-southeast-2</c>. For a list
        /// of Amazon Web Services Regions in which KMS is supported, see <a href="https://docs.aws.amazon.com/general/latest/gr/kms.html#kms_region">KMS
        /// service endpoints</a> in the <i>Amazon Web Services General Reference</i>.</para><note><para>HMAC KMS keys are not supported in all Amazon Web Services Regions. If you try to
        /// replicate an HMAC KMS key in an Amazon Web Services Region in which HMAC keys are
        /// not supported, the <c>ReplicateKey</c> operation returns an <c>UnsupportedOperationException</c>.
        /// For a list of Regions in which HMAC KMS keys are supported, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/hmac.html">HMAC
        /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.</para></note><para>The replica must be in a different Amazon Web Services Region than its primary key
        /// and other replicas of that primary key, but in the same Amazon Web Services partition.
        /// KMS must be available in the replica Region. If the Region is not enabled by default,
        /// the Amazon Web Services account must be enabled in the Region. For information about
        /// Amazon Web Services partitions, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>. For
        /// information about enabling and disabling Regions, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande-manage.html#rande-manage-enable">Enabling
        /// a Region</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/rande-manage.html#rande-manage-disable">Disabling
        /// a Region</a> in the <i>Amazon Web Services General Reference</i>.</para>
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
        public System.String ReplicaRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags to the replica key. Use this parameter to tag the KMS key
        /// when it is created. To tag an existing KMS key, use the <a>TagResource</a> operation.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><note><para>Tagging or untagging a KMS key can allow or deny permission to the KMS key. For details,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/abac.html">ABAC
        /// for KMS</a> in the <i>Key Management Service Developer Guide</i>.</para></note><para>To use this parameter, you must have <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:TagResource</a>
        /// permission in an IAM policy.</para><para>Tags are not a shared property of multi-Region keys. You can specify the same tags
        /// or different tags for each key in a set of related multi-Region keys. KMS does not
        /// synchronize this property.</para><para>Each tag consists of a tag key and a tag value. Both the tag key and the tag value
        /// are required, but the tag value can be an empty (null) string. You cannot have more
        /// than one tag on a KMS key with the same tag key. If you specify an existing tag key
        /// with a different tag value, KMS replaces the current tag value with the specified
        /// one.</para><para>When you add tags to an Amazon Web Services resource, Amazon Web Services generates
        /// a cost allocation report with usage and costs aggregated by tags. Tags can also be
        /// used to control access to a KMS key. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/tagging-keys.html">Tagging
        /// Keys</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KeyManagementService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ReplicateKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.ReplicateKeyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSReplicaKey (ReplicateKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ReplicateKeyResponse, NewKMSReplicaKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            context.Description = this.Description;
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            context.ReplicaRegion = this.ReplicaRegion;
            #if MODULAR
            if (this.ReplicaRegion == null && ParameterWasBound(nameof(this.ReplicaRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicaRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.KeyManagementService.Model.ReplicateKeyRequest();
            
            if (cmdletContext.BypassPolicyLockoutSafetyCheck != null)
            {
                request.BypassPolicyLockoutSafetyCheck = cmdletContext.BypassPolicyLockoutSafetyCheck.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.ReplicaRegion != null)
            {
                request.ReplicaRegion = cmdletContext.ReplicaRegion;
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
        
        private Amazon.KeyManagementService.Model.ReplicateKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ReplicateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ReplicateKey");
            try
            {
                return client.ReplicateKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KeyId { get; set; }
            public System.String Policy { get; set; }
            public System.String ReplicaRegion { get; set; }
            public List<Amazon.KeyManagementService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ReplicateKeyResponse, NewKMSReplicaKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
