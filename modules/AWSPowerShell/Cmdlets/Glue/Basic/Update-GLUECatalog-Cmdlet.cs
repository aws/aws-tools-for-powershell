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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Updates an existing catalog's properties in the Glue Data Catalog.
    /// </summary>
    [Cmdlet("Update", "GLUECatalog", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue UpdateCatalog API operation.", Operation = new[] {"UpdateCatalog"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateCatalogResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.UpdateCatalogResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.UpdateCatalogResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateGLUECatalogCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CatalogInput_AllowFullTableExternalDataAccess
        /// <summary>
        /// <para>
        /// <para> Allows third-party engines to access data in Amazon S3 locations that are registered
        /// with Lake Formation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.AllowFullTableExternalDataAccessEnum")]
        public Amazon.Glue.AllowFullTableExternalDataAccessEnum CatalogInput_AllowFullTableExternalDataAccess { get; set; }
        #endregion
        
        #region Parameter TargetRedshiftCatalog_CatalogArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the catalog resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_TargetRedshiftCatalog_CatalogArn")]
        public System.String TargetRedshiftCatalog_CatalogArn { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the catalog.</para>
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
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DataLakeAccessProperties_CatalogType
        /// <summary>
        /// <para>
        /// <para>Specifies a federated catalog type for the native catalog resource. The currently
        /// supported type is <c>aws:redshift</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_DataLakeAccessProperties_CatalogType")]
        public System.String DataLakeAccessProperties_CatalogType { get; set; }
        #endregion
        
        #region Parameter IcebergOptimizationProperties_Compaction
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that specify configuration parameters for Iceberg table compaction
        /// operations, which optimize the layout of data files to improve query performance.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_IcebergOptimizationProperties_Compaction")]
        public System.Collections.Hashtable IcebergOptimizationProperties_Compaction { get; set; }
        #endregion
        
        #region Parameter FederatedCatalog_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to an external data source, for example a Redshift-federated
        /// catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_FederatedCatalog_ConnectionName")]
        public System.String FederatedCatalog_ConnectionName { get; set; }
        #endregion
        
        #region Parameter FederatedCatalog_ConnectionType
        /// <summary>
        /// <para>
        /// <para>The type of connection used to access the federated catalog, specifying the protocol
        /// or method for connection to the external data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_FederatedCatalog_ConnectionType")]
        public System.String FederatedCatalog_ConnectionType { get; set; }
        #endregion
        
        #region Parameter CatalogInput_CreateDatabaseDefaultPermission
        /// <summary>
        /// <para>
        /// <para>An array of <c>PrincipalPermissions</c> objects. Creates a set of default permissions
        /// on the database(s) for principals. Used by Amazon Web Services Lake Formation. Typically
        /// should be explicitly set as an empty list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CreateDatabaseDefaultPermissions")]
        public Amazon.Glue.Model.PrincipalPermissions[] CatalogInput_CreateDatabaseDefaultPermission { get; set; }
        #endregion
        
        #region Parameter CatalogInput_CreateTableDefaultPermission
        /// <summary>
        /// <para>
        /// <para>An array of <c>PrincipalPermissions</c> objects. Creates a set of default permissions
        /// on the table(s) for principals. Used by Amazon Web Services Lake Formation. Typically
        /// should be explicitly set as an empty list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CreateTableDefaultPermissions")]
        public Amazon.Glue.Model.PrincipalPermissions[] CatalogInput_CreateTableDefaultPermission { get; set; }
        #endregion
        
        #region Parameter CatalogProperties_CustomProperty
        /// <summary>
        /// <para>
        /// <para>Additional key-value properties for the catalog, such as column statistics optimizations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_CustomProperties")]
        public System.Collections.Hashtable CatalogProperties_CustomProperty { get; set; }
        #endregion
        
        #region Parameter DataLakeAccessProperties_DataLakeAccess
        /// <summary>
        /// <para>
        /// <para>Turns on or off data lake access for Apache Spark applications that access Amazon
        /// Redshift databases in the Data Catalog from any non-Redshift engine, such as Amazon
        /// Athena, Amazon EMR, or Glue ETL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_DataLakeAccessProperties_DataLakeAccess")]
        public System.Boolean? DataLakeAccessProperties_DataLakeAccess { get; set; }
        #endregion
        
        #region Parameter DataLakeAccessProperties_DataTransferRole
        /// <summary>
        /// <para>
        /// <para>A role that will be assumed by Glue for transferring data into/out of the staging
        /// bucket during a query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_DataLakeAccessProperties_DataTransferRole")]
        public System.String DataLakeAccessProperties_DataTransferRole { get; set; }
        #endregion
        
        #region Parameter CatalogInput_Description
        /// <summary>
        /// <para>
        /// <para>Description string, not more than 2048 bytes long, matching the URI address multi-line
        /// string pattern. A description of the catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogInput_Description { get; set; }
        #endregion
        
        #region Parameter FederatedCatalog_Identifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the federated catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_FederatedCatalog_Identifier")]
        public System.String FederatedCatalog_Identifier { get; set; }
        #endregion
        
        #region Parameter DataLakeAccessProperties_KmsKey
        /// <summary>
        /// <para>
        /// <para>An encryption key that will be used for the staging bucket that will be created along
        /// with the catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_DataLakeAccessProperties_KmsKey")]
        public System.String DataLakeAccessProperties_KmsKey { get; set; }
        #endregion
        
        #region Parameter IcebergOptimizationProperties_OrphanFileDeletion
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that specify configuration parameters for Iceberg orphan
        /// file deletion operations, which identify and remove files that are no longer referenced
        /// by the table metadata.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_IcebergOptimizationProperties_OrphanFileDeletion")]
        public System.Collections.Hashtable IcebergOptimizationProperties_OrphanFileDeletion { get; set; }
        #endregion
        
        #region Parameter CatalogInput_Parameter
        /// <summary>
        /// <para>
        /// <para>A map array of key-value pairs that define the parameters and properties of the catalog.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_Parameters")]
        public System.Collections.Hashtable CatalogInput_Parameter { get; set; }
        #endregion
        
        #region Parameter IcebergOptimizationProperties_Retention
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that specify configuration parameters for Iceberg table retention
        /// operations, which manage the lifecycle of table snapshots to control storage costs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_IcebergOptimizationProperties_Retention")]
        public System.Collections.Hashtable IcebergOptimizationProperties_Retention { get; set; }
        #endregion
        
        #region Parameter IcebergOptimizationProperties_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that will be assumed to perform Iceberg
        /// table optimization operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogInput_CatalogProperties_IcebergOptimizationProperties_RoleArn")]
        public System.String IcebergOptimizationProperties_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateCatalogResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUECatalog (UpdateCatalog)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateCatalogResponse, UpdateGLUECatalogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            #if MODULAR
            if (this.CatalogId == null && ParameterWasBound(nameof(this.CatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter CatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CatalogInput_AllowFullTableExternalDataAccess = this.CatalogInput_AllowFullTableExternalDataAccess;
            if (this.CatalogProperties_CustomProperty != null)
            {
                context.CatalogProperties_CustomProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CatalogProperties_CustomProperty.Keys)
                {
                    context.CatalogProperties_CustomProperty.Add((String)hashKey, (System.String)(this.CatalogProperties_CustomProperty[hashKey]));
                }
            }
            context.DataLakeAccessProperties_CatalogType = this.DataLakeAccessProperties_CatalogType;
            context.DataLakeAccessProperties_DataLakeAccess = this.DataLakeAccessProperties_DataLakeAccess;
            context.DataLakeAccessProperties_DataTransferRole = this.DataLakeAccessProperties_DataTransferRole;
            context.DataLakeAccessProperties_KmsKey = this.DataLakeAccessProperties_KmsKey;
            if (this.IcebergOptimizationProperties_Compaction != null)
            {
                context.IcebergOptimizationProperties_Compaction = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IcebergOptimizationProperties_Compaction.Keys)
                {
                    context.IcebergOptimizationProperties_Compaction.Add((String)hashKey, (System.String)(this.IcebergOptimizationProperties_Compaction[hashKey]));
                }
            }
            if (this.IcebergOptimizationProperties_OrphanFileDeletion != null)
            {
                context.IcebergOptimizationProperties_OrphanFileDeletion = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IcebergOptimizationProperties_OrphanFileDeletion.Keys)
                {
                    context.IcebergOptimizationProperties_OrphanFileDeletion.Add((String)hashKey, (System.String)(this.IcebergOptimizationProperties_OrphanFileDeletion[hashKey]));
                }
            }
            if (this.IcebergOptimizationProperties_Retention != null)
            {
                context.IcebergOptimizationProperties_Retention = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IcebergOptimizationProperties_Retention.Keys)
                {
                    context.IcebergOptimizationProperties_Retention.Add((String)hashKey, (System.String)(this.IcebergOptimizationProperties_Retention[hashKey]));
                }
            }
            context.IcebergOptimizationProperties_RoleArn = this.IcebergOptimizationProperties_RoleArn;
            if (this.CatalogInput_CreateDatabaseDefaultPermission != null)
            {
                context.CatalogInput_CreateDatabaseDefaultPermission = new List<Amazon.Glue.Model.PrincipalPermissions>(this.CatalogInput_CreateDatabaseDefaultPermission);
            }
            if (this.CatalogInput_CreateTableDefaultPermission != null)
            {
                context.CatalogInput_CreateTableDefaultPermission = new List<Amazon.Glue.Model.PrincipalPermissions>(this.CatalogInput_CreateTableDefaultPermission);
            }
            context.CatalogInput_Description = this.CatalogInput_Description;
            context.FederatedCatalog_ConnectionName = this.FederatedCatalog_ConnectionName;
            context.FederatedCatalog_ConnectionType = this.FederatedCatalog_ConnectionType;
            context.FederatedCatalog_Identifier = this.FederatedCatalog_Identifier;
            if (this.CatalogInput_Parameter != null)
            {
                context.CatalogInput_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CatalogInput_Parameter.Keys)
                {
                    context.CatalogInput_Parameter.Add((String)hashKey, (System.String)(this.CatalogInput_Parameter[hashKey]));
                }
            }
            context.TargetRedshiftCatalog_CatalogArn = this.TargetRedshiftCatalog_CatalogArn;
            
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
            var request = new Amazon.Glue.Model.UpdateCatalogRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
             // populate CatalogInput
            request.CatalogInput = new Amazon.Glue.Model.CatalogInput();
            Amazon.Glue.AllowFullTableExternalDataAccessEnum requestCatalogInput_catalogInput_AllowFullTableExternalDataAccess = null;
            if (cmdletContext.CatalogInput_AllowFullTableExternalDataAccess != null)
            {
                requestCatalogInput_catalogInput_AllowFullTableExternalDataAccess = cmdletContext.CatalogInput_AllowFullTableExternalDataAccess;
            }
            if (requestCatalogInput_catalogInput_AllowFullTableExternalDataAccess != null)
            {
                request.CatalogInput.AllowFullTableExternalDataAccess = requestCatalogInput_catalogInput_AllowFullTableExternalDataAccess;
            }
            List<Amazon.Glue.Model.PrincipalPermissions> requestCatalogInput_catalogInput_CreateDatabaseDefaultPermission = null;
            if (cmdletContext.CatalogInput_CreateDatabaseDefaultPermission != null)
            {
                requestCatalogInput_catalogInput_CreateDatabaseDefaultPermission = cmdletContext.CatalogInput_CreateDatabaseDefaultPermission;
            }
            if (requestCatalogInput_catalogInput_CreateDatabaseDefaultPermission != null)
            {
                request.CatalogInput.CreateDatabaseDefaultPermissions = requestCatalogInput_catalogInput_CreateDatabaseDefaultPermission;
            }
            List<Amazon.Glue.Model.PrincipalPermissions> requestCatalogInput_catalogInput_CreateTableDefaultPermission = null;
            if (cmdletContext.CatalogInput_CreateTableDefaultPermission != null)
            {
                requestCatalogInput_catalogInput_CreateTableDefaultPermission = cmdletContext.CatalogInput_CreateTableDefaultPermission;
            }
            if (requestCatalogInput_catalogInput_CreateTableDefaultPermission != null)
            {
                request.CatalogInput.CreateTableDefaultPermissions = requestCatalogInput_catalogInput_CreateTableDefaultPermission;
            }
            System.String requestCatalogInput_catalogInput_Description = null;
            if (cmdletContext.CatalogInput_Description != null)
            {
                requestCatalogInput_catalogInput_Description = cmdletContext.CatalogInput_Description;
            }
            if (requestCatalogInput_catalogInput_Description != null)
            {
                request.CatalogInput.Description = requestCatalogInput_catalogInput_Description;
            }
            Dictionary<System.String, System.String> requestCatalogInput_catalogInput_Parameter = null;
            if (cmdletContext.CatalogInput_Parameter != null)
            {
                requestCatalogInput_catalogInput_Parameter = cmdletContext.CatalogInput_Parameter;
            }
            if (requestCatalogInput_catalogInput_Parameter != null)
            {
                request.CatalogInput.Parameters = requestCatalogInput_catalogInput_Parameter;
            }
            Amazon.Glue.Model.TargetRedshiftCatalog requestCatalogInput_catalogInput_TargetRedshiftCatalog = null;
            
             // populate TargetRedshiftCatalog
            var requestCatalogInput_catalogInput_TargetRedshiftCatalogIsNull = true;
            requestCatalogInput_catalogInput_TargetRedshiftCatalog = new Amazon.Glue.Model.TargetRedshiftCatalog();
            System.String requestCatalogInput_catalogInput_TargetRedshiftCatalog_targetRedshiftCatalog_CatalogArn = null;
            if (cmdletContext.TargetRedshiftCatalog_CatalogArn != null)
            {
                requestCatalogInput_catalogInput_TargetRedshiftCatalog_targetRedshiftCatalog_CatalogArn = cmdletContext.TargetRedshiftCatalog_CatalogArn;
            }
            if (requestCatalogInput_catalogInput_TargetRedshiftCatalog_targetRedshiftCatalog_CatalogArn != null)
            {
                requestCatalogInput_catalogInput_TargetRedshiftCatalog.CatalogArn = requestCatalogInput_catalogInput_TargetRedshiftCatalog_targetRedshiftCatalog_CatalogArn;
                requestCatalogInput_catalogInput_TargetRedshiftCatalogIsNull = false;
            }
             // determine if requestCatalogInput_catalogInput_TargetRedshiftCatalog should be set to null
            if (requestCatalogInput_catalogInput_TargetRedshiftCatalogIsNull)
            {
                requestCatalogInput_catalogInput_TargetRedshiftCatalog = null;
            }
            if (requestCatalogInput_catalogInput_TargetRedshiftCatalog != null)
            {
                request.CatalogInput.TargetRedshiftCatalog = requestCatalogInput_catalogInput_TargetRedshiftCatalog;
            }
            Amazon.Glue.Model.CatalogProperties requestCatalogInput_catalogInput_CatalogProperties = null;
            
             // populate CatalogProperties
            var requestCatalogInput_catalogInput_CatalogPropertiesIsNull = true;
            requestCatalogInput_catalogInput_CatalogProperties = new Amazon.Glue.Model.CatalogProperties();
            Dictionary<System.String, System.String> requestCatalogInput_catalogInput_CatalogProperties_catalogProperties_CustomProperty = null;
            if (cmdletContext.CatalogProperties_CustomProperty != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogProperties_CustomProperty = cmdletContext.CatalogProperties_CustomProperty;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogProperties_CustomProperty != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties.CustomProperties = requestCatalogInput_catalogInput_CatalogProperties_catalogProperties_CustomProperty;
                requestCatalogInput_catalogInput_CatalogPropertiesIsNull = false;
            }
            Amazon.Glue.Model.DataLakeAccessProperties requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties = null;
            
             // populate DataLakeAccessProperties
            var requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull = true;
            requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties = new Amazon.Glue.Model.DataLakeAccessProperties();
            System.String requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_CatalogType = null;
            if (cmdletContext.DataLakeAccessProperties_CatalogType != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_CatalogType = cmdletContext.DataLakeAccessProperties_CatalogType;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_CatalogType != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties.CatalogType = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_CatalogType;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull = false;
            }
            System.Boolean? requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataLakeAccess = null;
            if (cmdletContext.DataLakeAccessProperties_DataLakeAccess != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataLakeAccess = cmdletContext.DataLakeAccessProperties_DataLakeAccess.Value;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataLakeAccess != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties.DataLakeAccess = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataLakeAccess.Value;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull = false;
            }
            System.String requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataTransferRole = null;
            if (cmdletContext.DataLakeAccessProperties_DataTransferRole != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataTransferRole = cmdletContext.DataLakeAccessProperties_DataTransferRole;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataTransferRole != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties.DataTransferRole = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_DataTransferRole;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull = false;
            }
            System.String requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_KmsKey = null;
            if (cmdletContext.DataLakeAccessProperties_KmsKey != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_KmsKey = cmdletContext.DataLakeAccessProperties_KmsKey;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_KmsKey != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties.KmsKey = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties_dataLakeAccessProperties_KmsKey;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull = false;
            }
             // determine if requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties should be set to null
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessPropertiesIsNull)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties = null;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties.DataLakeAccessProperties = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_DataLakeAccessProperties;
                requestCatalogInput_catalogInput_CatalogPropertiesIsNull = false;
            }
            Amazon.Glue.Model.IcebergOptimizationProperties requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties = null;
            
             // populate IcebergOptimizationProperties
            var requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull = true;
            requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties = new Amazon.Glue.Model.IcebergOptimizationProperties();
            Dictionary<System.String, System.String> requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Compaction = null;
            if (cmdletContext.IcebergOptimizationProperties_Compaction != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Compaction = cmdletContext.IcebergOptimizationProperties_Compaction;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Compaction != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties.Compaction = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Compaction;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull = false;
            }
            Dictionary<System.String, System.String> requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_OrphanFileDeletion = null;
            if (cmdletContext.IcebergOptimizationProperties_OrphanFileDeletion != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_OrphanFileDeletion = cmdletContext.IcebergOptimizationProperties_OrphanFileDeletion;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_OrphanFileDeletion != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties.OrphanFileDeletion = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_OrphanFileDeletion;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull = false;
            }
            Dictionary<System.String, System.String> requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Retention = null;
            if (cmdletContext.IcebergOptimizationProperties_Retention != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Retention = cmdletContext.IcebergOptimizationProperties_Retention;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Retention != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties.Retention = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_Retention;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull = false;
            }
            System.String requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_RoleArn = null;
            if (cmdletContext.IcebergOptimizationProperties_RoleArn != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_RoleArn = cmdletContext.IcebergOptimizationProperties_RoleArn;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_RoleArn != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties.RoleArn = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties_icebergOptimizationProperties_RoleArn;
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull = false;
            }
             // determine if requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties should be set to null
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationPropertiesIsNull)
            {
                requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties = null;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties != null)
            {
                requestCatalogInput_catalogInput_CatalogProperties.IcebergOptimizationProperties = requestCatalogInput_catalogInput_CatalogProperties_catalogInput_CatalogProperties_IcebergOptimizationProperties;
                requestCatalogInput_catalogInput_CatalogPropertiesIsNull = false;
            }
             // determine if requestCatalogInput_catalogInput_CatalogProperties should be set to null
            if (requestCatalogInput_catalogInput_CatalogPropertiesIsNull)
            {
                requestCatalogInput_catalogInput_CatalogProperties = null;
            }
            if (requestCatalogInput_catalogInput_CatalogProperties != null)
            {
                request.CatalogInput.CatalogProperties = requestCatalogInput_catalogInput_CatalogProperties;
            }
            Amazon.Glue.Model.FederatedCatalog requestCatalogInput_catalogInput_FederatedCatalog = null;
            
             // populate FederatedCatalog
            var requestCatalogInput_catalogInput_FederatedCatalogIsNull = true;
            requestCatalogInput_catalogInput_FederatedCatalog = new Amazon.Glue.Model.FederatedCatalog();
            System.String requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionName = null;
            if (cmdletContext.FederatedCatalog_ConnectionName != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionName = cmdletContext.FederatedCatalog_ConnectionName;
            }
            if (requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionName != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog.ConnectionName = requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionName;
                requestCatalogInput_catalogInput_FederatedCatalogIsNull = false;
            }
            System.String requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionType = null;
            if (cmdletContext.FederatedCatalog_ConnectionType != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionType = cmdletContext.FederatedCatalog_ConnectionType;
            }
            if (requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionType != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog.ConnectionType = requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_ConnectionType;
                requestCatalogInput_catalogInput_FederatedCatalogIsNull = false;
            }
            System.String requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_Identifier = null;
            if (cmdletContext.FederatedCatalog_Identifier != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_Identifier = cmdletContext.FederatedCatalog_Identifier;
            }
            if (requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_Identifier != null)
            {
                requestCatalogInput_catalogInput_FederatedCatalog.Identifier = requestCatalogInput_catalogInput_FederatedCatalog_federatedCatalog_Identifier;
                requestCatalogInput_catalogInput_FederatedCatalogIsNull = false;
            }
             // determine if requestCatalogInput_catalogInput_FederatedCatalog should be set to null
            if (requestCatalogInput_catalogInput_FederatedCatalogIsNull)
            {
                requestCatalogInput_catalogInput_FederatedCatalog = null;
            }
            if (requestCatalogInput_catalogInput_FederatedCatalog != null)
            {
                request.CatalogInput.FederatedCatalog = requestCatalogInput_catalogInput_FederatedCatalog;
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
        
        private Amazon.Glue.Model.UpdateCatalogResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateCatalogRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateCatalog");
            try
            {
                return client.UpdateCatalogAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Glue.AllowFullTableExternalDataAccessEnum CatalogInput_AllowFullTableExternalDataAccess { get; set; }
            public Dictionary<System.String, System.String> CatalogProperties_CustomProperty { get; set; }
            public System.String DataLakeAccessProperties_CatalogType { get; set; }
            public System.Boolean? DataLakeAccessProperties_DataLakeAccess { get; set; }
            public System.String DataLakeAccessProperties_DataTransferRole { get; set; }
            public System.String DataLakeAccessProperties_KmsKey { get; set; }
            public Dictionary<System.String, System.String> IcebergOptimizationProperties_Compaction { get; set; }
            public Dictionary<System.String, System.String> IcebergOptimizationProperties_OrphanFileDeletion { get; set; }
            public Dictionary<System.String, System.String> IcebergOptimizationProperties_Retention { get; set; }
            public System.String IcebergOptimizationProperties_RoleArn { get; set; }
            public List<Amazon.Glue.Model.PrincipalPermissions> CatalogInput_CreateDatabaseDefaultPermission { get; set; }
            public List<Amazon.Glue.Model.PrincipalPermissions> CatalogInput_CreateTableDefaultPermission { get; set; }
            public System.String CatalogInput_Description { get; set; }
            public System.String FederatedCatalog_ConnectionName { get; set; }
            public System.String FederatedCatalog_ConnectionType { get; set; }
            public System.String FederatedCatalog_Identifier { get; set; }
            public Dictionary<System.String, System.String> CatalogInput_Parameter { get; set; }
            public System.String TargetRedshiftCatalog_CatalogArn { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateCatalogResponse, UpdateGLUECatalogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
