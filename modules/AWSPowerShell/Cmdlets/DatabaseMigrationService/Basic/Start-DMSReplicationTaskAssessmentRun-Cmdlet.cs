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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Starts a new premigration assessment run for one or more individual assessments of
    /// a migration task.
    /// 
    ///  
    /// <para>
    /// The assessments that you can specify depend on the source and target database engine
    /// and the migration type defined for the given task. To run this operation, your migration
    /// task must already be created. After you run this operation, you can review the status
    /// of each individual assessment. You can also run the migration task manually after
    /// the assessment run and its individual assessments complete.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DMSReplicationTaskAssessmentRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartReplicationTaskAssessmentRun API operation.", Operation = new[] {"StartReplicationTaskAssessmentRun"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun or Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDMSReplicationTaskAssessmentRunCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentRunName
        /// <summary>
        /// <para>
        /// <para>Unique name to identify the assessment run.</para>
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
        public System.String AssessmentRunName { get; set; }
        #endregion
        
        #region Parameter Exclude
        /// <summary>
        /// <para>
        /// <para>Space-separated list of names for specific individual assessments that you want to
        /// exclude. These names come from the default list of individual assessments that DMS
        /// supports for the associated migration task. This task is specified by <c>ReplicationTaskArn</c>.</para><note><para>You can't set a value for <c>Exclude</c> if you also set a value for <c>IncludeOnly</c>
        /// in the API operation.</para><para>To identify the names of the default individual assessments that DMS supports for
        /// the associated migration task, run the <c>DescribeApplicableIndividualAssessments</c>
        /// operation using its own <c>ReplicationTaskArn</c> request parameter.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Exclude { get; set; }
        #endregion
        
        #region Parameter IncludeOnly
        /// <summary>
        /// <para>
        /// <para>Space-separated list of names for specific individual assessments that you want to
        /// include. These names come from the default list of individual assessments that DMS
        /// supports for the associated migration task. This task is specified by <c>ReplicationTaskArn</c>.</para><note><para>You can't set a value for <c>IncludeOnly</c> if you also set a value for <c>Exclude</c>
        /// in the API operation. </para><para>To identify the names of the default individual assessments that DMS supports for
        /// the associated migration task, run the <c>DescribeApplicableIndividualAssessments</c>
        /// operation using its own <c>ReplicationTaskArn</c> request parameter.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] IncludeOnly { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the migration task associated with the premigration
        /// assessment run that you want to start.</para>
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
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter ResultEncryptionMode
        /// <summary>
        /// <para>
        /// <para>Encryption mode that you can specify to encrypt the results of this assessment run.
        /// If you don't specify this request parameter, DMS stores the assessment run results
        /// without encryption. You can specify one of the options following:</para><ul><li><para><c>"SSE_S3"</c> – The server-side encryption provided as a default by Amazon S3.</para></li><li><para><c>"SSE_KMS"</c> – Key Management Service (KMS) encryption. This encryption can use
        /// either a custom KMS encryption key that you specify or the default KMS encryption
        /// key that DMS provides.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultEncryptionMode { get; set; }
        #endregion
        
        #region Parameter ResultKmsKeyArn
        /// <summary>
        /// <para>
        /// <para>ARN of a custom KMS encryption key that you specify when you set <c>ResultEncryptionMode</c>
        /// to <c>"SSE_KMS</c>".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultKmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ResultLocationBucket
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket where you want DMS to store the results of this assessment run.</para>
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
        public System.String ResultLocationBucket { get; set; }
        #endregion
        
        #region Parameter ResultLocationFolder
        /// <summary>
        /// <para>
        /// <para>Folder within an Amazon S3 bucket where you want DMS to store the results of this
        /// assessment run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultLocationFolder { get; set; }
        #endregion
        
        #region Parameter ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the service role needed to start the assessment run. The role must allow the
        /// <c>iam:PassRole</c> action.</para>
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
        public System.String ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to be assigned to the premigration assessment run that you want to
        /// start.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationTaskAssessmentRun'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationTaskAssessmentRun";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssessmentRunName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSReplicationTaskAssessmentRun (StartReplicationTaskAssessmentRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse, StartDMSReplicationTaskAssessmentRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentRunName = this.AssessmentRunName;
            #if MODULAR
            if (this.AssessmentRunName == null && ParameterWasBound(nameof(this.AssessmentRunName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentRunName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Exclude != null)
            {
                context.Exclude = new List<System.String>(this.Exclude);
            }
            if (this.IncludeOnly != null)
            {
                context.IncludeOnly = new List<System.String>(this.IncludeOnly);
            }
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            #if MODULAR
            if (this.ReplicationTaskArn == null && ParameterWasBound(nameof(this.ReplicationTaskArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationTaskArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResultEncryptionMode = this.ResultEncryptionMode;
            context.ResultKmsKeyArn = this.ResultKmsKeyArn;
            context.ResultLocationBucket = this.ResultLocationBucket;
            #if MODULAR
            if (this.ResultLocationBucket == null && ParameterWasBound(nameof(this.ResultLocationBucket)))
            {
                WriteWarning("You are passing $null as a value for parameter ResultLocationBucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResultLocationFolder = this.ResultLocationFolder;
            context.ServiceAccessRoleArn = this.ServiceAccessRoleArn;
            #if MODULAR
            if (this.ServiceAccessRoleArn == null && ParameterWasBound(nameof(this.ServiceAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunRequest();
            
            if (cmdletContext.AssessmentRunName != null)
            {
                request.AssessmentRunName = cmdletContext.AssessmentRunName;
            }
            if (cmdletContext.Exclude != null)
            {
                request.Exclude = cmdletContext.Exclude;
            }
            if (cmdletContext.IncludeOnly != null)
            {
                request.IncludeOnly = cmdletContext.IncludeOnly;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
            }
            if (cmdletContext.ResultEncryptionMode != null)
            {
                request.ResultEncryptionMode = cmdletContext.ResultEncryptionMode;
            }
            if (cmdletContext.ResultKmsKeyArn != null)
            {
                request.ResultKmsKeyArn = cmdletContext.ResultKmsKeyArn;
            }
            if (cmdletContext.ResultLocationBucket != null)
            {
                request.ResultLocationBucket = cmdletContext.ResultLocationBucket;
            }
            if (cmdletContext.ResultLocationFolder != null)
            {
                request.ResultLocationFolder = cmdletContext.ResultLocationFolder;
            }
            if (cmdletContext.ServiceAccessRoleArn != null)
            {
                request.ServiceAccessRoleArn = cmdletContext.ServiceAccessRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartReplicationTaskAssessmentRun");
            try
            {
                return client.StartReplicationTaskAssessmentRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentRunName { get; set; }
            public List<System.String> Exclude { get; set; }
            public List<System.String> IncludeOnly { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public System.String ResultEncryptionMode { get; set; }
            public System.String ResultKmsKeyArn { get; set; }
            public System.String ResultLocationBucket { get; set; }
            public System.String ResultLocationFolder { get; set; }
            public System.String ServiceAccessRoleArn { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartReplicationTaskAssessmentRunResponse, StartDMSReplicationTaskAssessmentRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationTaskAssessmentRun;
        }
        
    }
}
