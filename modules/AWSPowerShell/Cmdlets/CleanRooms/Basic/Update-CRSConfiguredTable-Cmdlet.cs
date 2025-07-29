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
    /// Updates a configured table.
    /// </summary>
    [Cmdlet("Update", "CRSConfiguredTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTable")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service UpdateConfiguredTable API operation.", Operation = new[] {"UpdateConfiguredTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.UpdateConfiguredTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTable or Amazon.CleanRooms.Model.UpdateConfiguredTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTable object.",
        "The service call response (type Amazon.CleanRooms.Model.UpdateConfiguredTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCRSConfiguredTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedColumns")]
        public System.String[] AllowedColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisMethod
        /// <summary>
        /// <para>
        /// <para> The analysis method for the configured table.</para><para><c>DIRECT_QUERY</c> allows SQL queries to be run directly on this table.</para><para><c>DIRECT_JOB</c> allows PySpark jobs to be run directly on this table.</para><para><c>MULTIPLE</c> allows both SQL queries and PySpark jobs to be run directly on this
        /// table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRooms.AnalysisMethod")]
        public Amazon.CleanRooms.AnalysisMethod AnalysisMethod { get; set; }
        #endregion
        
        #region Parameter ConfiguredTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the configured table to update. Currently accepts the configured
        /// table ID.</para>
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
        public System.String ConfiguredTableIdentifier { get; set; }
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
        /// <para>A new description for the configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para> The selected analysis methods for the table configuration update.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.UpdateConfiguredTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.UpdateConfiguredTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredTable";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfiguredTableIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfiguredTableIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfiguredTableIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredTableIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRSConfiguredTable (UpdateConfiguredTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.UpdateConfiguredTableResponse, UpdateCRSConfiguredTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfiguredTableIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AllowedColumn != null)
            {
                context.AllowedColumn = new List<System.String>(this.AllowedColumn);
            }
            context.AnalysisMethod = this.AnalysisMethod;
            context.ConfiguredTableIdentifier = this.ConfiguredTableIdentifier;
            #if MODULAR
            if (this.ConfiguredTableIdentifier == null && ParameterWasBound(nameof(this.ConfiguredTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            if (this.SelectedAnalysisMethod != null)
            {
                context.SelectedAnalysisMethod = new List<System.String>(this.SelectedAnalysisMethod);
            }
            context.Athena_DatabaseName = this.Athena_DatabaseName;
            context.Athena_OutputLocation = this.Athena_OutputLocation;
            context.Athena_TableName = this.Athena_TableName;
            context.Athena_WorkGroup = this.Athena_WorkGroup;
            context.Glue_DatabaseName = this.Glue_DatabaseName;
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
            var request = new Amazon.CleanRooms.Model.UpdateConfiguredTableRequest();
            
            if (cmdletContext.AllowedColumn != null)
            {
                request.AllowedColumns = cmdletContext.AllowedColumn;
            }
            if (cmdletContext.AnalysisMethod != null)
            {
                request.AnalysisMethod = cmdletContext.AnalysisMethod;
            }
            if (cmdletContext.ConfiguredTableIdentifier != null)
            {
                request.ConfiguredTableIdentifier = cmdletContext.ConfiguredTableIdentifier;
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
        
        private Amazon.CleanRooms.Model.UpdateConfiguredTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.UpdateConfiguredTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "UpdateConfiguredTable");
            try
            {
                #if DESKTOP
                return client.UpdateConfiguredTable(request);
                #elif CORECLR
                return client.UpdateConfiguredTableAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfiguredTableIdentifier { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> SelectedAnalysisMethod { get; set; }
            public System.String Athena_DatabaseName { get; set; }
            public System.String Athena_OutputLocation { get; set; }
            public System.String Athena_TableName { get; set; }
            public System.String Athena_WorkGroup { get; set; }
            public System.String Glue_DatabaseName { get; set; }
            public System.String Glue_TableName { get; set; }
            public System.String Snowflake_AccountIdentifier { get; set; }
            public System.String Snowflake_DatabaseName { get; set; }
            public System.String Snowflake_SchemaName { get; set; }
            public System.String Snowflake_SecretArn { get; set; }
            public System.String Snowflake_TableName { get; set; }
            public List<Amazon.CleanRooms.Model.SnowflakeTableSchemaV1> TableSchema_V1 { get; set; }
            public System.Func<Amazon.CleanRooms.Model.UpdateConfiguredTableResponse, UpdateCRSConfiguredTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredTable;
        }
        
    }
}
