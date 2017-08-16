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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a volume on a specified gateway. This operation is only supported in the stored
    /// volume gateway architecture.
    /// 
    ///  
    /// <para>
    /// The size of the volume to create is inferred from the disk size. You can choose to
    /// preserve existing data on the disk, create volume from an existing snapshot, or create
    /// an empty volume. If you choose to create an empty gateway volume, then any existing
    /// data on the disk is erased.
    /// </para><para>
    /// In the request you must specify the gateway and the disk information on which you
    /// are creating the volume. In response, the gateway creates the volume and returns volume
    /// information such as the volume Amazon Resource Name (ARN), its size, and the iSCSI
    /// target ARN that initiators can use to connect to the volume target.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SGStorediSCSIVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse")]
    [AWSCmdlet("Invokes the CreateStorediSCSIVolume operation against AWS Storage Gateway.", Operation = new[] {"CreateStorediSCSIVolume"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGStorediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter DiskId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the gateway local disk that is configured as a stored volume.
        /// Use <a href="http://docs.aws.amazon.com/storagegateway/latest/userguide/API_ListLocalDisks.html">ListLocalDisks</a>
        /// to list disk IDs for a gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiskId { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The network interface of the gateway on which to expose the iSCSI target. Only IPv4
        /// addresses are accepted. Use <a>DescribeGatewayInformation</a> to get a list of the
        /// network interfaces available on a gateway.</para><para> Valid Values: A valid IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PreserveExistingData
        /// <summary>
        /// <para>
        /// <para>Specify this field as true if you want to preserve the data on the local disk. Otherwise,
        /// specifying this field as false creates an empty volume.</para><para> Valid Values: true, false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PreserveExistingData { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot ID (e.g. "snap-1122aabb") of the snapshot to restore as the new stored
        /// volume. Specify this field if you want to create the iSCSI storage volume from a snapshot
        /// otherwise do not include this field. To list snapshots for your account use <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-query-DescribeSnapshots.html">DescribeSnapshots</a>
        /// in the <i>Amazon Elastic Compute Cloud API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter TargetName
        /// <summary>
        /// <para>
        /// <para>The name of the iSCSI target used by initiators to connect to the target and as a
        /// suffix for the target ARN. For example, specifying <code>TargetName</code> as <i>myvolume</i>
        /// results in the target ARN of arn:aws:storagegateway:us-east-2:111122223333:gateway/sgw-12A3456B/target/iqn.1997-05.com.amazon:myvolume.
        /// The target name must be unique across all volumes of a gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String TargetName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGStorediSCSIVolume (CreateStorediSCSIVolume)"))
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
            
            context.DiskId = this.DiskId;
            context.GatewayARN = this.GatewayARN;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            if (ParameterWasBound("PreserveExistingData"))
                context.PreserveExistingData = this.PreserveExistingData;
            context.SnapshotId = this.SnapshotId;
            context.TargetName = this.TargetName;
            
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
            var request = new Amazon.StorageGateway.Model.CreateStorediSCSIVolumeRequest();
            
            if (cmdletContext.DiskId != null)
            {
                request.DiskId = cmdletContext.DiskId;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.PreserveExistingData != null)
            {
                request.PreserveExistingData = cmdletContext.PreserveExistingData.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.TargetName != null)
            {
                request.TargetName = cmdletContext.TargetName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateStorediSCSIVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateStorediSCSIVolume");
            try
            {
                #if DESKTOP
                return client.CreateStorediSCSIVolume(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateStorediSCSIVolumeAsync(request);
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
            public System.String DiskId { get; set; }
            public System.String GatewayARN { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Boolean? PreserveExistingData { get; set; }
            public System.String SnapshotId { get; set; }
            public System.String TargetName { get; set; }
        }
        
    }
}
