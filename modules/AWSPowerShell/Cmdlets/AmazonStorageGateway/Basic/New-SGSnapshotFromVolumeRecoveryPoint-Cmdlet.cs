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
    /// This operation initiates a snapshot of a gateway from a volume recovery point. This
    /// operation is supported only for the gateway-cached volume architecture (see ).
    /// 
    ///  
    /// <para>
    /// A volume recovery point is a point in time at which all data of the volume is consistent
    /// and from which you can create a snapshot. To get a list of volume recovery point for
    /// gateway-cached volumes, use <a>ListVolumeRecoveryPoints</a>.
    /// </para><para>
    /// In the <code>CreateSnapshotFromVolumeRecoveryPoint</code> request, you identify the
    /// volume by providing its Amazon Resource Name (ARN). You must also provide a description
    /// for the snapshot. When AWS Storage Gateway takes a snapshot of the specified volume,
    /// the snapshot and its description appear in the AWS Storage Gateway console. In response,
    /// AWS Storage Gateway returns you a snapshot ID. You can use this snapshot ID to check
    /// the snapshot progress or later use it when you want to create a volume from a snapshot.
    /// </para><note><para>
    /// To list or delete a snapshot, you must use the Amazon EC2 API. For more information,
    /// in <i>Amazon Elastic Compute Cloud API Reference</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SGSnapshotFromVolumeRecoveryPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse")]
    [AWSCmdlet("Invokes the CreateSnapshotFromVolumeRecoveryPoint operation against AWS Storage Gateway.", Operation = new[] {"CreateSnapshotFromVolumeRecoveryPoint"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSGSnapshotFromVolumeRecoveryPointCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SnapshotDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VolumeARN { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VolumeARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGSnapshotFromVolumeRecoveryPoint (CreateSnapshotFromVolumeRecoveryPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SnapshotDescription = this.SnapshotDescription;
            context.VolumeARN = this.VolumeARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointRequest();
            
            if (cmdletContext.SnapshotDescription != null)
            {
                request.SnapshotDescription = cmdletContext.SnapshotDescription;
            }
            if (cmdletContext.VolumeARN != null)
            {
                request.VolumeARN = cmdletContext.VolumeARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateSnapshotFromVolumeRecoveryPoint(request);
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
            public System.String SnapshotDescription { get; set; }
            public System.String VolumeARN { get; set; }
        }
        
    }
}
