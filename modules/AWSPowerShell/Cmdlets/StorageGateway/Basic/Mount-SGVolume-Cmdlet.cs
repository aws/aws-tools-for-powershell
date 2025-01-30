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
    /// Connects a volume to an iSCSI connection and then attaches the volume to the specified
    /// gateway. Detaching and attaching a volume enables you to recover your data from one
    /// gateway to a different gateway without creating a snapshot. It also makes it easier
    /// to move your volumes from an on-premises gateway to a gateway hosted on an Amazon
    /// EC2 instance.
    /// </summary>
    [Cmdlet("Mount", "SGVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.AttachVolumeResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway AttachVolume API operation.", Operation = new[] {"AttachVolume"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.AttachVolumeResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.AttachVolumeResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.AttachVolumeResponse object containing multiple properties."
    )]
    public partial class MountSGVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiskId
        /// <summary>
        /// <para>
        /// <para>The unique device ID or other distinguishing data that identifies the local disk used
        /// to create the volume. This value is only required when you are attaching a stored
        /// volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiskId { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway that you want to attach the volume to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The network interface of the gateway on which to expose the iSCSI target. Only IPv4
        /// addresses are accepted. Use <a>DescribeGatewayInformation</a> to get a list of the
        /// network interfaces available on a gateway.</para><para>Valid Values: A valid IP address.</para>
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
        public System.String NetworkInterfaceId { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetName { get; set; }
        #endregion
        
        #region Parameter VolumeARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the volume to attach to the specified gateway.</para>
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
        public System.String VolumeARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.AttachVolumeResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.AttachVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Mount-SGVolume (AttachVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.AttachVolumeResponse, MountSGVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DiskId = this.DiskId;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetName = this.TargetName;
            context.VolumeARN = this.VolumeARN;
            #if MODULAR
            if (this.VolumeARN == null && ParameterWasBound(nameof(this.VolumeARN)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.AttachVolumeRequest();
            
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
            if (cmdletContext.TargetName != null)
            {
                request.TargetName = cmdletContext.TargetName;
            }
            if (cmdletContext.VolumeARN != null)
            {
                request.VolumeARN = cmdletContext.VolumeARN;
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
        
        private Amazon.StorageGateway.Model.AttachVolumeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.AttachVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "AttachVolume");
            try
            {
                #if DESKTOP
                return client.AttachVolume(request);
                #elif CORECLR
                return client.AttachVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String TargetName { get; set; }
            public System.String VolumeARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.AttachVolumeResponse, MountSGVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
