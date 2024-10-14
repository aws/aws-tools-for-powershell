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
    /// You can create snapshots of volumes in a Region and volumes on an Outpost. If you
    /// create a snapshot of a volume in a Region, the snapshot must be stored in the same
    /// Region as the volume. If you create a snapshot of a volume on an Outpost, the snapshot
    /// can be stored on the same Outpost as the volume, or in the Region for that Outpost.
    /// </para><para>
    /// When a snapshot is created, any Amazon Web Services Marketplace product codes that
    /// are associated with the source volume are propagated to the snapshot.
    /// </para><para>
    /// You can take a snapshot of an attached volume that is in use. However, snapshots only
    /// capture data that has been written to your Amazon EBS volume at the time the snapshot
    /// command is issued; this might exclude any data that has been cached by any applications
    /// or the operating system. If you can pause any file systems on the volume long enough
    /// to take a snapshot, your snapshot should be complete. However, if you cannot pause
    /// all file writes to the volume, you should unmount the volume from within the instance,
    /// issue the snapshot command, and then remount the volume to ensure a consistent and
    /// complete snapshot. You may remount and use your volume while the snapshot status is
    /// <c>pending</c>.
    /// </para><para>
    /// When you create a snapshot for an EBS volume that serves as a root device, we recommend
    /// that you stop the instance before taking the snapshot.
    /// </para><para>
    /// Snapshots that are taken from encrypted volumes are automatically encrypted. Volumes
    /// that are created from encrypted snapshots are also automatically encrypted. Your encrypted
    /// volumes and any associated snapshots always remain protected.
    /// </para><para>
    /// You can tag your snapshots during creation. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tag
    /// your Amazon EC2 resources</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/what-is-ebs.html">Amazon
    /// EBS</a> and <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption.html">Amazon
    /// EBS encryption</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateSnapshot API operation.", Operation = new[] {"CreateSnapshot"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateSnapshotResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Snapshot or Amazon.EC2.Model.CreateSnapshotResponse",
        "This cmdlet returns an Amazon.EC2.Model.Snapshot object.",
        "The service call response (type Amazon.EC2.Model.CreateSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost on which to create a local snapshot.</para><ul><li><para>To create a snapshot of a volume in a Region, omit this parameter. The snapshot is
        /// created in the same Region as the volume.</para></li><li><para>To create a snapshot of a volume on an Outpost and store the snapshot in the Region,
        /// omit this parameter. The snapshot is created in the Region for the Outpost.</para></li><li><para>To create a snapshot of a volume on an Outpost and store the snapshot on an Outpost,
        /// specify the ARN of the destination Outpost. The snapshot must be created on the same
        /// Outpost as the volume.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#create-snapshot">Create
        /// local snapshots from volumes on an Outpost</a> in the <i>Amazon EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the snapshot during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EBS volume.</para>
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
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateSnapshotResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Snapshot (CreateSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateSnapshotResponse, NewEC2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.OutpostArn = this.OutpostArn;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateSnapshotRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.EC2.Model.CreateSnapshotResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateSnapshot(request);
                #elif CORECLR
                return client.CreateSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String OutpostArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateSnapshotResponse, NewEC2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshot;
        }
        
    }
}
