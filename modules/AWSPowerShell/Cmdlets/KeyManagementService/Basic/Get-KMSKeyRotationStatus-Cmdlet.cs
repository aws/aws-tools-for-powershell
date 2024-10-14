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
    /// Provides detailed information about the rotation status for a KMS key, including whether
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html">automatic
    /// rotation of the key material</a> is enabled for the specified KMS key, the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html#rotation-period">rotation
    /// period</a>, and the next scheduled rotation date.
    /// 
    ///  
    /// <para>
    /// Automatic key rotation is supported only on <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#symmetric-cmks">symmetric
    /// encryption KMS keys</a>. You cannot enable automatic rotation of <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">asymmetric
    /// KMS keys</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/hmac.html">HMAC
    /// KMS keys</a>, KMS keys with <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">imported
    /// key material</a>, or KMS keys in a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a>. To enable or disable automatic rotation of a set of related <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-manage.html#multi-region-rotate">multi-Region
    /// keys</a>, set the property on the primary key..
    /// </para><para>
    /// You can enable (<a>EnableKeyRotation</a>) and disable automatic rotation (<a>DisableKeyRotation</a>)
    /// of the key material in customer managed KMS keys. Key material rotation of <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed KMS keys</a> is not configurable. KMS always rotates the key
    /// material in Amazon Web Services managed KMS keys every year. The key rotation status
    /// for Amazon Web Services managed KMS keys is always <c>true</c>.
    /// </para><para>
    /// You can perform on-demand (<a>RotateKeyOnDemand</a>) rotation of the key material
    /// in customer managed KMS keys, regardless of whether or not automatic key rotation
    /// is enabled. You can use GetKeyRotationStatus to identify the date and time that an
    /// in progress on-demand rotation was initiated. You can use <a>ListKeyRotations</a>
    /// to view the details of completed rotations.
    /// </para><note><para>
    /// In May 2022, KMS changed the rotation schedule for Amazon Web Services managed keys
    /// from every three years to every year. For details, see <a>EnableKeyRotation</a>.
    /// </para></note><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><ul><li><para>
    /// Disabled: The key rotation status does not change when you disable a KMS key. However,
    /// while the KMS key is disabled, KMS does not rotate the key material. When you re-enable
    /// the KMS key, rotation resumes. If the key material in the re-enabled KMS key hasn't
    /// been rotated in one year, KMS rotates it immediately, and every year thereafter. If
    /// it's been less than a year since the key material in the re-enabled KMS key was rotated,
    /// the KMS key resumes its prior rotation schedule.
    /// </para></li><li><para>
    /// Pending deletion: While a KMS key is pending deletion, its key rotation status is
    /// <c>false</c> and KMS does not rotate the key material. If you cancel the deletion,
    /// the original key rotation status returns to <c>true</c>.
    /// </para></li></ul><para><b>Cross-account use</b>: Yes. To perform this operation on a KMS key in a different
    /// Amazon Web Services account, specify the key ARN in the value of the <c>KeyId</c>
    /// parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GetKeyRotationStatus</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DisableKeyRotation</a></para></li><li><para><a>EnableKeyRotation</a></para></li><li><para><a>ListKeyRotations</a></para></li><li><para><a>RotateKeyOnDemand</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSKeyRotationStatus")]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS Key Management Service GetKeyRotationStatus API operation.", Operation = new[] {"GetKeyRotationStatus"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKMSKeyRotationStatusCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Gets the rotation status for the specified KMS key.</para><para>Specify the key ID or key ARN of the KMS key. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyRotationEnabled'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyRotationEnabled";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse, GetKMSKeyRotationStatusCmdlet>(Select) ??
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
            var request = new Amazon.KeyManagementService.Model.GetKeyRotationStatusRequest();
            
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
        
        private Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetKeyRotationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetKeyRotationStatus");
            try
            {
                #if DESKTOP
                return client.GetKeyRotationStatus(request);
                #elif CORECLR
                return client.GetKeyRotationStatusAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.KeyManagementService.Model.GetKeyRotationStatusResponse, GetKMSKeyRotationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyRotationEnabled;
        }
        
    }
}
