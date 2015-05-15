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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Copies a point-in-time snapshot of an EBS volume and stores it in Amazon S3. You can
    /// copy the snapshot within the same region or from one region to another. You can use
    /// the snapshot to create EBS volumes or Amazon Machine Images (AMIs). The snapshot is
    /// copied to the regional endpoint that you send the HTTP request to.
    /// 
    ///  
    /// <para>
    /// Copies of encrypted EBS snapshots remain encrypted. Copies of unencrypted snapshots
    /// remain unencrypted.
    /// </para><note><para>
    /// Copying snapshots that were encrypted with non-default AWS Key Management Service
    /// (KMS) master keys is not supported at this time. 
    /// </para></note><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-copy-snapshot.html">Copying
    /// an Amazon EBS Snapshot</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CopySnapshot operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CopySnapshot"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CopySnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A description for the EBS snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The destination region to use in the <code>PresignedUrl</code> parameter of a snapshot
        /// copy operation. This parameter is only valid for specifying the destination region
        /// in a <code>PresignedUrl</code> parameter, where it is required.</para><note><para><code>CopySnapshot</code> sends the snapshot copy to the regional endpoint that you
        /// send the HTTP request to, such as <code>ec2.us-east-1.amazonaws.com</code> (in the
        /// AWS CLI, this is specified with the <code>--region</code> parameter or the default
        /// region in your AWS configuration file).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DestinationRegion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the region that contains the snapshot to be copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String SourceRegion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the EBS snapshot to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String SourceSnapshotId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceSnapshotId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Snapshot (CopySnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.DestinationRegion = this.DestinationRegion;
            context.SourceRegion = this.SourceRegion;
            context.SourceSnapshotId = this.SourceSnapshotId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CopySnapshotRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationRegion != null)
            {
                request.DestinationRegion = cmdletContext.DestinationRegion;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.SourceSnapshotId != null)
            {
                request.SourceSnapshotId = cmdletContext.SourceSnapshotId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CopySnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SnapshotId;
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
            public String Description { get; set; }
            public String DestinationRegion { get; set; }
            public String SourceRegion { get; set; }
            public String SourceSnapshotId { get; set; }
        }
        
    }
}
