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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Adds or edits tags on a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer
    /// managed key</a>.
    /// 
    ///  <note><para>
    /// Tagging or untagging a KMS key can allow or deny permission to the KMS key. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/abac.html">ABAC
    /// for KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para></note><para>
    /// Each tag consists of a tag key and a tag value, both of which are case-sensitive strings.
    /// The tag value can be an empty (null) string. To add a tag, specify a new tag key and
    /// a tag value. To edit a tag, specify an existing tag key and a new tag value.
    /// </para><para>
    /// You can use this operation to tag a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#customer-cmk">customer
    /// managed key</a>, but you cannot tag an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed key</a>, an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-owned-cmk">Amazon
    /// Web Services owned key</a>, a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#keystore-concept">custom
    /// key store</a>, or an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#alias-concept">alias</a>.
    /// </para><para>
    /// You can also add tags to a KMS key while creating it (<a>CreateKey</a>) or replicating
    /// it (<a>ReplicateKey</a>).
    /// </para><para>
    /// For information about using tags in KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/tagging-keys.html">Tagging
    /// keys</a>. For general information about tags, including the format and syntax, see
    /// <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging Amazon
    /// Web Services resources</a> in the <i>Amazon Web Services General Reference</i>. 
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account. 
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:TagResource</a>
    /// (key policy)
    /// </para><para><b>Related operations</b></para><ul><li><para><a>CreateKey</a></para></li><li><para><a>ListResourceTags</a></para></li><li><para><a>ReplicateKey</a></para></li><li><para><a>UntagResource</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KMSResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service TagResource API operation.", Operation = new[] {"TagResource"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.TagResourceResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.TagResourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.TagResourceResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddKMSResourceTagCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies a customer managed key in the account and Region.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags. Each tag consists of a tag key and a tag value. The tag value can
        /// be an empty (null) string. </para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>You cannot have more than one tag on a KMS key with the same tag key. If you specify
        /// an existing tag key with a different tag value, KMS replaces the current tag value
        /// with the specified one.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Tags")]
        public Amazon.KeyManagementService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.TagResourceResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KMSResourceTag (TagResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.TagResourceResponse, AddKMSResourceTagCmdlet>(Select) ??
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KeyManagementService.Model.Tag>(this.Tag);
            }
            #if MODULAR
            if (this.Tag == null && ParameterWasBound(nameof(this.Tag)))
            {
                WriteWarning("You are passing $null as a value for parameter Tag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.TagResourceRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
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
        
        private Amazon.KeyManagementService.Model.TagResourceResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.TagResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "TagResource");
            try
            {
                #if DESKTOP
                return client.TagResource(request);
                #elif CORECLR
                return client.TagResourceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.KeyManagementService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.TagResourceResponse, AddKMSResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
