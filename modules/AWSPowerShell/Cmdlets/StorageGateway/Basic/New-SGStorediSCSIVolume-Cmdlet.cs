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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a volume on a specified gateway. This operation is only supported in the stored
    /// volume gateway type.
    /// 
    ///  
    /// <para>
    /// The size of the volume to create is inferred from the disk size. You can choose to
    /// preserve existing data on the disk, create volume from an existing snapshot, or create
    /// an empty volume. If you choose to create an empty gateway volume, then any existing
    /// data on the disk is erased.
    /// </para><para>
    /// In the request, you must specify the gateway and the disk information on which you
    /// are creating the volume. In response, the gateway creates the volume and returns volume
    /// information such as the volume Amazon Resource Name (ARN), its size, and the iSCSI
    /// target ARN that initiators can use to connect to the volume target.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SGStorediSCSIVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateStorediSCSIVolume API operation.", Operation = new[] {"CreateStorediSCSIVolume"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse object containing multiple properties."
    )]
    public partial class NewSGStorediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiskId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the gateway local disk that is configured as a stored volume.
        /// Use <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/API_ListLocalDisks.html">ListLocalDisks</a>
        /// to list disk IDs for a gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DiskId { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to use Amazon S3 server-side encryption with your own KMS key,
        /// or <c>false</c> to use a key managed by Amazon S3. Optional.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a symmetric customer master key (CMK) used for Amazon
        /// S3 server-side encryption. Storage Gateway does not support asymmetric CMKs. This
        /// value can only be set when <c>KMSEncrypted</c> is <c>true</c>. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The network interface of the gateway on which to expose the iSCSI target. Accepts
        /// IPv4 and IPv6 addresses. Use <a>DescribeGatewayInformation</a> to get a list of the
        /// network interfaces available on a gateway.</para><para>Valid Values: A valid IP address.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PreserveExistingData
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> if you want to preserve the data on the local disk. Otherwise,
        /// set to <c>false</c> to create an empty volume.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? PreserveExistingData { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot ID (e.g., "snap-1122aabb") of the snapshot to restore as the new stored
        /// volume. Specify this field if you want to create the iSCSI storage volume from a snapshot;
        /// otherwise, do not include this field. To list snapshots for your account use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-query-DescribeSnapshots.html">DescribeSnapshots</a>
        /// in the <i>Amazon Elastic Compute Cloud API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to a stored volume. Each tag is a key-value
        /// pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetName
        /// <summary>
        /// <para>
        /// <para>The name of the iSCSI target used by an initiator to connect to a volume and used
        /// as a suffix for the target ARN. For example, specifying <c>TargetName</c> as <i>myvolume</i>
        /// results in the target ARN of <c>arn:aws:storagegateway:us-east-2:111122223333:gateway/sgw-12A3456B/target/iqn.1997-05.com.amazon:myvolume</c>.
        /// The target name must be unique across all volumes on a gateway.</para><para>If you don't specify a value, Storage Gateway uses the value that was previously used
        /// for this volume as the new target name.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGStorediSCSIVolume (CreateStorediSCSIVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse, NewSGStorediSCSIVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DiskId = this.DiskId;
            #if MODULAR
            if (this.DiskId == null && ParameterWasBound(nameof(this.DiskId)))
            {
                WriteWarning("You are passing $null as a value for parameter DiskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KMSEncrypted = this.KMSEncrypted;
            context.KMSKey = this.KMSKey;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PreserveExistingData = this.PreserveExistingData;
            #if MODULAR
            if (this.PreserveExistingData == null && ParameterWasBound(nameof(this.PreserveExistingData)))
            {
                WriteWarning("You are passing $null as a value for parameter PreserveExistingData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotId = this.SnapshotId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            context.TargetName = this.TargetName;
            #if MODULAR
            if (this.TargetName == null && ParameterWasBound(nameof(this.TargetName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.CreateStorediSCSIVolumeRequest();
            
            if (cmdletContext.DiskId != null)
            {
                request.DiskId = cmdletContext.DiskId;
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
            if (cmdletContext.PreserveExistingData != null)
            {
                request.PreserveExistingData = cmdletContext.PreserveExistingData.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetName != null)
            {
                request.TargetName = cmdletContext.TargetName;
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
        
        private Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateStorediSCSIVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateStorediSCSIVolume");
            try
            {
                #if DESKTOP
                return client.CreateStorediSCSIVolume(request);
                #elif CORECLR
                return client.CreateStorediSCSIVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Boolean? PreserveExistingData { get; set; }
            public System.String SnapshotId { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.String TargetName { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateStorediSCSIVolumeResponse, NewSGStorediSCSIVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
