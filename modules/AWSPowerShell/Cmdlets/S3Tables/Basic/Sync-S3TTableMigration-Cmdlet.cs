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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Migrates the changes in the source table since the previous start or sync, such as
    /// added and deleted source objects, into the destination table. The sync runs asynchronously:
    /// this operation returns the migration ID of the sync and its initial state, and you
    /// track progress with <c>GetTableMigration</c>.
    /// 
    ///  
    /// <para>
    /// A sync uses the source, destination and data migration settings of the table's migration,
    /// and plans the work and writes its reports in the same way as <c>StartTableMigration</c>.
    /// You can sync after a start or sync that succeeded, failed or was cancelled, if an
    /// earlier start or sync of the table has a valid plan (<c>hasValidPlan</c>). You can't
    /// sync a table while a start or sync is in progress for it, and you can sync a table
    /// until you call <c>CompleteTableMigration</c> for it. If a source object that an earlier
    /// migration migrated has since been overwritten, the sync fails.
    /// </para><dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:SyncTableMigration</c> permission to use this operation.
    /// </para></li><li><para>
    /// You must have the <c>iam:PassRole</c> permission on the role that you specify in <c>roleARN</c>,
    /// with a condition that allows passing it to <c>migration.s3tables.amazonaws.com</c>.
    /// The associated resource is the table.
    /// </para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Sync", "S3TTableMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.SyncTableMigrationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables SyncTableMigration API operation.", Operation = new[] {"SyncTableMigration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.SyncTableMigrationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.SyncTableMigrationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.SyncTableMigrationResponse object containing multiple properties."
    )]
    public partial class SyncS3TTableMigrationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationOutput_Bucket
        /// <summary>
        /// <para>
        /// <para>The general purpose bucket that the migration writes every report to.</para>
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
        public System.String MigrationOutput_Bucket { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_ObjectCompatibilityReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the object compatibility report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_ObjectCompatibilityReport { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_ObjectMigrationReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the object migration report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_ObjectMigrationReport { get; set; }
        #endregion
        
        #region Parameter ReviewMigrationPlan
        /// <summary>
        /// <para>
        /// <para>Specifies whether the sync waits in the <c>pendingReview</c> state, so that you can
        /// review the compatibility reports before it migrates any data. If <c>true</c>, the
        /// migration continues when you call <c>UpdateTableMigration</c> with <c>requestedState</c>
        /// set to <c>queued</c>. If you don't continue or cancel the migration within 30 days,
        /// the migration fails. The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReviewMigrationPlan { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the sync uses to read the source
        /// table and its data and to write the destination table and the reports. The role must
        /// be in your account, and its trust policy must allow <c>migration.s3tables.amazonaws.com</c>
        /// to assume it. You can limit the trust policy to the destination table bucket with
        /// the <c>aws:SourceArn</c> and <c>aws:SourceAccount</c> condition keys.</para>
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
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter TableARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination table to sync. The table must have
        /// a migration, and you must not have called <c>CompleteTableMigration</c> for it.</para>
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
        public System.String TableARN { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_TableCompatibilityReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the table compatibility report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_TableCompatibilityReport { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.SyncTableMigrationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.SyncTableMigrationResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.RoleARN),
                nameof(this.TableARN)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Sync-S3TTableMigration (SyncTableMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.SyncTableMigrationResponse, SyncS3TTableMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MigrationOutput_Bucket = this.MigrationOutput_Bucket;
            #if MODULAR
            if (this.MigrationOutput_Bucket == null && ParameterWasBound(nameof(this.MigrationOutput_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationOutput_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MigrationOutput_Prefixes_ObjectCompatibilityReport = this.MigrationOutput_Prefixes_ObjectCompatibilityReport;
            context.MigrationOutput_Prefixes_ObjectMigrationReport = this.MigrationOutput_Prefixes_ObjectMigrationReport;
            context.MigrationOutput_Prefixes_TableCompatibilityReport = this.MigrationOutput_Prefixes_TableCompatibilityReport;
            context.ReviewMigrationPlan = this.ReviewMigrationPlan;
            context.RoleARN = this.RoleARN;
            #if MODULAR
            if (this.RoleARN == null && ParameterWasBound(nameof(this.RoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableARN = this.TableARN;
            #if MODULAR
            if (this.TableARN == null && ParameterWasBound(nameof(this.TableARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.SyncTableMigrationRequest();
            
            
             // populate MigrationOutput
            var requestMigrationOutputIsNull = true;
            request.MigrationOutput = new Amazon.S3Tables.Model.MigrationOutputConfiguration();
            System.String requestMigrationOutput_migrationOutput_Bucket = null;
            if (cmdletContext.MigrationOutput_Bucket != null)
            {
                requestMigrationOutput_migrationOutput_Bucket = cmdletContext.MigrationOutput_Bucket;
            }
            if (requestMigrationOutput_migrationOutput_Bucket != null)
            {
                request.MigrationOutput.Bucket = requestMigrationOutput_migrationOutput_Bucket;
                requestMigrationOutputIsNull = false;
            }
            Amazon.S3Tables.Model.MigrationReportPrefixes requestMigrationOutput_migrationOutput_Prefixes = null;
            
             // populate Prefixes
            var requestMigrationOutput_migrationOutput_PrefixesIsNull = true;
            requestMigrationOutput_migrationOutput_Prefixes = new Amazon.S3Tables.Model.MigrationReportPrefixes();
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_ObjectCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport = cmdletContext.MigrationOutput_Prefixes_ObjectCompatibilityReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.ObjectCompatibilityReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_ObjectMigrationReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport = cmdletContext.MigrationOutput_Prefixes_ObjectMigrationReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.ObjectMigrationReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_TableCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport = cmdletContext.MigrationOutput_Prefixes_TableCompatibilityReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.TableCompatibilityReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
             // determine if requestMigrationOutput_migrationOutput_Prefixes should be set to null
            if (requestMigrationOutput_migrationOutput_PrefixesIsNull)
            {
                requestMigrationOutput_migrationOutput_Prefixes = null;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes != null)
            {
                request.MigrationOutput.Prefixes = requestMigrationOutput_migrationOutput_Prefixes;
                requestMigrationOutputIsNull = false;
            }
             // determine if request.MigrationOutput should be set to null
            if (requestMigrationOutputIsNull)
            {
                request.MigrationOutput = null;
            }
            if (cmdletContext.ReviewMigrationPlan != null)
            {
                request.ReviewMigrationPlan = cmdletContext.ReviewMigrationPlan.Value;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.TableARN != null)
            {
                request.TableARN = cmdletContext.TableARN;
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
        
        private Amazon.S3Tables.Model.SyncTableMigrationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.SyncTableMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "SyncTableMigration");
            try
            {
                return client.SyncTableMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MigrationOutput_Bucket { get; set; }
            public System.String MigrationOutput_Prefixes_ObjectCompatibilityReport { get; set; }
            public System.String MigrationOutput_Prefixes_ObjectMigrationReport { get; set; }
            public System.String MigrationOutput_Prefixes_TableCompatibilityReport { get; set; }
            public System.Boolean? ReviewMigrationPlan { get; set; }
            public System.String RoleARN { get; set; }
            public System.String TableARN { get; set; }
            public System.Func<Amazon.S3Tables.Model.SyncTableMigrationResponse, SyncS3TTableMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
