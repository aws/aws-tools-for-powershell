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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a snapshot of a block storage disk. You can use snapshots for backups, to
    /// make copies of disks, and to save data before shutting down a Lightsail instance.
    /// 
    ///  
    /// <para>
    /// You can take a snapshot of an attached disk that is in use; however, snapshots only
    /// capture data that has been written to your disk at the time the snapshot command is
    /// issued. This may exclude any data that has been cached by any applications or the
    /// operating system. If you can pause any file systems on the disk long enough to take
    /// a snapshot, your snapshot should be complete. Nevertheless, if you cannot pause all
    /// file writes to the disk, you should unmount the disk from within the Lightsail instance,
    /// issue the create disk snapshot command, and then remount the disk to ensure a consistent
    /// and complete snapshot. You may remount and use your disk while the snapshot status
    /// is pending.
    /// </para><para>
    /// You can also use this operation to create a snapshot of an instance's system volume.
    /// You might want to do this, for example, to recover data from the system volume of
    /// a botched instance or to create a backup of the system volume like you would for a
    /// block storage disk. To create a snapshot of a system volume, just define the <c>instance
    /// name</c> parameter when issuing the snapshot command, and a snapshot of the defined
    /// instance's system volume will be created. After the snapshot is available, you can
    /// create a block storage disk from the snapshot and attach it to a running instance
    /// to access the data on the disk.
    /// </para><para>
    /// The <c>create disk snapshot</c> operation supports tag-based access control via request
    /// tags. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSDiskSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateDiskSnapshot API operation.", Operation = new[] {"CreateDiskSnapshot"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateDiskSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CreateDiskSnapshotResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateDiskSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLSDiskSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiskName
        /// <summary>
        /// <para>
        /// <para>The unique name of the source disk (<c>Disk-Virginia-1</c>).</para><note><para>This parameter cannot be defined together with the <c>instance name</c> parameter.
        /// The <c>disk name</c> and <c>instance name</c> parameters are mutually exclusive.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiskName { get; set; }
        #endregion
        
        #region Parameter DiskSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the destination disk snapshot (<c>my-disk-snapshot</c>) based on the source
        /// disk.</para>
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
        public System.String DiskSnapshotName { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The unique name of the source instance (<c>Amazon_Linux-512MB-Virginia-1</c>). When
        /// this is defined, a snapshot of the instance's system volume is created.</para><note><para>This parameter cannot be defined together with the <c>disk name</c> parameter. The
        /// <c>instance name</c> and <c>disk name</c> parameters are mutually exclusive.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateDiskSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateDiskSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DiskSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSDiskSnapshot (CreateDiskSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateDiskSnapshotResponse, NewLSDiskSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DiskName = this.DiskName;
            context.DiskSnapshotName = this.DiskSnapshotName;
            #if MODULAR
            if (this.DiskSnapshotName == null && ParameterWasBound(nameof(this.DiskSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter DiskSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceName = this.InstanceName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
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
            var request = new Amazon.Lightsail.Model.CreateDiskSnapshotRequest();
            
            if (cmdletContext.DiskName != null)
            {
                request.DiskName = cmdletContext.DiskName;
            }
            if (cmdletContext.DiskSnapshotName != null)
            {
                request.DiskSnapshotName = cmdletContext.DiskSnapshotName;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
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
        
        private Amazon.Lightsail.Model.CreateDiskSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateDiskSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateDiskSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateDiskSnapshot(request);
                #elif CORECLR
                return client.CreateDiskSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String DiskName { get; set; }
            public System.String DiskSnapshotName { get; set; }
            public System.String InstanceName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateDiskSnapshotResponse, NewLSDiskSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
