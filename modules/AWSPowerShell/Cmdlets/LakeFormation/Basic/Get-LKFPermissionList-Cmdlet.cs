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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Returns a list of the principal permissions on the resource, filtered by the permissions
    /// of the caller. For example, if you are granted an ALTER permission, you are able to
    /// see only the principal permissions for ALTER.
    /// 
    ///  
    /// <para>
    /// This operation returns only those permissions that have been explicitly granted.
    /// </para><para>
    /// For information about permissions, see <a href="https://docs-aws.amazon.com/lake-formation/latest/dg/security-data-access.html">Security
    /// and Access Control to Metadata and Data</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LKFPermissionList")]
    [OutputType("Amazon.LakeFormation.Model.PrincipalResourcePermissions")]
    [AWSCmdlet("Calls the AWS Lake Formation ListPermissions API operation.", Operation = new[] {"ListPermissions"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.ListPermissionsResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.PrincipalResourcePermissions or Amazon.LakeFormation.Model.ListPermissionsResponse",
        "This cmdlet returns a collection of Amazon.LakeFormation.Model.PrincipalResourcePermissions objects.",
        "The service call response (type Amazon.LakeFormation.Model.ListPermissionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLKFPermissionListCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Resource_Catalog
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LakeFormation.Model.CatalogResource Resource_Catalog { get; set; }
        #endregion
        
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
        /// <para>The list of column names for the table. At least one of <code>ColumnNames</code> or
        /// <code>ColumnWildcard</code> is required.</para>
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
        
        #region Parameter Principal_DataLakePrincipalIdentifier
        /// <summary>
        /// <para>
        /// <para>An identifier for the Lake Formation principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal_DataLakePrincipalIdentifier { get; set; }
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
        /// <para>A list of LF-tag conditions that apply to the resource's LF-tag policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTagPolicy_Expression")]
        public Amazon.LakeFormation.Model.LFTag[] LFTagPolicy_Expression { get; set; }
        #endregion
        
        #region Parameter IncludeRelated
        /// <summary>
        /// <para>
        /// <para>Indicates that related permissions should be included in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncludeRelated { get; set; }
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
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies a resource type to filter the permissions returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LakeFormation.DataLakeResourceType")]
        public Amazon.LakeFormation.DataLakeResourceType ResourceType { get; set; }
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
        /// <para>A wildcard object representing every table under a database.</para><para>At least one of <code>TableResource$Name</code> or <code>TableResource$TableWildcard</code>
        /// is required.</para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is not the first call to retrieve this list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrincipalResourcePermissions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.ListPermissionsResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.ListPermissionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrincipalResourcePermissions";
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.ListPermissionsResponse, GetLKFPermissionListCmdlet>(Select) ??
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
            context.IncludeRelated = this.IncludeRelated;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Principal_DataLakePrincipalIdentifier = this.Principal_DataLakePrincipalIdentifier;
            context.Resource_Catalog = this.Resource_Catalog;
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
            context.LFTagPolicy_CatalogId = this.LFTagPolicy_CatalogId;
            if (this.LFTagPolicy_Expression != null)
            {
                context.LFTagPolicy_Expression = new List<Amazon.LakeFormation.Model.LFTag>(this.LFTagPolicy_Expression);
            }
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
            context.ResourceType = this.ResourceType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.LakeFormation.Model.ListPermissionsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.IncludeRelated != null)
            {
                request.IncludeRelated = cmdletContext.IncludeRelated;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Principal
            var requestPrincipalIsNull = true;
            request.Principal = new Amazon.LakeFormation.Model.DataLakePrincipal();
            System.String requestPrincipal_principal_DataLakePrincipalIdentifier = null;
            if (cmdletContext.Principal_DataLakePrincipalIdentifier != null)
            {
                requestPrincipal_principal_DataLakePrincipalIdentifier = cmdletContext.Principal_DataLakePrincipalIdentifier;
            }
            if (requestPrincipal_principal_DataLakePrincipalIdentifier != null)
            {
                request.Principal.DataLakePrincipalIdentifier = requestPrincipal_principal_DataLakePrincipalIdentifier;
                requestPrincipalIsNull = false;
            }
             // determine if request.Principal should be set to null
            if (requestPrincipalIsNull)
            {
                request.Principal = null;
            }
            
             // populate Resource
            var requestResourceIsNull = true;
            request.Resource = new Amazon.LakeFormation.Model.Resource();
            Amazon.LakeFormation.Model.CatalogResource requestResource_resource_Catalog = null;
            if (cmdletContext.Resource_Catalog != null)
            {
                requestResource_resource_Catalog = cmdletContext.Resource_Catalog;
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
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.LakeFormation.Model.ListPermissionsRequest();
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.IncludeRelated != null)
            {
                request.IncludeRelated = cmdletContext.IncludeRelated;
            }
            
             // populate Principal
            var requestPrincipalIsNull = true;
            request.Principal = new Amazon.LakeFormation.Model.DataLakePrincipal();
            System.String requestPrincipal_principal_DataLakePrincipalIdentifier = null;
            if (cmdletContext.Principal_DataLakePrincipalIdentifier != null)
            {
                requestPrincipal_principal_DataLakePrincipalIdentifier = cmdletContext.Principal_DataLakePrincipalIdentifier;
            }
            if (requestPrincipal_principal_DataLakePrincipalIdentifier != null)
            {
                request.Principal.DataLakePrincipalIdentifier = requestPrincipal_principal_DataLakePrincipalIdentifier;
                requestPrincipalIsNull = false;
            }
             // determine if request.Principal should be set to null
            if (requestPrincipalIsNull)
            {
                request.Principal = null;
            }
            
             // populate Resource
            var requestResourceIsNull = true;
            request.Resource = new Amazon.LakeFormation.Model.Resource();
            Amazon.LakeFormation.Model.CatalogResource requestResource_resource_Catalog = null;
            if (cmdletContext.Resource_Catalog != null)
            {
                requestResource_resource_Catalog = cmdletContext.Resource_Catalog;
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
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.PrincipalResourcePermissions.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LakeFormation.Model.ListPermissionsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.ListPermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "ListPermissions");
            try
            {
                #if DESKTOP
                return client.ListPermissions(request);
                #elif CORECLR
                return client.ListPermissionsAsync(request).GetAwaiter().GetResult();
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
            public System.String IncludeRelated { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Principal_DataLakePrincipalIdentifier { get; set; }
            public Amazon.LakeFormation.Model.CatalogResource Resource_Catalog { get; set; }
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
            public System.String LFTagPolicy_CatalogId { get; set; }
            public List<Amazon.LakeFormation.Model.LFTag> LFTagPolicy_Expression { get; set; }
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
            public Amazon.LakeFormation.DataLakeResourceType ResourceType { get; set; }
            public System.Func<Amazon.LakeFormation.Model.ListPermissionsResponse, GetLKFPermissionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrincipalResourcePermissions;
        }
        
    }
}
