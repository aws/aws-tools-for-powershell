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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Creates a new DataBrew dataset.
    /// </summary>
    [Cmdlet("New", "GDBDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue DataBrew CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.GlueDataBrew.Model.CreateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GlueDataBrew.Model.CreateDatasetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDBDatasetCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatabaseInputDefinition_TempDirectory_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_TempDirectory_Bucket")]
        public System.String DatabaseInputDefinition_TempDirectory_Bucket { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_TempDirectory_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_TempDirectory_Bucket")]
        public System.String DataCatalogInputDefinition_TempDirectory_Bucket { get; set; }
        #endregion
        
        #region Parameter S3InputDefinition_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3InputDefinition_Bucket")]
        public System.String S3InputDefinition_Bucket { get; set; }
        #endregion
        
        #region Parameter DatabaseInputDefinition_TempDirectory_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_TempDirectory_BucketOwner")]
        public System.String DatabaseInputDefinition_TempDirectory_BucketOwner { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_TempDirectory_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_TempDirectory_BucketOwner")]
        public System.String DataCatalogInputDefinition_TempDirectory_BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3InputDefinition_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3InputDefinition_BucketOwner")]
        public System.String S3InputDefinition_BucketOwner { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_CatalogId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Web Services account that holds the Data Catalog
        /// that stores the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_CatalogId")]
        public System.String DataCatalogInputDefinition_CatalogId { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of a database in the Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_DatabaseName")]
        public System.String DataCatalogInputDefinition_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DatabaseInputDefinition_DatabaseTableName
        /// <summary>
        /// <para>
        /// <para>The table within the target database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_DatabaseTableName")]
        public System.String DatabaseInputDefinition_DatabaseTableName { get; set; }
        #endregion
        
        #region Parameter Csv_Delimiter
        /// <summary>
        /// <para>
        /// <para>A single character that specifies the delimiter being used in the CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Csv_Delimiter")]
        public System.String Csv_Delimiter { get; set; }
        #endregion
        
        #region Parameter LastModifiedDateCondition_Expression
        /// <summary>
        /// <para>
        /// <para>The expression which includes condition names followed by substitution variables,
        /// possibly grouped and combined with other conditions. For example, "(starts_with :prefix1
        /// or starts_with :prefix2) and (ends_with :suffix1 or ends_with :suffix2)". Substitution
        /// variables should start with ':' symbol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_LastModifiedDateCondition_Expression")]
        public System.String LastModifiedDateCondition_Expression { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The file format of a dataset that is created from an Amazon S3 file or folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.InputFormat")]
        public Amazon.GlueDataBrew.InputFormat Format { get; set; }
        #endregion
        
        #region Parameter DatabaseInputDefinition_GlueConnectionName
        /// <summary>
        /// <para>
        /// <para>The Glue Connection that stores the connection information for the target database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_GlueConnectionName")]
        public System.String DatabaseInputDefinition_GlueConnectionName { get; set; }
        #endregion
        
        #region Parameter Csv_HeaderRow
        /// <summary>
        /// <para>
        /// <para>A variable that specifies whether the first row in the file is parsed as the header.
        /// If this value is false, column names are auto-generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Csv_HeaderRow")]
        public System.Boolean? Csv_HeaderRow { get; set; }
        #endregion
        
        #region Parameter Excel_HeaderRow
        /// <summary>
        /// <para>
        /// <para>A variable that specifies whether the first row in the file is parsed as the header.
        /// If this value is false, column names are auto-generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Excel_HeaderRow")]
        public System.Boolean? Excel_HeaderRow { get; set; }
        #endregion
        
        #region Parameter DatabaseInputDefinition_TempDirectory_Key
        /// <summary>
        /// <para>
        /// <para>The unique name of the object in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_TempDirectory_Key")]
        public System.String DatabaseInputDefinition_TempDirectory_Key { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_TempDirectory_Key
        /// <summary>
        /// <para>
        /// <para>The unique name of the object in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_TempDirectory_Key")]
        public System.String DataCatalogInputDefinition_TempDirectory_Key { get; set; }
        #endregion
        
        #region Parameter S3InputDefinition_Key
        /// <summary>
        /// <para>
        /// <para>The unique name of the object in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3InputDefinition_Key")]
        public System.String S3InputDefinition_Key { get; set; }
        #endregion
        
        #region Parameter FilesLimit_MaxFile
        /// <summary>
        /// <para>
        /// <para>The number of Amazon S3 files to select.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_FilesLimit_MaxFiles")]
        public System.Int32? FilesLimit_MaxFile { get; set; }
        #endregion
        
        #region Parameter Json_MultiLine
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether JSON input contains embedded new line characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Json_MultiLine")]
        public System.Boolean? Json_MultiLine { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the dataset to be created. Valid characters are alphanumeric (A-Z, a-z,
        /// 0-9), hyphen (-), period (.), and space.</para>
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
        
        #region Parameter FilesLimit_Order
        /// <summary>
        /// <para>
        /// <para>A criteria to use for Amazon S3 files sorting before their selection. By default uses
        /// DESCENDING order, i.e. most recent files are selected first. Another possible value
        /// is ASCENDING.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_FilesLimit_Order")]
        [AWSConstantClassSource("Amazon.GlueDataBrew.Order")]
        public Amazon.GlueDataBrew.Order FilesLimit_Order { get; set; }
        #endregion
        
        #region Parameter FilesLimit_OrderedBy
        /// <summary>
        /// <para>
        /// <para>A criteria to use for Amazon S3 files sorting before their selection. By default uses
        /// LAST_MODIFIED_DATE as a sorting criteria. Currently it's the only allowed value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_FilesLimit_OrderedBy")]
        [AWSConstantClassSource("Amazon.GlueDataBrew.OrderedBy")]
        public Amazon.GlueDataBrew.OrderedBy FilesLimit_OrderedBy { get; set; }
        #endregion
        
        #region Parameter PathOptions_Parameter
        /// <summary>
        /// <para>
        /// <para>A structure that maps names of parameters used in the Amazon S3 path of a dataset
        /// to their definitions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_Parameters")]
        public System.Collections.Hashtable PathOptions_Parameter { get; set; }
        #endregion
        
        #region Parameter DatabaseInputDefinition_QueryString
        /// <summary>
        /// <para>
        /// <para>Custom SQL to run against the provided Glue connection. This SQL will be used as the
        /// input for DataBrew projects and jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DatabaseInputDefinition_QueryString")]
        public System.String DatabaseInputDefinition_QueryString { get; set; }
        #endregion
        
        #region Parameter Excel_SheetIndex
        /// <summary>
        /// <para>
        /// <para>One or more sheet numbers in the Excel file that will be included in the dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Excel_SheetIndexes")]
        public System.Int32[] Excel_SheetIndex { get; set; }
        #endregion
        
        #region Parameter Excel_SheetName
        /// <summary>
        /// <para>
        /// <para>One or more named sheets in the Excel file that will be included in the dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatOptions_Excel_SheetNames")]
        public System.String[] Excel_SheetName { get; set; }
        #endregion
        
        #region Parameter Metadata_SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the dataset. Currently, DataBrew only
        /// supports ARNs from Amazon AppFlow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Metadata_SourceArn")]
        public System.String Metadata_SourceArn { get; set; }
        #endregion
        
        #region Parameter DataCatalogInputDefinition_TableName
        /// <summary>
        /// <para>
        /// <para>The name of a database table in the Data Catalog. This table corresponds to a DataBrew
        /// dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DataCatalogInputDefinition_TableName")]
        public System.String DataCatalogInputDefinition_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata tags to apply to this dataset.</para><para />
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
        
        #region Parameter LastModifiedDateCondition_ValuesMap
        /// <summary>
        /// <para>
        /// <para>The map of substitution variable names to their values used in this filter expression.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PathOptions_LastModifiedDateCondition_ValuesMap")]
        public System.Collections.Hashtable LastModifiedDateCondition_ValuesMap { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDBDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.CreateDatasetResponse, NewGDBDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Format = this.Format;
            context.Csv_Delimiter = this.Csv_Delimiter;
            context.Csv_HeaderRow = this.Csv_HeaderRow;
            context.Excel_HeaderRow = this.Excel_HeaderRow;
            if (this.Excel_SheetIndex != null)
            {
                context.Excel_SheetIndex = new List<System.Int32>(this.Excel_SheetIndex);
            }
            if (this.Excel_SheetName != null)
            {
                context.Excel_SheetName = new List<System.String>(this.Excel_SheetName);
            }
            context.Json_MultiLine = this.Json_MultiLine;
            context.DatabaseInputDefinition_DatabaseTableName = this.DatabaseInputDefinition_DatabaseTableName;
            context.DatabaseInputDefinition_GlueConnectionName = this.DatabaseInputDefinition_GlueConnectionName;
            context.DatabaseInputDefinition_QueryString = this.DatabaseInputDefinition_QueryString;
            context.DatabaseInputDefinition_TempDirectory_Bucket = this.DatabaseInputDefinition_TempDirectory_Bucket;
            context.DatabaseInputDefinition_TempDirectory_BucketOwner = this.DatabaseInputDefinition_TempDirectory_BucketOwner;
            context.DatabaseInputDefinition_TempDirectory_Key = this.DatabaseInputDefinition_TempDirectory_Key;
            context.DataCatalogInputDefinition_CatalogId = this.DataCatalogInputDefinition_CatalogId;
            context.DataCatalogInputDefinition_DatabaseName = this.DataCatalogInputDefinition_DatabaseName;
            context.DataCatalogInputDefinition_TableName = this.DataCatalogInputDefinition_TableName;
            context.DataCatalogInputDefinition_TempDirectory_Bucket = this.DataCatalogInputDefinition_TempDirectory_Bucket;
            context.DataCatalogInputDefinition_TempDirectory_BucketOwner = this.DataCatalogInputDefinition_TempDirectory_BucketOwner;
            context.DataCatalogInputDefinition_TempDirectory_Key = this.DataCatalogInputDefinition_TempDirectory_Key;
            context.Metadata_SourceArn = this.Metadata_SourceArn;
            context.S3InputDefinition_Bucket = this.S3InputDefinition_Bucket;
            context.S3InputDefinition_BucketOwner = this.S3InputDefinition_BucketOwner;
            context.S3InputDefinition_Key = this.S3InputDefinition_Key;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FilesLimit_MaxFile = this.FilesLimit_MaxFile;
            context.FilesLimit_Order = this.FilesLimit_Order;
            context.FilesLimit_OrderedBy = this.FilesLimit_OrderedBy;
            context.LastModifiedDateCondition_Expression = this.LastModifiedDateCondition_Expression;
            if (this.LastModifiedDateCondition_ValuesMap != null)
            {
                context.LastModifiedDateCondition_ValuesMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.LastModifiedDateCondition_ValuesMap.Keys)
                {
                    context.LastModifiedDateCondition_ValuesMap.Add((String)hashKey, (System.String)(this.LastModifiedDateCondition_ValuesMap[hashKey]));
                }
            }
            if (this.PathOptions_Parameter != null)
            {
                context.PathOptions_Parameter = new Dictionary<System.String, Amazon.GlueDataBrew.Model.DatasetParameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.PathOptions_Parameter.Keys)
                {
                    context.PathOptions_Parameter.Add((String)hashKey, (Amazon.GlueDataBrew.Model.DatasetParameter)(this.PathOptions_Parameter[hashKey]));
                }
            }
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
            var request = new Amazon.GlueDataBrew.Model.CreateDatasetRequest();
            
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            
             // populate FormatOptions
            var requestFormatOptionsIsNull = true;
            request.FormatOptions = new Amazon.GlueDataBrew.Model.FormatOptions();
            Amazon.GlueDataBrew.Model.JsonOptions requestFormatOptions_formatOptions_Json = null;
            
             // populate Json
            var requestFormatOptions_formatOptions_JsonIsNull = true;
            requestFormatOptions_formatOptions_Json = new Amazon.GlueDataBrew.Model.JsonOptions();
            System.Boolean? requestFormatOptions_formatOptions_Json_json_MultiLine = null;
            if (cmdletContext.Json_MultiLine != null)
            {
                requestFormatOptions_formatOptions_Json_json_MultiLine = cmdletContext.Json_MultiLine.Value;
            }
            if (requestFormatOptions_formatOptions_Json_json_MultiLine != null)
            {
                requestFormatOptions_formatOptions_Json.MultiLine = requestFormatOptions_formatOptions_Json_json_MultiLine.Value;
                requestFormatOptions_formatOptions_JsonIsNull = false;
            }
             // determine if requestFormatOptions_formatOptions_Json should be set to null
            if (requestFormatOptions_formatOptions_JsonIsNull)
            {
                requestFormatOptions_formatOptions_Json = null;
            }
            if (requestFormatOptions_formatOptions_Json != null)
            {
                request.FormatOptions.Json = requestFormatOptions_formatOptions_Json;
                requestFormatOptionsIsNull = false;
            }
            Amazon.GlueDataBrew.Model.CsvOptions requestFormatOptions_formatOptions_Csv = null;
            
             // populate Csv
            var requestFormatOptions_formatOptions_CsvIsNull = true;
            requestFormatOptions_formatOptions_Csv = new Amazon.GlueDataBrew.Model.CsvOptions();
            System.String requestFormatOptions_formatOptions_Csv_csv_Delimiter = null;
            if (cmdletContext.Csv_Delimiter != null)
            {
                requestFormatOptions_formatOptions_Csv_csv_Delimiter = cmdletContext.Csv_Delimiter;
            }
            if (requestFormatOptions_formatOptions_Csv_csv_Delimiter != null)
            {
                requestFormatOptions_formatOptions_Csv.Delimiter = requestFormatOptions_formatOptions_Csv_csv_Delimiter;
                requestFormatOptions_formatOptions_CsvIsNull = false;
            }
            System.Boolean? requestFormatOptions_formatOptions_Csv_csv_HeaderRow = null;
            if (cmdletContext.Csv_HeaderRow != null)
            {
                requestFormatOptions_formatOptions_Csv_csv_HeaderRow = cmdletContext.Csv_HeaderRow.Value;
            }
            if (requestFormatOptions_formatOptions_Csv_csv_HeaderRow != null)
            {
                requestFormatOptions_formatOptions_Csv.HeaderRow = requestFormatOptions_formatOptions_Csv_csv_HeaderRow.Value;
                requestFormatOptions_formatOptions_CsvIsNull = false;
            }
             // determine if requestFormatOptions_formatOptions_Csv should be set to null
            if (requestFormatOptions_formatOptions_CsvIsNull)
            {
                requestFormatOptions_formatOptions_Csv = null;
            }
            if (requestFormatOptions_formatOptions_Csv != null)
            {
                request.FormatOptions.Csv = requestFormatOptions_formatOptions_Csv;
                requestFormatOptionsIsNull = false;
            }
            Amazon.GlueDataBrew.Model.ExcelOptions requestFormatOptions_formatOptions_Excel = null;
            
             // populate Excel
            var requestFormatOptions_formatOptions_ExcelIsNull = true;
            requestFormatOptions_formatOptions_Excel = new Amazon.GlueDataBrew.Model.ExcelOptions();
            System.Boolean? requestFormatOptions_formatOptions_Excel_excel_HeaderRow = null;
            if (cmdletContext.Excel_HeaderRow != null)
            {
                requestFormatOptions_formatOptions_Excel_excel_HeaderRow = cmdletContext.Excel_HeaderRow.Value;
            }
            if (requestFormatOptions_formatOptions_Excel_excel_HeaderRow != null)
            {
                requestFormatOptions_formatOptions_Excel.HeaderRow = requestFormatOptions_formatOptions_Excel_excel_HeaderRow.Value;
                requestFormatOptions_formatOptions_ExcelIsNull = false;
            }
            List<System.Int32> requestFormatOptions_formatOptions_Excel_excel_SheetIndex = null;
            if (cmdletContext.Excel_SheetIndex != null)
            {
                requestFormatOptions_formatOptions_Excel_excel_SheetIndex = cmdletContext.Excel_SheetIndex;
            }
            if (requestFormatOptions_formatOptions_Excel_excel_SheetIndex != null)
            {
                requestFormatOptions_formatOptions_Excel.SheetIndexes = requestFormatOptions_formatOptions_Excel_excel_SheetIndex;
                requestFormatOptions_formatOptions_ExcelIsNull = false;
            }
            List<System.String> requestFormatOptions_formatOptions_Excel_excel_SheetName = null;
            if (cmdletContext.Excel_SheetName != null)
            {
                requestFormatOptions_formatOptions_Excel_excel_SheetName = cmdletContext.Excel_SheetName;
            }
            if (requestFormatOptions_formatOptions_Excel_excel_SheetName != null)
            {
                requestFormatOptions_formatOptions_Excel.SheetNames = requestFormatOptions_formatOptions_Excel_excel_SheetName;
                requestFormatOptions_formatOptions_ExcelIsNull = false;
            }
             // determine if requestFormatOptions_formatOptions_Excel should be set to null
            if (requestFormatOptions_formatOptions_ExcelIsNull)
            {
                requestFormatOptions_formatOptions_Excel = null;
            }
            if (requestFormatOptions_formatOptions_Excel != null)
            {
                request.FormatOptions.Excel = requestFormatOptions_formatOptions_Excel;
                requestFormatOptionsIsNull = false;
            }
             // determine if request.FormatOptions should be set to null
            if (requestFormatOptionsIsNull)
            {
                request.FormatOptions = null;
            }
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.GlueDataBrew.Model.Input();
            Amazon.GlueDataBrew.Model.Metadata requestInput_input_Metadata = null;
            
             // populate Metadata
            var requestInput_input_MetadataIsNull = true;
            requestInput_input_Metadata = new Amazon.GlueDataBrew.Model.Metadata();
            System.String requestInput_input_Metadata_metadata_SourceArn = null;
            if (cmdletContext.Metadata_SourceArn != null)
            {
                requestInput_input_Metadata_metadata_SourceArn = cmdletContext.Metadata_SourceArn;
            }
            if (requestInput_input_Metadata_metadata_SourceArn != null)
            {
                requestInput_input_Metadata.SourceArn = requestInput_input_Metadata_metadata_SourceArn;
                requestInput_input_MetadataIsNull = false;
            }
             // determine if requestInput_input_Metadata should be set to null
            if (requestInput_input_MetadataIsNull)
            {
                requestInput_input_Metadata = null;
            }
            if (requestInput_input_Metadata != null)
            {
                request.Input.Metadata = requestInput_input_Metadata;
                requestInputIsNull = false;
            }
            Amazon.GlueDataBrew.Model.S3Location requestInput_input_S3InputDefinition = null;
            
             // populate S3InputDefinition
            var requestInput_input_S3InputDefinitionIsNull = true;
            requestInput_input_S3InputDefinition = new Amazon.GlueDataBrew.Model.S3Location();
            System.String requestInput_input_S3InputDefinition_s3InputDefinition_Bucket = null;
            if (cmdletContext.S3InputDefinition_Bucket != null)
            {
                requestInput_input_S3InputDefinition_s3InputDefinition_Bucket = cmdletContext.S3InputDefinition_Bucket;
            }
            if (requestInput_input_S3InputDefinition_s3InputDefinition_Bucket != null)
            {
                requestInput_input_S3InputDefinition.Bucket = requestInput_input_S3InputDefinition_s3InputDefinition_Bucket;
                requestInput_input_S3InputDefinitionIsNull = false;
            }
            System.String requestInput_input_S3InputDefinition_s3InputDefinition_BucketOwner = null;
            if (cmdletContext.S3InputDefinition_BucketOwner != null)
            {
                requestInput_input_S3InputDefinition_s3InputDefinition_BucketOwner = cmdletContext.S3InputDefinition_BucketOwner;
            }
            if (requestInput_input_S3InputDefinition_s3InputDefinition_BucketOwner != null)
            {
                requestInput_input_S3InputDefinition.BucketOwner = requestInput_input_S3InputDefinition_s3InputDefinition_BucketOwner;
                requestInput_input_S3InputDefinitionIsNull = false;
            }
            System.String requestInput_input_S3InputDefinition_s3InputDefinition_Key = null;
            if (cmdletContext.S3InputDefinition_Key != null)
            {
                requestInput_input_S3InputDefinition_s3InputDefinition_Key = cmdletContext.S3InputDefinition_Key;
            }
            if (requestInput_input_S3InputDefinition_s3InputDefinition_Key != null)
            {
                requestInput_input_S3InputDefinition.Key = requestInput_input_S3InputDefinition_s3InputDefinition_Key;
                requestInput_input_S3InputDefinitionIsNull = false;
            }
             // determine if requestInput_input_S3InputDefinition should be set to null
            if (requestInput_input_S3InputDefinitionIsNull)
            {
                requestInput_input_S3InputDefinition = null;
            }
            if (requestInput_input_S3InputDefinition != null)
            {
                request.Input.S3InputDefinition = requestInput_input_S3InputDefinition;
                requestInputIsNull = false;
            }
            Amazon.GlueDataBrew.Model.DatabaseInputDefinition requestInput_input_DatabaseInputDefinition = null;
            
             // populate DatabaseInputDefinition
            var requestInput_input_DatabaseInputDefinitionIsNull = true;
            requestInput_input_DatabaseInputDefinition = new Amazon.GlueDataBrew.Model.DatabaseInputDefinition();
            System.String requestInput_input_DatabaseInputDefinition_databaseInputDefinition_DatabaseTableName = null;
            if (cmdletContext.DatabaseInputDefinition_DatabaseTableName != null)
            {
                requestInput_input_DatabaseInputDefinition_databaseInputDefinition_DatabaseTableName = cmdletContext.DatabaseInputDefinition_DatabaseTableName;
            }
            if (requestInput_input_DatabaseInputDefinition_databaseInputDefinition_DatabaseTableName != null)
            {
                requestInput_input_DatabaseInputDefinition.DatabaseTableName = requestInput_input_DatabaseInputDefinition_databaseInputDefinition_DatabaseTableName;
                requestInput_input_DatabaseInputDefinitionIsNull = false;
            }
            System.String requestInput_input_DatabaseInputDefinition_databaseInputDefinition_GlueConnectionName = null;
            if (cmdletContext.DatabaseInputDefinition_GlueConnectionName != null)
            {
                requestInput_input_DatabaseInputDefinition_databaseInputDefinition_GlueConnectionName = cmdletContext.DatabaseInputDefinition_GlueConnectionName;
            }
            if (requestInput_input_DatabaseInputDefinition_databaseInputDefinition_GlueConnectionName != null)
            {
                requestInput_input_DatabaseInputDefinition.GlueConnectionName = requestInput_input_DatabaseInputDefinition_databaseInputDefinition_GlueConnectionName;
                requestInput_input_DatabaseInputDefinitionIsNull = false;
            }
            System.String requestInput_input_DatabaseInputDefinition_databaseInputDefinition_QueryString = null;
            if (cmdletContext.DatabaseInputDefinition_QueryString != null)
            {
                requestInput_input_DatabaseInputDefinition_databaseInputDefinition_QueryString = cmdletContext.DatabaseInputDefinition_QueryString;
            }
            if (requestInput_input_DatabaseInputDefinition_databaseInputDefinition_QueryString != null)
            {
                requestInput_input_DatabaseInputDefinition.QueryString = requestInput_input_DatabaseInputDefinition_databaseInputDefinition_QueryString;
                requestInput_input_DatabaseInputDefinitionIsNull = false;
            }
            Amazon.GlueDataBrew.Model.S3Location requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory = null;
            
             // populate TempDirectory
            var requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectoryIsNull = true;
            requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory = new Amazon.GlueDataBrew.Model.S3Location();
            System.String requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Bucket = null;
            if (cmdletContext.DatabaseInputDefinition_TempDirectory_Bucket != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Bucket = cmdletContext.DatabaseInputDefinition_TempDirectory_Bucket;
            }
            if (requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Bucket != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory.Bucket = requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Bucket;
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectoryIsNull = false;
            }
            System.String requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_BucketOwner = null;
            if (cmdletContext.DatabaseInputDefinition_TempDirectory_BucketOwner != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_BucketOwner = cmdletContext.DatabaseInputDefinition_TempDirectory_BucketOwner;
            }
            if (requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_BucketOwner != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory.BucketOwner = requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_BucketOwner;
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectoryIsNull = false;
            }
            System.String requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Key = null;
            if (cmdletContext.DatabaseInputDefinition_TempDirectory_Key != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Key = cmdletContext.DatabaseInputDefinition_TempDirectory_Key;
            }
            if (requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Key != null)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory.Key = requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory_databaseInputDefinition_TempDirectory_Key;
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectoryIsNull = false;
            }
             // determine if requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory should be set to null
            if (requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectoryIsNull)
            {
                requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory = null;
            }
            if (requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory != null)
            {
                requestInput_input_DatabaseInputDefinition.TempDirectory = requestInput_input_DatabaseInputDefinition_input_DatabaseInputDefinition_TempDirectory;
                requestInput_input_DatabaseInputDefinitionIsNull = false;
            }
             // determine if requestInput_input_DatabaseInputDefinition should be set to null
            if (requestInput_input_DatabaseInputDefinitionIsNull)
            {
                requestInput_input_DatabaseInputDefinition = null;
            }
            if (requestInput_input_DatabaseInputDefinition != null)
            {
                request.Input.DatabaseInputDefinition = requestInput_input_DatabaseInputDefinition;
                requestInputIsNull = false;
            }
            Amazon.GlueDataBrew.Model.DataCatalogInputDefinition requestInput_input_DataCatalogInputDefinition = null;
            
             // populate DataCatalogInputDefinition
            var requestInput_input_DataCatalogInputDefinitionIsNull = true;
            requestInput_input_DataCatalogInputDefinition = new Amazon.GlueDataBrew.Model.DataCatalogInputDefinition();
            System.String requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_CatalogId = null;
            if (cmdletContext.DataCatalogInputDefinition_CatalogId != null)
            {
                requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_CatalogId = cmdletContext.DataCatalogInputDefinition_CatalogId;
            }
            if (requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_CatalogId != null)
            {
                requestInput_input_DataCatalogInputDefinition.CatalogId = requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_CatalogId;
                requestInput_input_DataCatalogInputDefinitionIsNull = false;
            }
            System.String requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_DatabaseName = null;
            if (cmdletContext.DataCatalogInputDefinition_DatabaseName != null)
            {
                requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_DatabaseName = cmdletContext.DataCatalogInputDefinition_DatabaseName;
            }
            if (requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_DatabaseName != null)
            {
                requestInput_input_DataCatalogInputDefinition.DatabaseName = requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_DatabaseName;
                requestInput_input_DataCatalogInputDefinitionIsNull = false;
            }
            System.String requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_TableName = null;
            if (cmdletContext.DataCatalogInputDefinition_TableName != null)
            {
                requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_TableName = cmdletContext.DataCatalogInputDefinition_TableName;
            }
            if (requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_TableName != null)
            {
                requestInput_input_DataCatalogInputDefinition.TableName = requestInput_input_DataCatalogInputDefinition_dataCatalogInputDefinition_TableName;
                requestInput_input_DataCatalogInputDefinitionIsNull = false;
            }
            Amazon.GlueDataBrew.Model.S3Location requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory = null;
            
             // populate TempDirectory
            var requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectoryIsNull = true;
            requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory = new Amazon.GlueDataBrew.Model.S3Location();
            System.String requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Bucket = null;
            if (cmdletContext.DataCatalogInputDefinition_TempDirectory_Bucket != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Bucket = cmdletContext.DataCatalogInputDefinition_TempDirectory_Bucket;
            }
            if (requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Bucket != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory.Bucket = requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Bucket;
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectoryIsNull = false;
            }
            System.String requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_BucketOwner = null;
            if (cmdletContext.DataCatalogInputDefinition_TempDirectory_BucketOwner != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_BucketOwner = cmdletContext.DataCatalogInputDefinition_TempDirectory_BucketOwner;
            }
            if (requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_BucketOwner != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory.BucketOwner = requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_BucketOwner;
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectoryIsNull = false;
            }
            System.String requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Key = null;
            if (cmdletContext.DataCatalogInputDefinition_TempDirectory_Key != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Key = cmdletContext.DataCatalogInputDefinition_TempDirectory_Key;
            }
            if (requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Key != null)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory.Key = requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory_dataCatalogInputDefinition_TempDirectory_Key;
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectoryIsNull = false;
            }
             // determine if requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory should be set to null
            if (requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectoryIsNull)
            {
                requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory = null;
            }
            if (requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory != null)
            {
                requestInput_input_DataCatalogInputDefinition.TempDirectory = requestInput_input_DataCatalogInputDefinition_input_DataCatalogInputDefinition_TempDirectory;
                requestInput_input_DataCatalogInputDefinitionIsNull = false;
            }
             // determine if requestInput_input_DataCatalogInputDefinition should be set to null
            if (requestInput_input_DataCatalogInputDefinitionIsNull)
            {
                requestInput_input_DataCatalogInputDefinition = null;
            }
            if (requestInput_input_DataCatalogInputDefinition != null)
            {
                request.Input.DataCatalogInputDefinition = requestInput_input_DataCatalogInputDefinition;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PathOptions
            var requestPathOptionsIsNull = true;
            request.PathOptions = new Amazon.GlueDataBrew.Model.PathOptions();
            Dictionary<System.String, Amazon.GlueDataBrew.Model.DatasetParameter> requestPathOptions_pathOptions_Parameter = null;
            if (cmdletContext.PathOptions_Parameter != null)
            {
                requestPathOptions_pathOptions_Parameter = cmdletContext.PathOptions_Parameter;
            }
            if (requestPathOptions_pathOptions_Parameter != null)
            {
                request.PathOptions.Parameters = requestPathOptions_pathOptions_Parameter;
                requestPathOptionsIsNull = false;
            }
            Amazon.GlueDataBrew.Model.FilterExpression requestPathOptions_pathOptions_LastModifiedDateCondition = null;
            
             // populate LastModifiedDateCondition
            var requestPathOptions_pathOptions_LastModifiedDateConditionIsNull = true;
            requestPathOptions_pathOptions_LastModifiedDateCondition = new Amazon.GlueDataBrew.Model.FilterExpression();
            System.String requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_Expression = null;
            if (cmdletContext.LastModifiedDateCondition_Expression != null)
            {
                requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_Expression = cmdletContext.LastModifiedDateCondition_Expression;
            }
            if (requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_Expression != null)
            {
                requestPathOptions_pathOptions_LastModifiedDateCondition.Expression = requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_Expression;
                requestPathOptions_pathOptions_LastModifiedDateConditionIsNull = false;
            }
            Dictionary<System.String, System.String> requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_ValuesMap = null;
            if (cmdletContext.LastModifiedDateCondition_ValuesMap != null)
            {
                requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_ValuesMap = cmdletContext.LastModifiedDateCondition_ValuesMap;
            }
            if (requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_ValuesMap != null)
            {
                requestPathOptions_pathOptions_LastModifiedDateCondition.ValuesMap = requestPathOptions_pathOptions_LastModifiedDateCondition_lastModifiedDateCondition_ValuesMap;
                requestPathOptions_pathOptions_LastModifiedDateConditionIsNull = false;
            }
             // determine if requestPathOptions_pathOptions_LastModifiedDateCondition should be set to null
            if (requestPathOptions_pathOptions_LastModifiedDateConditionIsNull)
            {
                requestPathOptions_pathOptions_LastModifiedDateCondition = null;
            }
            if (requestPathOptions_pathOptions_LastModifiedDateCondition != null)
            {
                request.PathOptions.LastModifiedDateCondition = requestPathOptions_pathOptions_LastModifiedDateCondition;
                requestPathOptionsIsNull = false;
            }
            Amazon.GlueDataBrew.Model.FilesLimit requestPathOptions_pathOptions_FilesLimit = null;
            
             // populate FilesLimit
            var requestPathOptions_pathOptions_FilesLimitIsNull = true;
            requestPathOptions_pathOptions_FilesLimit = new Amazon.GlueDataBrew.Model.FilesLimit();
            System.Int32? requestPathOptions_pathOptions_FilesLimit_filesLimit_MaxFile = null;
            if (cmdletContext.FilesLimit_MaxFile != null)
            {
                requestPathOptions_pathOptions_FilesLimit_filesLimit_MaxFile = cmdletContext.FilesLimit_MaxFile.Value;
            }
            if (requestPathOptions_pathOptions_FilesLimit_filesLimit_MaxFile != null)
            {
                requestPathOptions_pathOptions_FilesLimit.MaxFiles = requestPathOptions_pathOptions_FilesLimit_filesLimit_MaxFile.Value;
                requestPathOptions_pathOptions_FilesLimitIsNull = false;
            }
            Amazon.GlueDataBrew.Order requestPathOptions_pathOptions_FilesLimit_filesLimit_Order = null;
            if (cmdletContext.FilesLimit_Order != null)
            {
                requestPathOptions_pathOptions_FilesLimit_filesLimit_Order = cmdletContext.FilesLimit_Order;
            }
            if (requestPathOptions_pathOptions_FilesLimit_filesLimit_Order != null)
            {
                requestPathOptions_pathOptions_FilesLimit.Order = requestPathOptions_pathOptions_FilesLimit_filesLimit_Order;
                requestPathOptions_pathOptions_FilesLimitIsNull = false;
            }
            Amazon.GlueDataBrew.OrderedBy requestPathOptions_pathOptions_FilesLimit_filesLimit_OrderedBy = null;
            if (cmdletContext.FilesLimit_OrderedBy != null)
            {
                requestPathOptions_pathOptions_FilesLimit_filesLimit_OrderedBy = cmdletContext.FilesLimit_OrderedBy;
            }
            if (requestPathOptions_pathOptions_FilesLimit_filesLimit_OrderedBy != null)
            {
                requestPathOptions_pathOptions_FilesLimit.OrderedBy = requestPathOptions_pathOptions_FilesLimit_filesLimit_OrderedBy;
                requestPathOptions_pathOptions_FilesLimitIsNull = false;
            }
             // determine if requestPathOptions_pathOptions_FilesLimit should be set to null
            if (requestPathOptions_pathOptions_FilesLimitIsNull)
            {
                requestPathOptions_pathOptions_FilesLimit = null;
            }
            if (requestPathOptions_pathOptions_FilesLimit != null)
            {
                request.PathOptions.FilesLimit = requestPathOptions_pathOptions_FilesLimit;
                requestPathOptionsIsNull = false;
            }
             // determine if request.PathOptions should be set to null
            if (requestPathOptionsIsNull)
            {
                request.PathOptions = null;
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
        
        private Amazon.GlueDataBrew.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "CreateDataset");
            try
            {
                return client.CreateDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GlueDataBrew.InputFormat Format { get; set; }
            public System.String Csv_Delimiter { get; set; }
            public System.Boolean? Csv_HeaderRow { get; set; }
            public System.Boolean? Excel_HeaderRow { get; set; }
            public List<System.Int32> Excel_SheetIndex { get; set; }
            public List<System.String> Excel_SheetName { get; set; }
            public System.Boolean? Json_MultiLine { get; set; }
            public System.String DatabaseInputDefinition_DatabaseTableName { get; set; }
            public System.String DatabaseInputDefinition_GlueConnectionName { get; set; }
            public System.String DatabaseInputDefinition_QueryString { get; set; }
            public System.String DatabaseInputDefinition_TempDirectory_Bucket { get; set; }
            public System.String DatabaseInputDefinition_TempDirectory_BucketOwner { get; set; }
            public System.String DatabaseInputDefinition_TempDirectory_Key { get; set; }
            public System.String DataCatalogInputDefinition_CatalogId { get; set; }
            public System.String DataCatalogInputDefinition_DatabaseName { get; set; }
            public System.String DataCatalogInputDefinition_TableName { get; set; }
            public System.String DataCatalogInputDefinition_TempDirectory_Bucket { get; set; }
            public System.String DataCatalogInputDefinition_TempDirectory_BucketOwner { get; set; }
            public System.String DataCatalogInputDefinition_TempDirectory_Key { get; set; }
            public System.String Metadata_SourceArn { get; set; }
            public System.String S3InputDefinition_Bucket { get; set; }
            public System.String S3InputDefinition_BucketOwner { get; set; }
            public System.String S3InputDefinition_Key { get; set; }
            public System.String Name { get; set; }
            public System.Int32? FilesLimit_MaxFile { get; set; }
            public Amazon.GlueDataBrew.Order FilesLimit_Order { get; set; }
            public Amazon.GlueDataBrew.OrderedBy FilesLimit_OrderedBy { get; set; }
            public System.String LastModifiedDateCondition_Expression { get; set; }
            public Dictionary<System.String, System.String> LastModifiedDateCondition_ValuesMap { get; set; }
            public Dictionary<System.String, Amazon.GlueDataBrew.Model.DatasetParameter> PathOptions_Parameter { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.CreateDatasetResponse, NewGDBDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
