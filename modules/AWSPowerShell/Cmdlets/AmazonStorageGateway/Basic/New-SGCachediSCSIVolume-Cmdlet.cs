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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a cached volume on a specified cached volume gateway. This operation is only
    /// supported in the cached volume gateway type.
    /// 
    ///  <note><para>
    /// Cache storage must be allocated to the gateway before you can create a cached volume.
    /// Use the <a>AddCache</a> operation to add cache storage to a gateway. 
    /// </para></note><para>
    /// In the request, you must specify the gateway, size of the volume in bytes, the iSCSI
    /// target name, an IP address on which to expose the target, and a unique client token.
    /// In response, the gateway creates the volume and returns information about it. This
    /// information includes the volume Amazon Resource Name (ARN), its size, and the iSCSI
    /// target ARN that initiators can use to connect to the volume target.
    /// </para><para>
    /// Optionally, you can provide the ARN for an existing volume as the <code>SourceVolumeARN</code>
    /// for this cached volume, which creates an exact copy of the existing volume’s latest
    /// recovery point. The <code>VolumeSizeInBytes</code> value must be equal to or larger
    /// than the size of the copied volume, in bytes.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SGCachediSCSIVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateCachediSCSIVolume API operation.", Operation = new[] {"CreateCachediSCSIVolume"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGCachediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you use to retry a request. If you retry a request, use the
        /// same <code>ClientToken</code> you specified in the initial request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 5)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>True to use Amazon S3 server side encryption with your own AWS KMS key, or false to
        /// use a key managed by Amazon S3. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key used for Amazon S3 server side encryption.
        /// This value can only be set when KMSEncrypted is true. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KMSKey { get; set; }
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
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot ID (e.g. "snap-1122aabb") of the snapshot to restore as the new cached
        /// volume. Specify this field if you want to create the iSCSI storage volume from a snapshot
        /// otherwise do not include this field. To list snapshots for your account use <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-query-DescribeSnapshots.html">DescribeSnapshots</a>
        /// in the <i>Amazon Elastic Compute Cloud API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter SourceVolumeARN
        /// <summary>
        /// <para>
        /// <para>The ARN for an existing volume. Specifying this ARN makes the new volume into an exact
        /// copy of the specified existing volume's latest recovery point. The <code>VolumeSizeInBytes</code>
        /// value for this new volume must be equal to or larger than the size of the existing
        /// volume, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceVolumeARN { get; set; }
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
        
        #region Parameter VolumeSizeInBytes
        /// <summary>
        /// <para>
        /// <para>The size of the volume in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 VolumeSizeInBytes { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGCachediSCSIVolume (CreateCachediSCSIVolume)"))
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
            
            context.ClientToken = this.ClientToken;
            context.GatewayARN = this.GatewayARN;
            if (ParameterWasBound("KMSEncrypted"))
                context.KMSEncrypted = this.KMSEncrypted;
            context.KMSKey = this.KMSKey;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.SnapshotId = this.SnapshotId;
            context.SourceVolumeARN = this.SourceVolumeARN;
            context.TargetName = this.TargetName;
            if (ParameterWasBound("VolumeSizeInBytes"))
                context.VolumeSizeInBytes = this.VolumeSizeInBytes;
            
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
            var request = new Amazon.StorageGateway.Model.CreateCachediSCSIVolumeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.KMSEncrypted != null)
            {
                request.KMSEncrypted = cmdletContext.KMSEncrypted.Value;
            }
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.SourceVolumeARN != null)
            {
                request.SourceVolumeARN = cmdletContext.SourceVolumeARN;
            }
            if (cmdletContext.TargetName != null)
            {
                request.TargetName = cmdletContext.TargetName;
            }
            if (cmdletContext.VolumeSizeInBytes != null)
            {
                request.VolumeSizeInBytes = cmdletContext.VolumeSizeInBytes.Value;
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
        
        private Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateCachediSCSIVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateCachediSCSIVolume");
            try
            {
                #if DESKTOP
                return client.CreateCachediSCSIVolume(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCachediSCSIVolumeAsync(request);
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
            public System.String ClientToken { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.String SnapshotId { get; set; }
            public System.String SourceVolumeARN { get; set; }
            public System.String TargetName { get; set; }
            public System.Int64? VolumeSizeInBytes { get; set; }
        }
        
    }
}
