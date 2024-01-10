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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates a dataset. This operation doesn't support datasets that include uploaded files
    /// as a source. Partial updates are not supported by this operation.
    /// </summary>
    [Cmdlet("Update", "QSDataSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateDataSetResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateDataSet API operation.", Operation = new[] {"UpdateDataSet"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateDataSetResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateDataSetResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateDataSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateQSDataSetCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RowLevelPermissionDataSet_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset that contains permissions for RLS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RowLevelPermissionDataSet_Arn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ColumnGroup
        /// <summary>
        /// <para>
        /// <para>Groupings of columns that work together in certain Amazon QuickSight features. Currently,
        /// only geospatial hierarchy is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ColumnGroups")]
        public Amazon.QuickSight.Model.ColumnGroup[] ColumnGroup { get; set; }
        #endregion
        
        #region Parameter ColumnLevelPermissionRule
        /// <summary>
        /// <para>
        /// <para>A set of one or more definitions of a <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_ColumnLevelPermissionRule.html">ColumnLevelPermissionRule</a></c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ColumnLevelPermissionRules")]
        public Amazon.QuickSight.Model.ColumnLevelPermissionRule[] ColumnLevelPermissionRule { get; set; }
        #endregion
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>The ID for the dataset that you want to update. This ID is unique per Amazon Web Services
        /// Region for each Amazon Web Services account.</para>
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
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter DatasetParameter
        /// <summary>
        /// <para>
        /// <para>The parameter declarations of the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetParameters")]
        public Amazon.QuickSight.Model.DatasetParameter[] DatasetParameter { get; set; }
        #endregion
        
        #region Parameter DataSetUsageConfiguration_DisableUseAsDirectQuerySource
        /// <summary>
        /// <para>
        /// <para>An option that controls whether a child dataset of a direct query can use this dataset
        /// as a source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataSetUsageConfiguration_DisableUseAsDirectQuerySource { get; set; }
        #endregion
        
        #region Parameter DataSetUsageConfiguration_DisableUseAsImportedSource
        /// <summary>
        /// <para>
        /// <para>An option that controls whether a child dataset that's stored in QuickSight can use
        /// this dataset as a source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataSetUsageConfiguration_DisableUseAsImportedSource { get; set; }
        #endregion
        
        #region Parameter FieldFolder
        /// <summary>
        /// <para>
        /// <para>The folder that contains fields and nested subfolders for your dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldFolders")]
        public System.Collections.Hashtable FieldFolder { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionDataSet_FormatVersion
        /// <summary>
        /// <para>
        /// <para>The user or group rules associated with the dataset that contains permissions for
        /// RLS.</para><para>By default, <c>FormatVersion</c> is <c>VERSION_1</c>. When <c>FormatVersion</c> is
        /// <c>VERSION_1</c>, <c>UserName</c> and <c>GroupName</c> are required. When <c>FormatVersion</c>
        /// is <c>VERSION_2</c>, <c>UserARN</c> and <c>GroupARN</c> are required, and <c>Namespace</c>
        /// must not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.RowLevelPermissionFormatVersion")]
        public Amazon.QuickSight.RowLevelPermissionFormatVersion RowLevelPermissionDataSet_FormatVersion { get; set; }
        #endregion
        
        #region Parameter ImportMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to import the data into SPICE.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.DataSetImportMode")]
        public Amazon.QuickSight.DataSetImportMode ImportMode { get; set; }
        #endregion
        
        #region Parameter LogicalTableMap
        /// <summary>
        /// <para>
        /// <para>Configures the combination and transformation of the data from the physical tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable LogicalTableMap { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for the dataset.</para>
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
        
        #region Parameter RowLevelPermissionDataSet_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace associated with the dataset that contains permissions for RLS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RowLevelPermissionDataSet_Namespace { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionDataSet_PermissionPolicy
        /// <summary>
        /// <para>
        /// <para>The type of permissions to use when interpreting the permissions for RLS. <c>DENY_ACCESS</c>
        /// is included for backward compatibility only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.RowLevelPermissionPolicy")]
        public Amazon.QuickSight.RowLevelPermissionPolicy RowLevelPermissionDataSet_PermissionPolicy { get; set; }
        #endregion
        
        #region Parameter PhysicalTableMap
        /// <summary>
        /// <para>
        /// <para>Declares the physical tables that are available in the underlying data sources.</para>
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
        public System.Collections.Hashtable PhysicalTableMap { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionDataSet_Status
        /// <summary>
        /// <para>
        /// <para>The status of the row-level security permission dataset. If enabled, the status is
        /// <c>ENABLED</c>. If disabled, the status is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.Status")]
        public Amazon.QuickSight.Status RowLevelPermissionDataSet_Status { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionTagConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>The status of row-level security tags. If enabled, the status is <c>ENABLED</c>. If
        /// disabled, the status is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.Status")]
        public Amazon.QuickSight.Status RowLevelPermissionTagConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionTagConfiguration_TagRuleConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of tag configuration rules to apply to a dataset. All tag configurations have
        /// the OR condition. Tags within each tile will be joined (AND). At least one rule in
        /// this structure must have all tag values assigned to it to apply Row-level security
        /// (RLS) to the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RowLevelPermissionTagConfiguration_TagRuleConfigurations")]
        public System.String[][] RowLevelPermissionTagConfiguration_TagRuleConfiguration { get; set; }
        #endregion
        
        #region Parameter RowLevelPermissionTagConfiguration_TagRule
        /// <summary>
        /// <para>
        /// <para>A set of rules associated with row-level security, such as the tag names and columns
        /// that they are assigned to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RowLevelPermissionTagConfiguration_TagRules")]
        public Amazon.QuickSight.Model.RowLevelPermissionTagRule[] RowLevelPermissionTagConfiguration_TagRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateDataSetResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateDataSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataSetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataSetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataSetId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSDataSet (UpdateDataSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateDataSetResponse, UpdateQSDataSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataSetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ColumnGroup != null)
            {
                context.ColumnGroup = new List<Amazon.QuickSight.Model.ColumnGroup>(this.ColumnGroup);
            }
            if (this.ColumnLevelPermissionRule != null)
            {
                context.ColumnLevelPermissionRule = new List<Amazon.QuickSight.Model.ColumnLevelPermissionRule>(this.ColumnLevelPermissionRule);
            }
            context.DataSetId = this.DataSetId;
            #if MODULAR
            if (this.DataSetId == null && ParameterWasBound(nameof(this.DataSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DatasetParameter != null)
            {
                context.DatasetParameter = new List<Amazon.QuickSight.Model.DatasetParameter>(this.DatasetParameter);
            }
            context.DataSetUsageConfiguration_DisableUseAsDirectQuerySource = this.DataSetUsageConfiguration_DisableUseAsDirectQuerySource;
            context.DataSetUsageConfiguration_DisableUseAsImportedSource = this.DataSetUsageConfiguration_DisableUseAsImportedSource;
            if (this.FieldFolder != null)
            {
                context.FieldFolder = new Dictionary<System.String, Amazon.QuickSight.Model.FieldFolder>(StringComparer.Ordinal);
                foreach (var hashKey in this.FieldFolder.Keys)
                {
                    context.FieldFolder.Add((String)hashKey, (FieldFolder)(this.FieldFolder[hashKey]));
                }
            }
            context.ImportMode = this.ImportMode;
            #if MODULAR
            if (this.ImportMode == null && ParameterWasBound(nameof(this.ImportMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LogicalTableMap != null)
            {
                context.LogicalTableMap = new Dictionary<System.String, Amazon.QuickSight.Model.LogicalTable>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogicalTableMap.Keys)
                {
                    context.LogicalTableMap.Add((String)hashKey, (LogicalTable)(this.LogicalTableMap[hashKey]));
                }
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PhysicalTableMap != null)
            {
                context.PhysicalTableMap = new Dictionary<System.String, Amazon.QuickSight.Model.PhysicalTable>(StringComparer.Ordinal);
                foreach (var hashKey in this.PhysicalTableMap.Keys)
                {
                    context.PhysicalTableMap.Add((String)hashKey, (PhysicalTable)(this.PhysicalTableMap[hashKey]));
                }
            }
            #if MODULAR
            if (this.PhysicalTableMap == null && ParameterWasBound(nameof(this.PhysicalTableMap)))
            {
                WriteWarning("You are passing $null as a value for parameter PhysicalTableMap which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RowLevelPermissionDataSet_Arn = this.RowLevelPermissionDataSet_Arn;
            context.RowLevelPermissionDataSet_FormatVersion = this.RowLevelPermissionDataSet_FormatVersion;
            context.RowLevelPermissionDataSet_Namespace = this.RowLevelPermissionDataSet_Namespace;
            context.RowLevelPermissionDataSet_PermissionPolicy = this.RowLevelPermissionDataSet_PermissionPolicy;
            context.RowLevelPermissionDataSet_Status = this.RowLevelPermissionDataSet_Status;
            context.RowLevelPermissionTagConfiguration_Status = this.RowLevelPermissionTagConfiguration_Status;
            if (this.RowLevelPermissionTagConfiguration_TagRuleConfiguration != null)
            {
                context.RowLevelPermissionTagConfiguration_TagRuleConfiguration = new List<List<System.String>>();
                foreach (var innerList in this.RowLevelPermissionTagConfiguration_TagRuleConfiguration)
                {
                    context.RowLevelPermissionTagConfiguration_TagRuleConfiguration.Add(new List<System.String>(innerList));
                }
            }
            if (this.RowLevelPermissionTagConfiguration_TagRule != null)
            {
                context.RowLevelPermissionTagConfiguration_TagRule = new List<Amazon.QuickSight.Model.RowLevelPermissionTagRule>(this.RowLevelPermissionTagConfiguration_TagRule);
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
            var request = new Amazon.QuickSight.Model.UpdateDataSetRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.ColumnGroup != null)
            {
                request.ColumnGroups = cmdletContext.ColumnGroup;
            }
            if (cmdletContext.ColumnLevelPermissionRule != null)
            {
                request.ColumnLevelPermissionRules = cmdletContext.ColumnLevelPermissionRule;
            }
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            if (cmdletContext.DatasetParameter != null)
            {
                request.DatasetParameters = cmdletContext.DatasetParameter;
            }
            
             // populate DataSetUsageConfiguration
            var requestDataSetUsageConfigurationIsNull = true;
            request.DataSetUsageConfiguration = new Amazon.QuickSight.Model.DataSetUsageConfiguration();
            System.Boolean? requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsDirectQuerySource = null;
            if (cmdletContext.DataSetUsageConfiguration_DisableUseAsDirectQuerySource != null)
            {
                requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsDirectQuerySource = cmdletContext.DataSetUsageConfiguration_DisableUseAsDirectQuerySource.Value;
            }
            if (requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsDirectQuerySource != null)
            {
                request.DataSetUsageConfiguration.DisableUseAsDirectQuerySource = requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsDirectQuerySource.Value;
                requestDataSetUsageConfigurationIsNull = false;
            }
            System.Boolean? requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsImportedSource = null;
            if (cmdletContext.DataSetUsageConfiguration_DisableUseAsImportedSource != null)
            {
                requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsImportedSource = cmdletContext.DataSetUsageConfiguration_DisableUseAsImportedSource.Value;
            }
            if (requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsImportedSource != null)
            {
                request.DataSetUsageConfiguration.DisableUseAsImportedSource = requestDataSetUsageConfiguration_dataSetUsageConfiguration_DisableUseAsImportedSource.Value;
                requestDataSetUsageConfigurationIsNull = false;
            }
             // determine if request.DataSetUsageConfiguration should be set to null
            if (requestDataSetUsageConfigurationIsNull)
            {
                request.DataSetUsageConfiguration = null;
            }
            if (cmdletContext.FieldFolder != null)
            {
                request.FieldFolders = cmdletContext.FieldFolder;
            }
            if (cmdletContext.ImportMode != null)
            {
                request.ImportMode = cmdletContext.ImportMode;
            }
            if (cmdletContext.LogicalTableMap != null)
            {
                request.LogicalTableMap = cmdletContext.LogicalTableMap;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PhysicalTableMap != null)
            {
                request.PhysicalTableMap = cmdletContext.PhysicalTableMap;
            }
            
             // populate RowLevelPermissionDataSet
            var requestRowLevelPermissionDataSetIsNull = true;
            request.RowLevelPermissionDataSet = new Amazon.QuickSight.Model.RowLevelPermissionDataSet();
            System.String requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Arn = null;
            if (cmdletContext.RowLevelPermissionDataSet_Arn != null)
            {
                requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Arn = cmdletContext.RowLevelPermissionDataSet_Arn;
            }
            if (requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Arn != null)
            {
                request.RowLevelPermissionDataSet.Arn = requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Arn;
                requestRowLevelPermissionDataSetIsNull = false;
            }
            Amazon.QuickSight.RowLevelPermissionFormatVersion requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_FormatVersion = null;
            if (cmdletContext.RowLevelPermissionDataSet_FormatVersion != null)
            {
                requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_FormatVersion = cmdletContext.RowLevelPermissionDataSet_FormatVersion;
            }
            if (requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_FormatVersion != null)
            {
                request.RowLevelPermissionDataSet.FormatVersion = requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_FormatVersion;
                requestRowLevelPermissionDataSetIsNull = false;
            }
            System.String requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Namespace = null;
            if (cmdletContext.RowLevelPermissionDataSet_Namespace != null)
            {
                requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Namespace = cmdletContext.RowLevelPermissionDataSet_Namespace;
            }
            if (requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Namespace != null)
            {
                request.RowLevelPermissionDataSet.Namespace = requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Namespace;
                requestRowLevelPermissionDataSetIsNull = false;
            }
            Amazon.QuickSight.RowLevelPermissionPolicy requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_PermissionPolicy = null;
            if (cmdletContext.RowLevelPermissionDataSet_PermissionPolicy != null)
            {
                requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_PermissionPolicy = cmdletContext.RowLevelPermissionDataSet_PermissionPolicy;
            }
            if (requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_PermissionPolicy != null)
            {
                request.RowLevelPermissionDataSet.PermissionPolicy = requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_PermissionPolicy;
                requestRowLevelPermissionDataSetIsNull = false;
            }
            Amazon.QuickSight.Status requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Status = null;
            if (cmdletContext.RowLevelPermissionDataSet_Status != null)
            {
                requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Status = cmdletContext.RowLevelPermissionDataSet_Status;
            }
            if (requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Status != null)
            {
                request.RowLevelPermissionDataSet.Status = requestRowLevelPermissionDataSet_rowLevelPermissionDataSet_Status;
                requestRowLevelPermissionDataSetIsNull = false;
            }
             // determine if request.RowLevelPermissionDataSet should be set to null
            if (requestRowLevelPermissionDataSetIsNull)
            {
                request.RowLevelPermissionDataSet = null;
            }
            
             // populate RowLevelPermissionTagConfiguration
            var requestRowLevelPermissionTagConfigurationIsNull = true;
            request.RowLevelPermissionTagConfiguration = new Amazon.QuickSight.Model.RowLevelPermissionTagConfiguration();
            Amazon.QuickSight.Status requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_Status = null;
            if (cmdletContext.RowLevelPermissionTagConfiguration_Status != null)
            {
                requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_Status = cmdletContext.RowLevelPermissionTagConfiguration_Status;
            }
            if (requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_Status != null)
            {
                request.RowLevelPermissionTagConfiguration.Status = requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_Status;
                requestRowLevelPermissionTagConfigurationIsNull = false;
            }
            List<List<System.String>> requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRuleConfiguration = null;
            if (cmdletContext.RowLevelPermissionTagConfiguration_TagRuleConfiguration != null)
            {
                requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRuleConfiguration = cmdletContext.RowLevelPermissionTagConfiguration_TagRuleConfiguration;
            }
            if (requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRuleConfiguration != null)
            {
                request.RowLevelPermissionTagConfiguration.TagRuleConfigurations = requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRuleConfiguration;
                requestRowLevelPermissionTagConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.RowLevelPermissionTagRule> requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRule = null;
            if (cmdletContext.RowLevelPermissionTagConfiguration_TagRule != null)
            {
                requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRule = cmdletContext.RowLevelPermissionTagConfiguration_TagRule;
            }
            if (requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRule != null)
            {
                request.RowLevelPermissionTagConfiguration.TagRules = requestRowLevelPermissionTagConfiguration_rowLevelPermissionTagConfiguration_TagRule;
                requestRowLevelPermissionTagConfigurationIsNull = false;
            }
             // determine if request.RowLevelPermissionTagConfiguration should be set to null
            if (requestRowLevelPermissionTagConfigurationIsNull)
            {
                request.RowLevelPermissionTagConfiguration = null;
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
        
        private Amazon.QuickSight.Model.UpdateDataSetResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateDataSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateDataSet");
            try
            {
                #if DESKTOP
                return client.UpdateDataSet(request);
                #elif CORECLR
                return client.UpdateDataSetAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public List<Amazon.QuickSight.Model.ColumnGroup> ColumnGroup { get; set; }
            public List<Amazon.QuickSight.Model.ColumnLevelPermissionRule> ColumnLevelPermissionRule { get; set; }
            public System.String DataSetId { get; set; }
            public List<Amazon.QuickSight.Model.DatasetParameter> DatasetParameter { get; set; }
            public System.Boolean? DataSetUsageConfiguration_DisableUseAsDirectQuerySource { get; set; }
            public System.Boolean? DataSetUsageConfiguration_DisableUseAsImportedSource { get; set; }
            public Dictionary<System.String, Amazon.QuickSight.Model.FieldFolder> FieldFolder { get; set; }
            public Amazon.QuickSight.DataSetImportMode ImportMode { get; set; }
            public Dictionary<System.String, Amazon.QuickSight.Model.LogicalTable> LogicalTableMap { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.QuickSight.Model.PhysicalTable> PhysicalTableMap { get; set; }
            public System.String RowLevelPermissionDataSet_Arn { get; set; }
            public Amazon.QuickSight.RowLevelPermissionFormatVersion RowLevelPermissionDataSet_FormatVersion { get; set; }
            public System.String RowLevelPermissionDataSet_Namespace { get; set; }
            public Amazon.QuickSight.RowLevelPermissionPolicy RowLevelPermissionDataSet_PermissionPolicy { get; set; }
            public Amazon.QuickSight.Status RowLevelPermissionDataSet_Status { get; set; }
            public Amazon.QuickSight.Status RowLevelPermissionTagConfiguration_Status { get; set; }
            public List<List<System.String>> RowLevelPermissionTagConfiguration_TagRuleConfiguration { get; set; }
            public List<Amazon.QuickSight.Model.RowLevelPermissionTagRule> RowLevelPermissionTagConfiguration_TagRule { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateDataSetResponse, UpdateQSDataSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
