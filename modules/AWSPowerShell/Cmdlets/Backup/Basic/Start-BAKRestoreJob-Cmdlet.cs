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
        "The service call response (type Amazon.Backup.Model.StartRestoreJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartBAKRestoreJobCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Backup uses to create the target
        /// recovery point; for example, <code>arn:aws:iam::123456789012:role/S3Access</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A customer-chosen string that you can use to distinguish between otherwise identical
        /// calls to <code>StartRestoreJob</code>. Retrying a successful request with the same
        /// idempotency token results in a success message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>A set of metadata key-value pairs. Contains information, such as a resource name,
        /// required to restore a recovery point.</para><para> You can get configuration metadata about a resource at the time it was backed up
        /// by calling <code>GetRecoveryPointRestoreMetadata</code>. However, values in addition
        /// to those provided by <code>GetRecoveryPointRestoreMetadata</code> might be required
        /// to restore a resource. For example, you might need to provide a new resource name
        /// if the original already exists.</para><para>You need to specify specific metadata to restore an Amazon Elastic File System (Amazon
        /// EFS) instance:</para><ul><li><para><code>file-system-id</code>: The ID of the Amazon EFS file system that is backed
        /// up by Backup. Returned in <code>GetRecoveryPointRestoreMetadata</code>.</para></li><li><para><code>Encrypted</code>: A Boolean value that, if true, specifies that the file system
        /// is encrypted. If <code>KmsKeyId</code> is specified, <code>Encrypted</code> must be
        /// set to <code>true</code>.</para></li><li><para><code>KmsKeyId</code>: Specifies the Amazon Web Services KMS key that is used to
        /// encrypt the restored file system. You can specify a key from another Amazon Web Services
        /// account provided that key it is properly shared with your account via Amazon Web Services
        /// KMS.</para></li><li><para><code>PerformanceMode</code>: Specifies the throughput mode of the file system.</para></li><li><para><code>CreationToken</code>: A user-supplied value that ensures the uniqueness (idempotency)
        /// of the request.</para></li><li><para><code>newFileSystem</code>: A Boolean value that, if true, specifies that the recovery
        /// point is restored to a new Amazon EFS file system.</para></li><li><para><code>ItemsToRestore</code>: An array of one to five strings where each string is
        /// a file path. Use <code>ItemsToRestore</code> to restore specific files or directories
        /// rather than the entire file system. This parameter is optional. For example, <code>"itemsToRestore":"[\"/my.test\"]"</code>.</para></li></ul>
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
        /// <para>An ARN that uniquely identifies a recovery point; for example, <code>arn:aws:backup:us-east-1:123456789012:recovery-point:1EB3B5E7-9EB0-435A-A80B-108B488B0D45</code>.</para>
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
        /// <para>Starts a job to restore a recovery point for one of the following resources:</para><ul><li><para><code>Aurora</code> for Amazon Aurora</para></li><li><para><code>DocumentDB</code> for Amazon DocumentDB (with MongoDB compatibility)</para></li><li><para><code>DynamoDB</code> for Amazon DynamoDB</para></li><li><para><code>EBS</code> for Amazon Elastic Block Store</para></li><li><para><code>EC2</code> for Amazon Elastic Compute Cloud</para></li><li><para><code>EFS</code> for Amazon Elastic File System</para></li><li><para><code>FSx</code> for Amazon FSx</para></li><li><para><code>Neptune</code> for Amazon Neptune</para></li><li><para><code>RDS</code> for Amazon Relational Database Service</para></li><li><para><code>Storage Gateway</code> for Storage Gateway</para></li><li><para><code>S3</code> for Amazon S3</para></li><li><para><code>VirtualMachine</code> for virtual machines</para></li></ul>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecoveryPointArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecoveryPointArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecoveryPointArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryPointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKRestoreJob (StartRestoreJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.StartRestoreJobResponse, StartBAKRestoreJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecoveryPointArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IamRoleArn = this.IamRoleArn;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (String)(this.Metadata[hashKey]));
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
