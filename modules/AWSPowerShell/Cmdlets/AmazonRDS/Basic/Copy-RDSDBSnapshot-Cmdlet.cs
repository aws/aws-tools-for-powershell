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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Copies the specified DBSnapshot. The source DB snapshot must be in the "available"
    /// state. 
    /// 
    ///  
    /// <para>
    /// If you are copying from a shared manual DB snapshot, the <code>SourceDBSnapshotIdentifier</code>
    /// must be the ARN of the shared DB snapshot.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "RDSDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Invokes the CopyDBSnapshot operation against Amazon Relational Database Service.", Operation = new[] {"CopyDBSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot",
        "This cmdlet returns a DBSnapshot object.",
        "The service call response (type Amazon.RDS.Model.CopyDBSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the source DB snapshot to the target DB snapshot; otherwise
        /// false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CopyTags")]
        public System.Boolean CopyTag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier for the source DB snapshot. </para><para>If you are copying from a shared manual DB snapshot, this must be the ARN of the shared
        /// DB snapshot.</para><para>Constraints:</para><ul><li>Must specify a valid system snapshot in the "available" state.</li><li>If
        /// the source snapshot is in the same region as the copy, specify a valid DB snapshot
        /// identifier.</li><li>If the source snapshot is in a different region than the copy,
        /// specify a valid DB snapshot ARN. For more information, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopySnapshot.html">
        /// Copying a DB Snapshot</a>.</li></ul><para>Example: <code>rds:mydb-2012-04-02-00-01</code></para><para>Example: <code>arn:aws:rds:rr-regn-1:123456789012:snapshot:mysql-instance1-snapshot-20130805</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBSnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier for the copied snapshot. </para><para>Constraints:</para><ul><li>Cannot be null, empty, or blank</li><li>Must contain from 1 to 255 alphanumeric
        /// characters or hyphens</li><li>First character must be a letter</li><li>Cannot end
        /// with a hyphen or contain two consecutive hyphens</li></ul><para>Example: <code>my-db-snapshot</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetDBSnapshotIdentifier { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceDBSnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBSnapshot (CopyDBSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("CopyTag"))
                context.CopyTags = this.CopyTag;
            context.SourceDBSnapshotIdentifier = this.SourceDBSnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBSnapshotIdentifier = this.TargetDBSnapshotIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.CopyDBSnapshotRequest();
            
            if (cmdletContext.CopyTags != null)
            {
                request.CopyTags = cmdletContext.CopyTags.Value;
            }
            if (cmdletContext.SourceDBSnapshotIdentifier != null)
            {
                request.SourceDBSnapshotIdentifier = cmdletContext.SourceDBSnapshotIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetDBSnapshotIdentifier != null)
            {
                request.TargetDBSnapshotIdentifier = cmdletContext.TargetDBSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CopyDBSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBSnapshot;
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
            public System.Boolean? CopyTags { get; set; }
            public System.String SourceDBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetDBSnapshotIdentifier { get; set; }
        }
        
    }
}
