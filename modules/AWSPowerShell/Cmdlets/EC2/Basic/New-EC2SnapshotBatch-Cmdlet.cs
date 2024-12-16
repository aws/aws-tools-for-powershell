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
    /// Creates crash-consistent snapshots of multiple EBS volumes and stores the data in
    /// S3. Volumes are chosen by specifying an instance. Any attached volumes will produce
    /// one snapshot each that is crash-consistent across the instance.
    /// 
    ///  
    /// <para>
    /// You can include all of the volumes currently attached to the instance, or you can
    /// exclude the root volume or specific data (non-root) volumes from the multi-volume
    /// snapshot set.
    /// </para><para>
    /// You can create multi-volume snapshots of instances in a Region and instances on an
    /// Outpost. If you create snapshots from an instance in a Region, the snapshots must
    /// be stored in the same Region as the instance. If you create snapshots from an instance
    /// on an Outpost, the snapshots can be stored on the same Outpost as the instance, or
    /// in the Region for that Outpost.
    /// </para>
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
        /// use <b>ExcludeBootVolume</b>.</para><para>You can specify up to 40 volume IDs per request.</para>
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
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost on which to create the local snapshots.</para><ul><li><para>To create snapshots from an instance in a Region, omit this parameter. The snapshots
        /// are created in the same Region as the instance.</para></li><li><para>To create snapshots from an instance on an Outpost and store the snapshots in the
        /// Region, omit this parameter. The snapshots are created in the Region for the Outpost.</para></li><li><para>To create snapshots from an instance on an Outpost and store the snapshots on an Outpost,
        /// specify the ARN of the destination Outpost. The snapshots must be created on the same
        /// Outpost as the instance.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#create-multivol-snapshot">
        /// Create multi-volume local snapshots from instances on an Outpost</a> in the <i>Amazon
        /// EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>Tags to apply to every snapshot specified by the instance.</para>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
                #if DESKTOP
                return client.CreateSnapshots(request);
                #elif CORECLR
                return client.CreateSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.CopyTagsFromSource CopyTagsFromSource { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? InstanceSpecification_ExcludeBootVolume { get; set; }
            public List<System.String> InstanceSpecification_ExcludeDataVolumeId { get; set; }
            public System.String InstanceSpecification_InstanceId { get; set; }
            public System.String OutpostArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateSnapshotsResponse, NewEC2SnapshotBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
