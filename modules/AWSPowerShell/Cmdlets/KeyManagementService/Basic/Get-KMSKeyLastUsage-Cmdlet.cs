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
    /// Returns usage information about the last successful cryptographic operation performed
    /// with a specified KMS key, including the operation type, timestamp, and associated
    /// CloudTrail event ID.
    /// 
    ///  
    /// <para>
    /// The <c>TrackingStartDate</c> in the <c>GetKeyLastUsage</c> response indicates the
    /// date from which KMS began recording cryptographic activity for a given key. Use this
    /// value together with <c>KeyCreationDate</c> to understand the key's usage history:
    /// </para><ul><li><para>
    /// If the <c>KeyLastUsage</c> response element is <i>present</i>, the key has been used
    /// for a successful cryptographic operation since the <c>TrackingStartDate</c>. The response
    /// includes the operation type, timestamp, and associated CloudTrail event ID.
    /// </para></li><li><para>
    /// If the <c>KeyLastUsage</c> response element is <i>empty</i> and <c>KeyCreationDate</c>
    /// is on or after <c>TrackingStartDate</c>, the key has not been used for a successful
    /// cryptographic operation since it was created.
    /// </para></li><li><para>
    /// If the <c>KeyLastUsage</c> response element is <i>empty</i> and <c>KeyCreationDate</c>
    /// is before <c>TrackingStartDate</c>, there is no record of the key being used for a
    /// successful cryptographic operation since the <c>TrackingStartDate</c>. However, the
    /// key may have been used before tracking began. To determine whether the key was used
    /// before the <c>TrackingStartDate</c>, examine your past CloudTrail logs.
    /// </para></li></ul><para>
    /// For multi-Region KMS keys, primary and replica keys track last usage independently.
    /// Each key in a multi-Region key set maintains its own usage information.
    /// </para><para>
    /// The <c>ReEncrypt</c> operation uses two keys: a source key for decryption and a destination
    /// key for encryption. Usage information is recorded for both keys independently, each
    /// with the CloudTrail event ID from the respective key owner's account.
    /// </para><note><para>
    /// Do not use <c>GetKeyLastUsage</c> as the sole indicator when scheduling a key for
    /// deletion. Instead, first <a href="https://docs.aws.amazon.com/kms/latest/developerguide/enabling-keys.html">disable
    /// the key</a> and monitor CloudTrail for <c>DisabledException</c> entries, as there
    /// could be infrequent workflows that are dependent on the key. By looking for this exception,
    /// you can identify potential dependencies and workload failures before they occur.
    /// </para></note><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GetKeyLastUsage</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DescribeKey</a></para></li><li><para><a>DisableKey</a></para></li><li><para><a>ScheduleKeyDeletion</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSKeyLastUsage")]
    [OutputType("Amazon.KeyManagementService.Model.GetKeyLastUsageResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GetKeyLastUsage API operation.", Operation = new[] {"GetKeyLastUsage"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GetKeyLastUsageResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GetKeyLastUsageResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GetKeyLastUsageResponse object containing multiple properties."
    )]
    public partial class GetKMSKeyLastUsageCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the KMS key to get usage information for. To specify a KMS key, use its
        /// key ID or key ARN. Alias names are not supported.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GetKeyLastUsageResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GetKeyLastUsageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GetKeyLastUsageResponse, GetKMSKeyLastUsageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.GetKeyLastUsageRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
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
        
        private Amazon.KeyManagementService.Model.GetKeyLastUsageResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetKeyLastUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetKeyLastUsage");
            try
            {
                return client.GetKeyLastUsageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.KeyManagementService.Model.GetKeyLastUsageResponse, GetKMSKeyLastUsageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
