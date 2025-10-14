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
    /// Creates an EBS volume that can be attached to an instance in the same Availability
    /// Zone.
    /// 
    ///  
    /// <para>
    /// You can create a new empty volume or restore a volume from an EBS snapshot. Any Amazon
    /// Web Services Marketplace product codes from the snapshot are propagated to the volume.
    /// </para><para>
    /// You can create encrypted volumes. Encrypted volumes must be attached to instances
    /// that support Amazon EBS encryption. Volumes that are created from encrypted snapshots
    /// are also automatically encrypted. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption.html">Amazon
    /// EBS encryption</a> in the <i>Amazon EBS User Guide</i>.
    /// </para><para>
    /// You can tag your volumes during creation. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tag
    /// your Amazon EC2 resources</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-creating-volume.html">Create
    /// an Amazon EBS volume</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Volume")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVolume API operation.", Operation = new[] {"CreateVolume"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVolumeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Volume or Amazon.EC2.Model.CreateVolumeResponse",
        "This cmdlet returns an Amazon.EC2.Model.Volume object.",
        "The service call response (type Amazon.EC2.Model.CreateVolumeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone in which to create the volume. For example, <c>us-east-1a</c>.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone in which to create the volume. For example, <c>use1-az1</c>.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Indicates whether the volume should be encrypted. The effect of setting the encryption
        /// state to <c>true</c> depends on the volume origin (new or from a snapshot), starting
        /// encryption state, ownership, and whether encryption by default is enabled. For more
        /// information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/work-with-ebs-encr.html#encryption-by-default">Encryption
        /// by default</a> in the <i>Amazon EBS User Guide</i>.</para><para>Encrypted Amazon EBS volumes must be attached to instances that support Amazon EBS
        /// encryption. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption-requirements.html#ebs-encryption_supported_instances">Supported
        /// instance types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The number of I/O operations per second (IOPS) to provision for the volume. Required
        /// for <c>io1</c> and <c>io2</c> volumes. Optional for <c>gp3</c> volumes. Omit for all
        /// other volume types. </para><para>Valid ranges:</para><ul><li><para>gp3: <c>3,000 </c>(<i>default</i>)<c> - 80,000</c> IOPS</para></li><li><para>io1: <c>100 - 64,000</c> IOPS</para></li><li><para>io2: <c>100 - 256,000</c> IOPS</para></li></ul><note><para><a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">
        /// Instances built on the Nitro System</a> can support up to 256,000 IOPS. Other instances
        /// can support up to 32,000 IOPS.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
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
        
        #region Parameter MultiAttachEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable Amazon EBS Multi-Attach. If you enable Multi-Attach, you
        /// can attach the volume to up to 16 <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">Instances
        /// built on the Nitro System</a> in the same Availability Zone. This parameter is supported
        /// with <c>io1</c> and <c>io2</c> volumes only. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volumes-multi.html">
        /// Amazon EBS Multi-Attach</a> in the <i>Amazon EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAttachEnabled { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost on which to create the volume.</para><para>If you intend to use a volume with an instance running on an outpost, then you must
        /// create the volume on the same outpost as the instance. You can't use a volume created
        /// in an Amazon Web Services Region with an instance on an Amazon Web Services outpost,
        /// or the other way around.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter Operator_Principal
        /// <summary>
        /// <para>
        /// <para>The service provider that manages the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Operator_Principal { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The size of the volume, in GiBs. You must specify either a snapshot ID or a volume
        /// size. If you specify a snapshot, the default is the snapshot size, and you can specify
        /// a volume size that is equal to or larger than the snapshot size.</para><para>Valid sizes:</para><ul><li><para>gp2: <c>1 - 16,384</c> GiB</para></li><li><para>gp3: <c>1 - 65,536</c> GiB</para></li><li><para>io1: <c>4 - 16,384</c> GiB</para></li><li><para>io2: <c>4 - 65,536</c> GiB</para></li><li><para>st1 and sc1: <c>125 - 16,384</c> GiB</para></li><li><para>standard: <c>1 - 1024</c> GiB</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? Size { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot from which to create the volume. You must specify either a snapshot ID
        /// or a volume size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the volume during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Throughput
        /// <summary>
        /// <para>
        /// <para>The throughput to provision for the volume, in MiB/s. Supported for <c>gp3</c> volumes
        /// only. Omit for all other volume types.</para><para>Valid Range: <c>125 - 2000</c> MiB/s</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Throughput { get; set; }
        #endregion
        
        #region Parameter VolumeInitializationRate
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon EBS Provisioned Rate for Volume Initialization (volume initialization
        /// rate), in MiB/s, at which to download the snapshot blocks from Amazon S3 to the volume.
        /// This is also known as <i>volume initialization</i>. Specifying a volume initialization
        /// rate ensures that the volume is initialized at a predictable and consistent rate after
        /// creation.</para><para>This parameter is supported only for volumes created from snapshots. Omit this parameter
        /// if:</para><ul><li><para>You want to create the volume using fast snapshot restore. You must specify a snapshot
        /// that is enabled for fast snapshot restore. In this case, the volume is fully initialized
        /// at creation.</para><note><para>If you specify a snapshot that is enabled for fast snapshot restore and a volume initialization
        /// rate, the volume will be initialized at the specified rate instead of fast snapshot
        /// restore.</para></note></li><li><para>You want to create a volume that is initialized at the default rate.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/initalize-volume.html">
        /// Initialize Amazon EBS volumes</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Valid range: 100 - 300 MiB/s</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VolumeInitializationRate { get; set; }
        #endregion
        
        #region Parameter VolumeType
        /// <summary>
        /// <para>
        /// <para>The volume type. This parameter can be one of the following values:</para><ul><li><para>General Purpose SSD: <c>gp2</c> | <c>gp3</c></para></li><li><para>Provisioned IOPS SSD: <c>io1</c> | <c>io2</c></para></li><li><para>Throughput Optimized HDD: <c>st1</c></para></li><li><para>Cold HDD: <c>sc1</c></para></li><li><para>Magnetic: <c>standard</c></para></li></ul><important><para>Throughput Optimized HDD (<c>st1</c>) and Cold HDD (<c>sc1</c>) volumes can't be used
        /// as boot volumes.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volume-types.html">Amazon
        /// EBS volume types</a> in the <i>Amazon EBS User Guide</i>.</para><para>Default: <c>gp2</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VolumeType")]
        public Amazon.EC2.VolumeType VolumeType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensure
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volume'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVolumeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Volume";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Volume (CreateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVolumeResponse, NewEC2VolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.Encrypted = this.Encrypted;
            context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.MultiAttachEnabled = this.MultiAttachEnabled;
            context.Operator_Principal = this.Operator_Principal;
            context.OutpostArn = this.OutpostArn;
            context.Size = this.Size;
            context.SnapshotId = this.SnapshotId;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Throughput = this.Throughput;
            context.VolumeInitializationRate = this.VolumeInitializationRate;
            context.VolumeType = this.VolumeType;
            
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
            var request = new Amazon.EC2.Model.CreateVolumeRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MultiAttachEnabled != null)
            {
                request.MultiAttachEnabled = cmdletContext.MultiAttachEnabled.Value;
            }
            
             // populate Operator
            var requestOperatorIsNull = true;
            request.Operator = new Amazon.EC2.Model.OperatorRequest();
            System.String requestOperator_operator_Principal = null;
            if (cmdletContext.Operator_Principal != null)
            {
                requestOperator_operator_Principal = cmdletContext.Operator_Principal;
            }
            if (requestOperator_operator_Principal != null)
            {
                request.Operator.Principal = requestOperator_operator_Principal;
                requestOperatorIsNull = false;
            }
             // determine if request.Operator should be set to null
            if (requestOperatorIsNull)
            {
                request.Operator = null;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Throughput != null)
            {
                request.Throughput = cmdletContext.Throughput.Value;
            }
            if (cmdletContext.VolumeInitializationRate != null)
            {
                request.VolumeInitializationRate = cmdletContext.VolumeInitializationRate.Value;
            }
            if (cmdletContext.VolumeType != null)
            {
                request.VolumeType = cmdletContext.VolumeType;
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
        
        private Amazon.EC2.Model.CreateVolumeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVolume");
            try
            {
                #if DESKTOP
                return client.CreateVolume(request);
                #elif CORECLR
                return client.CreateVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Boolean? MultiAttachEnabled { get; set; }
            public System.String Operator_Principal { get; set; }
            public System.String OutpostArn { get; set; }
            public System.Int32? Size { get; set; }
            public System.String SnapshotId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Int32? Throughput { get; set; }
            public System.Int32? VolumeInitializationRate { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVolumeResponse, NewEC2VolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volume;
        }
        
    }
}
