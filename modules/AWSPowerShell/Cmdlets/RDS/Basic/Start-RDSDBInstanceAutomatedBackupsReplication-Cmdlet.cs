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
    /// Enables replication of automated backups to a different Amazon Web Services Region.
    /// 
    ///  
    /// <para>
    /// This command doesn't apply to RDS Custom.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ReplicateBackups.html">
    /// Replicating Automated Backups to Another Amazon Web Services Region</a> in the <i>Amazon
    /// RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Start", "RDSDBInstanceAutomatedBackupsReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstanceAutomatedBackup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service StartDBInstanceAutomatedBackupsReplication API operation.", Operation = new[] {"StartDBInstanceAutomatedBackupsReplication"}, SelectReturnType = typeof(Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstanceAutomatedBackup or Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstanceAutomatedBackup object.",
        "The service call response (type Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartRDSDBInstanceAutomatedBackupsReplicationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The retention period for the replicated automated backups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for encryption of the replicated automated
        /// backups. The KMS key ID is the Amazon Resource Name (ARN) for the KMS encryption key
        /// in the destination Amazon Web Services Region, for example, <c>arn:aws:kms:us-east-1:123456789012:key/AKIAIOSFODNN7EXAMPLE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>In an Amazon Web Services GovCloud (US) Region, an URL that contains a Signature Version
        /// 4 signed request for the <c>StartDBInstanceAutomatedBackupsReplication</c> operation
        /// to call in the Amazon Web Services Region of the source DB instance. The presigned
        /// URL must be a valid request for the <c>StartDBInstanceAutomatedBackupsReplication</c>
        /// API operation that can run in the Amazon Web Services Region that contains the source
        /// DB instance.</para><para>This setting applies only to Amazon Web Services GovCloud (US) Regions. It's ignored
        /// in other Amazon Web Services Regions.</para><para>To learn how to generate a Signature Version 4 signed request, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
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
        
        #region Parameter SourceDBInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source DB instance for the replicated automated
        /// backups, for example, <c>arn:aws:rds:us-west-2:123456789012:db:mydatabase</c>.</para>
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
        public System.String SourceDBInstanceArn { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstanceAutomatedBackup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstanceAutomatedBackup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSDBInstanceAutomatedBackupsReplication (StartDBInstanceAutomatedBackupsReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse, StartRDSDBInstanceAutomatedBackupsReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SourceRegion = this.SourceRegion;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.KmsKeyId = this.KmsKeyId;
            context.PreSignedUrl = this.PreSignedUrl;
            context.SourceDBInstanceArn = this.SourceDBInstanceArn;
            #if MODULAR
            if (this.SourceDBInstanceArn == null && ParameterWasBound(nameof(this.SourceDBInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PreSignedUrl != null)
            {
                request.PreSignedUrl = cmdletContext.PreSignedUrl;
            }
            if (cmdletContext.SourceDBInstanceArn != null)
            {
                request.SourceDBInstanceArn = cmdletContext.SourceDBInstanceArn;
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
        
        private Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "StartDBInstanceAutomatedBackupsReplication");
            try
            {
                #if DESKTOP
                return client.StartDBInstanceAutomatedBackupsReplication(request);
                #elif CORECLR
                return client.StartDBInstanceAutomatedBackupsReplicationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String SourceDBInstanceArn { get; set; }
            public System.Func<Amazon.RDS.Model.StartDBInstanceAutomatedBackupsReplicationResponse, StartRDSDBInstanceAutomatedBackupsReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstanceAutomatedBackup;
        }
        
    }
}
