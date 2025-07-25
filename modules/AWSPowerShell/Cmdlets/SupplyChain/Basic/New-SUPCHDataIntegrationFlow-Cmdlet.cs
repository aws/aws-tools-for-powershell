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
using Amazon.SupplyChain;
using Amazon.SupplyChain.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SUPCH
{
    /// <summary>
    /// Enables you to programmatically create a data pipeline to ingest data from source
    /// systems such as Amazon S3 buckets, to a predefined Amazon Web Services Supply Chain
    /// dataset (product, inbound_order) or a temporary dataset along with the data transformation
    /// query provided with the API.
    /// </summary>
    [Cmdlet("New", "SUPCHDataIntegrationFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse")]
    [AWSCmdlet("Calls the AWS Supply Chain CreateDataIntegrationFlow API operation.", Operation = new[] {"CreateDataIntegrationFlow"}, SelectReturnType = typeof(Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse))]
    [AWSCmdletOutput("Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse",
        "This cmdlet returns an Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse object containing multiple properties."
    )]
    public partial class NewSUPCHDataIntegrationFlowCmdlet : AmazonSupplyChainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Target_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucketName of the S3 target objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_BucketName")]
        public System.String S3Target_BucketName { get; set; }
        #endregion
        
        #region Parameter DatasetTarget_DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>The dataset ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_DatasetIdentifier")]
        public System.String DatasetTarget_DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter Options_DedupeRecord
        /// <summary>
        /// <para>
        /// <para>The option to perform deduplication on data records sharing same primary key values.
        /// If disabled, transformed data with duplicate primary key values will ingest into dataset,
        /// for datasets within <b>asc</b> namespace, such duplicates will cause ingestion fail.
        /// If enabled without dedupeStrategy, deduplication is done by retaining a random data
        /// record among those sharing the same primary key values. If enabled with dedupeStragtegy,
        /// the deduplication is done following the strategy.</para><para>Note that target dataset may have partition configured, when dedupe is enabled, it
        /// only dedupe against primary keys and retain only one record out of those duplicates
        /// regardless of its partition status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_DedupeRecords")]
        public System.Boolean? Options_DedupeRecord { get; set; }
        #endregion
        
        #region Parameter FieldPriority_Field
        /// <summary>
        /// <para>
        /// <para>The list of field names and their sort order for deduplication, arranged in descending
        /// priority from highest to lowest.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_DedupeStrategy_FieldPriority_Fields")]
        public Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeField[] FieldPriority_Field { get; set; }
        #endregion
        
        #region Parameter Options_FileType
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 file type in S3 options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_Options_FileType")]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowFileType")]
        public Amazon.SupplyChain.DataIntegrationFlowFileType Options_FileType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Supply Chain instance identifier.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Options_LoadType
        /// <summary>
        /// <para>
        /// <para>The target dataset's data load type. This only affects how source S3 files are selected
        /// in the S3-to-dataset flow.</para><ul><li><para><b>REPLACE</b> - Target dataset will get replaced with the new file added under the
        /// source s3 prefix.</para></li><li><para><b>INCREMENTAL</b> - Target dataset will get updated with the up-to-date content
        /// under S3 prefix incorporating any file additions or removals there.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_LoadType")]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowLoadType")]
        public Amazon.SupplyChain.DataIntegrationFlowLoadType Options_LoadType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the DataIntegrationFlow.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Target_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the S3 target objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_Prefix")]
        public System.String S3Target_Prefix { get; set; }
        #endregion
        
        #region Parameter SqlTransformation_Query
        /// <summary>
        /// <para>
        /// <para>The transformation SQL query body based on SparkSQL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Transformation_SqlTransformation_Query")]
        public System.String SqlTransformation_Query { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source configurations for DataIntegrationFlow.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Sources")]
        public Amazon.SupplyChain.Model.DataIntegrationFlowSource[] Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags of the DataIntegrationFlow to be created</para><para />
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
        
        #region Parameter Target_TargetType
        /// <summary>
        /// <para>
        /// <para>The DataIntegrationFlow target type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowTargetType")]
        public Amazon.SupplyChain.DataIntegrationFlowTargetType Target_TargetType { get; set; }
        #endregion
        
        #region Parameter Transformation_TransformationType
        /// <summary>
        /// <para>
        /// <para>The DataIntegrationFlow transformation type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowTransformationType")]
        public Amazon.SupplyChain.DataIntegrationFlowTransformationType Transformation_TransformationType { get; set; }
        #endregion
        
        #region Parameter DedupeStrategy_Type
        /// <summary>
        /// <para>
        /// <para>The type of the deduplication strategy.</para><ul><li><para><b>FIELD_PRIORITY</b> - Field priority configuration for the deduplication strategy
        /// specifies an ordered list of fields used to tie-break the data records sharing the
        /// same primary key values. Fields earlier in the list have higher priority for evaluation.
        /// For each field, the sort order determines whether to retain data record with larger
        /// or smaller field value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_DedupeStrategy_Type")]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowDedupeStrategyType")]
        public Amazon.SupplyChain.DataIntegrationFlowDedupeStrategyType DedupeStrategy_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse).
        /// Specifying the name of a property of type Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SUPCHDataIntegrationFlow (CreateDataIntegrationFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse, NewSUPCHDataIntegrationFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SupplyChain.Model.DataIntegrationFlowSource>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.DatasetTarget_DatasetIdentifier = this.DatasetTarget_DatasetIdentifier;
            context.Options_DedupeRecord = this.Options_DedupeRecord;
            if (this.FieldPriority_Field != null)
            {
                context.FieldPriority_Field = new List<Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeField>(this.FieldPriority_Field);
            }
            context.DedupeStrategy_Type = this.DedupeStrategy_Type;
            context.Options_LoadType = this.Options_LoadType;
            context.S3Target_BucketName = this.S3Target_BucketName;
            context.Options_FileType = this.Options_FileType;
            context.S3Target_Prefix = this.S3Target_Prefix;
            context.Target_TargetType = this.Target_TargetType;
            #if MODULAR
            if (this.Target_TargetType == null && ParameterWasBound(nameof(this.Target_TargetType)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_TargetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SqlTransformation_Query = this.SqlTransformation_Query;
            context.Transformation_TransformationType = this.Transformation_TransformationType;
            #if MODULAR
            if (this.Transformation_TransformationType == null && ParameterWasBound(nameof(this.Transformation_TransformationType)))
            {
                WriteWarning("You are passing $null as a value for parameter Transformation_TransformationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SupplyChain.Model.CreateDataIntegrationFlowRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.SupplyChain.Model.DataIntegrationFlowTarget();
            Amazon.SupplyChain.DataIntegrationFlowTargetType requestTarget_target_TargetType = null;
            if (cmdletContext.Target_TargetType != null)
            {
                requestTarget_target_TargetType = cmdletContext.Target_TargetType;
            }
            if (requestTarget_target_TargetType != null)
            {
                request.Target.TargetType = requestTarget_target_TargetType;
                requestTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowDatasetTargetConfiguration requestTarget_target_DatasetTarget = null;
            
             // populate DatasetTarget
            var requestTarget_target_DatasetTargetIsNull = true;
            requestTarget_target_DatasetTarget = new Amazon.SupplyChain.Model.DataIntegrationFlowDatasetTargetConfiguration();
            System.String requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier = null;
            if (cmdletContext.DatasetTarget_DatasetIdentifier != null)
            {
                requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier = cmdletContext.DatasetTarget_DatasetIdentifier;
            }
            if (requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier != null)
            {
                requestTarget_target_DatasetTarget.DatasetIdentifier = requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier;
                requestTarget_target_DatasetTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowDatasetOptions requestTarget_target_DatasetTarget_target_DatasetTarget_Options = null;
            
             // populate Options
            var requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = true;
            requestTarget_target_DatasetTarget_target_DatasetTarget_Options = new Amazon.SupplyChain.Model.DataIntegrationFlowDatasetOptions();
            System.Boolean? requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord = null;
            if (cmdletContext.Options_DedupeRecord != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord = cmdletContext.Options_DedupeRecord.Value;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options.DedupeRecords = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord.Value;
                requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = false;
            }
            Amazon.SupplyChain.DataIntegrationFlowLoadType requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType = null;
            if (cmdletContext.Options_LoadType != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType = cmdletContext.Options_LoadType;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options.LoadType = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType;
                requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowDedupeStrategy requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy = null;
            
             // populate DedupeStrategy
            var requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategyIsNull = true;
            requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy = new Amazon.SupplyChain.Model.DataIntegrationFlowDedupeStrategy();
            Amazon.SupplyChain.DataIntegrationFlowDedupeStrategyType requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_dedupeStrategy_Type = null;
            if (cmdletContext.DedupeStrategy_Type != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_dedupeStrategy_Type = cmdletContext.DedupeStrategy_Type;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_dedupeStrategy_Type != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy.Type = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_dedupeStrategy_Type;
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategyIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeStrategyConfiguration requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority = null;
            
             // populate FieldPriority
            var requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriorityIsNull = true;
            requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority = new Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeStrategyConfiguration();
            List<Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeField> requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority_fieldPriority_Field = null;
            if (cmdletContext.FieldPriority_Field != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority_fieldPriority_Field = cmdletContext.FieldPriority_Field;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority_fieldPriority_Field != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority.Fields = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority_fieldPriority_Field;
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriorityIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority should be set to null
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriorityIsNull)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority = null;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy.FieldPriority = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy_target_DatasetTarget_Options_DedupeStrategy_FieldPriority;
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategyIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy should be set to null
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategyIsNull)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy = null;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options.DedupeStrategy = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_target_DatasetTarget_Options_DedupeStrategy;
                requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget_target_DatasetTarget_Options should be set to null
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options = null;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options != null)
            {
                requestTarget_target_DatasetTarget.Options = requestTarget_target_DatasetTarget_target_DatasetTarget_Options;
                requestTarget_target_DatasetTargetIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget should be set to null
            if (requestTarget_target_DatasetTargetIsNull)
            {
                requestTarget_target_DatasetTarget = null;
            }
            if (requestTarget_target_DatasetTarget != null)
            {
                request.Target.DatasetTarget = requestTarget_target_DatasetTarget;
                requestTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowS3TargetConfiguration requestTarget_target_S3Target = null;
            
             // populate S3Target
            var requestTarget_target_S3TargetIsNull = true;
            requestTarget_target_S3Target = new Amazon.SupplyChain.Model.DataIntegrationFlowS3TargetConfiguration();
            System.String requestTarget_target_S3Target_s3Target_BucketName = null;
            if (cmdletContext.S3Target_BucketName != null)
            {
                requestTarget_target_S3Target_s3Target_BucketName = cmdletContext.S3Target_BucketName;
            }
            if (requestTarget_target_S3Target_s3Target_BucketName != null)
            {
                requestTarget_target_S3Target.BucketName = requestTarget_target_S3Target_s3Target_BucketName;
                requestTarget_target_S3TargetIsNull = false;
            }
            System.String requestTarget_target_S3Target_s3Target_Prefix = null;
            if (cmdletContext.S3Target_Prefix != null)
            {
                requestTarget_target_S3Target_s3Target_Prefix = cmdletContext.S3Target_Prefix;
            }
            if (requestTarget_target_S3Target_s3Target_Prefix != null)
            {
                requestTarget_target_S3Target.Prefix = requestTarget_target_S3Target_s3Target_Prefix;
                requestTarget_target_S3TargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowS3Options requestTarget_target_S3Target_target_S3Target_Options = null;
            
             // populate Options
            var requestTarget_target_S3Target_target_S3Target_OptionsIsNull = true;
            requestTarget_target_S3Target_target_S3Target_Options = new Amazon.SupplyChain.Model.DataIntegrationFlowS3Options();
            Amazon.SupplyChain.DataIntegrationFlowFileType requestTarget_target_S3Target_target_S3Target_Options_options_FileType = null;
            if (cmdletContext.Options_FileType != null)
            {
                requestTarget_target_S3Target_target_S3Target_Options_options_FileType = cmdletContext.Options_FileType;
            }
            if (requestTarget_target_S3Target_target_S3Target_Options_options_FileType != null)
            {
                requestTarget_target_S3Target_target_S3Target_Options.FileType = requestTarget_target_S3Target_target_S3Target_Options_options_FileType;
                requestTarget_target_S3Target_target_S3Target_OptionsIsNull = false;
            }
             // determine if requestTarget_target_S3Target_target_S3Target_Options should be set to null
            if (requestTarget_target_S3Target_target_S3Target_OptionsIsNull)
            {
                requestTarget_target_S3Target_target_S3Target_Options = null;
            }
            if (requestTarget_target_S3Target_target_S3Target_Options != null)
            {
                requestTarget_target_S3Target.Options = requestTarget_target_S3Target_target_S3Target_Options;
                requestTarget_target_S3TargetIsNull = false;
            }
             // determine if requestTarget_target_S3Target should be set to null
            if (requestTarget_target_S3TargetIsNull)
            {
                requestTarget_target_S3Target = null;
            }
            if (requestTarget_target_S3Target != null)
            {
                request.Target.S3Target = requestTarget_target_S3Target;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            
             // populate Transformation
            var requestTransformationIsNull = true;
            request.Transformation = new Amazon.SupplyChain.Model.DataIntegrationFlowTransformation();
            Amazon.SupplyChain.DataIntegrationFlowTransformationType requestTransformation_transformation_TransformationType = null;
            if (cmdletContext.Transformation_TransformationType != null)
            {
                requestTransformation_transformation_TransformationType = cmdletContext.Transformation_TransformationType;
            }
            if (requestTransformation_transformation_TransformationType != null)
            {
                request.Transformation.TransformationType = requestTransformation_transformation_TransformationType;
                requestTransformationIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowSQLTransformationConfiguration requestTransformation_transformation_SqlTransformation = null;
            
             // populate SqlTransformation
            var requestTransformation_transformation_SqlTransformationIsNull = true;
            requestTransformation_transformation_SqlTransformation = new Amazon.SupplyChain.Model.DataIntegrationFlowSQLTransformationConfiguration();
            System.String requestTransformation_transformation_SqlTransformation_sqlTransformation_Query = null;
            if (cmdletContext.SqlTransformation_Query != null)
            {
                requestTransformation_transformation_SqlTransformation_sqlTransformation_Query = cmdletContext.SqlTransformation_Query;
            }
            if (requestTransformation_transformation_SqlTransformation_sqlTransformation_Query != null)
            {
                requestTransformation_transformation_SqlTransformation.Query = requestTransformation_transformation_SqlTransformation_sqlTransformation_Query;
                requestTransformation_transformation_SqlTransformationIsNull = false;
            }
             // determine if requestTransformation_transformation_SqlTransformation should be set to null
            if (requestTransformation_transformation_SqlTransformationIsNull)
            {
                requestTransformation_transformation_SqlTransformation = null;
            }
            if (requestTransformation_transformation_SqlTransformation != null)
            {
                request.Transformation.SqlTransformation = requestTransformation_transformation_SqlTransformation;
                requestTransformationIsNull = false;
            }
             // determine if request.Transformation should be set to null
            if (requestTransformationIsNull)
            {
                request.Transformation = null;
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
        
        private Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse CallAWSServiceOperation(IAmazonSupplyChain client, Amazon.SupplyChain.Model.CreateDataIntegrationFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Supply Chain", "CreateDataIntegrationFlow");
            try
            {
                return client.CreateDataIntegrationFlowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SupplyChain.Model.DataIntegrationFlowSource> Source { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String DatasetTarget_DatasetIdentifier { get; set; }
            public System.Boolean? Options_DedupeRecord { get; set; }
            public List<Amazon.SupplyChain.Model.DataIntegrationFlowFieldPriorityDedupeField> FieldPriority_Field { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowDedupeStrategyType DedupeStrategy_Type { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowLoadType Options_LoadType { get; set; }
            public System.String S3Target_BucketName { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowFileType Options_FileType { get; set; }
            public System.String S3Target_Prefix { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowTargetType Target_TargetType { get; set; }
            public System.String SqlTransformation_Query { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowTransformationType Transformation_TransformationType { get; set; }
            public System.Func<Amazon.SupplyChain.Model.CreateDataIntegrationFlowResponse, NewSUPCHDataIntegrationFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
