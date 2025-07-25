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
    /// Creates crash-consistent snapshots of multiple EBS volumes attached to an Amazon EC2
    /// instance. Volumes are chosen by specifying an instance. Each volume attached to the
    /// specified instance will produce one snapshot that is crash-consistent across the instance.
    /// You can include all of the volumes currently attached to the instance, or you can
    /// exclude the root volume or specific data (non-root) volumes from the multi-volume
    /// snapshot set.
    /// 
    ///  
    /// <para>
    /// The location of the source instance determines where you can create the snapshots.
    /// </para><ul><li><para>
    /// If the source instance is in a Region, you must create the snapshots in the same Region
    /// as the instance.
    /// </para></li><li><para>
    /// If the source instance is in a Local Zone, you can create the snapshots in the same
    /// Local Zone or in its parent Amazon Web Services Region.
    /// </para></li><li><para>
    /// If the source instance is on an Outpost, you can create the snapshots on the same
    /// Outpost or in its parent Amazon Web Services Region.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2SnapshotBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.SnapshotInfo")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateSnapshots API operation.", Operation = new[] {"CreateSnapshots"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SnapshotInfo or Amazon.EC2.Model.CreateSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.SnapshotInfo objects.",
        "The service call response (type Amazon.EC2.Model.CreateSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2SnapshotBatchCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CopyTagsFromSource
        /// <summary>
        /// <para>
        /// <para>Copies the tags from the specified volume to corresponding snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CopyTagsFromSource")]
        public Amazon.EC2.CopyTagsFromSource CopyTagsFromSource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description propagated to every snapshot specified by the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter InstanceSpecification_ExcludeBootVolume
        /// <summary>
        /// <para>
        /// <para>Excludes the root volume from being snapshotted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceSpecification_ExcludeBootVolume { get; set; }
        #endregion
        
        #region Parameter InstanceSpecification_ExcludeDataVolumeId
        /// <summary>
        /// <para>
        /// <para>The IDs of the data (non-root) volumes to exclude from the multi-volume snapshot set.
        /// If you specify the ID of the root volume, the request fails. To exclude the root volume,
        /// use <b>ExcludeBootVolume</b>.</para><para>You can specify up to 40 volume IDs per request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceSpecification_ExcludeDataVolumeIds")]
        public System.String[] InstanceSpecification_ExcludeDataVolumeId { get; set; }
        #endregion
        
        #region Parameter InstanceSpecification_InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance to specify which volumes should be snapshotted.</para>
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
        public System.String InstanceSpecification_InstanceId { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <note><para>Only supported for instances in Local Zones. If the source instance is not in a Local
        /// Zone, omit this parameter.</para></note><ul><li><para>To create local snapshots in the same Local Zone as the source instance, specify <c>local</c>.</para></li><li><para>To create regional snapshots in the parent Region of the Local Zone, specify <c>regional</c>
        /// or omit this parameter.</para></li></ul><para>Default value: <c>regional</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SnapshotLocationEnum")]
        public Amazon.EC2.SnapshotLocationEnum Location { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <note><para>Only supported for instances on Outposts. If the source instance is not on an Outpost,
        /// omit this parameter.</para></note><ul><li><para>To create the snapshots on the same Outpost as the source instance, specify the ARN
        /// of that Outpost. The snapshots must be created on the same Outpost as the instance.</para></li><li><para>To create the snapshots in the parent Region of the Outpost, omit this parameter.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#create-snapshot">
        /// Create local snapshots from volumes on an Outpost</a> in the <i>Amazon EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>Tags to apply to every snapshot specified by the instance.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshots";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceSpecification_InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2SnapshotBatch (CreateSnapshots)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateSnapshotsResponse, NewEC2SnapshotBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CopyTagsFromSource = this.CopyTagsFromSource;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.InstanceSpecification_ExcludeBootVolume = this.InstanceSpecification_ExcludeBootVolume;
            if (this.InstanceSpecification_ExcludeDataVolumeId != null)
            {
                context.InstanceSpecification_ExcludeDataVolumeId = new List<System.String>(this.InstanceSpecification_ExcludeDataVolumeId);
            }
            context.InstanceSpecification_InstanceId = this.InstanceSpecification_InstanceId;
            #if MODULAR
            if (this.InstanceSpecification_InstanceId == null && ParameterWasBound(nameof(this.InstanceSpecification_InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceSpecification_InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location = this.Location;
            context.OutpostArn = this.OutpostArn;
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
            var request = new Amazon.EC2.Model.CreateSnapshotsRequest();
            
            if (cmdletContext.CopyTagsFromSource != null)
            {
                request.CopyTagsFromSource = cmdletContext.CopyTagsFromSource;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate InstanceSpecification
            var requestInstanceSpecificationIsNull = true;
            request.InstanceSpecification = new Amazon.EC2.Model.InstanceSpecification();
            System.Boolean? requestInstanceSpecification_instanceSpecification_ExcludeBootVolume = null;
            if (cmdletContext.InstanceSpecification_ExcludeBootVolume != null)
            {
                requestInstanceSpecification_instanceSpecification_ExcludeBootVolume = cmdletContext.InstanceSpecification_ExcludeBootVolume.Value;
            }
            if (requestInstanceSpecification_instanceSpecification_ExcludeBootVolume != null)
            {
                request.InstanceSpecification.ExcludeBootVolume = requestInstanceSpecification_instanceSpecification_ExcludeBootVolume.Value;
                requestInstanceSpecificationIsNull = false;
            }
            List<System.String> requestInstanceSpecification_instanceSpecification_ExcludeDataVolumeId = null;
            if (cmdletContext.InstanceSpecification_ExcludeDataVolumeId != null)
            {
                requestInstanceSpecification_instanceSpecification_ExcludeDataVolumeId = cmdletContext.InstanceSpecification_ExcludeDataVolumeId;
            }
            if (requestInstanceSpecification_instanceSpecification_ExcludeDataVolumeId != null)
            {
                request.InstanceSpecification.ExcludeDataVolumeIds = requestInstanceSpecification_instanceSpecification_ExcludeDataVolumeId;
                requestInstanceSpecificationIsNull = false;
            }
            System.String requestInstanceSpecification_instanceSpecification_InstanceId = null;
            if (cmdletContext.InstanceSpecification_InstanceId != null)
            {
                requestInstanceSpecification_instanceSpecification_InstanceId = cmdletContext.InstanceSpecification_InstanceId;
            }
            if (requestInstanceSpecification_instanceSpecification_InstanceId != null)
            {
                request.InstanceSpecification.InstanceId = requestInstanceSpecification_instanceSpecification_InstanceId;
                requestInstanceSpecificationIsNull = false;
            }
             // determine if request.InstanceSpecification should be set to null
            if (requestInstanceSpecificationIsNull)
            {
                request.InstanceSpecification = null;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
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
        
        private Amazon.EC2.Model.CreateSnapshotsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateSnapshots");
            try
            {
                return client.CreateSnapshotsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.CopyTagsFromSource CopyTagsFromSource { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? InstanceSpecification_ExcludeBootVolume { get; set; }
            public List<System.String> InstanceSpecification_ExcludeDataVolumeId { get; set; }
            public System.String InstanceSpecification_InstanceId { get; set; }
            public Amazon.EC2.SnapshotLocationEnum Location { get; set; }
            public System.String OutpostArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateSnapshotsResponse, NewEC2SnapshotBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
