/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Zone. The volume is created in the regional endpoint that you send the HTTP request
    /// to. For more information see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
    /// and Endpoints</a>.
    /// 
    ///  
    /// <para>
    /// You can create a new empty volume or restore a volume from an EBS snapshot. Any AWS
    /// Marketplace product codes from the snapshot are propagated to the volume.
    /// </para><para>
    /// You can create encrypted volumes with the <code>Encrypted</code> parameter. Encrypted
    /// volumes may only be attached to instances that support Amazon EBS encryption. Volumes
    /// that are created from encrypted snapshots are also automatically encrypted. For more
    /// information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
    /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// You can tag your volumes during creation. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tagging
    /// Your Amazon EC2 Resources</a>.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-creating-volume.html">Creating
    /// an Amazon EBS Volume</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Volume")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateVolume API operation.", Operation = new[] {"CreateVolume"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Volume",
        "This cmdlet returns a Volume object.",
        "The service call response (type Amazon.EC2.Model.CreateVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create the volume. Use <a>DescribeAvailabilityZones</a>
        /// to list the Availability Zones that are currently available to you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether the volume should be encrypted. Encrypted Amazon EBS volumes may
        /// only be attached to instances that support Amazon EBS encryption. Volumes that are
        /// created from encrypted snapshots are automatically encrypted. There is no way to create
        /// an encrypted volume from an unencrypted snapshot or vice versa. If your AMI uses encrypted
        /// volumes, you can only launch it on supported instance types. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
        /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 5)]
        public System.Boolean Encrypted { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The number of I/O operations per second (IOPS) to provision for the volume, with a
        /// maximum ratio of 50 IOPS/GiB. Range is 100 to 32000 IOPS for volumes in most regions.
        /// For exceptions, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSVolumeTypes.html">Amazon
        /// EBS Volume Types</a>.</para><para>This parameter is valid only for Provisioned IOPS SSD (io1) volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An identifier for the AWS Key Management Service (AWS KMS) customer master key (CMK)
        /// to use when creating the encrypted volume. This parameter is only required if you
        /// want to use a non-default CMK; if this parameter is not specified, the default CMK
        /// for EBS is used. If a <code>KmsKeyId</code> is specified, the <code>Encrypted</code>
        /// flag must also be set. </para><para>The CMK identifier may be provided in any of the following formats: </para><ul><li><para>Key ID</para></li><li><para>Key alias</para></li><li><para>ARN using key ID. The ID ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the region of the CMK, the AWS account ID of the CMK owner, the <code>key</code>
        /// namespace, and then the CMK ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.
        /// </para></li><li><para>ARN using key alias. The alias ARN contains the <code>arn:aws:kms</code> namespace,
        /// followed by the region of the CMK, the AWS account ID of the CMK owner, the <code>alias</code>
        /// namespace, and then the CMK alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.
        /// </para></li></ul><para>AWS parses <code>KmsKeyId</code> asynchronously, meaning that the action you call
        /// may appear to complete even though you provided an invalid identifier. The action
        /// will eventually fail. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The size of the volume, in GiBs.</para><para>Constraints: 1-16384 for <code>gp2</code>, 4-16384 for <code>io1</code>, 500-16384
        /// for <code>st1</code>, 500-16384 for <code>sc1</code>, and 1-1024 for <code>standard</code>.
        /// If you specify a snapshot, the volume size must be equal to or larger than the snapshot
        /// size.</para><para>Default: If you're creating the volume from a snapshot and don't specify a volume
        /// size, the default is the snapshot size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 Size { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot from which to create the volume.</para>
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
        [System.Management.Automation.Parameter]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter VolumeType
        /// <summary>
        /// <para>
        /// <para>The volume type. This can be <code>gp2</code> for General Purpose SSD, <code>io1</code>
        /// for Provisioned IOPS SSD, <code>st1</code> for Throughput Optimized HDD, <code>sc1</code>
        /// for Cold HDD, or <code>standard</code> for Magnetic volumes.</para><para>Defaults: If no volume type is specified, the default is <code>standard</code> in
        /// us-east-1, eu-west-1, eu-central-1, us-west-2, us-west-1, sa-east-1, ap-northeast-1,
        /// ap-northeast-2, ap-southeast-1, ap-southeast-2, ap-south-1, us-gov-west-1, and cn-north-1.
        /// In all other regions, EBS defaults to <code>gp2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        [AWSConstantClassSource("Amazon.EC2.VolumeType")]
        public Amazon.EC2.VolumeType VolumeType { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Volume (CreateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            if (ParameterWasBound("Size"))
                context.Size = this.Size;
            context.SnapshotId = this.SnapshotId;
            if (this.TagSpecification != null)
            {
                context.TagSpecifications = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
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
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.TagSpecifications != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecifications;
            }
            if (cmdletContext.VolumeType != null)
            {
                request.VolumeType = cmdletContext.VolumeType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Volume;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateVolume");
            try
            {
                #if DESKTOP
                return client.CreateVolume(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVolumeAsync(request);
                return task.Result;
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
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? Size { get; set; }
            public System.String SnapshotId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecifications { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
        }
        
    }
}
