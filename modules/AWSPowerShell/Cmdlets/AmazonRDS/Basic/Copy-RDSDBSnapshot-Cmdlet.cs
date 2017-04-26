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
    /// To copy a DB snapshot from a shared manual DB snapshot, <code>SourceDBSnapshotIdentifier</code>
    /// must be the Amazon Resource Name (ARN) of the shared DB snapshot.
    /// </para><para>
    /// You can copy an encrypted DB snapshot from another AWS region. In that case, the region
    /// where you call the <code>CopyDBSnapshot</code> action is the destination region for
    /// the encrypted DB snapshot to be copied to. To copy an encrypted DB snapshot from another
    /// region, you must provide the following values:
    /// </para><ul><li><para><code>KmsKeyId</code> - The AWS Key Management System (KMS) key identifier for the
    /// key to use to encrypt the copy of the DB snapshot in the destination region.
    /// </para></li><li><para><code>PreSignedUrl</code> - A URL that contains a Signature Version 4 signed request
    /// for the <code>CopyDBSnapshot</code> action to be called in the source region where
    /// the DB snapshot will be copied from. The presigned URL must be a valid request for
    /// the <code>CopyDBSnapshot</code> API action that can be executed in the source region
    /// that contains the encrypted DB snapshot to be copied.
    /// </para><para>
    /// The presigned URL request must contain the following parameter values:
    /// </para><ul><li><para><code>DestinationRegion</code> - The AWS Region that the encrypted DB snapshot will
    /// be copied to. This region is the same one where the <code>CopyDBSnapshot</code> action
    /// is called that contains this presigned URL. 
    /// </para><para>
    /// For example, if you copy an encrypted DB snapshot from the us-west-2 region to the
    /// us-east-1 region, then you will call the <code>CopyDBSnapshot</code> action in the
    /// us-east-1 region and provide a presigned URL that contains a call to the <code>CopyDBSnapshot</code>
    /// action in the us-west-2 region. For this example, the <code>DestinationRegion</code>
    /// in the presigned URL must be set to the us-east-1 region.
    /// </para></li><li><para><code>KmsKeyId</code> - The KMS key identifier for the key to use to encrypt the
    /// copy of the DB snapshot in the destination region. This identifier is the same for
    /// both the <code>CopyDBSnapshot</code> action that is called in the destination region,
    /// and the action contained in the presigned URL.
    /// </para></li><li><para><code>SourceDBSnapshotIdentifier</code> - The DB snapshot identifier for the encrypted
    /// snapshot to be copied. This identifier must be in the Amazon Resource Name (ARN) format
    /// for the source region. For example, if you copy an encrypted DB snapshot from the
    /// us-west-2 region, then your <code>SourceDBSnapshotIdentifier</code> looks like this
    /// example: <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20161115</code>.
    /// </para></li></ul><para>
    /// To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
    /// Authenticating Requests: Using Query Parameters (AWS Signature Version 4)</a> and
    /// <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html"> Signature
    /// Version 4 Signing Process</a>.
    /// </para></li><li><para><code>TargetDBSnapshotIdentifier</code> - The identifier for the new copy of the
    /// DB snapshot in the destination region.
    /// </para></li><li><para><code>SourceDBSnapshotIdentifier</code> - The DB snapshot identifier for the encrypted
    /// snapshot to be copied. This identifier must be in the ARN format for the source region
    /// and is the same value as the <code>SourceDBSnapshotIdentifier</code> in the presigned
    /// URL. 
    /// </para></li></ul><para>
    /// For more information on copying encrypted snapshots from one region to another, see
    /// <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopySnapshot.html#USER_CopyDBSnapshot">
    /// Copying a DB Snapshot</a> in the Amazon RDS User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "RDSDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Invokes the CopyDBSnapshot operation against Amazon Relational Database Service.", Operation = new[] {"CopyDBSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot",
        "This cmdlet returns a DBSnapshot object.",
        "The service call response (type Amazon.RDS.Model.CopyDBSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
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
        /// <para>The AWS KMS key ID for an encrypted DB snapshot. The KMS key ID is the Amazon Resource
        /// Name (ARN), KMS key identifier, or the KMS key alias for the KMS encryption key. </para><para>If you copy an unencrypted DB snapshot and specify a value for the <code>KmsKeyId</code>
        /// parameter, Amazon RDS encrypts the target DB snapshot using the specified KMS encryption
        /// key. </para><para>If you copy an encrypted DB snapshot from your AWS account, you can specify a value
        /// for <code>KmsKeyId</code> to encrypt the copy with a new KMS encryption key. If you
        /// don't specify a value for <code>KmsKeyId</code>, then the copy of the DB snapshot
        /// is encrypted with the same KMS key as the source DB snapshot. </para><para>If you copy an encrypted snapshot to a different AWS region, then you must specify
        /// a KMS key for the destination AWS region.</para><para>If you copy an encrypted DB snapshot that is shared from another AWS account, then
        /// you must specify a value for <code>KmsKeyId</code>. </para><para>To copy an encrypted DB snapshot to another region, you must set <code>KmsKeyId</code>
        /// to the KMS key ID used to encrypt the copy of the DB snapshot in the destination region.
        /// KMS encryption keys are specific to the region that they are created in, and you cannot
        /// use encryption keys from one region in another region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the <code>CopyDBSnapshot</code>
        /// API action in the AWS region that contains the source DB snapshot to copy. The <code>PreSignedUrl</code>
        /// parameter must be used when copying an encrypted DB snapshot from another AWS region.</para><para>The presigned URL must be a valid request for the <code>CopyDBSnapshot</code> API
        /// action that can be executed in the source region that contains the encrypted DB snapshot
        /// to be copied. The presigned URL request must contain the following parameter values:</para><ul><li><para><code>DestinationRegion</code> - The AWS Region that the encrypted DB snapshot will
        /// be copied to. This region is the same one where the <code>CopyDBSnapshot</code> action
        /// is called that contains this presigned URL. </para><para>For example, if you copy an encrypted DB snapshot from the us-west-2 region to the
        /// us-east-1 region, then you will call the <code>CopyDBSnapshot</code> action in the
        /// us-east-1 region and provide a presigned URL that contains a call to the <code>CopyDBSnapshot</code>
        /// action in the us-west-2 region. For this example, the <code>DestinationRegion</code>
        /// in the presigned URL must be set to the us-east-1 region.</para></li><li><para><code>KmsKeyId</code> - The KMS key identifier for the key to use to encrypt the
        /// copy of the DB snapshot in the destination region. This is the same identifier for
        /// both the <code>CopyDBSnapshot</code> action that is called in the destination region,
        /// and the action contained in the presigned URL.</para></li><li><para><code>SourceDBSnapshotIdentifier</code> - The DB snapshot identifier for the encrypted
        /// snapshot to be copied. This identifier must be in the Amazon Resource Name (ARN) format
        /// for the source region. For example, if you are copying an encrypted DB snapshot from
        /// the us-west-2 region, then your <code>SourceDBSnapshotIdentifier</code> looks like
        /// the following example: <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20161115</code>.</para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
        /// Authenticating Requests: Using Query Parameters (AWS Signature Version 4)</a> and
        /// <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html"> Signature
        /// Version 4 Signing Process</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the source DB snapshot.</para><para>If you are copying from a shared manual DB snapshot, this must be the ARN of the shared
        /// DB snapshot.</para><para>You cannot copy an encrypted, shared DB snapshot from one AWS region to another.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li><li><para>If the source snapshot is in the same region as the copy, specify a valid DB snapshot
        /// identifier.</para></li><li><para>If the source snapshot is in a different region than the copy, specify a valid DB
        /// snapshot ARN. For more information, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopySnapshot.html">
        /// Copying a DB Snapshot or DB Cluster Snapshot</a>.</para></li></ul><para>Example: <code>rds:mydb-2012-04-02-00-01</code></para><para>Example: <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20130805</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        ///  The SourceRegion for generating the PreSignedUrl property.
        /// 
        ///  If SourceRegion is set and the PreSignedUrl property is not,
        ///  then PreSignedUrl will be automatically generated by the client.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceRegion { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.SourceRegion = this.SourceRegion;
            if (ParameterWasBound("CopyTag"))
                context.CopyTags = this.CopyTag;
            context.KmsKeyId = this.KmsKeyId;
            context.PreSignedUrl = this.PreSignedUrl;
            context.SourceDBSnapshotIdentifier = this.SourceDBSnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBSnapshotIdentifier = this.TargetDBSnapshotIdentifier;
            
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
            var request = new Amazon.RDS.Model.CopyDBSnapshotRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.CopyTags != null)
            {
                request.CopyTags = cmdletContext.CopyTags.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PreSignedUrl != null)
            {
                request.PreSignedUrl = cmdletContext.PreSignedUrl;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.CopyDBSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CopyDBSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CopyDBSnapshot");
            #if DESKTOP
            return client.CopyDBSnapshot(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CopyDBSnapshotAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String SourceRegion { get; set; }
            public System.Boolean? CopyTags { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetDBSnapshotIdentifier { get; set; }
        }
        
    }
}
