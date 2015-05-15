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
    /// Creates a snapshot of an EBS volume and stores it in Amazon S3. You can use snapshots
    /// for backups, to make copies of EBS volumes, and to save data before shutting down
    /// an instance.
    /// 
    ///  
    /// <para>
    /// When a snapshot is created, any AWS Marketplace product codes that are associated
    /// with the source volume are propagated to the snapshot.
    /// </para><para>
    /// You can take a snapshot of an attached volume that is in use. However, snapshots only
    /// capture data that has been written to your EBS volume at the time the snapshot command
    /// is issued; this may exclude any data that has been cached by any applications or the
    /// operating system. If you can pause any file systems on the volume long enough to take
    /// a snapshot, your snapshot should be complete. However, if you cannot pause all file
    /// writes to the volume, you should unmount the volume from within the instance, issue
    /// the snapshot command, and then remount the volume to ensure a consistent and complete
    /// snapshot. You may remount and use your volume while the snapshot status is <code>pending</code>.
    /// </para><para>
    /// To create a snapshot for EBS volumes that serve as root devices, you should stop the
    /// instance before taking the snapshot.
    /// </para><para>
    /// Snapshots that are taken from encrypted volumes are automatically encrypted. Volumes
    /// that are created from encrypted snapshots are also automatically encrypted. Your encrypted
    /// volumes and any associated snapshots always remain protected.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/AmazonEBS.html">Amazon
    /// Elastic Block Store</a> and <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
    /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Snapshot")]
    [AWSCmdlet("Invokes the CreateSnapshot operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateSnapshot"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Snapshot",
        "This cmdlet returns a Snapshot object.",
        "The service call response (type CreateSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A description for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the EBS volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String VolumeId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VolumeId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Snapshot (CreateSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.VolumeId = this.VolumeId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateSnapshotRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Snapshot;
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
            public String Description { get; set; }
            public String VolumeId { get; set; }
        }
        
    }
}
