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
    /// Schedules the deletion of a customer master key (CMK). By default, AWS KMS applies
    /// a waiting period of 30 days, but you can specify a waiting period of 7-30 days. When
    /// this operation is successful, the key state of the CMK changes to <code>PendingDeletion</code>
    /// and the key can't be used in any cryptographic operations. It remains in this state
    /// for the duration of the waiting period. Before the waiting period ends, you can use
    /// <a>CancelKeyDeletion</a> to cancel the deletion of the CMK. After the waiting period
    /// ends, AWS KMS deletes the CMK, its key material, and all AWS KMS data associated with
    /// it, including all aliases that refer to it.
    /// 
    ///  <important><para>
    /// Deleting a CMK is a destructive and potentially dangerous operation. When a CMK is
    /// deleted, all data that was encrypted under the CMK is unrecoverable. (The only exception
    /// is a multi-Region replica key.) To prevent the use of a CMK without deleting it, use
    /// <a>DisableKey</a>. 
    /// </para></important><para>
    /// If you schedule deletion of a CMK from a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a>, when the waiting period expires, <code>ScheduleKeyDeletion</code> deletes
    /// the CMK from AWS KMS. Then AWS KMS makes a best effort to delete the key material
    /// from the associated AWS CloudHSM cluster. However, you might need to manually <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html#fix-keystore-orphaned-key">delete
    /// the orphaned key material</a> from the cluster and its backups.
    /// </para><para>
    /// You can schedule the deletion of a multi-Region primary key and its replica keys at
    /// any time. However, AWS KMS will not delete a multi-Region primary key with existing
    /// replica keys. If you schedule the deletion of a primary key with replicas, its key
    /// state changes to <code>PendingReplicaDeletion</code> and it cannot be replicated or
    /// used in cryptographic operations. This status can continue indefinitely. When the
    /// last of its replicas keys is deleted (not just scheduled), the key state of the primary
    /// key changes to <code>PendingDeletion</code> and its waiting period (<code>PendingWindowInDays</code>)
    /// begins. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-delete.html">Deleting
    /// multi-Region keys</a> in the <i>AWS Key Management Service Developer Guide</i>. 
    /// </para><para>
    /// For more information about scheduling a CMK for deletion, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/deleting-keys.html">Deleting
    /// Customer Master Keys</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// state: Effect on your CMK</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a CMK in a different
    /// AWS account.
    /// </para><para><b>Required permissions</b>: kms:ScheduleKeyDeletion (key policy)
    /// </para><para><b>Related operations</b></para><ul><li><para><a>CancelKeyDeletion</a></para></li><li><para><a>DisableKey</a></para></li></ul>
    /// </summary>
    [Cmdlet("Request", "KMSKeyDeletion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ScheduleKeyDeletion API operation.", Operation = new[] {"ScheduleKeyDeletion"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestKMSKeyDeletionCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the customer master key (CMK) to delete.</para><para>Specify the key ID or key ARN of the CMK.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        /// <para>The waiting period, specified in number of days. After the waiting period ends, AWS
        /// KMS deletes the customer master key (CMK).</para><para>If the CMK is a multi-Region primary key with replicas, the waiting period begins
        /// when the last of its replica keys is deleted. Otherwise, the waiting period begins
        /// immediately.</para><para>This value is optional. If you include a value, it must be between 7 and 30, inclusive.
        /// If you do not include a value, it defaults to 30.</para>
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
