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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Attaches one or more LF-tags to an existing resource.
    /// </summary>
    [Cmdlet("Add", "LKFLFTagsToResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LakeFormation.Model.LFTagError")]
    [AWSCmdlet("Calls the AWS Lake Formation AddLFTagsToResource API operation.", Operation = new[] {"AddLFTagsToResource"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.AddLFTagsToResourceResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.LFTagError or Amazon.LakeFormation.Model.AddLFTagsToResourceResponse",
        "This cmdlet returns a collection of Amazon.LakeFormation.Model.LFTagError objects.",
        "The service call response (type Amazon.LakeFormation.Model.AddLFTagsToResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddLKFLFTagsToResourceCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter Database_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Database_CatalogId")]
        public System.String Database_CatalogId { get; set; }
        #endregion
        
        #region Parameter DataLocation_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog where the location is registered with Lake Formation.
        /// By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataLocation_CatalogId")]
        public System.String DataLocation_CatalogId { get; set; }
        #endregion
        
        #region Parameter LFTag_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTag_CatalogId")]
        public System.String LFTag_CatalogId { get; set; }
        #endregion
        
        #region Parameter LFTagExpression_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagExpression_CatalogId")]
        public System.String LFTagExpression_CatalogId { get; set; }
        #endregion
        
        #region Parameter LFTagPolicy_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagPolicy_CatalogId")]
        public System.String LFTagPolicy_CatalogId { get; set; }
        #endregion
        
        #region Parameter Table_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Table_CatalogId")]
        public System.String Table_CatalogId { get; set; }
        #endregion
        
        #region Parameter TableWithColumns_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_CatalogId")]
        public System.String TableWithColumns_CatalogId { get; set; }
        #endregion
        
        #region Parameter TableWithColumns_ColumnName
        /// <summary>
        /// <para>
        /// <para>The list of column names for the table. At least one of <c>ColumnNames</c> or <c>ColumnWildcard</c>
        /// is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_ColumnNames")]
        public System.String[] TableWithColumns_ColumnName { get; set; }
        #endregion
        
        #region Parameter DataCellsFilter_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataCellsFilter_DatabaseName")]
        public System.String DataCellsFilter_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Table_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database for the table. Unique to a Data Catalog. A database is a
        /// set of associated table definitions organized into a logical group. You can Grant
        /// and Revoke database privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Table_DatabaseName")]
        public System.String Table_DatabaseName { get; set; }
        #endregion
        
        #region Parameter TableWithColumns_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database for the table with columns resource. Unique to the Data Catalog.
        /// A database is a set of associated table definitions organized into a logical group.
        /// You can Grant and Revoke database privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_DatabaseName")]
        public System.String TableWithColumns_DatabaseName { get; set; }
        #endregion
        
        #region Parameter ColumnWildcard_ExcludedColumnName
        /// <summary>
        /// <para>
        /// <para>Excludes column names. Any column with this name will be excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_ColumnWildcard_ExcludedColumnNames")]
        public System.String[] ColumnWildcard_ExcludedColumnName { get; set; }
        #endregion
        
        #region Parameter LFTagPolicy_Expression
        /// <summary>
        /// <para>
        /// <para>A list of LF-tag conditions or a saved expression that apply to the resource's LF-tag
        /// policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagPolicy_Expression")]
        public Amazon.LakeFormation.Model.LFTag[] LFTagPolicy_Expression { get; set; }
        #endregion
        
        #region Parameter LFTagPolicy_ExpressionName
        /// <summary>
        /// <para>
        /// <para>If provided, permissions are granted to the Data Catalog resources whose assigned
        /// LF-Tags match the expression body of the saved expression under the provided <c>ExpressionName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagPolicy_ExpressionName")]
        public System.String LFTagPolicy_ExpressionName { get; set; }
        #endregion
        
        #region Parameter Catalog_Id
        /// <summary>
        /// <para>
        /// <para>An identifier for the catalog resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Catalog_Id")]
        public System.String Catalog_Id { get; set; }
        #endregion
        
        #region Parameter LFTag
        /// <summary>
        /// <para>
        /// <para>The LF-tags to attach to the resource.</para>
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
        [Alias("LFTags")]
        public Amazon.LakeFormation.Model.LFTagPair[] LFTag { get; set; }
        #endregion
        
        #region Parameter Database_Name
        /// <summary>
        /// <para>
        /// <para>The name of the database resource. Unique to the Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Database_Name")]
        public System.String Database_Name { get; set; }
        #endregion
        
        #region Parameter DataCellsFilter_Name
        /// <summary>
        /// <para>
        /// <para>The name of the data cells filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataCellsFilter_Name")]
        public System.String DataCellsFilter_Name { get; set; }
        #endregion
        
        #region Parameter LFTagExpression_Name
        /// <summary>
        /// <para>
        /// <para>The name of the LF-Tag expression to grant permissions on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagExpression_Name")]
        public System.String LFTagExpression_Name { get; set; }
        #endregion
        
        #region Parameter Table_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Table_Name")]
        public System.String Table_Name { get; set; }
        #endregion
        
        #region Parameter TableWithColumns_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table resource. A table is a metadata definition that represents your
        /// data. You can Grant and Revoke table privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_Name")]
        public System.String TableWithColumns_Name { get; set; }
        #endregion
        
        #region Parameter DataLocation_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the data location resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataLocation_ResourceArn")]
        public System.String DataLocation_ResourceArn { get; set; }
        #endregion
        
        #region Parameter LFTagPolicy_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type for which the LF-tag policy applies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagPolicy_ResourceType")]
        [AWSConstantClassSource("Amazon.LakeFormation.ResourceType")]
        public Amazon.LakeFormation.ResourceType LFTagPolicy_ResourceType { get; set; }
        #endregion
        
        #region Parameter DataCellsFilter_TableCatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the catalog to which the table belongs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataCellsFilter_TableCatalogId")]
        public System.String DataCellsFilter_TableCatalogId { get; set; }
        #endregion
        
        #region Parameter DataCellsFilter_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_DataCellsFilter_TableName")]
        public System.String DataCellsFilter_TableName { get; set; }
        #endregion
        
        #region Parameter Table_TableWildcard
        /// <summary>
        /// <para>
        /// <para>A wildcard object representing every table under a database.</para><para>At least one of <c>TableResource$Name</c> or <c>TableResource$TableWildcard</c> is
        /// required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_Table_TableWildcard")]
        public Amazon.LakeFormation.Model.TableWildcard Table_TableWildcard { get; set; }
        #endregion
        
        #region Parameter LFTag_TagKey
        /// <summary>
        /// <para>
        /// <para>The key-name for the LF-tag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTag_TagKey")]
        public System.String LFTag_TagKey { get; set; }
        #endregion
        
        #region Parameter LFTag_TagValue
        /// <summary>
        /// <para>
        /// <para>A list of possible values an attribute can take.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTag_TagValues")]
        public System.String[] LFTag_TagValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Failures'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.AddLFTagsToResourceResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.AddLFTagsToResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Failures";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LKFLFTagsToResource (AddLFTagsToResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.AddLFTagsToResourceResponse, AddLKFLFTagsToResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            if (this.LFTag != null)
            {
                context.LFTag = new List<Amazon.LakeFormation.Model.LFTagPair>(this.LFTag);
            }
            #if MODULAR
            if (this.LFTag == null && ParameterWasBound(nameof(this.LFTag)))
            {
                WriteWarning("You are passing $null as a value for parameter LFTag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog_Id = this.Catalog_Id;
            context.Database_CatalogId = this.Database_CatalogId;
            context.Database_Name = this.Database_Name;
            context.DataCellsFilter_DatabaseName = this.DataCellsFilter_DatabaseName;
            context.DataCellsFilter_Name = this.DataCellsFilter_Name;
            context.DataCellsFilter_TableCatalogId = this.DataCellsFilter_TableCatalogId;
            context.DataCellsFilter_TableName = this.DataCellsFilter_TableName;
            context.DataLocation_CatalogId = this.DataLocation_CatalogId;
            context.DataLocation_ResourceArn = this.DataLocation_ResourceArn;
            context.LFTag_CatalogId = this.LFTag_CatalogId;
            context.LFTag_TagKey = this.LFTag_TagKey;
            if (this.LFTag_TagValue != null)
            {
                context.LFTag_TagValue = new List<System.String>(this.LFTag_TagValue);
            }
            context.LFTagExpression_CatalogId = this.LFTagExpression_CatalogId;
            context.LFTagExpression_Name = this.LFTagExpression_Name;
            context.LFTagPolicy_CatalogId = this.LFTagPolicy_CatalogId;
            if (this.LFTagPolicy_Expression != null)
            {
                context.LFTagPolicy_Expression = new List<Amazon.LakeFormation.Model.LFTag>(this.LFTagPolicy_Expression);
            }
            context.LFTagPolicy_ExpressionName = this.LFTagPolicy_ExpressionName;
            context.LFTagPolicy_ResourceType = this.LFTagPolicy_ResourceType;
            context.Table_CatalogId = this.Table_CatalogId;
            context.Table_DatabaseName = this.Table_DatabaseName;
            context.Table_Name = this.Table_Name;
            context.Table_TableWildcard = this.Table_TableWildcard;
            context.TableWithColumns_CatalogId = this.TableWithColumns_CatalogId;
            if (this.TableWithColumns_ColumnName != null)
            {
                context.TableWithColumns_ColumnName = new List<System.String>(this.TableWithColumns_ColumnName);
            }
            if (this.ColumnWildcard_ExcludedColumnName != null)
            {
                context.ColumnWildcard_ExcludedColumnName = new List<System.String>(this.ColumnWildcard_ExcludedColumnName);
            }
            context.TableWithColumns_DatabaseName = this.TableWithColumns_DatabaseName;
            context.TableWithColumns_Name = this.TableWithColumns_Name;
            
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
            var request = new Amazon.LakeFormation.Model.AddLFTagsToResourceRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.LFTag != null)
            {
                request.LFTags = cmdletContext.LFTag;
            }
            
             // populate Resource
            var requestResourceIsNull = true;
            request.Resource = new Amazon.LakeFormation.Model.Resource();
            Amazon.LakeFormation.Model.CatalogResource requestResource_resource_Catalog = null;
            
             // populate Catalog
            var requestResource_resource_CatalogIsNull = true;
            requestResource_resource_Catalog = new Amazon.LakeFormation.Model.CatalogResource();
            System.String requestResource_resource_Catalog_catalog_Id = null;
            if (cmdletContext.Catalog_Id != null)
            {
                requestResource_resource_Catalog_catalog_Id = cmdletContext.Catalog_Id;
            }
            if (requestResource_resource_Catalog_catalog_Id != null)
            {
                requestResource_resource_Catalog.Id = requestResource_resource_Catalog_catalog_Id;
                requestResource_resource_CatalogIsNull = false;
            }
             // determine if requestResource_resource_Catalog should be set to null
            if (requestResource_resource_CatalogIsNull)
            {
                requestResource_resource_Catalog = null;
            }
            if (requestResource_resource_Catalog != null)
            {
                request.Resource.Catalog = requestResource_resource_Catalog;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.DatabaseResource requestResource_resource_Database = null;
            
             // populate Database
            var requestResource_resource_DatabaseIsNull = true;
            requestResource_resource_Database = new Amazon.LakeFormation.Model.DatabaseResource();
            System.String requestResource_resource_Database_database_CatalogId = null;
            if (cmdletContext.Database_CatalogId != null)
            {
                requestResource_resource_Database_database_CatalogId = cmdletContext.Database_CatalogId;
            }
            if (requestResource_resource_Database_database_CatalogId != null)
            {
                requestResource_resource_Database.CatalogId = requestResource_resource_Database_database_CatalogId;
                requestResource_resource_DatabaseIsNull = false;
            }
            System.String requestResource_resource_Database_database_Name = null;
            if (cmdletContext.Database_Name != null)
            {
                requestResource_resource_Database_database_Name = cmdletContext.Database_Name;
            }
            if (requestResource_resource_Database_database_Name != null)
            {
                requestResource_resource_Database.Name = requestResource_resource_Database_database_Name;
                requestResource_resource_DatabaseIsNull = false;
            }
             // determine if requestResource_resource_Database should be set to null
            if (requestResource_resource_DatabaseIsNull)
            {
                requestResource_resource_Database = null;
            }
            if (requestResource_resource_Database != null)
            {
                request.Resource.Database = requestResource_resource_Database;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.DataLocationResource requestResource_resource_DataLocation = null;
            
             // populate DataLocation
            var requestResource_resource_DataLocationIsNull = true;
            requestResource_resource_DataLocation = new Amazon.LakeFormation.Model.DataLocationResource();
            System.String requestResource_resource_DataLocation_dataLocation_CatalogId = null;
            if (cmdletContext.DataLocation_CatalogId != null)
            {
                requestResource_resource_DataLocation_dataLocation_CatalogId = cmdletContext.DataLocation_CatalogId;
            }
            if (requestResource_resource_DataLocation_dataLocation_CatalogId != null)
            {
                requestResource_resource_DataLocation.CatalogId = requestResource_resource_DataLocation_dataLocation_CatalogId;
                requestResource_resource_DataLocationIsNull = false;
            }
            System.String requestResource_resource_DataLocation_dataLocation_ResourceArn = null;
            if (cmdletContext.DataLocation_ResourceArn != null)
            {
                requestResource_resource_DataLocation_dataLocation_ResourceArn = cmdletContext.DataLocation_ResourceArn;
            }
            if (requestResource_resource_DataLocation_dataLocation_ResourceArn != null)
            {
                requestResource_resource_DataLocation.ResourceArn = requestResource_resource_DataLocation_dataLocation_ResourceArn;
                requestResource_resource_DataLocationIsNull = false;
            }
             // determine if requestResource_resource_DataLocation should be set to null
            if (requestResource_resource_DataLocationIsNull)
            {
                requestResource_resource_DataLocation = null;
            }
            if (requestResource_resource_DataLocation != null)
            {
                request.Resource.DataLocation = requestResource_resource_DataLocation;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.LFTagExpressionResource requestResource_resource_LFTagExpression = null;
            
             // populate LFTagExpression
            var requestResource_resource_LFTagExpressionIsNull = true;
            requestResource_resource_LFTagExpression = new Amazon.LakeFormation.Model.LFTagExpressionResource();
            System.String requestResource_resource_LFTagExpression_lFTagExpression_CatalogId = null;
            if (cmdletContext.LFTagExpression_CatalogId != null)
            {
                requestResource_resource_LFTagExpression_lFTagExpression_CatalogId = cmdletContext.LFTagExpression_CatalogId;
            }
            if (requestResource_resource_LFTagExpression_lFTagExpression_CatalogId != null)
            {
                requestResource_resource_LFTagExpression.CatalogId = requestResource_resource_LFTagExpression_lFTagExpression_CatalogId;
                requestResource_resource_LFTagExpressionIsNull = false;
            }
            System.String requestResource_resource_LFTagExpression_lFTagExpression_Name = null;
            if (cmdletContext.LFTagExpression_Name != null)
            {
                requestResource_resource_LFTagExpression_lFTagExpression_Name = cmdletContext.LFTagExpression_Name;
            }
            if (requestResource_resource_LFTagExpression_lFTagExpression_Name != null)
            {
                requestResource_resource_LFTagExpression.Name = requestResource_resource_LFTagExpression_lFTagExpression_Name;
                requestResource_resource_LFTagExpressionIsNull = false;
            }
             // determine if requestResource_resource_LFTagExpression should be set to null
            if (requestResource_resource_LFTagExpressionIsNull)
            {
                requestResource_resource_LFTagExpression = null;
            }
            if (requestResource_resource_LFTagExpression != null)
            {
                request.Resource.LFTagExpression = requestResource_resource_LFTagExpression;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.LFTagKeyResource requestResource_resource_LFTag = null;
            
             // populate LFTag
            var requestResource_resource_LFTagIsNull = true;
            requestResource_resource_LFTag = new Amazon.LakeFormation.Model.LFTagKeyResource();
            System.String requestResource_resource_LFTag_lFTag_CatalogId = null;
            if (cmdletContext.LFTag_CatalogId != null)
            {
                requestResource_resource_LFTag_lFTag_CatalogId = cmdletContext.LFTag_CatalogId;
            }
            if (requestResource_resource_LFTag_lFTag_CatalogId != null)
            {
                requestResource_resource_LFTag.CatalogId = requestResource_resource_LFTag_lFTag_CatalogId;
                requestResource_resource_LFTagIsNull = false;
            }
            System.String requestResource_resource_LFTag_lFTag_TagKey = null;
            if (cmdletContext.LFTag_TagKey != null)
            {
                requestResource_resource_LFTag_lFTag_TagKey = cmdletContext.LFTag_TagKey;
            }
            if (requestResource_resource_LFTag_lFTag_TagKey != null)
            {
                requestResource_resource_LFTag.TagKey = requestResource_resource_LFTag_lFTag_TagKey;
                requestResource_resource_LFTagIsNull = false;
            }
            List<System.String> requestResource_resource_LFTag_lFTag_TagValue = null;
            if (cmdletContext.LFTag_TagValue != null)
            {
                requestResource_resource_LFTag_lFTag_TagValue = cmdletContext.LFTag_TagValue;
            }
            if (requestResource_resource_LFTag_lFTag_TagValue != null)
            {
                requestResource_resource_LFTag.TagValues = requestResource_resource_LFTag_lFTag_TagValue;
                requestResource_resource_LFTagIsNull = false;
            }
             // determine if requestResource_resource_LFTag should be set to null
            if (requestResource_resource_LFTagIsNull)
            {
                requestResource_resource_LFTag = null;
            }
            if (requestResource_resource_LFTag != null)
            {
                request.Resource.LFTag = requestResource_resource_LFTag;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.DataCellsFilterResource requestResource_resource_DataCellsFilter = null;
            
             // populate DataCellsFilter
            var requestResource_resource_DataCellsFilterIsNull = true;
            requestResource_resource_DataCellsFilter = new Amazon.LakeFormation.Model.DataCellsFilterResource();
            System.String requestResource_resource_DataCellsFilter_dataCellsFilter_DatabaseName = null;
            if (cmdletContext.DataCellsFilter_DatabaseName != null)
            {
                requestResource_resource_DataCellsFilter_dataCellsFilter_DatabaseName = cmdletContext.DataCellsFilter_DatabaseName;
            }
            if (requestResource_resource_DataCellsFilter_dataCellsFilter_DatabaseName != null)
            {
                requestResource_resource_DataCellsFilter.DatabaseName = requestResource_resource_DataCellsFilter_dataCellsFilter_DatabaseName;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_dataCellsFilter_Name = null;
            if (cmdletContext.DataCellsFilter_Name != null)
            {
                requestResource_resource_DataCellsFilter_dataCellsFilter_Name = cmdletContext.DataCellsFilter_Name;
            }
            if (requestResource_resource_DataCellsFilter_dataCellsFilter_Name != null)
            {
                requestResource_resource_DataCellsFilter.Name = requestResource_resource_DataCellsFilter_dataCellsFilter_Name;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_dataCellsFilter_TableCatalogId = null;
            if (cmdletContext.DataCellsFilter_TableCatalogId != null)
            {
                requestResource_resource_DataCellsFilter_dataCellsFilter_TableCatalogId = cmdletContext.DataCellsFilter_TableCatalogId;
            }
            if (requestResource_resource_DataCellsFilter_dataCellsFilter_TableCatalogId != null)
            {
                requestResource_resource_DataCellsFilter.TableCatalogId = requestResource_resource_DataCellsFilter_dataCellsFilter_TableCatalogId;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_dataCellsFilter_TableName = null;
            if (cmdletContext.DataCellsFilter_TableName != null)
            {
                requestResource_resource_DataCellsFilter_dataCellsFilter_TableName = cmdletContext.DataCellsFilter_TableName;
            }
            if (requestResource_resource_DataCellsFilter_dataCellsFilter_TableName != null)
            {
                requestResource_resource_DataCellsFilter.TableName = requestResource_resource_DataCellsFilter_dataCellsFilter_TableName;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
             // determine if requestResource_resource_DataCellsFilter should be set to null
            if (requestResource_resource_DataCellsFilterIsNull)
            {
                requestResource_resource_DataCellsFilter = null;
            }
            if (requestResource_resource_DataCellsFilter != null)
            {
                request.Resource.DataCellsFilter = requestResource_resource_DataCellsFilter;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.LFTagPolicyResource requestResource_resource_LFTagPolicy = null;
            
             // populate LFTagPolicy
            var requestResource_resource_LFTagPolicyIsNull = true;
            requestResource_resource_LFTagPolicy = new Amazon.LakeFormation.Model.LFTagPolicyResource();
            System.String requestResource_resource_LFTagPolicy_lFTagPolicy_CatalogId = null;
            if (cmdletContext.LFTagPolicy_CatalogId != null)
            {
                requestResource_resource_LFTagPolicy_lFTagPolicy_CatalogId = cmdletContext.LFTagPolicy_CatalogId;
            }
            if (requestResource_resource_LFTagPolicy_lFTagPolicy_CatalogId != null)
            {
                requestResource_resource_LFTagPolicy.CatalogId = requestResource_resource_LFTagPolicy_lFTagPolicy_CatalogId;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            List<Amazon.LakeFormation.Model.LFTag> requestResource_resource_LFTagPolicy_lFTagPolicy_Expression = null;
            if (cmdletContext.LFTagPolicy_Expression != null)
            {
                requestResource_resource_LFTagPolicy_lFTagPolicy_Expression = cmdletContext.LFTagPolicy_Expression;
            }
            if (requestResource_resource_LFTagPolicy_lFTagPolicy_Expression != null)
            {
                requestResource_resource_LFTagPolicy.Expression = requestResource_resource_LFTagPolicy_lFTagPolicy_Expression;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            System.String requestResource_resource_LFTagPolicy_lFTagPolicy_ExpressionName = null;
            if (cmdletContext.LFTagPolicy_ExpressionName != null)
            {
                requestResource_resource_LFTagPolicy_lFTagPolicy_ExpressionName = cmdletContext.LFTagPolicy_ExpressionName;
            }
            if (requestResource_resource_LFTagPolicy_lFTagPolicy_ExpressionName != null)
            {
                requestResource_resource_LFTagPolicy.ExpressionName = requestResource_resource_LFTagPolicy_lFTagPolicy_ExpressionName;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            Amazon.LakeFormation.ResourceType requestResource_resource_LFTagPolicy_lFTagPolicy_ResourceType = null;
            if (cmdletContext.LFTagPolicy_ResourceType != null)
            {
                requestResource_resource_LFTagPolicy_lFTagPolicy_ResourceType = cmdletContext.LFTagPolicy_ResourceType;
            }
            if (requestResource_resource_LFTagPolicy_lFTagPolicy_ResourceType != null)
            {
                requestResource_resource_LFTagPolicy.ResourceType = requestResource_resource_LFTagPolicy_lFTagPolicy_ResourceType;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
             // determine if requestResource_resource_LFTagPolicy should be set to null
            if (requestResource_resource_LFTagPolicyIsNull)
            {
                requestResource_resource_LFTagPolicy = null;
            }
            if (requestResource_resource_LFTagPolicy != null)
            {
                request.Resource.LFTagPolicy = requestResource_resource_LFTagPolicy;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.TableResource requestResource_resource_Table = null;
            
             // populate Table
            var requestResource_resource_TableIsNull = true;
            requestResource_resource_Table = new Amazon.LakeFormation.Model.TableResource();
            System.String requestResource_resource_Table_table_CatalogId = null;
            if (cmdletContext.Table_CatalogId != null)
            {
                requestResource_resource_Table_table_CatalogId = cmdletContext.Table_CatalogId;
            }
            if (requestResource_resource_Table_table_CatalogId != null)
            {
                requestResource_resource_Table.CatalogId = requestResource_resource_Table_table_CatalogId;
                requestResource_resource_TableIsNull = false;
            }
            System.String requestResource_resource_Table_table_DatabaseName = null;
            if (cmdletContext.Table_DatabaseName != null)
            {
                requestResource_resource_Table_table_DatabaseName = cmdletContext.Table_DatabaseName;
            }
            if (requestResource_resource_Table_table_DatabaseName != null)
            {
                requestResource_resource_Table.DatabaseName = requestResource_resource_Table_table_DatabaseName;
                requestResource_resource_TableIsNull = false;
            }
            System.String requestResource_resource_Table_table_Name = null;
            if (cmdletContext.Table_Name != null)
            {
                requestResource_resource_Table_table_Name = cmdletContext.Table_Name;
            }
            if (requestResource_resource_Table_table_Name != null)
            {
                requestResource_resource_Table.Name = requestResource_resource_Table_table_Name;
                requestResource_resource_TableIsNull = false;
            }
            Amazon.LakeFormation.Model.TableWildcard requestResource_resource_Table_table_TableWildcard = null;
            if (cmdletContext.Table_TableWildcard != null)
            {
                requestResource_resource_Table_table_TableWildcard = cmdletContext.Table_TableWildcard;
            }
            if (requestResource_resource_Table_table_TableWildcard != null)
            {
                requestResource_resource_Table.TableWildcard = requestResource_resource_Table_table_TableWildcard;
                requestResource_resource_TableIsNull = false;
            }
             // determine if requestResource_resource_Table should be set to null
            if (requestResource_resource_TableIsNull)
            {
                requestResource_resource_Table = null;
            }
            if (requestResource_resource_Table != null)
            {
                request.Resource.Table = requestResource_resource_Table;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.TableWithColumnsResource requestResource_resource_TableWithColumns = null;
            
             // populate TableWithColumns
            var requestResource_resource_TableWithColumnsIsNull = true;
            requestResource_resource_TableWithColumns = new Amazon.LakeFormation.Model.TableWithColumnsResource();
            System.String requestResource_resource_TableWithColumns_tableWithColumns_CatalogId = null;
            if (cmdletContext.TableWithColumns_CatalogId != null)
            {
                requestResource_resource_TableWithColumns_tableWithColumns_CatalogId = cmdletContext.TableWithColumns_CatalogId;
            }
            if (requestResource_resource_TableWithColumns_tableWithColumns_CatalogId != null)
            {
                requestResource_resource_TableWithColumns.CatalogId = requestResource_resource_TableWithColumns_tableWithColumns_CatalogId;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            List<System.String> requestResource_resource_TableWithColumns_tableWithColumns_ColumnName = null;
            if (cmdletContext.TableWithColumns_ColumnName != null)
            {
                requestResource_resource_TableWithColumns_tableWithColumns_ColumnName = cmdletContext.TableWithColumns_ColumnName;
            }
            if (requestResource_resource_TableWithColumns_tableWithColumns_ColumnName != null)
            {
                requestResource_resource_TableWithColumns.ColumnNames = requestResource_resource_TableWithColumns_tableWithColumns_ColumnName;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            System.String requestResource_resource_TableWithColumns_tableWithColumns_DatabaseName = null;
            if (cmdletContext.TableWithColumns_DatabaseName != null)
            {
                requestResource_resource_TableWithColumns_tableWithColumns_DatabaseName = cmdletContext.TableWithColumns_DatabaseName;
            }
            if (requestResource_resource_TableWithColumns_tableWithColumns_DatabaseName != null)
            {
                requestResource_resource_TableWithColumns.DatabaseName = requestResource_resource_TableWithColumns_tableWithColumns_DatabaseName;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            System.String requestResource_resource_TableWithColumns_tableWithColumns_Name = null;
            if (cmdletContext.TableWithColumns_Name != null)
            {
                requestResource_resource_TableWithColumns_tableWithColumns_Name = cmdletContext.TableWithColumns_Name;
            }
            if (requestResource_resource_TableWithColumns_tableWithColumns_Name != null)
            {
                requestResource_resource_TableWithColumns.Name = requestResource_resource_TableWithColumns_tableWithColumns_Name;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            Amazon.LakeFormation.Model.ColumnWildcard requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard = null;
            
             // populate ColumnWildcard
            var requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcardIsNull = true;
            requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard = new Amazon.LakeFormation.Model.ColumnWildcard();
            List<System.String> requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_columnWildcard_ExcludedColumnName = null;
            if (cmdletContext.ColumnWildcard_ExcludedColumnName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_columnWildcard_ExcludedColumnName = cmdletContext.ColumnWildcard_ExcludedColumnName;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_columnWildcard_ExcludedColumnName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard.ExcludedColumnNames = requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_columnWildcard_ExcludedColumnName;
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcardIsNull = false;
            }
             // determine if requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard should be set to null
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcardIsNull)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard = null;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard != null)
            {
                requestResource_resource_TableWithColumns.ColumnWildcard = requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
             // determine if requestResource_resource_TableWithColumns should be set to null
            if (requestResource_resource_TableWithColumnsIsNull)
            {
                requestResource_resource_TableWithColumns = null;
            }
            if (requestResource_resource_TableWithColumns != null)
            {
                request.Resource.TableWithColumns = requestResource_resource_TableWithColumns;
                requestResourceIsNull = false;
            }
             // determine if request.Resource should be set to null
            if (requestResourceIsNull)
            {
                request.Resource = null;
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
        
        private Amazon.LakeFormation.Model.AddLFTagsToResourceResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.AddLFTagsToResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "AddLFTagsToResource");
            try
            {
                #if DESKTOP
                return client.AddLFTagsToResource(request);
                #elif CORECLR
                return client.AddLFTagsToResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public List<Amazon.LakeFormation.Model.LFTagPair> LFTag { get; set; }
            public System.String Catalog_Id { get; set; }
            public System.String Database_CatalogId { get; set; }
            public System.String Database_Name { get; set; }
            public System.String DataCellsFilter_DatabaseName { get; set; }
            public System.String DataCellsFilter_Name { get; set; }
            public System.String DataCellsFilter_TableCatalogId { get; set; }
            public System.String DataCellsFilter_TableName { get; set; }
            public System.String DataLocation_CatalogId { get; set; }
            public System.String DataLocation_ResourceArn { get; set; }
            public System.String LFTag_CatalogId { get; set; }
            public System.String LFTag_TagKey { get; set; }
            public List<System.String> LFTag_TagValue { get; set; }
            public System.String LFTagExpression_CatalogId { get; set; }
            public System.String LFTagExpression_Name { get; set; }
            public System.String LFTagPolicy_CatalogId { get; set; }
            public List<Amazon.LakeFormation.Model.LFTag> LFTagPolicy_Expression { get; set; }
            public System.String LFTagPolicy_ExpressionName { get; set; }
            public Amazon.LakeFormation.ResourceType LFTagPolicy_ResourceType { get; set; }
            public System.String Table_CatalogId { get; set; }
            public System.String Table_DatabaseName { get; set; }
            public System.String Table_Name { get; set; }
            public Amazon.LakeFormation.Model.TableWildcard Table_TableWildcard { get; set; }
            public System.String TableWithColumns_CatalogId { get; set; }
            public List<System.String> TableWithColumns_ColumnName { get; set; }
            public List<System.String> ColumnWildcard_ExcludedColumnName { get; set; }
            public System.String TableWithColumns_DatabaseName { get; set; }
            public System.String TableWithColumns_Name { get; set; }
            public System.Func<Amazon.LakeFormation.Model.AddLFTagsToResourceResponse, AddLKFLFTagsToResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Failures;
        }
        
    }
}
