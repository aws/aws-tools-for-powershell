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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Starts a batch job and returns the unique identifier of this execution of the batch
    /// job. The associated application must be running in order to start the batch job.
    /// </summary>
    [Cmdlet("Start", "AMMBatchJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the M2 StartBatchJob API operation.", Operation = new[] {"StartBatchJob"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.StartBatchJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.MainframeModernization.Model.StartBatchJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MainframeModernization.Model.StartBatchJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartAMMBatchJobCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application associated with this batch job.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AuthSecretsManagerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Secrets Manager containing user's credentials for authentication
        /// and authorization for Start Batch Job execution operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthSecretsManagerArn { get; set; }
        #endregion
        
        #region Parameter S3BatchJobIdentifier_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that contains the batch job definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_S3BatchJobIdentifier_Bucket")]
        public System.String S3BatchJobIdentifier_Bucket { get; set; }
        #endregion
        
        #region Parameter RestartBatchJobIdentifier_ExecutionId
        /// <summary>
        /// <para>
        /// <para>The <c>executionId</c> from the <c>StartBatchJob</c> response when the job ran for
        /// the first time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_ExecutionId")]
        public System.String RestartBatchJobIdentifier_ExecutionId { get; set; }
        #endregion
        
        #region Parameter FileBatchJobIdentifier_FileName
        /// <summary>
        /// <para>
        /// <para>The file name for the batch job identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_FileBatchJobIdentifier_FileName")]
        public System.String FileBatchJobIdentifier_FileName { get; set; }
        #endregion
        
        #region Parameter Identifier_FileName
        /// <summary>
        /// <para>
        /// <para>The name of the file that contains the batch job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_S3BatchJobIdentifier_Identifier_FileName")]
        public System.String Identifier_FileName { get; set; }
        #endregion
        
        #region Parameter FileBatchJobIdentifier_FolderPath
        /// <summary>
        /// <para>
        /// <para>The relative path to the file name for the batch job identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_FileBatchJobIdentifier_FolderPath")]
        public System.String FileBatchJobIdentifier_FolderPath { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_FromProcStep
        /// <summary>
        /// <para>
        /// <para>The procedure step name that a batch job was restarted from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_FromProcStep")]
        public System.String JobStepRestartMarker_FromProcStep { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_FromStep
        /// <summary>
        /// <para>
        /// <para>The step name that a batch job was restarted from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_FromStep")]
        public System.String JobStepRestartMarker_FromStep { get; set; }
        #endregion
        
        #region Parameter JobParam
        /// <summary>
        /// <para>
        /// <para>The collection of batch job parameters. For details about limits for keys and values,
        /// see <a href="https://www.ibm.com/docs/en/workload-automation/9.3.0?topic=zos-coding-variables-in-jcl">Coding
        /// variables in JCL</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParams")]
        public System.Collections.Hashtable JobParam { get; set; }
        #endregion
        
        #region Parameter S3BatchJobIdentifier_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The key prefix that specifies the path to the folder in the S3 bucket that has the
        /// batch job definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_S3BatchJobIdentifier_KeyPrefix")]
        public System.String S3BatchJobIdentifier_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Identifier_ScriptName
        /// <summary>
        /// <para>
        /// <para>The name of the script that contains the batch job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_S3BatchJobIdentifier_Identifier_ScriptName")]
        public System.String Identifier_ScriptName { get; set; }
        #endregion
        
        #region Parameter ScriptBatchJobIdentifier_ScriptName
        /// <summary>
        /// <para>
        /// <para>The name of the script containing the batch job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_ScriptBatchJobIdentifier_ScriptName")]
        public System.String ScriptBatchJobIdentifier_ScriptName { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_Skip
        /// <summary>
        /// <para>
        /// <para>The step-level checkpoint timestamp (creation or last modification) for an Amazon
        /// Web Services Blu Age application batch job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_Skip")]
        public System.Boolean? JobStepRestartMarker_Skip { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_StepCheckpoint
        /// <summary>
        /// <para>
        /// <para>Skip selected step and issue a restart from immediate successor step for an Amazon
        /// Web Services Blu Age application batch job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_StepCheckpoint")]
        public System.Int32? JobStepRestartMarker_StepCheckpoint { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_ToProcStep
        /// <summary>
        /// <para>
        /// <para>The procedure step name that a batch job was restarted to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_ToProcStep")]
        public System.String JobStepRestartMarker_ToProcStep { get; set; }
        #endregion
        
        #region Parameter JobStepRestartMarker_ToStep
        /// <summary>
        /// <para>
        /// <para>The step name that a batch job was restarted to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_ToStep")]
        public System.String JobStepRestartMarker_ToStep { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.StartBatchJobResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.StartBatchJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExecutionId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AMMBatchJob (StartBatchJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.StartBatchJobResponse, StartAMMBatchJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthSecretsManagerArn = this.AuthSecretsManagerArn;
            context.FileBatchJobIdentifier_FileName = this.FileBatchJobIdentifier_FileName;
            context.FileBatchJobIdentifier_FolderPath = this.FileBatchJobIdentifier_FolderPath;
            context.RestartBatchJobIdentifier_ExecutionId = this.RestartBatchJobIdentifier_ExecutionId;
            context.JobStepRestartMarker_FromProcStep = this.JobStepRestartMarker_FromProcStep;
            context.JobStepRestartMarker_FromStep = this.JobStepRestartMarker_FromStep;
            context.JobStepRestartMarker_Skip = this.JobStepRestartMarker_Skip;
            context.JobStepRestartMarker_StepCheckpoint = this.JobStepRestartMarker_StepCheckpoint;
            context.JobStepRestartMarker_ToProcStep = this.JobStepRestartMarker_ToProcStep;
            context.JobStepRestartMarker_ToStep = this.JobStepRestartMarker_ToStep;
            context.S3BatchJobIdentifier_Bucket = this.S3BatchJobIdentifier_Bucket;
            context.Identifier_FileName = this.Identifier_FileName;
            context.Identifier_ScriptName = this.Identifier_ScriptName;
            context.S3BatchJobIdentifier_KeyPrefix = this.S3BatchJobIdentifier_KeyPrefix;
            context.ScriptBatchJobIdentifier_ScriptName = this.ScriptBatchJobIdentifier_ScriptName;
            if (this.JobParam != null)
            {
                context.JobParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.JobParam.Keys)
                {
                    context.JobParam.Add((String)hashKey, (System.String)(this.JobParam[hashKey]));
                }
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
            var request = new Amazon.MainframeModernization.Model.StartBatchJobRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AuthSecretsManagerArn != null)
            {
                request.AuthSecretsManagerArn = cmdletContext.AuthSecretsManagerArn;
            }
            
             // populate BatchJobIdentifier
            request.BatchJobIdentifier = new Amazon.MainframeModernization.Model.BatchJobIdentifier();
            Amazon.MainframeModernization.Model.ScriptBatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = null;
            
             // populate ScriptBatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = new Amazon.MainframeModernization.Model.ScriptBatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName = null;
            if (cmdletContext.ScriptBatchJobIdentifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName = cmdletContext.ScriptBatchJobIdentifier_ScriptName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier.ScriptName = requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName;
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.ScriptBatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier;
            }
            Amazon.MainframeModernization.Model.FileBatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = null;
            
             // populate FileBatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = new Amazon.MainframeModernization.Model.FileBatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName = null;
            if (cmdletContext.FileBatchJobIdentifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName = cmdletContext.FileBatchJobIdentifier_FileName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier.FileName = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName;
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath = null;
            if (cmdletContext.FileBatchJobIdentifier_FolderPath != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath = cmdletContext.FileBatchJobIdentifier_FolderPath;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier.FolderPath = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath;
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.FileBatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier;
            }
            Amazon.MainframeModernization.Model.RestartBatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier = null;
            
             // populate RestartBatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier = new Amazon.MainframeModernization.Model.RestartBatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_restartBatchJobIdentifier_ExecutionId = null;
            if (cmdletContext.RestartBatchJobIdentifier_ExecutionId != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_restartBatchJobIdentifier_ExecutionId = cmdletContext.RestartBatchJobIdentifier_ExecutionId;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_restartBatchJobIdentifier_ExecutionId != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier.ExecutionId = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_restartBatchJobIdentifier_ExecutionId;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifierIsNull = false;
            }
            Amazon.MainframeModernization.Model.JobStepRestartMarker requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker = null;
            
             // populate JobStepRestartMarker
            var requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker = new Amazon.MainframeModernization.Model.JobStepRestartMarker();
            System.String requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromProcStep = null;
            if (cmdletContext.JobStepRestartMarker_FromProcStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromProcStep = cmdletContext.JobStepRestartMarker_FromProcStep;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromProcStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.FromProcStep = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromProcStep;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromStep = null;
            if (cmdletContext.JobStepRestartMarker_FromStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromStep = cmdletContext.JobStepRestartMarker_FromStep;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.FromStep = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_FromStep;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
            System.Boolean? requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_Skip = null;
            if (cmdletContext.JobStepRestartMarker_Skip != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_Skip = cmdletContext.JobStepRestartMarker_Skip.Value;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_Skip != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.Skip = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_Skip.Value;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
            System.Int32? requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_StepCheckpoint = null;
            if (cmdletContext.JobStepRestartMarker_StepCheckpoint != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_StepCheckpoint = cmdletContext.JobStepRestartMarker_StepCheckpoint.Value;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_StepCheckpoint != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.StepCheckpoint = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_StepCheckpoint.Value;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToProcStep = null;
            if (cmdletContext.JobStepRestartMarker_ToProcStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToProcStep = cmdletContext.JobStepRestartMarker_ToProcStep;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToProcStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.ToProcStep = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToProcStep;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToStep = null;
            if (cmdletContext.JobStepRestartMarker_ToStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToStep = cmdletContext.JobStepRestartMarker_ToStep;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToStep != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker.ToStep = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker_jobStepRestartMarker_ToStep;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarkerIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier.JobStepRestartMarker = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier_JobStepRestartMarker;
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.RestartBatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_RestartBatchJobIdentifier;
            }
            Amazon.MainframeModernization.Model.S3BatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier = null;
            
             // populate S3BatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier = new Amazon.MainframeModernization.Model.S3BatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_Bucket = null;
            if (cmdletContext.S3BatchJobIdentifier_Bucket != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_Bucket = cmdletContext.S3BatchJobIdentifier_Bucket;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_Bucket != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier.Bucket = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_Bucket;
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifierIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_KeyPrefix = null;
            if (cmdletContext.S3BatchJobIdentifier_KeyPrefix != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_KeyPrefix = cmdletContext.S3BatchJobIdentifier_KeyPrefix;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_KeyPrefix != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier.KeyPrefix = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_s3BatchJobIdentifier_KeyPrefix;
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifierIsNull = false;
            }
            Amazon.MainframeModernization.Model.JobIdentifier requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier = null;
            
             // populate Identifier
            requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier = new Amazon.MainframeModernization.Model.JobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_FileName = null;
            if (cmdletContext.Identifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_FileName = cmdletContext.Identifier_FileName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier.FileName = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_FileName;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_ScriptName = null;
            if (cmdletContext.Identifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_ScriptName = cmdletContext.Identifier_ScriptName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier.ScriptName = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier_identifier_ScriptName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier.Identifier = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier_Identifier;
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.S3BatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_S3BatchJobIdentifier;
            }
            if (cmdletContext.JobParam != null)
            {
                request.JobParams = cmdletContext.JobParam;
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
        
        private Amazon.MainframeModernization.Model.StartBatchJobResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.StartBatchJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "StartBatchJob");
            try
            {
                return client.StartBatchJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String AuthSecretsManagerArn { get; set; }
            public System.String FileBatchJobIdentifier_FileName { get; set; }
            public System.String FileBatchJobIdentifier_FolderPath { get; set; }
            public System.String RestartBatchJobIdentifier_ExecutionId { get; set; }
            public System.String JobStepRestartMarker_FromProcStep { get; set; }
            public System.String JobStepRestartMarker_FromStep { get; set; }
            public System.Boolean? JobStepRestartMarker_Skip { get; set; }
            public System.Int32? JobStepRestartMarker_StepCheckpoint { get; set; }
            public System.String JobStepRestartMarker_ToProcStep { get; set; }
            public System.String JobStepRestartMarker_ToStep { get; set; }
            public System.String S3BatchJobIdentifier_Bucket { get; set; }
            public System.String Identifier_FileName { get; set; }
            public System.String Identifier_ScriptName { get; set; }
            public System.String S3BatchJobIdentifier_KeyPrefix { get; set; }
            public System.String ScriptBatchJobIdentifier_ScriptName { get; set; }
            public Dictionary<System.String, System.String> JobParam { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.StartBatchJobResponse, StartAMMBatchJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExecutionId;
        }
        
    }
}
