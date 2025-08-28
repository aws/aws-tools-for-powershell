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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Initiates an AMI copy operation. You must specify the source AMI ID and both the source
    /// and destination locations. The copy operation must be initiated in the destination
    /// Region.
    /// 
    ///  
    /// <para><b>CopyImage supports the following source to destination copies:</b></para><ul><li><para>
    /// Region to Region
    /// </para></li><li><para>
    /// Region to Outpost
    /// </para></li><li><para>
    /// Parent Region to Local Zone
    /// </para></li><li><para>
    /// Local Zone to parent Region
    /// </para></li><li><para>
    /// Between Local Zones with the same parent Region (only supported for certain Local
    /// Zones)
    /// </para></li></ul><para><b>CopyImage does not support the following source to destination copies:</b></para><ul><li><para>
    /// Local Zone to non-parent Regions
    /// </para></li><li><para>
    /// Between Local Zones with different parent Regions
    /// </para></li><li><para>
    /// Local Zone to Outpost
    /// </para></li><li><para>
    /// Outpost to Local Zone
    /// </para></li><li><para>
    /// Outpost to Region
    /// </para></li><li><para>
    /// Between Outposts
    /// </para></li><li><para>
    /// Within same Outpost
    /// </para></li><li><para>
    /// Cross-partition copies (use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateStoreImageTask.html">CreateStoreImageTask</a>
    /// instead)
    /// </para></li></ul><para><b>Destination specification</b></para><ul><li><para>
    /// Region to Region: The destination Region is the Region in which you initiate the copy
    /// operation.
    /// </para></li><li><para>
    /// Region to Outpost: Specify the destination using the <c>DestinationOutpostArn</c>
    /// parameter (the ARN of the Outpost)
    /// </para></li><li><para>
    /// Region to Local Zone, and Local Zone to Local Zone copies: Specify the destination
    /// using the <c>DestinationAvailabilityZone</c> parameter (the name of the destination
    /// Local Zone) or <c>DestinationAvailabilityZoneId</c> parameter (the ID of the destination
    /// Local Zone).
    /// </para></li></ul><para><b>Snapshot encryption</b></para><ul><li><para>
    /// Region to Outpost: Backing snapshots copied to an Outpost are encrypted by default
    /// using the default encryption key for the Region or the key that you specify. Outposts
    /// do not support unencrypted snapshots.
    /// </para></li><li><para>
    /// Region to Local Zone, and Local Zone to Local Zone: Not all Local Zones require encrypted
    /// snapshots. In Local Zones that require encrypted snapshots, backing snapshots are
    /// automatically encrypted during copy. In Local Zones where encryption is not required,
    /// snapshots retain their original encryption state (encrypted or unencrypted) by default.
    /// </para></li></ul><para>
    /// For more information, including the required permissions for copying an AMI, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/CopyingAMIs.html">Copy an
    /// Amazon EC2 AMI</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CopyImage API operation.", Operation = new[] {"CopyImage"}, SelectReturnType = typeof(Amazon.EC2.Model.CopyImageResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.CopyImageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.CopyImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CopyImageTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy your user-defined AMI tags to the new AMI.</para><para>The following tags are not be copied:</para><ul><li><para>System tags (prefixed with <c>aws:</c>)</para></li><li><para>For public and shared AMIs, user-defined tags that are attached by other Amazon Web
        /// Services accounts</para></li></ul><para>Default: Your user-defined AMI tags are not copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyImageTags")]
        public System.Boolean? CopyImageTag { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the new AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Local Zone for the new AMI (for example, <c>cn-north-1-pkx-1a</c>).</para><para>Only one of <c>DestinationAvailabilityZone</c>, <c>DestinationAvailabilityZoneId</c>,
        /// or <c>DestinationOutpostArn</c> can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DestinationAvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Local Zone for the new AMI (for example, <c>cnn1-pkx1-az1</c>).</para><para>Only one of <c>DestinationAvailabilityZone</c>, <c>DestinationAvailabilityZoneId</c>,
        /// or <c>DestinationOutpostArn</c> can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationAvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter DestinationOutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost for the new AMI.</para><para>Only specify this parameter when copying an AMI from an Amazon Web Services Region
        /// to an Outpost. The AMI must be in the Region of the destination Outpost. You can't
        /// copy an AMI from an Outpost to a Region, from one Outpost to another, or within the
        /// same Outpost.</para><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#copy-amis">Copy
        /// AMIs from an Amazon Web Services Region to an Outpost</a> in the <i>Amazon EBS User
        /// Guide</i>.</para><para>Only one of <c>DestinationAvailabilityZone</c>, <c>DestinationAvailabilityZoneId</c>,
        /// or <c>DestinationOutpostArn</c> can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationOutpostArn { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether to encrypt the snapshots of the copied image.</para><para>You can encrypt a copy of an unencrypted snapshot, but you cannot create an unencrypted
        /// copy of an encrypted snapshot. The default KMS key for Amazon EBS is used unless you
        /// specify a non-default Key Management Service (KMS) KMS key using <c>KmsKeyId</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/AMIEncryption.html">Use
        /// encryption with EBS-backed AMIs</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the symmetric Key Management Service (KMS) KMS key to use when creating
        /// encrypted volumes. If this parameter is not specified, your Amazon Web Services managed
        /// KMS key for Amazon EBS is used. If you specify a KMS key, you must also set the encrypted
        /// state to <c>true</c>.</para><para>You can specify a KMS key using any of the following:</para><ul><li><para>Key ID. For example, 1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Key alias. For example, alias/ExampleAlias.</para></li><li><para>Key ARN. For example, arn:aws:kms:us-east-1:012345678910:key/1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Alias ARN. For example, arn:aws:kms:us-east-1:012345678910:alias/ExampleAlias.</para></li></ul><para>Amazon Web Services authenticates the KMS key asynchronously. Therefore, if you specify
        /// an identifier that is not valid, the action can appear to complete, but eventually
        /// fails.</para><para>The specified KMS key must exist in the destination Region.</para><para>Amazon EBS does not support asymmetric KMS keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new AMI.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SnapshotCopyCompletionDurationMinute
        /// <summary>
        /// <para>
        /// <para>Specify a completion duration, in 15 minute increments, to initiate a time-based AMI
        /// copy. The specified completion duration applies to each of the snapshots associated
        /// with the AMI. Each snapshot associated with the AMI will be completed within the specified
        /// completion duration, with copy throughput automatically adjusted for each snapshot
        /// based on its size to meet the timing target.</para><para>If you do not specify a value, the AMI copy operation is completed on a best-effort
        /// basis.</para><note><para>This parameter is not supported when copying an AMI to or from a Local Zone, or to
        /// an Outpost.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/time-based-copies.html">Time-based
        /// copies for Amazon EBS snapshots and EBS-backed AMIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotCopyCompletionDurationMinutes")]
        public System.Int64? SnapshotCopyCompletionDurationMinute { get; set; }
        #endregion
        
        #region Parameter SourceImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI to copy.</para>
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
        public System.String SourceImageId { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// <para>The name of the Region that contains the AMI to copy.</para>
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
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the new AMI and new snapshots. You can tag the AMI, the snapshots,
        /// or both.</para><ul><li><para>To tag the new AMI, the value for <c>ResourceType</c> must be <c>image</c>.</para></li><li><para>To tag the new snapshots, the value for <c>ResourceType</c> must be <c>snapshot</c>.
        /// The same tag is applied to all the new snapshots.</para></li></ul><para>If you specify other values for <c>ResourceType</c>, the request fails.</para><para>To tag an AMI or snapshot after it has been created, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateTags.html">CreateTags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency in Amazon EC2 API requests</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CopyImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CopyImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceImageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceImageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceImageId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Image (CopyImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CopyImageResponse, CopyEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceImageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.CopyImageTag = this.CopyImageTag;
            context.Description = this.Description;
            context.DestinationAvailabilityZone = this.DestinationAvailabilityZone;
            context.DestinationAvailabilityZoneId = this.DestinationAvailabilityZoneId;
            context.DestinationOutpostArn = this.DestinationOutpostArn;
            context.Encrypted = this.Encrypted;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotCopyCompletionDurationMinute = this.SnapshotCopyCompletionDurationMinute;
            context.SourceImageId = this.SourceImageId;
            #if MODULAR
            if (this.SourceImageId == null && ParameterWasBound(nameof(this.SourceImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceRegion = this.SourceRegion;
            #if MODULAR
            if (this.SourceRegion == null && ParameterWasBound(nameof(this.SourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CopyImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CopyImageTag != null)
            {
                request.CopyImageTags = cmdletContext.CopyImageTag.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationAvailabilityZone != null)
            {
                request.DestinationAvailabilityZone = cmdletContext.DestinationAvailabilityZone;
            }
            if (cmdletContext.DestinationAvailabilityZoneId != null)
            {
                request.DestinationAvailabilityZoneId = cmdletContext.DestinationAvailabilityZoneId;
            }
            if (cmdletContext.DestinationOutpostArn != null)
            {
                request.DestinationOutpostArn = cmdletContext.DestinationOutpostArn;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SnapshotCopyCompletionDurationMinute != null)
            {
                request.SnapshotCopyCompletionDurationMinutes = cmdletContext.SnapshotCopyCompletionDurationMinute.Value;
            }
            if (cmdletContext.SourceImageId != null)
            {
                request.SourceImageId = cmdletContext.SourceImageId;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
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
        
        private Amazon.EC2.Model.CopyImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CopyImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CopyImage");
            try
            {
                #if DESKTOP
                return client.CopyImage(request);
                #elif CORECLR
                return client.CopyImageAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopyImageTag { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationAvailabilityZone { get; set; }
            public System.String DestinationAvailabilityZoneId { get; set; }
            public System.String DestinationOutpostArn { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.Int64? SnapshotCopyCompletionDurationMinute { get; set; }
            public System.String SourceImageId { get; set; }
            public System.String SourceRegion { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CopyImageResponse, CopyEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageId;
        }
        
    }
}
