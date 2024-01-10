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
    /// Schedules the deletion of a KMS key. By default, KMS applies a waiting period of 30
    /// days, but you can specify a waiting period of 7-30 days. When this operation is successful,
    /// the key state of the KMS key changes to <c>PendingDeletion</c> and the key can't be
    /// used in any cryptographic operations. It remains in this state for the duration of
    /// the waiting period. Before the waiting period ends, you can use <a>CancelKeyDeletion</a>
    /// to cancel the deletion of the KMS key. After the waiting period ends, KMS deletes
    /// the KMS key, its key material, and all KMS data associated with it, including all
    /// aliases that refer to it.
    /// 
    ///  <important><para>
    /// Deleting a KMS key is a destructive and potentially dangerous operation. When a KMS
    /// key is deleted, all data that was encrypted under the KMS key is unrecoverable. (The
    /// only exception is a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-delete.html">multi-Region
    /// replica key</a>, or an <a href="kms/latest/developerguide/importing-keys-managing.html#import-delete-key">asymmetric
    /// or HMAC KMS key with imported key material</a>.) To prevent the use of a KMS key without
    /// deleting it, use <a>DisableKey</a>. 
    /// </para></important><para>
    /// You can schedule the deletion of a multi-Region primary key and its replica keys at
    /// any time. However, KMS will not delete a multi-Region primary key with existing replica
    /// keys. If you schedule the deletion of a primary key with replicas, its key state changes
    /// to <c>PendingReplicaDeletion</c> and it cannot be replicated or used in cryptographic
    /// operations. This status can continue indefinitely. When the last of its replicas keys
    /// is deleted (not just scheduled), the key state of the primary key changes to <c>PendingDeletion</c>
    /// and its waiting period (<c>PendingWindowInDays</c>) begins. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-delete.html">Deleting
    /// multi-Region keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// When KMS <a href="https://docs.aws.amazon.com/kms/latest/developerguide/delete-cmk-keystore.html">deletes
    /// a KMS key from an CloudHSM key store</a>, it makes a best effort to delete the associated
    /// key material from the associated CloudHSM cluster. However, you might need to manually
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html#fix-keystore-orphaned-key">delete
    /// the orphaned key material</a> from the cluster and its backups. <a href="https://docs.aws.amazon.com/kms/latest/developerguide/delete-xks-key.html">Deleting
    /// a KMS key from an external key store</a> has no effect on the associated external
    /// key. However, for both types of custom key stores, deleting a KMS key is destructive
    /// and irreversible. You cannot decrypt ciphertext encrypted under the KMS key by using
    /// only its associated external key or CloudHSM key. Also, you cannot recreate a KMS
    /// key in an external key store by creating a new KMS key with the same key material.
    /// </para><para>
    /// For more information about scheduling a KMS key for deletion, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/deleting-keys.html">Deleting
    /// KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: kms:ScheduleKeyDeletion (key policy)
    /// </para><para><b>Related operations</b></para><ul><li><para><a>CancelKeyDeletion</a></para></li><li><para><a>DisableKey</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "KMSKeyDeletion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ScheduleKeyDeletion API operation.", Operation = new[] {"ScheduleKeyDeletion"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestKMSKeyDeletionCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the KMS key to delete.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter PendingWindowInDay
        /// <summary>
        /// <para>
        /// <para>The waiting period, specified in number of days. After the waiting period ends, KMS
        /// deletes the KMS key.</para><para>If the KMS key is a multi-Region primary key with replica keys, the waiting period
        /// begins when the last of its replica keys is deleted. Otherwise, the waiting period
        /// begins immediately.</para><para>This value is optional. If you include a value, it must be between 7 and 30, inclusive.
        /// If you do not include a value, it defaults to 30. You can use the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/conditions-kms.html#conditions-kms-schedule-key-deletion-pending-window-in-days"><c>kms:ScheduleKeyDeletionPendingWindowInDays</c></a> condition key to further constrain
        /// the values that principals can specify in the <c>PendingWindowInDays</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PendingWindowInDays")]
        public System.Int32? PendingWindowInDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-KMSKeyDeletion (ScheduleKeyDeletion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse, RequestKMSKeyDeletionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PendingWindowInDay = this.PendingWindowInDay;
            
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
            var request = new Amazon.KeyManagementService.Model.ScheduleKeyDeletionRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.PendingWindowInDay != null)
            {
                request.PendingWindowInDays = cmdletContext.PendingWindowInDay.Value;
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
        
        private Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ScheduleKeyDeletionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ScheduleKeyDeletion");
            try
            {
                #if DESKTOP
                return client.ScheduleKeyDeletion(request);
                #elif CORECLR
                return client.ScheduleKeyDeletionAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? PendingWindowInDay { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse, RequestKMSKeyDeletionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
