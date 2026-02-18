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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new configured table resource.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTable")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredTable API operation.", Operation = new[] {"CreateConfiguredTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTable or Amazon.CleanRooms.Model.CreateConfiguredTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTable object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSConfiguredTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Snowflake_AccountIdentifier
        /// <summary>
        /// <para>
        /// <para> The account identifier for the Snowflake table reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_AccountIdentifier")]
        public System.String Snowflake_AccountIdentifier { get; set; }
        #endregion
        
        #region Parameter AllowedColumn
        /// <summary>
        /// <para>
        /// <para>The columns of the underlying table that can be used by collaborations or analysis
        /// rules.</para>
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
        [Alias("AllowedColumns")]
        public System.String[] AllowedColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisMethod
        /// <summary>
        /// <para>
        /// <para>The analysis method allowed for the configured tables.</para><para><c>DIRECT_QUERY</c> allows SQL queries to be run directly on this table.</para><para><c>DIRECT_JOB</c> allows PySpark jobs to be run directly on this table.</para><para><c>MULTIPLE</c> allows both SQL queries and PySpark jobs to be run directly on this
        /// table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.AnalysisMethod")]
        public Amazon.CleanRooms.AnalysisMethod AnalysisMethod { get; set; }
        #endregion
        
        #region Parameter TableReference_Athena_CatalogName
        /// <summary>
        /// <para>
        /// <para> The catalog name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableReference_Athena_CatalogName { get; set; }
        #endregion
        
        #region Parameter Athena_DatabaseName
        /// <summary>
        /// <para>
        /// <para> The database name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Athena_DatabaseName")]
        public System.String Athena_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Glue_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database the Glue table belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Glue_DatabaseName")]
        public System.String Glue_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Snowflake_DatabaseName
        /// <summary>
        /// <para>
        /// <para> The name of the database the Snowflake table belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_DatabaseName")]
        public System.String Snowflake_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configured table.</para>
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
        
        #region Parameter Athena_OutputLocation
        /// <summary>
        /// <para>
        /// <para> The output location for the Athena table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Athena_OutputLocation")]
        public System.String Athena_OutputLocation { get; set; }
        #endregion
        
        #region Parameter Athena_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the Athena table is located. This parameter is
        /// required to uniquely identify and access tables across different Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Athena_Region")]
        [AWSConstantClassSource("Amazon.CleanRooms.CommercialRegion")]
        public Amazon.CleanRooms.CommercialRegion Athena_Region { get; set; }
        #endregion
        
        #region Parameter Glue_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the Glue table is located. This parameter is
        /// required to uniquely identify and access tables across different Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Glue_Region")]
        [AWSConstantClassSource("Amazon.CleanRooms.CommercialRegion")]
        public Amazon.CleanRooms.CommercialRegion Glue_Region { get; set; }
        #endregion
        
        #region Parameter Snowflake_SchemaName
        /// <summary>
        /// <para>
        /// <para> The schema name of the Snowflake table reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_SchemaName")]
        public System.String Snowflake_SchemaName { get; set; }
        #endregion
        
        #region Parameter Snowflake_SecretArn
        /// <summary>
        /// <para>
        /// <para> The secret ARN of the Snowflake table reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_SecretArn")]
        public System.String Snowflake_SecretArn { get; set; }
        #endregion
        
        #region Parameter SelectedAnalysisMethod
        /// <summary>
        /// <para>
        /// <para> The analysis methods to enable for the configured table. When configured, you must
        /// specify at least two analysis methods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectedAnalysisMethods")]
        public System.String[] SelectedAnalysisMethod { get; set; }
        #endregion
        
        #region Parameter Athena_TableName
        /// <summary>
        /// <para>
        /// <para> The table reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Athena_TableName")]
        public System.String Athena_TableName { get; set; }
        #endregion
        
        #region Parameter Glue_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Glue_TableName")]
        public System.String Glue_TableName { get; set; }
        #endregion
        
        #region Parameter Snowflake_TableName
        /// <summary>
        /// <para>
        /// <para> The name of the Snowflake table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_TableName")]
        public System.String Snowflake_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TableSchema_V1
        /// <summary>
        /// <para>
        /// <para> The schema of a Snowflake table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Snowflake_TableSchema_V1")]
        public Amazon.CleanRooms.Model.SnowflakeTableSchemaV1[] TableSchema_V1 { get; set; }
        #endregion
        
        #region Parameter Athena_WorkGroup
        /// <summary>
        /// <para>
        /// <para> The workgroup of the Athena table reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Athena_WorkGroup")]
        public System.String Athena_WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredTable'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredTable";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredTable (CreateConfiguredTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredTableResponse, NewCRSConfiguredTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedColumn != null)
            {
                context.AllowedColumn = new List<System.String>(this.AllowedColumn);
            }
            #if MODULAR
            if (this.AllowedColumn == null && ParameterWasBound(nameof(this.AllowedColumn)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedColumn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnalysisMethod = this.AnalysisMethod;
            #if MODULAR
            if (this.AnalysisMethod == null && ParameterWasBound(nameof(this.AnalysisMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SelectedAnalysisMethod != null)
            {
                context.SelectedAnalysisMethod = new List<System.String>(this.SelectedAnalysisMethod);
            }
            context.TableReference_Athena_CatalogName = this.TableReference_Athena_CatalogName;
            context.Athena_DatabaseName = this.Athena_DatabaseName;
            context.Athena_OutputLocation = this.Athena_OutputLocation;
            context.Athena_Region = this.Athena_Region;
            context.Athena_TableName = this.Athena_TableName;
            context.Athena_WorkGroup = this.Athena_WorkGroup;
            context.Glue_DatabaseName = this.Glue_DatabaseName;
            context.Glue_Region = this.Glue_Region;
            context.Glue_TableName = this.Glue_TableName;
            context.Snowflake_AccountIdentifier = this.Snowflake_AccountIdentifier;
            context.Snowflake_DatabaseName = this.Snowflake_DatabaseName;
            context.Snowflake_SchemaName = this.Snowflake_SchemaName;
            context.Snowflake_SecretArn = this.Snowflake_SecretArn;
            context.Snowflake_TableName = this.Snowflake_TableName;
            if (this.TableSchema_V1 != null)
            {
                context.TableSchema_V1 = new List<Amazon.CleanRooms.Model.SnowflakeTableSchemaV1>(this.TableSchema_V1);
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
            var request = new Amazon.CleanRooms.Model.CreateConfiguredTableRequest();
            
            if (cmdletContext.AllowedColumn != null)
            {
                request.AllowedColumns = cmdletContext.AllowedColumn;
            }
            if (cmdletContext.AnalysisMethod != null)
            {
                request.AnalysisMethod = cmdletContext.AnalysisMethod;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SelectedAnalysisMethod != null)
            {
                request.SelectedAnalysisMethods = cmdletContext.SelectedAnalysisMethod;
            }
            
             // populate TableReference
            var requestTableReferenceIsNull = true;
            request.TableReference = new Amazon.CleanRooms.Model.TableReference();
            Amazon.CleanRooms.Model.GlueTableReference requestTableReference_tableReference_Glue = null;
            
             // populate Glue
            var requestTableReference_tableReference_GlueIsNull = true;
            requestTableReference_tableReference_Glue = new Amazon.CleanRooms.Model.GlueTableReference();
            System.String requestTableReference_tableReference_Glue_glue_DatabaseName = null;
            if (cmdletContext.Glue_DatabaseName != null)
            {
                requestTableReference_tableReference_Glue_glue_DatabaseName = cmdletContext.Glue_DatabaseName;
            }
            if (requestTableReference_tableReference_Glue_glue_DatabaseName != null)
            {
                requestTableReference_tableReference_Glue.DatabaseName = requestTableReference_tableReference_Glue_glue_DatabaseName;
                requestTableReference_tableReference_GlueIsNull = false;
            }
            Amazon.CleanRooms.CommercialRegion requestTableReference_tableReference_Glue_glue_Region = null;
            if (cmdletContext.Glue_Region != null)
            {
                requestTableReference_tableReference_Glue_glue_Region = cmdletContext.Glue_Region;
            }
            if (requestTableReference_tableReference_Glue_glue_Region != null)
            {
                requestTableReference_tableReference_Glue.Region = requestTableReference_tableReference_Glue_glue_Region;
                requestTableReference_tableReference_GlueIsNull = false;
            }
            System.String requestTableReference_tableReference_Glue_glue_TableName = null;
            if (cmdletContext.Glue_TableName != null)
            {
                requestTableReference_tableReference_Glue_glue_TableName = cmdletContext.Glue_TableName;
            }
            if (requestTableReference_tableReference_Glue_glue_TableName != null)
            {
                requestTableReference_tableReference_Glue.TableName = requestTableReference_tableReference_Glue_glue_TableName;
                requestTableReference_tableReference_GlueIsNull = false;
            }
             // determine if requestTableReference_tableReference_Glue should be set to null
            if (requestTableReference_tableReference_GlueIsNull)
            {
                requestTableReference_tableReference_Glue = null;
            }
            if (requestTableReference_tableReference_Glue != null)
            {
                request.TableReference.Glue = requestTableReference_tableReference_Glue;
                requestTableReferenceIsNull = false;
            }
            Amazon.CleanRooms.Model.AthenaTableReference requestTableReference_tableReference_Athena = null;
            
             // populate Athena
            var requestTableReference_tableReference_AthenaIsNull = true;
            requestTableReference_tableReference_Athena = new Amazon.CleanRooms.Model.AthenaTableReference();
            System.String requestTableReference_tableReference_Athena_tableReference_Athena_CatalogName = null;
            if (cmdletContext.TableReference_Athena_CatalogName != null)
            {
                requestTableReference_tableReference_Athena_tableReference_Athena_CatalogName = cmdletContext.TableReference_Athena_CatalogName;
            }
            if (requestTableReference_tableReference_Athena_tableReference_Athena_CatalogName != null)
            {
                requestTableReference_tableReference_Athena.CatalogName = requestTableReference_tableReference_Athena_tableReference_Athena_CatalogName;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
            System.String requestTableReference_tableReference_Athena_athena_DatabaseName = null;
            if (cmdletContext.Athena_DatabaseName != null)
            {
                requestTableReference_tableReference_Athena_athena_DatabaseName = cmdletContext.Athena_DatabaseName;
            }
            if (requestTableReference_tableReference_Athena_athena_DatabaseName != null)
            {
                requestTableReference_tableReference_Athena.DatabaseName = requestTableReference_tableReference_Athena_athena_DatabaseName;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
            System.String requestTableReference_tableReference_Athena_athena_OutputLocation = null;
            if (cmdletContext.Athena_OutputLocation != null)
            {
                requestTableReference_tableReference_Athena_athena_OutputLocation = cmdletContext.Athena_OutputLocation;
            }
            if (requestTableReference_tableReference_Athena_athena_OutputLocation != null)
            {
                requestTableReference_tableReference_Athena.OutputLocation = requestTableReference_tableReference_Athena_athena_OutputLocation;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
            Amazon.CleanRooms.CommercialRegion requestTableReference_tableReference_Athena_athena_Region = null;
            if (cmdletContext.Athena_Region != null)
            {
                requestTableReference_tableReference_Athena_athena_Region = cmdletContext.Athena_Region;
            }
            if (requestTableReference_tableReference_Athena_athena_Region != null)
            {
                requestTableReference_tableReference_Athena.Region = requestTableReference_tableReference_Athena_athena_Region;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
            System.String requestTableReference_tableReference_Athena_athena_TableName = null;
            if (cmdletContext.Athena_TableName != null)
            {
                requestTableReference_tableReference_Athena_athena_TableName = cmdletContext.Athena_TableName;
            }
            if (requestTableReference_tableReference_Athena_athena_TableName != null)
            {
                requestTableReference_tableReference_Athena.TableName = requestTableReference_tableReference_Athena_athena_TableName;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
            System.String requestTableReference_tableReference_Athena_athena_WorkGroup = null;
            if (cmdletContext.Athena_WorkGroup != null)
            {
                requestTableReference_tableReference_Athena_athena_WorkGroup = cmdletContext.Athena_WorkGroup;
            }
            if (requestTableReference_tableReference_Athena_athena_WorkGroup != null)
            {
                requestTableReference_tableReference_Athena.WorkGroup = requestTableReference_tableReference_Athena_athena_WorkGroup;
                requestTableReference_tableReference_AthenaIsNull = false;
            }
             // determine if requestTableReference_tableReference_Athena should be set to null
            if (requestTableReference_tableReference_AthenaIsNull)
            {
                requestTableReference_tableReference_Athena = null;
            }
            if (requestTableReference_tableReference_Athena != null)
            {
                request.TableReference.Athena = requestTableReference_tableReference_Athena;
                requestTableReferenceIsNull = false;
            }
            Amazon.CleanRooms.Model.SnowflakeTableReference requestTableReference_tableReference_Snowflake = null;
            
             // populate Snowflake
            var requestTableReference_tableReference_SnowflakeIsNull = true;
            requestTableReference_tableReference_Snowflake = new Amazon.CleanRooms.Model.SnowflakeTableReference();
            System.String requestTableReference_tableReference_Snowflake_snowflake_AccountIdentifier = null;
            if (cmdletContext.Snowflake_AccountIdentifier != null)
            {
                requestTableReference_tableReference_Snowflake_snowflake_AccountIdentifier = cmdletContext.Snowflake_AccountIdentifier;
            }
            if (requestTableReference_tableReference_Snowflake_snowflake_AccountIdentifier != null)
            {
                requestTableReference_tableReference_Snowflake.AccountIdentifier = requestTableReference_tableReference_Snowflake_snowflake_AccountIdentifier;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
            System.String requestTableReference_tableReference_Snowflake_snowflake_DatabaseName = null;
            if (cmdletContext.Snowflake_DatabaseName != null)
            {
                requestTableReference_tableReference_Snowflake_snowflake_DatabaseName = cmdletContext.Snowflake_DatabaseName;
            }
            if (requestTableReference_tableReference_Snowflake_snowflake_DatabaseName != null)
            {
                requestTableReference_tableReference_Snowflake.DatabaseName = requestTableReference_tableReference_Snowflake_snowflake_DatabaseName;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
            System.String requestTableReference_tableReference_Snowflake_snowflake_SchemaName = null;
            if (cmdletContext.Snowflake_SchemaName != null)
            {
                requestTableReference_tableReference_Snowflake_snowflake_SchemaName = cmdletContext.Snowflake_SchemaName;
            }
            if (requestTableReference_tableReference_Snowflake_snowflake_SchemaName != null)
            {
                requestTableReference_tableReference_Snowflake.SchemaName = requestTableReference_tableReference_Snowflake_snowflake_SchemaName;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
            System.String requestTableReference_tableReference_Snowflake_snowflake_SecretArn = null;
            if (cmdletContext.Snowflake_SecretArn != null)
            {
                requestTableReference_tableReference_Snowflake_snowflake_SecretArn = cmdletContext.Snowflake_SecretArn;
            }
            if (requestTableReference_tableReference_Snowflake_snowflake_SecretArn != null)
            {
                requestTableReference_tableReference_Snowflake.SecretArn = requestTableReference_tableReference_Snowflake_snowflake_SecretArn;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
            System.String requestTableReference_tableReference_Snowflake_snowflake_TableName = null;
            if (cmdletContext.Snowflake_TableName != null)
            {
                requestTableReference_tableReference_Snowflake_snowflake_TableName = cmdletContext.Snowflake_TableName;
            }
            if (requestTableReference_tableReference_Snowflake_snowflake_TableName != null)
            {
                requestTableReference_tableReference_Snowflake.TableName = requestTableReference_tableReference_Snowflake_snowflake_TableName;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
            Amazon.CleanRooms.Model.SnowflakeTableSchema requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema = null;
            
             // populate TableSchema
            var requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchemaIsNull = true;
            requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema = new Amazon.CleanRooms.Model.SnowflakeTableSchema();
            List<Amazon.CleanRooms.Model.SnowflakeTableSchemaV1> requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema_tableSchema_V1 = null;
            if (cmdletContext.TableSchema_V1 != null)
            {
                requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema_tableSchema_V1 = cmdletContext.TableSchema_V1;
            }
            if (requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema_tableSchema_V1 != null)
            {
                requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema.V1 = requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema_tableSchema_V1;
                requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchemaIsNull = false;
            }
             // determine if requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema should be set to null
            if (requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchemaIsNull)
            {
                requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema = null;
            }
            if (requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema != null)
            {
                requestTableReference_tableReference_Snowflake.TableSchema = requestTableReference_tableReference_Snowflake_tableReference_Snowflake_TableSchema;
                requestTableReference_tableReference_SnowflakeIsNull = false;
            }
             // determine if requestTableReference_tableReference_Snowflake should be set to null
            if (requestTableReference_tableReference_SnowflakeIsNull)
            {
                requestTableReference_tableReference_Snowflake = null;
            }
            if (requestTableReference_tableReference_Snowflake != null)
            {
                request.TableReference.Snowflake = requestTableReference_tableReference_Snowflake;
                requestTableReferenceIsNull = false;
            }
             // determine if request.TableReference should be set to null
            if (requestTableReferenceIsNull)
            {
                request.TableReference = null;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredTable");
            try
            {
                #if DESKTOP
                return client.CreateConfiguredTable(request);
                #elif CORECLR
                return client.CreateConfiguredTableAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedColumn { get; set; }
            public Amazon.CleanRooms.AnalysisMethod AnalysisMethod { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> SelectedAnalysisMethod { get; set; }
            public System.String TableReference_Athena_CatalogName { get; set; }
            public System.String Athena_DatabaseName { get; set; }
            public System.String Athena_OutputLocation { get; set; }
            public Amazon.CleanRooms.CommercialRegion Athena_Region { get; set; }
            public System.String Athena_TableName { get; set; }
            public System.String Athena_WorkGroup { get; set; }
            public System.String Glue_DatabaseName { get; set; }
            public Amazon.CleanRooms.CommercialRegion Glue_Region { get; set; }
            public System.String Glue_TableName { get; set; }
            public System.String Snowflake_AccountIdentifier { get; set; }
            public System.String Snowflake_DatabaseName { get; set; }
            public System.String Snowflake_SchemaName { get; set; }
            public System.String Snowflake_SecretArn { get; set; }
            public System.String Snowflake_TableName { get; set; }
            public List<Amazon.CleanRooms.Model.SnowflakeTableSchemaV1> TableSchema_V1 { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredTableResponse, NewCRSConfiguredTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredTable;
        }
        
    }
}
