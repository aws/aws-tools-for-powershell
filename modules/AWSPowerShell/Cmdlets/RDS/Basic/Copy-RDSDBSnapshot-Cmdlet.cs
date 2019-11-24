/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// You can copy a snapshot from one AWS Region to another. In that case, the AWS Region
    /// where you call the <code>CopyDBSnapshot</code> action is the destination AWS Region
    /// for the DB snapshot copy. 
    /// </para><para>
    /// For more information about copying snapshots, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopyDBSnapshot.html">Copying
    /// a DB Snapshot</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Copy", "RDSDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CopyDBSnapshot API operation.", Operation = new[] {"CopyDBSnapshot"}, SelectReturnType = typeof(Amazon.RDS.Model.CopyDBSnapshotResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot or Amazon.RDS.Model.CopyDBSnapshotResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSnapshot object.",
        "The service call response (type Amazon.RDS.Model.CopyDBSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to copy all tags from the source DB snapshot to the
        /// target DB snapshot. By default, tags are not copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key ID for an encrypted DB snapshot. The KMS key ID is the Amazon Resource
        /// Name (ARN), KMS key identifier, or the KMS key alias for the KMS encryption key. </para><para>If you copy an encrypted DB snapshot from your AWS account, you can specify a value
        /// for this parameter to encrypt the copy with a new KMS encryption key. If you don't
        /// specify a value for this parameter, then the copy of the DB snapshot is encrypted
        /// with the same KMS key as the source DB snapshot. </para><para>If you copy an encrypted DB snapshot that is shared from another AWS account, then
        /// you must specify a value for this parameter. </para><para>If you specify this parameter when you copy an unencrypted snapshot, the copy is encrypted.
        /// </para><para>If you copy an encrypted snapshot to a different AWS Region, then you must specify
        /// a KMS key for the destination AWS Region. KMS encryption keys are specific to the
        /// AWS Region that they are created in, and you can't use encryption keys from one AWS
        /// Region in another AWS Region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of an option group to associate with the copy of the snapshot.</para><para>Specify this option if you are copying a snapshot from one AWS Region to another,
        /// and your DB instance uses a nondefault option group. If your source DB instance uses
        /// Transparent Data Encryption for Oracle or Microsoft SQL Server, you must specify this
        /// option when copying across AWS Regions. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CopySnapshot.html#USER_CopySnapshot.Options">Option
        /// Group Considerations</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the <code>CopyDBSnapshot</code>
        /// API action in the source AWS Region that contains the source DB snapshot to copy.
        /// </para><para>You must specify this parameter when you copy an encrypted DB snapshot from another
        /// AWS Region by using the Amazon RDS API. Don't specify <code>PreSignedUrl</code> when
        /// you are copying an encrypted DB snapshot in the same AWS Region.</para><para>The presigned URL must be a valid request for the <code>CopyDBSnapshot</code> API
        /// action that can be executed in the source AWS Region that contains the encrypted DB
        /// snapshot to be copied. The presigned URL request must contain the following parameter
        /// values: </para><ul><li><para><code>DestinationRegion</code> - The AWS Region that the encrypted DB snapshot is
        /// copied to. This AWS Region is the same one where the <code>CopyDBSnapshot</code> action
        /// is called that contains this presigned URL. </para><para>For example, if you copy an encrypted DB snapshot from the us-west-2 AWS Region to
        /// the us-east-1 AWS Region, then you call the <code>CopyDBSnapshot</code> action in
        /// the us-east-1 AWS Region and provide a presigned URL that contains a call to the <code>CopyDBSnapshot</code>
        /// action in the us-west-2 AWS Region. For this example, the <code>DestinationRegion</code>
        /// in the presigned URL must be set to the us-east-1 AWS Region. </para></li><li><para><code>KmsKeyId</code> - The AWS KMS key identifier for the key to use to encrypt
        /// the copy of the DB snapshot in the destination AWS Region. This is the same identifier
        /// for both the <code>CopyDBSnapshot</code> action that is called in the destination
        /// AWS Region, and the action contained in the presigned URL. </para></li><li><para><code>SourceDBSnapshotIdentifier</code> - The DB snapshot identifier for the encrypted
        /// snapshot to be copied. This identifier must be in the Amazon Resource Name (ARN) format
        /// for the source AWS Region. For example, if you are copying an encrypted DB snapshot
        /// from the us-west-2 AWS Region, then your <code>SourceDBSnapshotIdentifier</code> looks
        /// like the following example: <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20161115</code>.
        /// </para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">Authenticating
        /// Requests: Using Query Parameters (AWS Signature Version 4)</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
        /// Version 4 Signing Process</a>. </para><note><para>If you are using an AWS SDK tool or the AWS CLI, you can specify <code>SourceRegion</code>
        /// (or <code>--source-region</code> for the AWS CLI) instead of specifying <code>PreSignedUrl</code>
        /// manually. Specifying <code>SourceRegion</code> autogenerates a pre-signed URL that
        /// is a valid request for the operation that can be executed in the source AWS Region.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the source DB snapshot.</para><para>If the source snapshot is in the same AWS Region as the copy, specify a valid DB snapshot
        /// identifier. For example, you might specify <code>rds:mysql-instance1-snapshot-20130805</code>.
        /// </para><para>If the source snapshot is in a different AWS Region than the copy, specify a valid
        /// DB snapshot ARN. For example, you might specify <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20130805</code>.
        /// </para><para>If you are copying from a shared manual DB snapshot, this parameter must be the Amazon
        /// Resource Name (ARN) of the shared DB snapshot. </para><para>If you are copying an encrypted snapshot this parameter must be in the ARN format
        /// for the source AWS Region, and must match the <code>SourceDBSnapshotIdentifier</code>
        /// in the <code>PreSignedUrl</code> parameter. </para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li></ul><para>Example: <code>rds:mydb-2012-04-02-00-01</code></para><para>Example: <code>arn:aws:rds:us-west-2:123456789012:snapshot:mysql-instance1-snapshot-20130805</code></para>
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
        
        #region Parameter TargetDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copy of the snapshot. </para><para>Constraints:</para><ul><li><para>Can't be null, empty, or blank</para></li><li><para>Must contain from 1 to 255 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-db-snapshot</code></para>
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
        public System.String TargetDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CopyDBSnapshotResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CopyDBSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSnapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceDBSnapshotIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceDBSnapshotIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceDBSnapshotIdentifier' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBSnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBSnapshot (CopyDBSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CopyDBSnapshotResponse, CopyRDSDBSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceDBSnapshotIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SourceRegion = this.SourceRegion;
            context.CopyTag = this.CopyTag;
            context.KmsKeyId = this.KmsKeyId;
            context.OptionGroupName = this.OptionGroupName;
            context.PreSignedUrl = this.PreSignedUrl;
            context.SourceDBSnapshotIdentifier = this.SourceDBSnapshotIdentifier;
            #if MODULAR
            if (this.SourceDBSnapshotIdentifier == null && ParameterWasBound(nameof(this.SourceDBSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBSnapshotIdentifier = this.TargetDBSnapshotIdentifier;
            #if MODULAR
            if (this.TargetDBSnapshotIdentifier == null && ParameterWasBound(nameof(this.TargetDBSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CopyDBSnapshotRequest();
            
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
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.PreSignedUrl != null)
            {
                request.PreSignedUrl = cmdletContext.PreSignedUrl;
            }
            if (cmdletContext.SourceDBSnapshotIdentifier != null)
            {
                request.SourceDBSnapshotIdentifier = cmdletContext.SourceDBSnapshotIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDBSnapshotIdentifier != null)
            {
                request.TargetDBSnapshotIdentifier = cmdletContext.TargetDBSnapshotIdentifier;
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
        
        private Amazon.RDS.Model.CopyDBSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CopyDBSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CopyDBSnapshot");
            try
            {
                #if DESKTOP
                return client.CopyDBSnapshot(request);
                #elif CORECLR
                return client.CopyDBSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String OptionGroupName { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TargetDBSnapshotIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.CopyDBSnapshotResponse, CopyRDSDBSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSnapshot;
        }
        
    }
}
