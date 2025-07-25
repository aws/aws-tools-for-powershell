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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Starts an export of DB snapshot or DB cluster data to Amazon S3. The provided IAM
    /// role must have access to the S3 bucket.
    /// 
    ///  
    /// <para>
    /// You can't export snapshot data from RDS Custom DB instances. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RDS_Fea_Regions_DB-eng.Feature.ExportSnapshotToS3.html">
    /// Supported Regions and DB engines for exporting snapshots to S3 in Amazon RDS</a>.
    /// </para><para>
    /// For more information on exporting DB snapshot data, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ExportSnapshot.html">Exporting
    /// DB snapshot data to Amazon S3</a> in the <i>Amazon RDS User Guide</i> or <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-export-snapshot.html">Exporting
    /// DB cluster snapshot data to Amazon S3</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on exporting DB cluster data, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/export-cluster-data.html">Exporting
    /// DB cluster data to Amazon S3</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "RDSExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.StartExportTaskResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service StartExportTask API operation.", Operation = new[] {"StartExportTask"}, SelectReturnType = typeof(Amazon.RDS.Model.StartExportTaskResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.StartExportTaskResponse",
        "This cmdlet returns an Amazon.RDS.Model.StartExportTaskResponse object containing multiple properties."
    )]
    public partial class StartRDSExportTaskCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExportOnly
        /// <summary>
        /// <para>
        /// <para>The data to be exported from the snapshot or cluster. If this parameter isn't provided,
        /// all of the data is exported.</para><para>Valid Values:</para><ul><li><para><c>database</c> - Export all the data from a specified database.</para></li><li><para><c>database.table</c><i>table-name</i> - Export a table of the snapshot or cluster.
        /// This format is valid only for RDS for MySQL, RDS for MariaDB, and Aurora MySQL.</para></li><li><para><c>database.schema</c><i>schema-name</i> - Export a database schema of the snapshot
        /// or cluster. This format is valid only for RDS for PostgreSQL and Aurora PostgreSQL.</para></li><li><para><c>database.schema.table</c><i>table-name</i> - Export a table of the database schema.
        /// This format is valid only for RDS for PostgreSQL and Aurora PostgreSQL.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ExportOnly { get; set; }
        #endregion
        
        #region Parameter ExportTaskIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the export task. This ID isn't an identifier for the Amazon
        /// S3 bucket where the data is to be exported.</para>
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
        public System.String ExportTaskIdentifier { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to use for writing to the Amazon S3 bucket when exporting
        /// a snapshot or cluster.</para><para>In the IAM policy attached to your IAM role, include the following required actions
        /// to allow the transfer of files from Amazon RDS or Amazon Aurora to an S3 bucket:</para><ul><li><para>s3:PutObject*</para></li><li><para>s3:GetObject*</para></li><li><para>s3:ListBucket</para></li><li><para>s3:DeleteObject*</para></li><li><para>s3:GetBucketLocation </para></li></ul><para>In the policy, include the resources to identify the S3 bucket and objects in the
        /// bucket. The following list of resources shows the Amazon Resource Name (ARN) format
        /// for accessing S3:</para><ul><li><para><c>arn:aws:s3:::<i>your-s3-bucket</i></c></para></li><li><para><c>arn:aws:s3:::<i>your-s3-bucket</i>/*</c></para></li></ul>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services KMS key to use to encrypt the data exported to Amazon
        /// S3. The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN,
        /// or alias name for the KMS key. The caller of this operation must be authorized to
        /// run the following operations. These can be set in the Amazon Web Services KMS key
        /// policy:</para><ul><li><para>kms:CreateGrant</para></li><li><para>kms:DescribeKey</para></li></ul>
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
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to export the snapshot or cluster data to.</para>
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
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket prefix to use as the file name and path of the exported data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Prefix { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the snapshot or cluster to export to Amazon S3.</para>
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
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.StartExportTaskResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.StartExportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportTaskIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSExportTask (StartExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.StartExportTaskResponse, StartRDSExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ExportOnly != null)
            {
                context.ExportOnly = new List<System.String>(this.ExportOnly);
            }
            context.ExportTaskIdentifier = this.ExportTaskIdentifier;
            #if MODULAR
            if (this.ExportTaskIdentifier == null && ParameterWasBound(nameof(this.ExportTaskIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportTaskIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            #if MODULAR
            if (this.KmsKeyId == null && ParameterWasBound(nameof(this.KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketName = this.S3BucketName;
            #if MODULAR
            if (this.S3BucketName == null && ParameterWasBound(nameof(this.S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Prefix = this.S3Prefix;
            context.SourceArn = this.SourceArn;
            #if MODULAR
            if (this.SourceArn == null && ParameterWasBound(nameof(this.SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.StartExportTaskRequest();
            
            if (cmdletContext.ExportOnly != null)
            {
                request.ExportOnly = cmdletContext.ExportOnly;
            }
            if (cmdletContext.ExportTaskIdentifier != null)
            {
                request.ExportTaskIdentifier = cmdletContext.ExportTaskIdentifier;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.S3Prefix != null)
            {
                request.S3Prefix = cmdletContext.S3Prefix;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
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
        
        private Amazon.RDS.Model.StartExportTaskResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.StartExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "StartExportTask");
            try
            {
                return client.StartExportTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ExportOnly { get; set; }
            public System.String ExportTaskIdentifier { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3Prefix { get; set; }
            public System.String SourceArn { get; set; }
            public System.Func<Amazon.RDS.Model.StartExportTaskResponse, StartRDSExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
