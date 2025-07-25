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
using System.Threading;
using Amazon.DocDB;
using Amazon.DocDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Copies a snapshot of a cluster.
    /// 
    ///  
    /// <para>
    /// To copy a cluster snapshot from a shared manual cluster snapshot, <c>SourceDBClusterSnapshotIdentifier</c>
    /// must be the Amazon Resource Name (ARN) of the shared cluster snapshot. You can only
    /// copy a shared DB cluster snapshot, whether encrypted or not, in the same Amazon Web
    /// Services Region.
    /// </para><para>
    /// To cancel the copy operation after it is in progress, delete the target cluster snapshot
    /// identified by <c>TargetDBClusterSnapshotIdentifier</c> while that cluster snapshot
    /// is in the <i>copying</i> status.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "DOCDBClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBClusterSnapshot")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) CopyDBClusterSnapshot API operation.", Operation = new[] {"CopyDBClusterSnapshot"}, SelectReturnType = typeof(Amazon.DocDB.Model.CopyDBClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterSnapshot or Amazon.DocDB.Model.CopyDBClusterSnapshotResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBClusterSnapshot object.",
        "The service call response (type Amazon.DocDB.Model.CopyDBClusterSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyDOCDBClusterSnapshotCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to copy all tags from the source cluster snapshot to the target
        /// cluster snapshot, and otherwise <c>false</c>. The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key ID for an encrypted cluster snapshot. The KMS key ID is the Amazon Resource
        /// Name (ARN), KMS key identifier, or the KMS key alias for the KMS encryption key. </para><para>If you copy an encrypted cluster snapshot from your Amazon Web Services account, you
        /// can specify a value for <c>KmsKeyId</c> to encrypt the copy with a new KMS encryption
        /// key. If you don't specify a value for <c>KmsKeyId</c>, then the copy of the cluster
        /// snapshot is encrypted with the same KMS key as the source cluster snapshot.</para><para>If you copy an encrypted cluster snapshot that is shared from another Amazon Web Services
        /// account, then you must specify a value for <c>KmsKeyId</c>.</para><para>To copy an encrypted cluster snapshot to another Amazon Web Services Region, set <c>KmsKeyId</c>
        /// to the KMS key ID that you want to use to encrypt the copy of the cluster snapshot
        /// in the destination Region. KMS encryption keys are specific to the Amazon Web Services
        /// Region that they are created in, and you can't use encryption keys from one Amazon
        /// Web Services Region in another Amazon Web Services Region.</para><para>If you copy an unencrypted cluster snapshot and specify a value for the <c>KmsKeyId</c>
        /// parameter, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the<c>CopyDBClusterSnapshot</c>
        /// API action in the Amazon Web Services Region that contains the source cluster snapshot
        /// to copy. You must use the <c>PreSignedUrl</c> parameter when copying a cluster snapshot
        /// from another Amazon Web Services Region.</para><para>If you are using an Amazon Web Services SDK tool or the CLI, you can specify <c>SourceRegion</c>
        /// (or <c>--source-region</c> for the CLI) instead of specifying <c>PreSignedUrl</c>
        /// manually. Specifying <c>SourceRegion</c> autogenerates a pre-signed URL that is a
        /// valid request for the operation that can be executed in the source Amazon Web Services
        /// Region.</para><para>The presigned URL must be a valid request for the <c>CopyDBClusterSnapshot</c> API
        /// action that can be executed in the source Amazon Web Services Region that contains
        /// the cluster snapshot to be copied. The presigned URL request must contain the following
        /// parameter values:</para><ul><li><para><c>SourceRegion</c> - The ID of the region that contains the snapshot to be copied.</para></li><li><para><c>SourceDBClusterSnapshotIdentifier</c> - The identifier for the the encrypted cluster
        /// snapshot to be copied. This identifier must be in the Amazon Resource Name (ARN) format
        /// for the source Amazon Web Services Region. For example, if you are copying an encrypted
        /// cluster snapshot from the us-east-1 Amazon Web Services Region, then your <c>SourceDBClusterSnapshotIdentifier</c>
        /// looks something like the following: <c>arn:aws:rds:us-east-1:12345678012:sample-cluster:sample-cluster-snapshot</c>.</para></li><li><para><c>TargetDBClusterSnapshotIdentifier</c> - The identifier for the new cluster snapshot
        /// to be created. This parameter isn't case sensitive.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster snapshot to copy. This parameter is not case sensitive.</para><para>Constraints:</para><ul><li><para>Must specify a valid system snapshot in the <i>available</i> state.</para></li><li><para>If the source snapshot is in the same Amazon Web Services Region as the copy, specify
        /// a valid snapshot identifier.</para></li><li><para>If the source snapshot is in a different Amazon Web Services Region than the copy,
        /// specify a valid cluster snapshot ARN.</para></li></ul><para>Example: <c>my-cluster-snapshot1</c></para>
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
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// The SourceRegion for generating the PreSignedUrl property.
        /// If SourceRegion is set and the PreSignedUrl property is not,
        /// then PreSignedUrl will be automatically generated by the client.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the cluster snapshot.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the new cluster snapshot to create from the source cluster snapshot.
        /// This parameter is not case sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens. </para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens. </para></li></ul><para>Example: <c>my-cluster-snapshot2</c></para>
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.CopyDBClusterSnapshotResponse, CopyDOCDBClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
        
        private Amazon.DocDB.Model.CopyDBClusterSnapshotResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.CopyDBClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "CopyDBClusterSnapshot");
            try
            {
                return client.CopyDBClusterSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.DocDB.Model.Tag> Tag { get; set; }
            public System.String TargetDBClusterSnapshotIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.CopyDBClusterSnapshotResponse, CopyDOCDBClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshot;
        }
        
    }
}
