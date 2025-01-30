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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Copies a snapshot of a DB cluster.
    /// 
    ///  
    /// <para>
    /// To copy a DB cluster snapshot from a shared manual DB cluster snapshot, <c>SourceDBClusterSnapshotIdentifier</c>
    /// must be the Amazon Resource Name (ARN) of the shared DB cluster snapshot.
    /// </para><para>
    /// You can copy an encrypted DB cluster snapshot from another Amazon Web Services Region.
    /// In that case, the Amazon Web Services Region where you call the <c>CopyDBClusterSnapshot</c>
    /// operation is the destination Amazon Web Services Region for the encrypted DB cluster
    /// snapshot to be copied to. To copy an encrypted DB cluster snapshot from another Amazon
    /// Web Services Region, you must provide the following values:
    /// </para><ul><li><para><c>KmsKeyId</c> - The Amazon Web Services Key Management System (Amazon Web Services
    /// KMS) key identifier for the key to use to encrypt the copy of the DB cluster snapshot
    /// in the destination Amazon Web Services Region.
    /// </para></li><li><para><c>TargetDBClusterSnapshotIdentifier</c> - The identifier for the new copy of the
    /// DB cluster snapshot in the destination Amazon Web Services Region.
    /// </para></li><li><para><c>SourceDBClusterSnapshotIdentifier</c> - The DB cluster snapshot identifier for
    /// the encrypted DB cluster snapshot to be copied. This identifier must be in the ARN
    /// format for the source Amazon Web Services Region and is the same value as the <c>SourceDBClusterSnapshotIdentifier</c>
    /// in the presigned URL.
    /// </para></li></ul><para>
    /// To cancel the copy operation once it is in progress, delete the target DB cluster
    /// snapshot identified by <c>TargetDBClusterSnapshotIdentifier</c> while that DB cluster
    /// snapshot is in "copying" status.
    /// </para><para>
    /// For more information on copying encrypted Amazon Aurora DB cluster snapshots from
    /// one Amazon Web Services Region to another, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_CopySnapshot.html">
    /// Copying a Snapshot</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Amazon Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "RDSDBClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshot")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CopyDBClusterSnapshot API operation.", Operation = new[] {"CopyDBClusterSnapshot"}, SelectReturnType = typeof(Amazon.RDS.Model.CopyDBClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshot or Amazon.RDS.Model.CopyDBClusterSnapshotResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBClusterSnapshot object.",
        "The service call response (type Amazon.RDS.Model.CopyDBClusterSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyRDSDBClusterSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy all tags from the source DB cluster snapshot to the target
        /// DB cluster snapshot. By default, tags are not copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for an encrypted DB cluster snapshot. The
        /// Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the Amazon Web Services KMS key.</para><para>If you copy an encrypted DB cluster snapshot from your Amazon Web Services account,
        /// you can specify a value for <c>KmsKeyId</c> to encrypt the copy with a new KMS key.
        /// If you don't specify a value for <c>KmsKeyId</c>, then the copy of the DB cluster
        /// snapshot is encrypted with the same KMS key as the source DB cluster snapshot.</para><para>If you copy an encrypted DB cluster snapshot that is shared from another Amazon Web
        /// Services account, then you must specify a value for <c>KmsKeyId</c>.</para><para>To copy an encrypted DB cluster snapshot to another Amazon Web Services Region, you
        /// must set <c>KmsKeyId</c> to the Amazon Web Services KMS key identifier you want to
        /// use to encrypt the copy of the DB cluster snapshot in the destination Amazon Web Services
        /// Region. KMS keys are specific to the Amazon Web Services Region that they are created
        /// in, and you can't use KMS keys from one Amazon Web Services Region in another Amazon
        /// Web Services Region.</para><para>If you copy an unencrypted DB cluster snapshot and specify a value for the <c>KmsKeyId</c>
        /// parameter, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>When you are copying a DB cluster snapshot from one Amazon Web Services GovCloud (US)
        /// Region to another, the URL that contains a Signature Version 4 signed request for
        /// the <c>CopyDBClusterSnapshot</c> API operation in the Amazon Web Services Region that
        /// contains the source DB cluster snapshot to copy. Use the <c>PreSignedUrl</c> parameter
        /// when copying an encrypted DB cluster snapshot from another Amazon Web Services Region.
        /// Don't specify <c>PreSignedUrl</c> when copying an encrypted DB cluster snapshot in
        /// the same Amazon Web Services Region.</para><para>This setting applies only to Amazon Web Services GovCloud (US) Regions. It's ignored
        /// in other Amazon Web Services Regions.</para><para>The presigned URL must be a valid request for the <c>CopyDBClusterSnapshot</c> API
        /// operation that can run in the source Amazon Web Services Region that contains the
        /// encrypted DB cluster snapshot to copy. The presigned URL request must contain the
        /// following parameter values:</para><ul><li><para><c>KmsKeyId</c> - The KMS key identifier for the KMS key to use to encrypt the copy
        /// of the DB cluster snapshot in the destination Amazon Web Services Region. This is
        /// the same identifier for both the <c>CopyDBClusterSnapshot</c> operation that is called
        /// in the destination Amazon Web Services Region, and the operation contained in the
        /// presigned URL.</para></li><li><para><c>DestinationRegion</c> - The name of the Amazon Web Services Region that the DB
        /// cluster snapshot is to be created in.</para></li><li><para><c>SourceDBClusterSnapshotIdentifier</c> - The DB cluster snapshot identifier for
        /// the encrypted DB cluster snapshot to be copied. This identifier must be in the Amazon
        /// Resource Name (ARN) format for the source Amazon Web Services Region. For example,
        /// if you are copying an encrypted DB cluster snapshot from the us-west-2 Amazon Web
        /// Services Region, then your <c>SourceDBClusterSnapshotIdentifier</c> looks like the
        /// following example: <c>arn:aws:rds:us-west-2:123456789012:cluster-snapshot:aurora-cluster1-snapshot-20161115</c>.</para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
        /// Authenticating Requests: Using Query Parameters (Amazon Web Services Signature Version
        /// 4)</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">
        /// Signature Version 4 Signing Process</a>.</para><note><para>If you are using an Amazon Web Services SDK tool or the CLI, you can specify <c>SourceRegion</c>
        /// (or <c>--source-region</c> for the CLI) instead of specifying <c>PreSignedUrl</c>
        /// manually. Specifying <c>SourceRegion</c> autogenerates a presigned URL that is a valid
        /// request for the operation that can run in the source Amazon Web Services Region.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster snapshot to copy. This parameter isn't case-sensitive.</para><para>You can't copy an encrypted, shared DB cluster snapshot from one Amazon Web Services
        /// Region to another.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li><li><para>If the source snapshot is in the same Amazon Web Services Region as the copy, specify
        /// a valid DB snapshot identifier.</para></li><li><para>If the source snapshot is in a different Amazon Web Services Region than the copy,
        /// specify a valid DB cluster snapshot ARN. For more information, go to <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_CopySnapshot.html#USER_CopySnapshot.AcrossRegions">
        /// Copying Snapshots Across Amazon Web Services Regions</a> in the <i>Amazon Aurora User
        /// Guide</i>.</para></li></ul><para>Example: <c>my-cluster-snapshot1</c></para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the new DB cluster snapshot to create from the source DB cluster
        /// snapshot. This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>my-cluster-snapshot2</c></para>
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
        public System.String TargetDBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CopyDBClusterSnapshotResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CopyDBClusterSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceDBClusterSnapshotIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceDBClusterSnapshotIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceDBClusterSnapshotIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBClusterSnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBClusterSnapshot (CopyDBClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CopyDBClusterSnapshotResponse, CopyRDSDBClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceDBClusterSnapshotIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SourceRegion = this.SourceRegion;
            context.CopyTag = this.CopyTag;
            context.KmsKeyId = this.KmsKeyId;
            context.PreSignedUrl = this.PreSignedUrl;
            context.SourceDBClusterSnapshotIdentifier = this.SourceDBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.SourceDBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.SourceDBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBClusterSnapshotIdentifier = this.TargetDBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.TargetDBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.TargetDBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CopyDBClusterSnapshotRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.CopyTag != null)
            {
                request.CopyTags = cmdletContext.CopyTag.Value;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDBClusterSnapshotIdentifier != null)
            {
                request.TargetDBClusterSnapshotIdentifier = cmdletContext.TargetDBClusterSnapshotIdentifier;
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
        
        private Amazon.RDS.Model.CopyDBClusterSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CopyDBClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CopyDBClusterSnapshot");
            try
            {
                #if DESKTOP
                return client.CopyDBClusterSnapshot(request);
                #elif CORECLR
                return client.CopyDBClusterSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopyTag { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBClusterSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TargetDBClusterSnapshotIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.CopyDBClusterSnapshotResponse, CopyRDSDBClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshot;
        }
        
    }
}
