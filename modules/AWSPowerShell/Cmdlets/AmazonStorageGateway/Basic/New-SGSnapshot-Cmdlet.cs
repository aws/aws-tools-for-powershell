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
    /// Initiates a snapshot of a volume.
    /// 
    ///  
    /// <para>
    /// AWS Storage Gateway provides the ability to back up point-in-time snapshots of your
    /// data to Amazon Simple Storage (S3) for durable off-site recovery, as well as import
    /// the data to an Amazon Elastic Block Store (EBS) volume in Amazon Elastic Compute Cloud
    /// (EC2). You can take snapshots of your gateway volume on a scheduled or ad-hoc basis.
    /// This API enables you to take ad-hoc snapshot. For more information, see <a href="http://docs.aws.amazon.com/storagegateway/latest/userguide/WorkingWithSnapshots.html">Working
    /// With Snapshots in the AWS Storage Gateway Console</a>.
    /// </para><para>
    /// In the CreateSnapshot request you identify the volume by providing its Amazon Resource
    /// Name (ARN). You must also provide description for the snapshot. When AWS Storage Gateway
    /// takes the snapshot of specified volume, the snapshot and description appears in the
    /// AWS Storage Gateway Console. In response, AWS Storage Gateway returns you a snapshot
    /// ID. You can use this snapshot ID to check the snapshot progress or later use it when
    /// you want to create a volume from a snapshot. This operation is only supported in stored
    /// and cached volumes gateways.
    /// </para><note><para>
    /// To list or delete a snapshot, you must use the Amazon EC2 API. For more information,
    /// see DescribeSnapshots or DeleteSnapshot in the <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_Operations.html">EC2
    /// API reference</a>.
    /// </para></note><important><para>
    /// Volume and snapshot IDs are changing to a longer length ID format. For more information,
    /// see the important note on the <a href="http://docs.aws.amazon.com/storagegateway/latest/APIReference/Welcome.html">Welcome</a>
    /// page.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SGSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateSnapshotResponse")]
    [AWSCmdlet("Invokes the CreateSnapshot operation against AWS Storage Gateway.", Operation = new[] {"CreateSnapshot"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateSnapshotResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.CreateSnapshotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGSnapshotCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter SnapshotDescription
        /// <summary>
        /// <para>
        /// <para>Textual description of the snapshot that appears in the Amazon EC2 console, Elastic
        /// Block Store snapshots panel in the <b>Description</b> field, and in the AWS Storage
        /// Gateway snapshot <b>Details</b> pane, <b>Description</b> field</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SnapshotDescription { get; set; }
        #endregion
        
        #region Parameter VolumeARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the volume. Use the <a>ListVolumes</a> operation
        /// to return a list of gateway volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VolumeARN { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VolumeARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGSnapshot (CreateSnapshot)"))
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
            
            context.SnapshotDescription = this.SnapshotDescription;
            context.VolumeARN = this.VolumeARN;
            
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
            var request = new Amazon.StorageGateway.Model.CreateSnapshotRequest();
            
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
        
        private static Amazon.StorageGateway.Model.CreateSnapshotResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateSnapshotRequest request)
        {
            #if DESKTOP
            return client.CreateSnapshot(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateSnapshotAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String SnapshotDescription { get; set; }
            public System.String VolumeARN { get; set; }
        }
        
    }
}
