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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a SnapMirror policy for an Amazon FSx for NetApp ONTAP file system or storage
    /// virtual machine (SVM). A SnapMirror policy defines how the SnapMirror relationships
    /// that use the policy replicate data, including which snapshots to transfer, the maximum
    /// number of snapshots to retain on the destination volume, and when to transfer data.
    /// 
    ///  
    /// <para>
    /// The <c>CreateSnapmirrorPolicy</c> operation returns while the SnapMirror policy's
    /// lifecycle state is still <c>CREATING</c>. You can check the SnapMirror policy creation
    /// status by calling the DescribeSnapmirrorPolicies operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXSnapmirrorPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.SnapmirrorPolicy")]
    [AWSCmdlet("Calls the Amazon FSx CreateSnapmirrorPolicy API operation.", Operation = new[] {"CreateSnapmirrorPolicy"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateSnapmirrorPolicyResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.SnapmirrorPolicy or Amazon.FSx.Model.CreateSnapmirrorPolicyResponse",
        "This cmdlet returns an Amazon.FSx.Model.SnapmirrorPolicy object.",
        "The service call response (type Amazon.FSx.Model.CreateSnapmirrorPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXSnapmirrorPolicyCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the Amazon FSx for NetApp ONTAP file system on which to create
        /// the SnapMirror policy. You must specify either a <c>FileSystemId</c> or a <c>StorageVirtualMachineId</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the SnapMirror policy.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkCompressionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether SnapMirror compresses data when it transfers the data over the network.
        /// This value defaults to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkCompressionEnabled { get; set; }
        #endregion
        
        #region Parameter RetentionRule
        /// <summary>
        /// <para>
        /// <para>Specifies the rules that determine which snapshots SnapMirror retains on the destination
        /// volume, based on their SnapMirror labels.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionRules")]
        public Amazon.FSx.Model.SnapmirrorPolicyRetentionRule[] RetentionRule { get; set; }
        #endregion
        
        #region Parameter SnapshotCopyMode
        /// <summary>
        /// <para>
        /// <para>Specifies which snapshots SnapMirror transfers to the destination volume:</para><ul><li><para><c>COPY_ALL_SOURCE_SNAPSHOTS</c> – SnapMirror copies all snapshots of the source
        /// volume to the destination volume on a transfer. You can't specify <c>RetentionRules</c>
        /// along with this property.</para></li><li><para><c>COPY_LATEST_SOURCE_SNAPSHOT</c> – SnapMirror copies the latest snapshot of the
        /// source volume to the destination volume on a transfer. You can't specify <c>RetentionRules</c>
        /// along with this property.</para></li><li><para><c>NO_CREATE_SNAPSHOT_ON_SOURCE</c> – SnapMirror doesn't create a snapshot on the
        /// source volume at beginning of an update or resync operation. You must specify <c>RetentionRules</c>
        /// along with this property.</para></li></ul><para>If you don't specify a <c>SnapshotCopyMode</c>, SnapMirror creates a new snapshot
        /// of the source volume and copies it, along with any snapshots that match <c>RetentionRules</c>,
        /// to the destination volume on a transfer. <c>RetentionRules</c> is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SnapmirrorPolicySnapshotCopyMode")]
        public Amazon.FSx.SnapmirrorPolicySnapshotCopyMode SnapshotCopyMode { get; set; }
        #endregion
        
        #region Parameter StorageVirtualMachineId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the SVM on which to create the SnapMirror policy. You must specify
        /// either a <c>FileSystemId</c> or a <c>StorageVirtualMachineId</c>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageVirtualMachineId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThrottleInKbp
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum bandwidth, in kilobytes per second (KBps), that SnapMirror uses
        /// to transfer data. A value of <c>0</c> means that the bandwidth is unlimited.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThrottleInKbps")]
        public System.Int64? ThrottleInKbp { get; set; }
        #endregion
        
        #region Parameter TransferSchedule
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the ONTAP schedule that determines when SnapMirror transfers
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransferSchedule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapmirrorPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateSnapmirrorPolicyResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateSnapmirrorPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapmirrorPolicy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXSnapmirrorPolicy (CreateSnapmirrorPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateSnapmirrorPolicyResponse, NewFSXSnapmirrorPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkCompressionEnabled = this.NetworkCompressionEnabled;
            if (this.RetentionRule != null)
            {
                context.RetentionRule = new List<Amazon.FSx.Model.SnapmirrorPolicyRetentionRule>(this.RetentionRule);
            }
            context.SnapshotCopyMode = this.SnapshotCopyMode;
            context.StorageVirtualMachineId = this.StorageVirtualMachineId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.ThrottleInKbp = this.ThrottleInKbp;
            context.TransferSchedule = this.TransferSchedule;
            
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
            var request = new Amazon.FSx.Model.CreateSnapmirrorPolicyRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkCompressionEnabled != null)
            {
                request.NetworkCompressionEnabled = cmdletContext.NetworkCompressionEnabled.Value;
            }
            if (cmdletContext.RetentionRule != null)
            {
                request.RetentionRules = cmdletContext.RetentionRule;
            }
            if (cmdletContext.SnapshotCopyMode != null)
            {
                request.SnapshotCopyMode = cmdletContext.SnapshotCopyMode;
            }
            if (cmdletContext.StorageVirtualMachineId != null)
            {
                request.StorageVirtualMachineId = cmdletContext.StorageVirtualMachineId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThrottleInKbp != null)
            {
                request.ThrottleInKbps = cmdletContext.ThrottleInKbp.Value;
            }
            if (cmdletContext.TransferSchedule != null)
            {
                request.TransferSchedule = cmdletContext.TransferSchedule;
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
        
        private Amazon.FSx.Model.CreateSnapmirrorPolicyResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateSnapmirrorPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateSnapmirrorPolicy");
            try
            {
                return client.CreateSnapmirrorPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? NetworkCompressionEnabled { get; set; }
            public List<Amazon.FSx.Model.SnapmirrorPolicyRetentionRule> RetentionRule { get; set; }
            public Amazon.FSx.SnapmirrorPolicySnapshotCopyMode SnapshotCopyMode { get; set; }
            public System.String StorageVirtualMachineId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Int64? ThrottleInKbp { get; set; }
            public System.String TransferSchedule { get; set; }
            public System.Func<Amazon.FSx.Model.CreateSnapmirrorPolicyResponse, NewFSXSnapmirrorPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapmirrorPolicy;
        }
        
    }
}
