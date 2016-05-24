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
    /// Copies the specified DB snapshot. The source DB snapshot must be in the "available"
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
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the source DB snapshot to the target DB snapshot; otherwise
        /// false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CopyTags")]
        public System.Boolean CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (AWS KMS) key identifier for an encrypted DB snapshot.
        /// The KMS key identifier is the Amazon Resource Name (ARN) or the KMS key alias for
        /// the KMS encryption key.</para><para>If you copy an unencrypted DB snapshot and specify a value for the <code>KmsKeyId</code>
        /// parameter, Amazon RDS encrypts the target DB snapshot using the specified KMS encryption
        /// key.</para><para>If you copy an encrypted DB snapshot from your AWS account, you can specify a value
        /// for <code>KmsKeyId</code> to encrypt the copy with a new KMS encryption key. If you
        /// don't specify a value for <code>KmsKeyId</code> then the copy of the DB snapshot is
        /// encrypted with the same KMS key as the source DB snapshot. </para><para>If you copy an encrypted DB snapshot that is shared from another AWS account, then
        /// you must specify a value for <code>KmsKeyId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the source DB snapshot.</para><para>If you are copying from a shared manual DB snapshot, this must be the ARN of the shared
        /// DB snapshot.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li><li><para>If the source snapshot is in the same region as the copy, specify a valid DB snapshot
        /// identifier.</para></li><li><para>If the source snapshot is in a different region than the copy, specify a valid DB
        /// snapshot ARN. For more information, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopySnapshot.html">
        /// Copying a DB Snapshot</a>.</para></li></ul><para>Example: <code>rds:mydb-2012-04-02-00-01</code></para><para>Example: <code>arn:aws:rds:rr-regn-1:123456789012:snapshot:mysql-instance1-snapshot-20130805</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied snapshot.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank</para></li><li><para>Must contain from 1 to 255 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-db-snapshot</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetDBSnapshotIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KmsKeyId", MyInvocation.BoundParameters);
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
            context.KmsKeyId = this.KmsKeyId;
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
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
            public System.String KmsKeyId { get; set; }
            public System.String SourceDBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetDBSnapshotIdentifier { get; set; }
        }
        
    }
}
