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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Recovers the saved resource identified by an Amazon Resource Name (ARN).
    /// </summary>
    [Cmdlet("Start", "BAKRestoreJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Backup StartRestoreJob API operation.", Operation = new[] {"StartRestoreJob"}, SelectReturnType = typeof(Amazon.Backup.Model.StartRestoreJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Backup.Model.StartRestoreJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Backup.Model.StartRestoreJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartBAKRestoreJobCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CopySourceTagsToRestoredResource
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter. If this equals <c>True</c>, tags included in the backup
        /// will be copied to the restored resource.</para><para>This can only be applied to backups created through Backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopySourceTagsToRestoredResource { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Backup uses to create the target
        /// resource; for example: <c>arn:aws:iam::123456789012:role/S3Access</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A customer-chosen string that you can use to distinguish between otherwise identical
        /// calls to <c>StartRestoreJob</c>. Retrying a successful request with the same idempotency
        /// token results in a success message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>A set of metadata key-value pairs.</para><para>You can get configuration metadata about a resource at the time it was backed up by
        /// calling <c>GetRecoveryPointRestoreMetadata</c>. However, values in addition to those
        /// provided by <c>GetRecoveryPointRestoreMetadata</c> might be required to restore a
        /// resource. For example, you might need to provide a new resource name if the original
        /// already exists.</para><para>For more information about the metadata for each resource, see the following:</para><ul><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-aur.html#aur-restore-cli">Metadata
        /// for Amazon Aurora</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-docdb.html#docdb-restore-cli">Metadata
        /// for Amazon DocumentDB</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restore-application-stacks.html#restoring-cfn-cli">Metadata
        /// for CloudFormation</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-dynamodb.html#ddb-restore-cli">Metadata
        /// for Amazon DynamoDB</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-ebs.html#ebs-restore-cli">
        /// Metadata for Amazon EBS</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-ec2.html#restoring-ec2-cli">Metadata
        /// for Amazon EC2</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-efs.html#efs-restore-cli">Metadata
        /// for Amazon EFS</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-fsx.html#fsx-restore-cli">Metadata
        /// for Amazon FSx</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-nep.html#nep-restore-cli">Metadata
        /// for Amazon Neptune</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-rds.html#rds-restore-cli">Metadata
        /// for Amazon RDS</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/redshift-restores.html#redshift-restore-api">Metadata
        /// for Amazon Redshift</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-storage-gateway.html#restoring-sgw-cli">Metadata
        /// for Storage Gateway</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-s3.html#s3-restore-cli">Metadata
        /// for Amazon S3</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/timestream-restore.html#timestream-restore-api">Metadata
        /// for Amazon Timestream</a></para></li><li><para><a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restoring-vm.html#vm-restore-cli">Metadata
        /// for virtual machines</a></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter RecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>An ARN that uniquely identifies a recovery point; for example, <c>arn:aws:backup:us-east-1:123456789012:recovery-point:1EB3B5E7-9EB0-435A-A80B-108B488B0D45</c>.</para>
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
        public System.String RecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Starts a job to restore a recovery point for one of the following resources:</para><ul><li><para><c>Aurora</c> - Amazon Aurora</para></li><li><para><c>DocumentDB</c> - Amazon DocumentDB</para></li><li><para><c>CloudFormation</c> - CloudFormation</para></li><li><para><c>DynamoDB</c> - Amazon DynamoDB</para></li><li><para><c>EBS</c> - Amazon Elastic Block Store</para></li><li><para><c>EC2</c> - Amazon Elastic Compute Cloud</para></li><li><para><c>EFS</c> - Amazon Elastic File System</para></li><li><para><c>FSx</c> - Amazon FSx</para></li><li><para><c>Neptune</c> - Amazon Neptune</para></li><li><para><c>RDS</c> - Amazon Relational Database Service</para></li><li><para><c>Redshift</c> - Amazon Redshift</para></li><li><para><c>Storage Gateway</c> - Storage Gateway</para></li><li><para><c>S3</c> - Amazon Simple Storage Service</para></li><li><para><c>Timestream</c> - Amazon Timestream</para></li><li><para><c>VirtualMachine</c> - Virtual machines</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RestoreJobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.StartRestoreJobResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.StartRestoreJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RestoreJobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryPointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKRestoreJob (StartRestoreJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.StartRestoreJobResponse, StartBAKRestoreJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CopySourceTagsToRestoredResource = this.CopySourceTagsToRestoredResource;
            context.IamRoleArn = this.IamRoleArn;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            #if MODULAR
            if (this.Metadata == null && ParameterWasBound(nameof(this.Metadata)))
            {
                WriteWarning("You are passing $null as a value for parameter Metadata which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecoveryPointArn = this.RecoveryPointArn;
            #if MODULAR
            if (this.RecoveryPointArn == null && ParameterWasBound(nameof(this.RecoveryPointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.Backup.Model.StartRestoreJobRequest();
            
            if (cmdletContext.CopySourceTagsToRestoredResource != null)
            {
                request.CopySourceTagsToRestoredResource = cmdletContext.CopySourceTagsToRestoredResource.Value;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.RecoveryPointArn != null)
            {
                request.RecoveryPointArn = cmdletContext.RecoveryPointArn;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.Backup.Model.StartRestoreJobResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.StartRestoreJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "StartRestoreJob");
            try
            {
                #if DESKTOP
                return client.StartRestoreJob(request);
                #elif CORECLR
                return client.StartRestoreJobAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopySourceTagsToRestoredResource { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String RecoveryPointArn { get; set; }
            public System.String ResourceType { get; set; }
            public System.Func<Amazon.Backup.Model.StartRestoreJobResponse, StartBAKRestoreJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RestoreJobId;
        }
        
    }
}
