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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Copies a point-in-time snapshot of an EBS volume and stores it in Amazon S3. You can
    /// copy a snapshot within the same Region, from one Region to another, or from a Region
    /// to an Outpost. You can't copy a snapshot from an Outpost to a Region, from one Outpost
    /// to another, or within the same Outpost.
    /// 
    ///  
    /// <para>
    /// You can use the snapshot to create EBS volumes or Amazon Machine Images (AMIs).
    /// </para><para>
    /// When copying snapshots to a Region, copies of encrypted EBS snapshots remain encrypted.
    /// Copies of unencrypted snapshots remain unencrypted, unless you enable encryption for
    /// the snapshot copy operation. By default, encrypted snapshot copies use the default
    /// KMS key; however, you can specify a different KMS key. To copy an encrypted snapshot
    /// that has been shared from another account, you must have permissions for the KMS key
    /// used to encrypt the snapshot.
    /// </para><para>
    /// Snapshots copied to an Outpost are encrypted by default using the default encryption
    /// key for the Region, or a different key that you specify in the request using <b>KmsKeyId</b>.
    /// Outposts do not support unencrypted snapshots. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#ami">Amazon
    /// EBS local snapshots on Outposts</a> in the <i>Amazon EBS User Guide</i>.
    /// </para><para>
    /// Snapshots created by copying another snapshot have an arbitrary volume ID that should
    /// not be used for any purpose.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-copy-snapshot.html">Copy
    /// an Amazon EBS snapshot</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CopySnapshot API operation.", Operation = new[] {"CopySnapshot"}, SelectReturnType = typeof(Amazon.EC2.Model.CopySnapshotResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.CopySnapshotResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.CopySnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CompletionDurationMinute
        /// <summary>
        /// <para>
        /// <para>Specify a completion duration, in 15 minute increments, to initiate a time-based snapshot
        /// copy. Time-based snapshot copy operations complete within the specified duration.
        /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/time-based-copies.html">
        /// Time-based copies</a>.</para><para>If you do not specify a value, the snapshot copy operation is completed on a best-effort
        /// basis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompletionDurationMinutes")]
        public System.Int32? CompletionDurationMinute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the EBS snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationOutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost to which to copy the snapshot. Only
        /// specify this parameter when copying a snapshot from an Amazon Web Services Region
        /// to an Outpost. The snapshot must be in the Region for the destination Outpost. You
        /// cannot copy a snapshot from an Outpost to a Region, from one Outpost to another, or
        /// within the same Outpost.</para><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#copy-snapshots">
        /// Copy snapshots from an Amazon Web Services Region to an Outpost</a> in the <i>Amazon
        /// EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationOutpostArn { get; set; }
        #endregion
        
        #region Parameter DestinationRegion
        /// <summary>
        /// <para>
        /// <para>The destination Region to use in the <c>PresignedUrl</c> parameter of a snapshot copy
        /// operation. This parameter is only valid for specifying the destination Region in a
        /// <c>PresignedUrl</c> parameter, where it is required.</para><para>The snapshot copy is sent to the regional endpoint that you sent the HTTP request
        /// to (for example, <c>ec2.us-east-1.amazonaws.com</c>). With the CLI, this is specified
        /// using the <c>--region</c> parameter or the default Region in your Amazon Web Services
        /// configuration file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationRegion { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>To encrypt a copy of an unencrypted snapshot if encryption by default is not enabled,
        /// enable encryption using this parameter. Otherwise, omit this parameter. Encrypted
        /// snapshots are encrypted, even if you omit this parameter and encryption by default
        /// is not enabled. You cannot set this parameter to false. For more information, see
        /// <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption.html">Amazon
        /// EBS encryption</a> in the <i>Amazon EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key to use for Amazon EBS encryption. If this parameter
        /// is not specified, your KMS key for Amazon EBS is used. If <c>KmsKeyId</c> is specified,
        /// the encrypted state must be <c>true</c>.</para><para>You can specify the KMS key using any of the following:</para><ul><li><para>Key ID. For example, 1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Key alias. For example, alias/ExampleAlias.</para></li><li><para>Key ARN. For example, arn:aws:kms:us-east-1:012345678910:key/1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Alias ARN. For example, arn:aws:kms:us-east-1:012345678910:alias/ExampleAlias.</para></li></ul><para>Amazon Web Services authenticates the KMS key asynchronously. Therefore, if you specify
        /// an ID, alias, or ARN that is not valid, the action can appear to complete, but eventually
        /// fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// <para>The ID of the Region that contains the snapshot to be copied.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the EBS snapshot to copy.</para>
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
        public System.String SourceSnapshotId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the new snapshot.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapshotId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CopySnapshotResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CopySnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapshotId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceSnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Snapshot (CopySnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CopySnapshotResponse, CopyEC2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CompletionDurationMinute = this.CompletionDurationMinute;
            context.Description = this.Description;
            context.DestinationOutpostArn = this.DestinationOutpostArn;
            context.DestinationRegion = this.DestinationRegion;
            context.DryRun = this.DryRun;
            context.Encrypted = this.Encrypted;
            context.KmsKeyId = this.KmsKeyId;
            context.SourceRegion = this.SourceRegion;
            #if MODULAR
            if (this.SourceRegion == null && ParameterWasBound(nameof(this.SourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceSnapshotId = this.SourceSnapshotId;
            #if MODULAR
            if (this.SourceSnapshotId == null && ParameterWasBound(nameof(this.SourceSnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CopySnapshotRequest();
            
            if (cmdletContext.CompletionDurationMinute != null)
            {
                request.CompletionDurationMinutes = cmdletContext.CompletionDurationMinute.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationOutpostArn != null)
            {
                request.DestinationOutpostArn = cmdletContext.DestinationOutpostArn;
            }
            if (cmdletContext.DestinationRegion != null)
            {
                request.DestinationRegion = cmdletContext.DestinationRegion;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.SourceSnapshotId != null)
            {
                request.SourceSnapshotId = cmdletContext.SourceSnapshotId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CopySnapshotResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CopySnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CopySnapshot");
            try
            {
                return client.CopySnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CompletionDurationMinute { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationOutpostArn { get; set; }
            public System.String DestinationRegion { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String SourceRegion { get; set; }
            public System.String SourceSnapshotId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CopySnapshotResponse, CopyEC2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapshotId;
        }
        
    }
}
