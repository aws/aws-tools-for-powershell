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
    /// Provides detailed information about a KMS key. You can run <c>DescribeKey</c> on a
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer
    /// managed key</a> or an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed key</a>.
    /// 
    ///  
    /// <para>
    /// This detailed information includes the key ARN, creation date (and deletion date,
    /// if applicable), the key state, and the origin and expiration date (if any) of the
    /// key material. It includes fields, like <c>KeySpec</c>, that help you distinguish different
    /// types of KMS keys. It also displays the key usage (encryption, signing, or generating
    /// and verifying MACs) and the algorithms that the KMS key supports. 
    /// </para><para>
    /// For <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
    /// keys</a>, <c>DescribeKey</c> displays the primary key and all related replica keys.
    /// For KMS keys in <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-cloudhsm.html">CloudHSM
    /// key stores</a>, it includes information about the key store, such as the key store
    /// ID and the CloudHSM cluster ID. For KMS keys in <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html">external
    /// key stores</a>, it includes the custom key store ID and the ID of the external key.
    /// </para><para><c>DescribeKey</c> does not return the following information:
    /// </para><ul><li><para>
    /// Aliases associated with the KMS key. To get this information, use <a>ListAliases</a>.
    /// </para></li><li><para>
    /// Whether automatic key rotation is enabled on the KMS key. To get this information,
    /// use <a>GetKeyRotationStatus</a>. Also, some key states prevent a KMS key from being
    /// automatically rotated. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html#rotate-keys-how-it-works">How
    /// Automatic Key Rotation Works</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para></li><li><para>
    /// Tags on the KMS key. To get this information, use <a>ListResourceTags</a>.
    /// </para></li><li><para>
    /// Key policies and grants on the KMS key. To get this information, use <a>GetKeyPolicy</a>
    /// and <a>ListGrants</a>.
    /// </para></li></ul><para>
    /// In general, <c>DescribeKey</c> is a non-mutating operation. It returns data about
    /// KMS keys, but doesn't change them. However, Amazon Web Services services use <c>DescribeKey</c>
    /// to create <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed keys</a> from a <i>predefined Amazon Web Services alias</i> with
    /// no key ID.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:DescribeKey</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GetKeyPolicy</a></para></li><li><para><a>GetKeyRotationStatus</a></para></li><li><para><a>ListAliases</a></para></li><li><para><a>ListGrants</a></para></li><li><para><a>ListKeys</a></para></li><li><para><a>ListResourceTags</a></para></li><li><para><a>ListRetirableGrants</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSKey")]
    [OutputType("Amazon.KeyManagementService.Model.KeyMetadata")]
    [AWSCmdlet("Calls the AWS Key Management Service DescribeKey API operation.", Operation = new[] {"DescribeKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DescribeKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.KeyMetadata or Amazon.KeyManagementService.Model.DescribeKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.KeyMetadata object.",
        "The service call response (type Amazon.KeyManagementService.Model.DescribeKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKMSKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#using-grant-token">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Describes the specified KMS key. </para><para>If you specify a predefined Amazon Web Services alias (an Amazon Web Services alias
        /// with no key ID), KMS associates the alias with an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html##aws-managed-cmk">Amazon
        /// Web Services managed key</a> and returns its <c>KeyId</c> and <c>Arn</c> in the response.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.DescribeKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.DescribeKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyMetadata";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.DescribeKeyResponse, GetKMSKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
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
            var request = new Amazon.KeyManagementService.Model.DescribeKeyRequest();
            
            if (cmdletContext.GrantToken != null)
            {
                request.GrantTokens = cmdletContext.GrantToken;
            }
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
        
        private Amazon.KeyManagementService.Model.DescribeKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DescribeKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "DescribeKey");
            try
            {
                #if DESKTOP
                return client.DescribeKey(request);
                #elif CORECLR
                return client.DescribeKeyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.DescribeKeyResponse, GetKMSKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyMetadata;
        }
        
    }
}
