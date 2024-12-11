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
    /// Changes the primary key of a multi-Region key. 
    /// 
    ///  
    /// <para>
    /// This operation changes the replica key in the specified Region to a primary key and
    /// changes the former primary key to a replica key. For example, suppose you have a primary
    /// key in <c>us-east-1</c> and a replica key in <c>eu-west-2</c>. If you run <c>UpdatePrimaryRegion</c>
    /// with a <c>PrimaryRegion</c> value of <c>eu-west-2</c>, the primary key is now the
    /// key in <c>eu-west-2</c>, and the key in <c>us-east-1</c> becomes a replica key. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-manage.html#multi-region-update">Updating
    /// the primary Region</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// This operation supports <i>multi-Region keys</i>, an KMS feature that lets you create
    /// multiple interoperable KMS keys in different Amazon Web Services Regions. Because
    /// these KMS keys have the same key ID, key material, and other metadata, you can use
    /// them interchangeably to encrypt data in one Amazon Web Services Region and decrypt
    /// it in a different Amazon Web Services Region without re-encrypting the data or making
    /// a cross-Region call. For more information about multi-Region keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Multi-Region
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The <i>primary key</i> of a multi-Region key is the source for properties that are
    /// always shared by primary and replica keys, including the key material, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-id">key
    /// ID</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-spec">key
    /// spec</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-usage">key
    /// usage</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-origin">key
    /// material origin</a>, and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html">automatic
    /// key rotation</a>. It's the only key that can be replicated. You cannot <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_ScheduleKeyDeletion.html">delete
    /// the primary key</a> until all replica keys are deleted.
    /// </para><para>
    /// The key ID and primary Region that you specify uniquely identify the replica key that
    /// will become the primary key. The primary Region must already have a replica key. This
    /// operation does not create a KMS key in the specified Region. To find the replica keys,
    /// use the <a>DescribeKey</a> operation on the primary key or any replica key. To create
    /// a replica key, use the <a>ReplicateKey</a> operation.
    /// </para><para>
    /// You can run this operation while using the affected multi-Region keys in cryptographic
    /// operations. This operation should not delay, interrupt, or cause failures in cryptographic
    /// operations. 
    /// </para><para>
    /// Even after this operation completes, the process of updating the primary Region might
    /// still be in progress for a few more seconds. Operations such as <c>DescribeKey</c>
    /// might display both the old and new primary keys as replicas. The old and new primary
    /// keys have a transient key state of <c>Updating</c>. The original key state is restored
    /// when the update is complete. While the key state is <c>Updating</c>, you can use the
    /// keys in cryptographic operations, but you cannot replicate the new primary key or
    /// perform certain management operations, such as enabling or disabling these keys. For
    /// details about the <c>Updating</c> key state, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// This operation does not return any output. To verify that primary key is changed,
    /// use the <a>DescribeKey</a> operation.
    /// </para><para><b>Cross-account use</b>: No. You cannot use this operation in a different Amazon
    /// Web Services account. 
    /// </para><para><b>Required permissions</b>: 
    /// </para><ul><li><para><c>kms:UpdatePrimaryRegion</c> on the current primary key (in the primary key's Region).
    /// Include this permission primary key's key policy.
    /// </para></li><li><para><c>kms:UpdatePrimaryRegion</c> on the current replica key (in the replica key's Region).
    /// Include this permission in the replica key's key policy.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para><a>CreateKey</a></para></li><li><para><a>ReplicateKey</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KMSPrimaryRegion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service UpdatePrimaryRegion API operation.", Operation = new[] {"UpdatePrimaryRegion"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKMSPrimaryRegionCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the current primary key. When the operation completes, this KMS key will
        /// be a replica key.</para><para>Specify the key ID or key ARN of a multi-Region primary key.</para><para>For example:</para><ul><li><para>Key ID: <c>mrk-1234abcd12ab34cd56ef1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/mrk-1234abcd12ab34cd56ef1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter PrimaryRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the new primary key. Enter the Region ID, such as
        /// <c>us-east-1</c> or <c>ap-southeast-2</c>. There must be an existing replica key in
        /// this Region. </para><para>When the operation completes, the multi-Region key in this Region will be the primary
        /// key.</para>
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
        public System.String PrimaryRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KMSPrimaryRegion (UpdatePrimaryRegion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse, UpdateKMSPrimaryRegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryRegion = this.PrimaryRegion;
            #if MODULAR
            if (this.PrimaryRegion == null && ParameterWasBound(nameof(this.PrimaryRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.UpdatePrimaryRegionRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.PrimaryRegion != null)
            {
                request.PrimaryRegion = cmdletContext.PrimaryRegion;
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
        
        private Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.UpdatePrimaryRegionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "UpdatePrimaryRegion");
            try
            {
                #if DESKTOP
                return client.UpdatePrimaryRegion(request);
                #elif CORECLR
                return client.UpdatePrimaryRegionAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyId { get; set; }
            public System.String PrimaryRegion { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.UpdatePrimaryRegionResponse, UpdateKMSPrimaryRegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
