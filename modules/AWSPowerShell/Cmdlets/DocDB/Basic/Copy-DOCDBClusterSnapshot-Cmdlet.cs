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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Copies a snapshot of a DB cluster.
    /// 
    ///  
    /// <para>
    /// To copy a DB cluster snapshot from a shared manual DB cluster snapshot, <code>SourceDBClusterSnapshotIdentifier</code>
    /// must be the Amazon Resource Name (ARN) of the shared DB cluster snapshot.
    /// </para><para>
    /// To cancel the copy operation after it is in progress, delete the target DB cluster
    /// snapshot identified by <code>TargetDBClusterSnapshotIdentifier</code> while that DB
    /// cluster snapshot is in the <i>copying</i> status.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "DOCDBClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBClusterSnapshot")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) CopyDBClusterSnapshot API operation.", Operation = new[] {"CopyDBClusterSnapshot"}, SelectReturnType = typeof(Amazon.DocDB.Model.CopyDBClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterSnapshot or Amazon.DocDB.Model.CopyDBClusterSnapshotResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBClusterSnapshot object.",
        "The service call response (type Amazon.DocDB.Model.CopyDBClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyDOCDBClusterSnapshotCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to copy all tags from the source DB cluster snapshot to the
        /// target DB cluster snapshot, and otherwise <code>false</code>. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key ID for an encrypted DB cluster snapshot. The AWS KMS key ID is the
        /// Amazon Resource Name (ARN), AWS KMS key identifier, or the AWS KMS key alias for the
        /// AWS KMS encryption key. </para><para>If you copy an encrypted DB cluster snapshot from your AWS account, you can specify
        /// a value for <code>KmsKeyId</code> to encrypt the copy with a new AWS KMS encryption
        /// key. If you don't specify a value for <code>KmsKeyId</code>, then the copy of the
        /// DB cluster snapshot is encrypted with the same AWS KMS key as the source DB cluster
        /// snapshot. </para><para>If you copy an encrypted DB cluster snapshot that is shared from another AWS account,
        /// then you must specify a value for <code>KmsKeyId</code>. </para><para>To copy an encrypted DB cluster snapshot to another AWS Region, set <code>KmsKeyId</code>
        /// to the AWS KMS key ID that you want to use to encrypt the copy of the DB cluster snapshot
        /// in the destination Region. AWS KMS encryption keys are specific to the AWS Region
        /// that they are created in, and you can't use encryption keys from one Region in another
        /// Region.</para><para>If you copy an unencrypted DB cluster snapshot and specify a value for the <code>KmsKeyId</code>
        /// parameter, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the <code>CopyDBClusterSnapshot</code>
        /// API action in the AWS Region that contains the source DB cluster snapshot to copy.
        /// You must use the <code>PreSignedUrl</code> parameter when copying an encrypted DB
        /// cluster snapshot from another AWS Region.</para><para>The presigned URL must be a valid request for the <code>CopyDBSClusterSnapshot</code>
        /// API action that can be executed in the source AWS Region that contains the encrypted
        /// DB cluster snapshot to be copied. The presigned URL request must contain the following
        /// parameter values:</para><ul><li><para><code>KmsKeyId</code> - The AWS KMS key identifier for the key to use to encrypt
        /// the copy of the DB cluster snapshot in the destination AWS Region. This is the same
        /// identifier for both the <code>CopyDBClusterSnapshot</code> action that is called in
        /// the destination AWS Region, and the action contained in the presigned URL.</para></li><li><para><code>DestinationRegion</code> - The name of the AWS Region that the DB cluster snapshot
        /// will be created in.</para></li><li><para><code>SourceDBClusterSnapshotIdentifier</code> - The DB cluster snapshot identifier
        /// for the encrypted DB cluster snapshot to be copied. This identifier must be in the
        /// Amazon Resource Name (ARN) format for the source AWS Region. For example, if you are
        /// copying an encrypted DB cluster snapshot from the us-west-2 AWS Region, then your
        /// <code>SourceDBClusterSnapshotIdentifier</code> looks like the following example: <code>arn:aws:rds:us-west-2:123456789012:cluster-snapshot:my-cluster-snapshot-20161115</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster snapshot to copy. This parameter is not case sensitive.</para><para>You can't copy an encrypted, shared DB cluster snapshot from one AWS Region to another.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the "available" state.</para></li><li><para>If the source snapshot is in the same AWS Region as the copy, specify a valid DB snapshot
        /// identifier.</para></li><li><para>If the source snapshot is in a different AWS Region than the copy, specify a valid
        /// DB cluster snapshot ARN.</para></li></ul><para>Example: <code>my-cluster-snapshot1</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceDBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the DB cluster snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the new DB cluster snapshot to create from the source DB cluster
        /// snapshot. This parameter is not case sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster-snapshot2</code></para>
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
        public System.String TargetDBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.CopyDBClusterSnapshotResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.CopyDBClusterSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetDBClusterSnapshotIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetDBClusterSnapshotIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetDBClusterSnapshotIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetDBClusterSnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-DOCDBClusterSnapshot (CopyDBClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.CopyDBClusterSnapshotResponse, CopyDOCDBClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetDBClusterSnapshotIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                context.Tag = new List<Amazon.DocDB.Model.Tag>(this.Tag);
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
            var request = new Amazon.DocDB.Model.CopyDBClusterSnapshotRequest();
            
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
        
        private Amazon.DocDB.Model.CopyDBClusterSnapshotResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.CopyDBClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "CopyDBClusterSnapshot");
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
            public System.Boolean? CopyTag { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBClusterSnapshotIdentifier { get; set; }
            public List<Amazon.DocDB.Model.Tag> Tag { get; set; }
            public System.String TargetDBClusterSnapshotIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.CopyDBClusterSnapshotResponse, CopyDOCDBClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshot;
        }
        
    }
}
