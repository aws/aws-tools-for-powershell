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
using Amazon.Omics;
using Amazon.Omics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Starts a batch of workflow runs. You can group up to 100,000 runs into a single batch
    /// that share a common configuration defined in <c>defaultRunSetting</c>. Per-run overrides
    /// can be provided either inline via <c>inlineSettings</c> (up to 100 runs) or via a
    /// JSON file stored in Amazon S3 via <c>s3UriSettings</c> (up to 100,000 runs).
    /// 
    ///  
    /// <para><c>StartRunBatch</c> validates common fields synchronously and returns immediately
    /// with a batch ID and status <c>CREATING</c>. The batch transitions to <c>PENDING</c>
    /// once initial setup completes. Runs are then submitted gradually and asynchronously
    /// at a rate governed by your <c>StartRun</c> throughput quota.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "OMICSRunBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.StartRunBatchResponse")]
    [AWSCmdlet("Calls the Amazon Omics StartRunBatch API operation.", Operation = new[] {"StartRunBatch"}, SelectReturnType = typeof(Amazon.Omics.Model.StartRunBatchResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.StartRunBatchResponse",
        "This cmdlet returns an Amazon.Omics.Model.StartRunBatchResponse object containing multiple properties."
    )]
    public partial class StartOMICSRunBatchCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BatchName
        /// <summary>
        /// <para>
        /// <para>An optional user-friendly name for the run batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BatchName { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_CacheBehavior
        /// <summary>
        /// <para>
        /// <para>The cache behavior for the runs. Requires <c>cacheId</c> to be set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.CacheBehavior")]
        public Amazon.Omics.CacheBehavior DefaultRunSetting_CacheBehavior { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_CacheId
        /// <summary>
        /// <para>
        /// <para>The identifier of the run cache to associate with the runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_CacheId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_ConfigurationName
        /// <summary>
        /// <para>
        /// <para>Optional configuration name to use for the workflow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_ConfigurationName { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_EngineSetting
        /// <summary>
        /// <para>
        /// <para>Engine-specific settings for the workflow run. Use this field to specify configuration
        /// options that are specific to the workflow engine (for example, Nextflow profiles).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultRunSetting_EngineSettings")]
        public System.Management.Automation.PSObject DefaultRunSetting_EngineSetting { get; set; }
        #endregion
        
        #region Parameter BatchRunSettings_InlineSetting
        /// <summary>
        /// <para>
        /// <para>A list of per-run configurations provided inline in the request. Each entry must include
        /// a unique <c>runSettingId</c>. Supports up to 100 entries. For batches with more than
        /// 100 runs, use <c>s3UriSettings</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchRunSettings_InlineSettings")]
        public Amazon.Omics.Model.InlineSetting[] BatchRunSettings_InlineSetting { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_LogLevel
        /// <summary>
        /// <para>
        /// <para>The verbosity level for CloudWatch Logs emitted during each run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.RunLogLevel")]
        public Amazon.Omics.RunLogLevel DefaultRunSetting_LogLevel { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_Name
        /// <summary>
        /// <para>
        /// <para>An optional user-friendly name applied to each workflow run. Can be overridden per
        /// run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_Name { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_NetworkingMode
        /// <summary>
        /// <para>
        /// <para>Optional configuration for run networking behavior. If not specified, this will default
        /// to RESTRICTED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.NetworkingMode")]
        public Amazon.Omics.NetworkingMode DefaultRunSetting_NetworkingMode { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_OutputBucketOwnerId
        /// <summary>
        /// <para>
        /// <para>The expected AWS account ID of the owner of the output S3 bucket. Can be overridden
        /// per run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_OutputBucketOwnerId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_OutputUri
        /// <summary>
        /// <para>
        /// <para>The destination S3 URI for workflow outputs. Must begin with <c>s3://</c>. The <c>roleArn</c>
        /// must grant write permissions to this bucket. Can be overridden per run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_OutputUri { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_Parameter
        /// <summary>
        /// <para>
        /// <para>Workflow parameter names and values shared across all runs. Merged with per-run parameters;
        /// run-specific values take precedence when keys overlap. Can be overridden per run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultRunSetting_Parameters")]
        public System.Management.Automation.PSObject DefaultRunSetting_Parameter { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_Priority
        /// <summary>
        /// <para>
        /// <para>An integer priority for the workflow runs. Higher values correspond to higher priority.
        /// A value of 0 corresponds to the lowest priority. Can be overridden per run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultRunSetting_Priority { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>A client token used to deduplicate retry requests and prevent duplicate batches from
        /// being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_RetentionMode
        /// <summary>
        /// <para>
        /// <para>The retention behavior for runs after completion.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.RunRetentionMode")]
        public Amazon.Omics.RunRetentionMode DefaultRunSetting_RetentionMode { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that grants HealthOmics permissions to access required AWS resources
        /// such as Amazon S3 and CloudWatch. The role must have the same permissions required
        /// for individual <c>StartRun</c> calls.</para>
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
        public System.String DefaultRunSetting_RoleArn { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_RunGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the run group to contain all workflow runs in the batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_RunGroupId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_RunTag
        /// <summary>
        /// <para>
        /// <para>AWS tags to associate with each workflow run. Merged with per-run <c>runTags</c>;
        /// run-specific values take precedence when keys overlap.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultRunSetting_RunTags")]
        public System.Collections.Hashtable DefaultRunSetting_RunTag { get; set; }
        #endregion
        
        #region Parameter BatchRunSettings_S3UriSetting
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI pointing to a JSON file containing per-run configurations. The file
        /// must be a JSON array in the same format as <c>inlineSettings</c>. Supports up to 100,000
        /// run configurations. The maximum file size is 6 GB.</para><para>The IAM service role in <c>roleArn</c> must have read access to this S3 object. HealthOmics
        /// validates access to the file during the synchronous API call and records the file's
        /// ETag. If the file is modified after submission, the batch fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchRunSettings_S3UriSettings")]
        public System.String BatchRunSettings_S3UriSetting { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The filesystem size in gibibytes (GiB) provisioned for each workflow run and shared
        /// by all tasks in that run. Defaults to 1200 GiB if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultRunSetting_StorageCapacity { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type for the workflow runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.StorageType")]
        public Amazon.Omics.StorageType DefaultRunSetting_StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>AWS tags to associate with the batch resource. These tags are not inherited by individual
        /// runs. To tag individual runs, use <c>defaultRunSetting.runTags</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the workflow to run.</para>
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
        public System.String DefaultRunSetting_WorkflowId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_WorkflowOwnerId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the workflow owner, used for cross-account workflow sharing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_WorkflowOwnerId { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_WorkflowType
        /// <summary>
        /// <para>
        /// <para>The type of the originating workflow. Batch runs are not supported with <c>READY2RUN</c>
        /// workflows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.WorkflowType")]
        public Amazon.Omics.WorkflowType DefaultRunSetting_WorkflowType { get; set; }
        #endregion
        
        #region Parameter DefaultRunSetting_WorkflowVersionName
        /// <summary>
        /// <para>
        /// <para>The version name of the specified workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRunSetting_WorkflowVersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.StartRunBatchResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.StartRunBatchResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OMICSRunBatch (StartRunBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.StartRunBatchResponse, StartOMICSRunBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BatchName = this.BatchName;
            if (this.BatchRunSettings_InlineSetting != null)
            {
                context.BatchRunSettings_InlineSetting = new List<Amazon.Omics.Model.InlineSetting>(this.BatchRunSettings_InlineSetting);
            }
            context.BatchRunSettings_S3UriSetting = this.BatchRunSettings_S3UriSetting;
            context.DefaultRunSetting_CacheBehavior = this.DefaultRunSetting_CacheBehavior;
            context.DefaultRunSetting_CacheId = this.DefaultRunSetting_CacheId;
            context.DefaultRunSetting_ConfigurationName = this.DefaultRunSetting_ConfigurationName;
            context.DefaultRunSetting_EngineSetting = this.DefaultRunSetting_EngineSetting;
            context.DefaultRunSetting_LogLevel = this.DefaultRunSetting_LogLevel;
            context.DefaultRunSetting_Name = this.DefaultRunSetting_Name;
            context.DefaultRunSetting_NetworkingMode = this.DefaultRunSetting_NetworkingMode;
            context.DefaultRunSetting_OutputBucketOwnerId = this.DefaultRunSetting_OutputBucketOwnerId;
            context.DefaultRunSetting_OutputUri = this.DefaultRunSetting_OutputUri;
            context.DefaultRunSetting_Parameter = this.DefaultRunSetting_Parameter;
            context.DefaultRunSetting_Priority = this.DefaultRunSetting_Priority;
            context.DefaultRunSetting_RetentionMode = this.DefaultRunSetting_RetentionMode;
            context.DefaultRunSetting_RoleArn = this.DefaultRunSetting_RoleArn;
            #if MODULAR
            if (this.DefaultRunSetting_RoleArn == null && ParameterWasBound(nameof(this.DefaultRunSetting_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultRunSetting_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultRunSetting_RunGroupId = this.DefaultRunSetting_RunGroupId;
            if (this.DefaultRunSetting_RunTag != null)
            {
                context.DefaultRunSetting_RunTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultRunSetting_RunTag.Keys)
                {
                    context.DefaultRunSetting_RunTag.Add((String)hashKey, (System.String)(this.DefaultRunSetting_RunTag[hashKey]));
                }
            }
            context.DefaultRunSetting_StorageCapacity = this.DefaultRunSetting_StorageCapacity;
            context.DefaultRunSetting_StorageType = this.DefaultRunSetting_StorageType;
            context.DefaultRunSetting_WorkflowId = this.DefaultRunSetting_WorkflowId;
            #if MODULAR
            if (this.DefaultRunSetting_WorkflowId == null && ParameterWasBound(nameof(this.DefaultRunSetting_WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultRunSetting_WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultRunSetting_WorkflowOwnerId = this.DefaultRunSetting_WorkflowOwnerId;
            context.DefaultRunSetting_WorkflowType = this.DefaultRunSetting_WorkflowType;
            context.DefaultRunSetting_WorkflowVersionName = this.DefaultRunSetting_WorkflowVersionName;
            context.RequestId = this.RequestId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.Omics.Model.StartRunBatchRequest();
            
            if (cmdletContext.BatchName != null)
            {
                request.BatchName = cmdletContext.BatchName;
            }
            
             // populate BatchRunSettings
            var requestBatchRunSettingsIsNull = true;
            request.BatchRunSettings = new Amazon.Omics.Model.BatchRunSettings();
            List<Amazon.Omics.Model.InlineSetting> requestBatchRunSettings_batchRunSettings_InlineSetting = null;
            if (cmdletContext.BatchRunSettings_InlineSetting != null)
            {
                requestBatchRunSettings_batchRunSettings_InlineSetting = cmdletContext.BatchRunSettings_InlineSetting;
            }
            if (requestBatchRunSettings_batchRunSettings_InlineSetting != null)
            {
                request.BatchRunSettings.InlineSettings = requestBatchRunSettings_batchRunSettings_InlineSetting;
                requestBatchRunSettingsIsNull = false;
            }
            System.String requestBatchRunSettings_batchRunSettings_S3UriSetting = null;
            if (cmdletContext.BatchRunSettings_S3UriSetting != null)
            {
                requestBatchRunSettings_batchRunSettings_S3UriSetting = cmdletContext.BatchRunSettings_S3UriSetting;
            }
            if (requestBatchRunSettings_batchRunSettings_S3UriSetting != null)
            {
                request.BatchRunSettings.S3UriSettings = requestBatchRunSettings_batchRunSettings_S3UriSetting;
                requestBatchRunSettingsIsNull = false;
            }
             // determine if request.BatchRunSettings should be set to null
            if (requestBatchRunSettingsIsNull)
            {
                request.BatchRunSettings = null;
            }
            
             // populate DefaultRunSetting
            var requestDefaultRunSettingIsNull = true;
            request.DefaultRunSetting = new Amazon.Omics.Model.DefaultRunSetting();
            Amazon.Omics.CacheBehavior requestDefaultRunSetting_defaultRunSetting_CacheBehavior = null;
            if (cmdletContext.DefaultRunSetting_CacheBehavior != null)
            {
                requestDefaultRunSetting_defaultRunSetting_CacheBehavior = cmdletContext.DefaultRunSetting_CacheBehavior;
            }
            if (requestDefaultRunSetting_defaultRunSetting_CacheBehavior != null)
            {
                request.DefaultRunSetting.CacheBehavior = requestDefaultRunSetting_defaultRunSetting_CacheBehavior;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_CacheId = null;
            if (cmdletContext.DefaultRunSetting_CacheId != null)
            {
                requestDefaultRunSetting_defaultRunSetting_CacheId = cmdletContext.DefaultRunSetting_CacheId;
            }
            if (requestDefaultRunSetting_defaultRunSetting_CacheId != null)
            {
                request.DefaultRunSetting.CacheId = requestDefaultRunSetting_defaultRunSetting_CacheId;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_ConfigurationName = null;
            if (cmdletContext.DefaultRunSetting_ConfigurationName != null)
            {
                requestDefaultRunSetting_defaultRunSetting_ConfigurationName = cmdletContext.DefaultRunSetting_ConfigurationName;
            }
            if (requestDefaultRunSetting_defaultRunSetting_ConfigurationName != null)
            {
                request.DefaultRunSetting.ConfigurationName = requestDefaultRunSetting_defaultRunSetting_ConfigurationName;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestDefaultRunSetting_defaultRunSetting_EngineSetting = null;
            if (cmdletContext.DefaultRunSetting_EngineSetting != null)
            {
                requestDefaultRunSetting_defaultRunSetting_EngineSetting = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.DefaultRunSetting_EngineSetting);
            }
            if (requestDefaultRunSetting_defaultRunSetting_EngineSetting != null)
            {
                request.DefaultRunSetting.EngineSettings = requestDefaultRunSetting_defaultRunSetting_EngineSetting.Value;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Omics.RunLogLevel requestDefaultRunSetting_defaultRunSetting_LogLevel = null;
            if (cmdletContext.DefaultRunSetting_LogLevel != null)
            {
                requestDefaultRunSetting_defaultRunSetting_LogLevel = cmdletContext.DefaultRunSetting_LogLevel;
            }
            if (requestDefaultRunSetting_defaultRunSetting_LogLevel != null)
            {
                request.DefaultRunSetting.LogLevel = requestDefaultRunSetting_defaultRunSetting_LogLevel;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_Name = null;
            if (cmdletContext.DefaultRunSetting_Name != null)
            {
                requestDefaultRunSetting_defaultRunSetting_Name = cmdletContext.DefaultRunSetting_Name;
            }
            if (requestDefaultRunSetting_defaultRunSetting_Name != null)
            {
                request.DefaultRunSetting.Name = requestDefaultRunSetting_defaultRunSetting_Name;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Omics.NetworkingMode requestDefaultRunSetting_defaultRunSetting_NetworkingMode = null;
            if (cmdletContext.DefaultRunSetting_NetworkingMode != null)
            {
                requestDefaultRunSetting_defaultRunSetting_NetworkingMode = cmdletContext.DefaultRunSetting_NetworkingMode;
            }
            if (requestDefaultRunSetting_defaultRunSetting_NetworkingMode != null)
            {
                request.DefaultRunSetting.NetworkingMode = requestDefaultRunSetting_defaultRunSetting_NetworkingMode;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_OutputBucketOwnerId = null;
            if (cmdletContext.DefaultRunSetting_OutputBucketOwnerId != null)
            {
                requestDefaultRunSetting_defaultRunSetting_OutputBucketOwnerId = cmdletContext.DefaultRunSetting_OutputBucketOwnerId;
            }
            if (requestDefaultRunSetting_defaultRunSetting_OutputBucketOwnerId != null)
            {
                request.DefaultRunSetting.OutputBucketOwnerId = requestDefaultRunSetting_defaultRunSetting_OutputBucketOwnerId;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_OutputUri = null;
            if (cmdletContext.DefaultRunSetting_OutputUri != null)
            {
                requestDefaultRunSetting_defaultRunSetting_OutputUri = cmdletContext.DefaultRunSetting_OutputUri;
            }
            if (requestDefaultRunSetting_defaultRunSetting_OutputUri != null)
            {
                request.DefaultRunSetting.OutputUri = requestDefaultRunSetting_defaultRunSetting_OutputUri;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestDefaultRunSetting_defaultRunSetting_Parameter = null;
            if (cmdletContext.DefaultRunSetting_Parameter != null)
            {
                requestDefaultRunSetting_defaultRunSetting_Parameter = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.DefaultRunSetting_Parameter);
            }
            if (requestDefaultRunSetting_defaultRunSetting_Parameter != null)
            {
                request.DefaultRunSetting.Parameters = requestDefaultRunSetting_defaultRunSetting_Parameter.Value;
                requestDefaultRunSettingIsNull = false;
            }
            System.Int32? requestDefaultRunSetting_defaultRunSetting_Priority = null;
            if (cmdletContext.DefaultRunSetting_Priority != null)
            {
                requestDefaultRunSetting_defaultRunSetting_Priority = cmdletContext.DefaultRunSetting_Priority.Value;
            }
            if (requestDefaultRunSetting_defaultRunSetting_Priority != null)
            {
                request.DefaultRunSetting.Priority = requestDefaultRunSetting_defaultRunSetting_Priority.Value;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Omics.RunRetentionMode requestDefaultRunSetting_defaultRunSetting_RetentionMode = null;
            if (cmdletContext.DefaultRunSetting_RetentionMode != null)
            {
                requestDefaultRunSetting_defaultRunSetting_RetentionMode = cmdletContext.DefaultRunSetting_RetentionMode;
            }
            if (requestDefaultRunSetting_defaultRunSetting_RetentionMode != null)
            {
                request.DefaultRunSetting.RetentionMode = requestDefaultRunSetting_defaultRunSetting_RetentionMode;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_RoleArn = null;
            if (cmdletContext.DefaultRunSetting_RoleArn != null)
            {
                requestDefaultRunSetting_defaultRunSetting_RoleArn = cmdletContext.DefaultRunSetting_RoleArn;
            }
            if (requestDefaultRunSetting_defaultRunSetting_RoleArn != null)
            {
                request.DefaultRunSetting.RoleArn = requestDefaultRunSetting_defaultRunSetting_RoleArn;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_RunGroupId = null;
            if (cmdletContext.DefaultRunSetting_RunGroupId != null)
            {
                requestDefaultRunSetting_defaultRunSetting_RunGroupId = cmdletContext.DefaultRunSetting_RunGroupId;
            }
            if (requestDefaultRunSetting_defaultRunSetting_RunGroupId != null)
            {
                request.DefaultRunSetting.RunGroupId = requestDefaultRunSetting_defaultRunSetting_RunGroupId;
                requestDefaultRunSettingIsNull = false;
            }
            Dictionary<System.String, System.String> requestDefaultRunSetting_defaultRunSetting_RunTag = null;
            if (cmdletContext.DefaultRunSetting_RunTag != null)
            {
                requestDefaultRunSetting_defaultRunSetting_RunTag = cmdletContext.DefaultRunSetting_RunTag;
            }
            if (requestDefaultRunSetting_defaultRunSetting_RunTag != null)
            {
                request.DefaultRunSetting.RunTags = requestDefaultRunSetting_defaultRunSetting_RunTag;
                requestDefaultRunSettingIsNull = false;
            }
            System.Int32? requestDefaultRunSetting_defaultRunSetting_StorageCapacity = null;
            if (cmdletContext.DefaultRunSetting_StorageCapacity != null)
            {
                requestDefaultRunSetting_defaultRunSetting_StorageCapacity = cmdletContext.DefaultRunSetting_StorageCapacity.Value;
            }
            if (requestDefaultRunSetting_defaultRunSetting_StorageCapacity != null)
            {
                request.DefaultRunSetting.StorageCapacity = requestDefaultRunSetting_defaultRunSetting_StorageCapacity.Value;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Omics.StorageType requestDefaultRunSetting_defaultRunSetting_StorageType = null;
            if (cmdletContext.DefaultRunSetting_StorageType != null)
            {
                requestDefaultRunSetting_defaultRunSetting_StorageType = cmdletContext.DefaultRunSetting_StorageType;
            }
            if (requestDefaultRunSetting_defaultRunSetting_StorageType != null)
            {
                request.DefaultRunSetting.StorageType = requestDefaultRunSetting_defaultRunSetting_StorageType;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_WorkflowId = null;
            if (cmdletContext.DefaultRunSetting_WorkflowId != null)
            {
                requestDefaultRunSetting_defaultRunSetting_WorkflowId = cmdletContext.DefaultRunSetting_WorkflowId;
            }
            if (requestDefaultRunSetting_defaultRunSetting_WorkflowId != null)
            {
                request.DefaultRunSetting.WorkflowId = requestDefaultRunSetting_defaultRunSetting_WorkflowId;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_WorkflowOwnerId = null;
            if (cmdletContext.DefaultRunSetting_WorkflowOwnerId != null)
            {
                requestDefaultRunSetting_defaultRunSetting_WorkflowOwnerId = cmdletContext.DefaultRunSetting_WorkflowOwnerId;
            }
            if (requestDefaultRunSetting_defaultRunSetting_WorkflowOwnerId != null)
            {
                request.DefaultRunSetting.WorkflowOwnerId = requestDefaultRunSetting_defaultRunSetting_WorkflowOwnerId;
                requestDefaultRunSettingIsNull = false;
            }
            Amazon.Omics.WorkflowType requestDefaultRunSetting_defaultRunSetting_WorkflowType = null;
            if (cmdletContext.DefaultRunSetting_WorkflowType != null)
            {
                requestDefaultRunSetting_defaultRunSetting_WorkflowType = cmdletContext.DefaultRunSetting_WorkflowType;
            }
            if (requestDefaultRunSetting_defaultRunSetting_WorkflowType != null)
            {
                request.DefaultRunSetting.WorkflowType = requestDefaultRunSetting_defaultRunSetting_WorkflowType;
                requestDefaultRunSettingIsNull = false;
            }
            System.String requestDefaultRunSetting_defaultRunSetting_WorkflowVersionName = null;
            if (cmdletContext.DefaultRunSetting_WorkflowVersionName != null)
            {
                requestDefaultRunSetting_defaultRunSetting_WorkflowVersionName = cmdletContext.DefaultRunSetting_WorkflowVersionName;
            }
            if (requestDefaultRunSetting_defaultRunSetting_WorkflowVersionName != null)
            {
                request.DefaultRunSetting.WorkflowVersionName = requestDefaultRunSetting_defaultRunSetting_WorkflowVersionName;
                requestDefaultRunSettingIsNull = false;
            }
             // determine if request.DefaultRunSetting should be set to null
            if (requestDefaultRunSettingIsNull)
            {
                request.DefaultRunSetting = null;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
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
        
        private Amazon.Omics.Model.StartRunBatchResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.StartRunBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "StartRunBatch");
            try
            {
                return client.StartRunBatchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BatchName { get; set; }
            public List<Amazon.Omics.Model.InlineSetting> BatchRunSettings_InlineSetting { get; set; }
            public System.String BatchRunSettings_S3UriSetting { get; set; }
            public Amazon.Omics.CacheBehavior DefaultRunSetting_CacheBehavior { get; set; }
            public System.String DefaultRunSetting_CacheId { get; set; }
            public System.String DefaultRunSetting_ConfigurationName { get; set; }
            public System.Management.Automation.PSObject DefaultRunSetting_EngineSetting { get; set; }
            public Amazon.Omics.RunLogLevel DefaultRunSetting_LogLevel { get; set; }
            public System.String DefaultRunSetting_Name { get; set; }
            public Amazon.Omics.NetworkingMode DefaultRunSetting_NetworkingMode { get; set; }
            public System.String DefaultRunSetting_OutputBucketOwnerId { get; set; }
            public System.String DefaultRunSetting_OutputUri { get; set; }
            public System.Management.Automation.PSObject DefaultRunSetting_Parameter { get; set; }
            public System.Int32? DefaultRunSetting_Priority { get; set; }
            public Amazon.Omics.RunRetentionMode DefaultRunSetting_RetentionMode { get; set; }
            public System.String DefaultRunSetting_RoleArn { get; set; }
            public System.String DefaultRunSetting_RunGroupId { get; set; }
            public Dictionary<System.String, System.String> DefaultRunSetting_RunTag { get; set; }
            public System.Int32? DefaultRunSetting_StorageCapacity { get; set; }
            public Amazon.Omics.StorageType DefaultRunSetting_StorageType { get; set; }
            public System.String DefaultRunSetting_WorkflowId { get; set; }
            public System.String DefaultRunSetting_WorkflowOwnerId { get; set; }
            public Amazon.Omics.WorkflowType DefaultRunSetting_WorkflowType { get; set; }
            public System.String DefaultRunSetting_WorkflowVersionName { get; set; }
            public System.String RequestId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.StartRunBatchResponse, StartOMICSRunBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
