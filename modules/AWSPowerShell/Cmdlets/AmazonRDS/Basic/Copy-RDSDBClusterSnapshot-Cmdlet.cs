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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Copies a snapshot of a DB cluster.
    /// 
    ///  
    /// <para>
    /// To copy a DB cluster snapshot from a shared manual DB cluster snapshot, <code>SourceDBClusterSnapshotIdentifier</code>
    /// must be the Amazon Resource Name (ARN) of the shared DB cluster snapshot.
    /// </para><para>
    /// You can copy an encrypted DB cluster snapshot from another AWS Region. In that case,
    /// the AWS Region where you call the <code>CopyDBClusterSnapshot</code> action is the
    /// destination AWS Region for the encrypted DB cluster snapshot to be copied to. To copy
    /// an encrypted DB cluster snapshot from another AWS Region, you must provide the following
    /// values:
    /// </para><ul><li><para><code>KmsKeyId</code> - The AWS Key Management System (AWS KMS) key identifier for
    /// the key to use to encrypt the copy of the DB cluster snapshot in the destination AWS
    /// Region.
    /// </para></li><li><para><code>PreSignedUrl</code> - A URL that contains a Signature Version 4 signed request
    /// for the <code>CopyDBClusterSnapshot</code> action to be called in the source AWS Region
    /// where the DB cluster snapshot is copied from. The pre-signed URL must be a valid request
    /// for the <code>CopyDBClusterSnapshot</code> API action that can be executed in the
    /// source AWS Region that contains the encrypted DB cluster snapshot to be copied.
    /// </para><para>
    /// The pre-signed URL request must contain the following parameter values:
    /// </para><ul><li><para><code>KmsKeyId</code> - The KMS key identifier for the key to use to encrypt the
    /// copy of the DB cluster snapshot in the destination AWS Region. This is the same identifier
    /// for both the <code>CopyDBClusterSnapshot</code> action that is called in the destination
    /// AWS Region, and the action contained in the pre-signed URL.
    /// </para></li><li><para><code>DestinationRegion</code> - The name of the AWS Region that the DB cluster snapshot
    /// will be created in.
    /// </para></li><li><para><code>SourceDBClusterSnapshotIdentifier</code> - The DB cluster snapshot identifier
    /// for the encrypted DB cluster snapshot to be copied. This identifier must be in the
    /// Amazon Resource Name (ARN) format for the source AWS Region. For example, if you are
    /// copying an encrypted DB cluster snapshot from the us-west-2 AWS Region, then your
    /// <code>SourceDBClusterSnapshotIdentifier</code> looks like the following example: <code>arn:aws:rds:us-west-2:123456789012:cluster-snapshot:aurora-cluster1-snapshot-20161115</code>.
    /// </para></li></ul><para>
    /// To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
    /// Authenticating Requests: Using Query Parameters (AWS Signature Version 4)</a> and
    /// <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html"> Signature
    /// Version 4 Signing Process</a>.
    /// </para></li><li><para><code>TargetDBClusterSnapshotIdentifier</code> - The identifier for the new copy
    /// of the DB cluster snapshot in the destination AWS Region.
    /// </para></li><li><para><code>SourceDBClusterSnapshotIdentifier</code> - The DB cluster snapshot identifier
    /// for the encrypted DB cluster snapshot to be copied. This identifier must be in the
    /// ARN format for the source AWS Region and is the same value as the <code>SourceDBClusterSnapshotIdentifier</code>
    /// in the pre-signed URL. 
    /// </para></li></ul><para>
    /// To cancel the copy operation once it is in progress, delete the target DB cluster
    /// snapshot identified by <code>TargetDBClusterSnapshotIdentifier</code> while that DB
    /// cluster snapshot is in "copying" status.
    /// </para><para>
    /// For more information on copying encrypted DB cluster snapshots from one AWS Region
    /// to another, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_CopySnapshot.html">
    /// Copying a Snapshot</a> in the <i>Amazon Aurora User Guide.</i></para><para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What Is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide.</i></para>
    /// </summary>
    [Cmdlet("Copy", "RDSDBClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshot")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CopyDBClusterSnapshot API operation.", Operation = new[] {"CopyDBClusterSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshot",
        "This cmdlet returns a DBClusterSnapshot object.",
        "The service call response (type Amazon.RDS.Model.CopyDBClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyRDSDBClusterSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the source DB cluster snapshot to the target DB cluster
        /// snapshot, and otherwise false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CopyTags")]
        public System.Boolean CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS AWS KMS key ID for an encrypted DB cluster snapshot. The KMS key ID is the
        /// Amazon Resource Name (ARN), KMS key identifier, or the KMS key alias for the KMS encryption
        /// key. </para><para>If you copy an encrypted DB cluster snapshot from your AWS account, you can specify
        /// a value for <code>KmsKeyId</code> to encrypt the copy with a new KMS encryption key.
        /// If you don't specify a value for <code>KmsKeyId</code>, then the copy of the DB cluster
        /// snapshot is encrypted with the same KMS key as the source DB cluster snapshot. </para><para>If you copy an encrypted DB cluster snapshot that is shared from another AWS account,
        /// then you must specify a value for <code>KmsKeyId</code>. </para><para>To copy an encrypted DB cluster snapshot to another AWS Region, you must set <code>KmsKeyId</code>
        /// to the KMS key ID you want to use to encrypt the copy of the DB cluster snapshot in
        /// the destination AWS Region. KMS encryption keys are specific to the AWS Region that
        /// they are created in, and you can't use encryption keys from one AWS Region in another
        /// AWS Region.</para><para>If you copy an unencrypted DB cluster snapshot and specify a value for the <code>KmsKeyId</code>
        /// parameter, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the <code>CopyDBClusterSnapshot</code>
        /// API action in the AWS Region that contains the source DB cluster snapshot to copy.
        /// The <code>PreSignedUrl</code> parameter must be used when copying an encrypted DB
        /// cluster snapshot from another AWS Region.</para><para>The pre-signed URL must be a valid request for the <code>CopyDBSClusterSnapshot</code>
        /// API action that can be executed in the source AWS Region that contains the encrypted
        /// DB cluster snapshot to be copied. The pre-signed URL request must contain the following
        /// parameter values:</para><ul><li><para><code>KmsKeyId</code> - The AWS KMS key identifier for the key to use to encrypt
        /// the copy of the DB cluster snapshot in the destination AWS Region. This is the same
        /// identifier for both the <code>CopyDBClusterSnapshot</code> action that is called in
        /// the destination AWS Region, and the action contained in the pre-signed URL.</para></li><li><para><code>DestinationRegion</code> - The name of the AWS Region that the DB cluster snapshot
        /// will be created in.</para></li><li><para><code>SourceDBClusterSnapshotIdentifier</code> - The DB cluster snapshot identifier
        /// for the encrypted DB cluster snapshot to be copied. This identifier must be in the
        /// Amazon Resource Name (ARN) format for the source AWS Region. For example, if you are
        /// copying an encrypted DB cluster snapshot from the us-west-2 AWS Region, then your
        /// <code>SourceDBClusterSnapshotIdentifier</code> looks like the following example: <code>arn:aws:rds:us-west-2:123456789012:cluster-snapshot:aurora-cluster1-snapshot-20161115</code>.</para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
        /// Authenticating Requests: Using Query Parameters (AWS Signature Version 4)</a> and
        /// <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html"> Signature
        /// Version 4 Signing Process</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster snapshot to copy. This parameter is not case-sensitive.</para><para>You can't copy an encrypted, shared DB cluster snapshot from one AWS Region to another.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li><li><para>If the source snapshot is in the same AWS Region as the copy, specify a valid DB snapshot
        /// identifier.</para></li><li><para>If the source snapshot is in a different AWS Region than the copy, specify a valid
        /// DB cluster snapshot ARN. For more information, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_CopySnapshot.html#USER_CopySnapshot.AcrossRegions">
        /// Copying Snapshots Across AWS Regions</a> in the <i>Amazon Aurora User Guide.</i></para></li></ul><para>Example: <code>my-cluster-snapshot1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBClusterSnapshotIdentifier { get; set; }
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the new DB cluster snapshot to create from the source DB cluster
        /// snapshot. This parameter is not case-sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster-snapshot2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetDBClusterSnapshotIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceDBClusterSnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBClusterSnapshot (CopyDBClusterSnapshot)"))
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
            context.SourceDBClusterSnapshotIdentifier = this.SourceDBClusterSnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBClusterSnapshotIdentifier = this.TargetDBClusterSnapshotIdentifier;
            
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
            var request = new Amazon.RDS.Model.CopyDBClusterSnapshotRequest();
            
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
            if (cmdletContext.SourceDBClusterSnapshotIdentifier != null)
            {
                request.SourceDBClusterSnapshotIdentifier = cmdletContext.SourceDBClusterSnapshotIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetDBClusterSnapshotIdentifier != null)
            {
                request.TargetDBClusterSnapshotIdentifier = cmdletContext.TargetDBClusterSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBClusterSnapshot;
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
        
        private Amazon.RDS.Model.CopyDBClusterSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CopyDBClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CopyDBClusterSnapshot");
            try
            {
                #if DESKTOP
                return client.CopyDBClusterSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CopyDBClusterSnapshotAsync(request);
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
            public System.String SourceRegion { get; set; }
            public System.Boolean? CopyTags { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBClusterSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetDBClusterSnapshotIdentifier { get; set; }
        }
        
    }
}
