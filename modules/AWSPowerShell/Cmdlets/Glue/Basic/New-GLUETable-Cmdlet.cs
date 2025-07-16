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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new table definition in the Data Catalog.
    /// </summary>
    [Cmdlet("New", "GLUETable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateTableResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreateTableResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreateTableResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewGLUETableCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog in which to create the <c>Table</c>. If none is supplied,
        /// the Amazon Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The catalog database in which to create the new table. For Hive compatibility, this
        /// name is entirely lowercase.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter PartitionSpec_Field
        /// <summary>
        /// <para>
        /// <para>The list of partition fields that define how the table data should be partitioned,
        /// including source fields and their transformations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_Fields")]
        public Amazon.Glue.Model.IcebergPartitionField[] PartitionSpec_Field { get; set; }
        #endregion
        
        #region Parameter Schema_Field
        /// <summary>
        /// <para>
        /// <para>The list of field definitions that make up the table schema, including field names,
        /// types, and metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_Fields")]
        public Amazon.Glue.Model.IcebergStructField[] Schema_Field { get; set; }
        #endregion
        
        #region Parameter WriteOrder_Field
        /// <summary>
        /// <para>
        /// <para>The list of fields and their sort directions that define the ordering criteria for
        /// the Iceberg table data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_Fields")]
        public Amazon.Glue.Model.IcebergSortField[] WriteOrder_Field { get; set; }
        #endregion
        
        #region Parameter Schema_IdentifierFieldId
        /// <summary>
        /// <para>
        /// <para>The list of field identifiers that uniquely identify records in the table, used for
        /// row-level operations and deduplication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_IdentifierFieldIds")]
        public System.Int32[] Schema_IdentifierFieldId { get; set; }
        #endregion
        
        #region Parameter CreateIcebergTableInput_Location
        /// <summary>
        /// <para>
        /// <para>The S3 location where the Iceberg table data will be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Location")]
        public System.String CreateIcebergTableInput_Location { get; set; }
        #endregion
        
        #region Parameter IcebergInput_MetadataOperation
        /// <summary>
        /// <para>
        /// <para>A required metadata operation. Can only be set to <c>CREATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_MetadataOperation")]
        [AWSConstantClassSource("Amazon.Glue.MetadataOperation")]
        public Amazon.Glue.MetadataOperation IcebergInput_MetadataOperation { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the table within the specified database that will be created
        /// in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter WriteOrder_OrderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this sort order specification within the Iceberg table's
        /// metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_OrderId")]
        public System.Int32? WriteOrder_OrderId { get; set; }
        #endregion
        
        #region Parameter PartitionIndex
        /// <summary>
        /// <para>
        /// <para>A list of partition indexes, <c>PartitionIndex</c> structures, to create in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartitionIndexes")]
        public Amazon.Glue.Model.PartitionIndex[] PartitionIndex { get; set; }
        #endregion
        
        #region Parameter CreateIcebergTableInput_Property
        /// <summary>
        /// <para>
        /// <para>Key-value pairs of additional table properties and configuration settings for the
        /// Iceberg table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Properties")]
        public System.Collections.Hashtable CreateIcebergTableInput_Property { get; set; }
        #endregion
        
        #region Parameter Schema_SchemaId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this schema version within the Iceberg table's schema evolution
        /// history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_SchemaId")]
        public System.Int32? Schema_SchemaId { get; set; }
        #endregion
        
        #region Parameter PartitionSpec_SpecId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this partition specification within the Iceberg table's
        /// metadata history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_SpecId")]
        public System.Int32? PartitionSpec_SpecId { get; set; }
        #endregion
        
        #region Parameter TableInput
        /// <summary>
        /// <para>
        /// <para>The <c>TableInput</c> object that defines the metadata table to create in the catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.Glue.Model.TableInput TableInput { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The ID of the transaction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter Schema_Type
        /// <summary>
        /// <para>
        /// <para>The root type of the schema structure, typically "struct" for Iceberg table schemas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_Type")]
        [AWSConstantClassSource("Amazon.Glue.IcebergStructTypeEnum")]
        public Amazon.Glue.IcebergStructTypeEnum Schema_Type { get; set; }
        #endregion
        
        #region Parameter IcebergInput_Version
        /// <summary>
        /// <para>
        /// <para>The table version for the Iceberg table. Defaults to 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_Version")]
        public System.String IcebergInput_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateTableResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableInput parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableInput' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableInput' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUETable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateTableResponse, NewGLUETableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableInput;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.CreateIcebergTableInput_Location = this.CreateIcebergTableInput_Location;
            if (this.PartitionSpec_Field != null)
            {
                context.PartitionSpec_Field = new List<Amazon.Glue.Model.IcebergPartitionField>(this.PartitionSpec_Field);
            }
            context.PartitionSpec_SpecId = this.PartitionSpec_SpecId;
            if (this.CreateIcebergTableInput_Property != null)
            {
                context.CreateIcebergTableInput_Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CreateIcebergTableInput_Property.Keys)
                {
                    context.CreateIcebergTableInput_Property.Add((String)hashKey, (System.String)(this.CreateIcebergTableInput_Property[hashKey]));
                }
            }
            if (this.Schema_Field != null)
            {
                context.Schema_Field = new List<Amazon.Glue.Model.IcebergStructField>(this.Schema_Field);
            }
            if (this.Schema_IdentifierFieldId != null)
            {
                context.Schema_IdentifierFieldId = new List<System.Int32>(this.Schema_IdentifierFieldId);
            }
            context.Schema_SchemaId = this.Schema_SchemaId;
            context.Schema_Type = this.Schema_Type;
            if (this.WriteOrder_Field != null)
            {
                context.WriteOrder_Field = new List<Amazon.Glue.Model.IcebergSortField>(this.WriteOrder_Field);
            }
            context.WriteOrder_OrderId = this.WriteOrder_OrderId;
            context.IcebergInput_MetadataOperation = this.IcebergInput_MetadataOperation;
            context.IcebergInput_Version = this.IcebergInput_Version;
            if (this.PartitionIndex != null)
            {
                context.PartitionIndex = new List<Amazon.Glue.Model.PartitionIndex>(this.PartitionIndex);
            }
            context.TableInput = this.TableInput;
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.Glue.Model.CreateTableRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OpenTableFormatInput
            var requestOpenTableFormatInputIsNull = true;
            request.OpenTableFormatInput = new Amazon.Glue.Model.OpenTableFormatInput();
            Amazon.Glue.Model.IcebergInput requestOpenTableFormatInput_openTableFormatInput_IcebergInput = null;
            
             // populate IcebergInput
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput = new Amazon.Glue.Model.IcebergInput();
            Amazon.Glue.MetadataOperation requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation = null;
            if (cmdletContext.IcebergInput_MetadataOperation != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation = cmdletContext.IcebergInput_MetadataOperation;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput.MetadataOperation = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = false;
            }
            System.String requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version = null;
            if (cmdletContext.IcebergInput_Version != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version = cmdletContext.IcebergInput_Version;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput.Version = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = false;
            }
            Amazon.Glue.Model.CreateIcebergTableInput requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput = null;
            
             // populate CreateIcebergTableInput
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput = new Amazon.Glue.Model.CreateIcebergTableInput();
            System.String requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Location = null;
            if (cmdletContext.CreateIcebergTableInput_Location != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Location = cmdletContext.CreateIcebergTableInput_Location;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Location != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput.Location = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Location;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = false;
            }
            Dictionary<System.String, System.String> requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Property = null;
            if (cmdletContext.CreateIcebergTableInput_Property != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Property = cmdletContext.CreateIcebergTableInput_Property;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Property != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput.Properties = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_createIcebergTableInput_Property;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = false;
            }
            Amazon.Glue.Model.IcebergPartitionSpec requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec = null;
            
             // populate PartitionSpec
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpecIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec = new Amazon.Glue.Model.IcebergPartitionSpec();
            List<Amazon.Glue.Model.IcebergPartitionField> requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_Field = null;
            if (cmdletContext.PartitionSpec_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_Field = cmdletContext.PartitionSpec_Field;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec.Fields = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_Field;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpecIsNull = false;
            }
            System.Int32? requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_SpecId = null;
            if (cmdletContext.PartitionSpec_SpecId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_SpecId = cmdletContext.PartitionSpec_SpecId.Value;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_SpecId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec.SpecId = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec_partitionSpec_SpecId.Value;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpecIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpecIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput.PartitionSpec = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_PartitionSpec;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = false;
            }
            Amazon.Glue.Model.IcebergSortOrder requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder = null;
            
             // populate WriteOrder
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrderIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder = new Amazon.Glue.Model.IcebergSortOrder();
            List<Amazon.Glue.Model.IcebergSortField> requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_Field = null;
            if (cmdletContext.WriteOrder_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_Field = cmdletContext.WriteOrder_Field;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder.Fields = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_Field;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrderIsNull = false;
            }
            System.Int32? requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_OrderId = null;
            if (cmdletContext.WriteOrder_OrderId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_OrderId = cmdletContext.WriteOrder_OrderId.Value;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_OrderId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder.OrderId = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder_writeOrder_OrderId.Value;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrderIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrderIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput.WriteOrder = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_WriteOrder;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = false;
            }
            Amazon.Glue.Model.IcebergSchema requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema = null;
            
             // populate Schema
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema = new Amazon.Glue.Model.IcebergSchema();
            List<Amazon.Glue.Model.IcebergStructField> requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Field = null;
            if (cmdletContext.Schema_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Field = cmdletContext.Schema_Field;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Field != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema.Fields = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Field;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull = false;
            }
            List<System.Int32> requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_IdentifierFieldId = null;
            if (cmdletContext.Schema_IdentifierFieldId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_IdentifierFieldId = cmdletContext.Schema_IdentifierFieldId;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_IdentifierFieldId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema.IdentifierFieldIds = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_IdentifierFieldId;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull = false;
            }
            System.Int32? requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_SchemaId = null;
            if (cmdletContext.Schema_SchemaId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_SchemaId = cmdletContext.Schema_SchemaId.Value;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_SchemaId != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema.SchemaId = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_SchemaId.Value;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull = false;
            }
            Amazon.Glue.IcebergStructTypeEnum requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Type = null;
            if (cmdletContext.Schema_Type != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Type = cmdletContext.Schema_Type;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Type != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema.Type = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema_schema_Type;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_SchemaIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput.Schema = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput_Schema;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInputIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput.CreateIcebergTableInput = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_openTableFormatInput_IcebergInput_CreateIcebergTableInput;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput != null)
            {
                request.OpenTableFormatInput.IcebergInput = requestOpenTableFormatInput_openTableFormatInput_IcebergInput;
                requestOpenTableFormatInputIsNull = false;
            }
             // determine if request.OpenTableFormatInput should be set to null
            if (requestOpenTableFormatInputIsNull)
            {
                request.OpenTableFormatInput = null;
            }
            if (cmdletContext.PartitionIndex != null)
            {
                request.PartitionIndexes = cmdletContext.PartitionIndex;
            }
            if (cmdletContext.TableInput != null)
            {
                request.TableInput = cmdletContext.TableInput;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.Glue.Model.CreateTableResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateTable");
            try
            {
                #if DESKTOP
                return client.CreateTable(request);
                #elif CORECLR
                return client.CreateTableAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.String Name { get; set; }
            public System.String CreateIcebergTableInput_Location { get; set; }
            public List<Amazon.Glue.Model.IcebergPartitionField> PartitionSpec_Field { get; set; }
            public System.Int32? PartitionSpec_SpecId { get; set; }
            public Dictionary<System.String, System.String> CreateIcebergTableInput_Property { get; set; }
            public List<Amazon.Glue.Model.IcebergStructField> Schema_Field { get; set; }
            public List<System.Int32> Schema_IdentifierFieldId { get; set; }
            public System.Int32? Schema_SchemaId { get; set; }
            public Amazon.Glue.IcebergStructTypeEnum Schema_Type { get; set; }
            public List<Amazon.Glue.Model.IcebergSortField> WriteOrder_Field { get; set; }
            public System.Int32? WriteOrder_OrderId { get; set; }
            public Amazon.Glue.MetadataOperation IcebergInput_MetadataOperation { get; set; }
            public System.String IcebergInput_Version { get; set; }
            public List<Amazon.Glue.Model.PartitionIndex> PartitionIndex { get; set; }
            public Amazon.Glue.Model.TableInput TableInput { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.Glue.Model.CreateTableResponse, NewGLUETableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
