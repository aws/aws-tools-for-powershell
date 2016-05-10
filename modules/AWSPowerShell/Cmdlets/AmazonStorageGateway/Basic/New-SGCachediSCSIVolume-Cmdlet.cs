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
    /// Creates a cached volume on a specified cached gateway. This operation is supported
    /// only for the gateway-cached volume architecture.
    /// 
    ///  <note><para>
    /// Cache storage must be allocated to the gateway before you can create a cached volume.
    /// Use the <a>AddCache</a> operation to add cache storage to a gateway. 
    /// </para></note><para>
    /// In the request, you must specify the gateway, size of the volume in bytes, the iSCSI
    /// target name, an IP address on which to expose the target, and a unique client token.
    /// In response, AWS Storage Gateway creates the volume and returns information about
    /// it such as the volume Amazon Resource Name (ARN), its size, and the iSCSI target ARN
    /// that initiators can use to connect to the volume target.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SGCachediSCSIVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse")]
    [AWSCmdlet("Invokes the CreateCachediSCSIVolume operation against AWS Storage Gateway.", Operation = new[] {"CreateCachediSCSIVolume"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.CreateCachediSCSIVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSGCachediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 5)]
        public System.String ClientToken { get; set; }
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
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter TargetName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String TargetName { get; set; }
        #endregion
        
        #region Parameter VolumeSizeInBytes
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
            
            context.ClientToken = this.ClientToken;
            context.GatewayARN = this.GatewayARN;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.SnapshotId = this.SnapshotId;
            context.TargetName = this.TargetName;
            if (ParameterWasBound("VolumeSizeInBytes"))
                context.VolumeSizeInBytes = this.VolumeSizeInBytes;
            
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
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
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
                var response = client.CreateCachediSCSIVolume(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String GatewayARN { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.String SnapshotId { get; set; }
            public System.String TargetName { get; set; }
            public System.Int64? VolumeSizeInBytes { get; set; }
        }
        
    }
}
