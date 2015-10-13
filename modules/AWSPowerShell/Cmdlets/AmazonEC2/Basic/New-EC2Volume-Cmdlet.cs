/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-creating-volume.html">Creating
    /// or Restoring an Amazon EBS Volume</a> in the <i>Amazon Elastic Compute Cloud User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Volume")]
    [AWSCmdlet("Invokes the CreateVolume operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateVolume"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Volume",
        "This cmdlet returns a Volume object.",
        "The service call response (type Amazon.EC2.Model.CreateVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create the volume. Use <a>DescribeAvailabilityZones</a>
        /// to list the Availability Zones that are currently available to you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        
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
        
        /// <summary>
        /// <para>
        /// <para>Only valid for Provisioned IOPS (SSD) volumes. The number of I/O operations per second
        /// (IOPS) to provision for the volume, with a maximum ratio of 30 IOPS/GiB.</para><para>Constraint: Range is 100 to 20000 for Provisioned IOPS (SSD) volumes </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Iops { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The full ARN of the AWS Key Management Service (AWS KMS) customer master key (CMK)
        /// to use when creating the encrypted volume. This parameter is only required if you
        /// want to use a non-default CMK; if this parameter is not specified, the default CMK
        /// for EBS is used. The ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the region of the CMK, the AWS account ID of the CMK owner, the <code>key</code>
        /// namespace, and then the CMK ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.
        /// If a <code>KmsKeyId</code> is specified, the <code>Encrypted</code> flag must also
        /// be set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The size of the volume, in GiBs.</para><para>Constraints: <code>1-1024</code> for <code>standard</code> volumes, <code>1-16384</code>
        /// for <code>gp2</code> volumes, and <code>4-16384</code> for <code>io1</code> volumes.
        /// If you specify a snapshot, the volume size must be equal to or larger than the snapshot
        /// size.</para><para>Default: If you're creating the volume from a snapshot and don't specify a volume
        /// size, the default is the snapshot size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 Size { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The snapshot from which to create the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SnapshotId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The volume type. This can be <code>gp2</code> for General Purpose (SSD) volumes, <code>io1</code>
        /// for Provisioned IOPS (SSD) volumes, or <code>standard</code> for Magnetic volumes.</para><para>Default: <code>standard</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public Amazon.EC2.VolumeType VolumeType { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            if (ParameterWasBound("Size"))
                context.Size = this.Size;
            context.SnapshotId = this.SnapshotId;
            context.VolumeType = this.VolumeType;
            
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
            if (cmdletContext.VolumeType != null)
            {
                request.VolumeType = cmdletContext.VolumeType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateVolume(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AvailabilityZone { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? Size { get; set; }
            public System.String SnapshotId { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
        }
        
    }
}
