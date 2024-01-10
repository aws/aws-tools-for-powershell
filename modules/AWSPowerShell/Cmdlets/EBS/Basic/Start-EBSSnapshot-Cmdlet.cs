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
using Amazon.EBS;
using Amazon.EBS.Model;

namespace Amazon.PowerShell.Cmdlets.EBS
{
    /// <summary>
    /// Creates a new Amazon EBS snapshot. The new snapshot enters the <c>pending</c> state
    /// after the request completes. 
    /// 
    ///  
    /// <para>
    /// After creating the snapshot, use <a href="https://docs.aws.amazon.com/ebs/latest/APIReference/API_PutSnapshotBlock.html">
    /// PutSnapshotBlock</a> to write blocks of data to the snapshot.
    /// </para><note><para>
    /// You should always retry requests that receive server (<c>5xx</c>) error responses,
    /// and <c>ThrottlingException</c> and <c>RequestThrottledException</c> client error responses.
    /// For more information see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/error-retries.html">Error
    /// retries</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "EBSSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EBS.Model.StartSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon EBS StartSnapshot API operation.", Operation = new[] {"StartSnapshot"}, SelectReturnType = typeof(Amazon.EBS.Model.StartSnapshotResponse))]
    [AWSCmdletOutput("Amazon.EBS.Model.StartSnapshotResponse",
        "This cmdlet returns an Amazon.EBS.Model.StartSnapshotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartEBSSnapshotCmdlet : AmazonEBSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Indicates whether to encrypt the snapshot.</para><para>You can't specify <b>Encrypted</b> and <b> ParentSnapshotId</b> in the same request.
        /// If you specify both parameters, the request fails with <c>ValidationException</c>.</para><para>The encryption status of the snapshot depends on the values that you specify for <b>Encrypted</b>,
        /// <b>KmsKeyArn</b>, and <b>ParentSnapshotId</b>, and whether your Amazon Web Services
        /// account is enabled for <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html#encryption-by-default">
        /// encryption by default</a>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapis-using-encryption.html">
        /// Using encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para><important><para>To create an encrypted snapshot, you must have permission to use the KMS key. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapi-permissions.html#ebsapi-kms-permissions">
        /// Permissions to use Key Management Service keys</a> in the <i>Amazon Elastic Compute
        /// Cloud User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key to be used
        /// to encrypt the snapshot.</para><para>The encryption status of the snapshot depends on the values that you specify for <b>Encrypted</b>,
        /// <b>KmsKeyArn</b>, and <b>ParentSnapshotId</b>, and whether your Amazon Web Services
        /// account is enabled for <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html#encryption-by-default">
        /// encryption by default</a>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapis-using-encryption.html">
        /// Using encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para><important><para>To create an encrypted snapshot, you must have permission to use the KMS key. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapi-permissions.html#ebsapi-kms-permissions">
        /// Permissions to use Key Management Service keys</a> in the <i>Amazon Elastic Compute
        /// Cloud User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ParentSnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent snapshot. If there is no parent snapshot, or if you are creating
        /// the first snapshot for an on-premises volume, omit this parameter.</para><para>You can't specify <b>ParentSnapshotId</b> and <b>Encrypted</b> in the same request.
        /// If you specify both parameters, the request fails with <c>ValidationException</c>.</para><para>The encryption status of the snapshot depends on the values that you specify for <b>Encrypted</b>,
        /// <b>KmsKeyArn</b>, and <b>ParentSnapshotId</b>, and whether your Amazon Web Services
        /// account is enabled for <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html#encryption-by-default">
        /// encryption by default</a>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapis-using-encryption.html">
        /// Using encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para><important><para>If you specify an encrypted parent snapshot, you must have permission to use the KMS
        /// key that was used to encrypt the parent snapshot. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebsapi-permissions.html#ebsapi-kms-permissions">
        /// Permissions to use Key Management Service keys</a> in the <i>Amazon Elastic Compute
        /// Cloud User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentSnapshotId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.EBS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) after which the snapshot is automatically cancelled
        /// if:</para><ul><li><para>No blocks are written to the snapshot.</para></li><li><para>The snapshot is not completed after writing the last block of data.</para></li></ul><para>If no value is specified, the timeout defaults to <c>60</c> minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter VolumeSize
        /// <summary>
        /// <para>
        /// <para>The size of the volume, in GiB. The maximum size is <c>65536</c> GiB (64 TiB).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? VolumeSize { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully. The subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-direct-api-idempotency.html">
        /// Idempotency for StartSnapshot API</a> in the <i>Amazon Elastic Compute Cloud User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EBS.Model.StartSnapshotResponse).
        /// Specifying the name of a property of type Amazon.EBS.Model.StartSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeSize parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeSize' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeSize' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EBSSnapshot (StartSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EBS.Model.StartSnapshotResponse, StartEBSSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeSize;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Encrypted = this.Encrypted;
            context.KmsKeyArn = this.KmsKeyArn;
            context.ParentSnapshotId = this.ParentSnapshotId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.EBS.Model.Tag>(this.Tag);
            }
            context.Timeout = this.Timeout;
            context.VolumeSize = this.VolumeSize;
            #if MODULAR
            if (this.VolumeSize == null && ParameterWasBound(nameof(this.VolumeSize)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EBS.Model.StartSnapshotRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.ParentSnapshotId != null)
            {
                request.ParentSnapshotId = cmdletContext.ParentSnapshotId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            if (cmdletContext.VolumeSize != null)
            {
                request.VolumeSize = cmdletContext.VolumeSize.Value;
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
        
        private Amazon.EBS.Model.StartSnapshotResponse CallAWSServiceOperation(IAmazonEBS client, Amazon.EBS.Model.StartSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EBS", "StartSnapshot");
            try
            {
                #if DESKTOP
                return client.StartSnapshot(request);
                #elif CORECLR
                return client.StartSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String ParentSnapshotId { get; set; }
            public List<Amazon.EBS.Model.Tag> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.Int64? VolumeSize { get; set; }
            public System.Func<Amazon.EBS.Model.StartSnapshotResponse, StartEBSSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
