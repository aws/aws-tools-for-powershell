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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Lists the row-level security policy attachments in the Data Catalog. You can filter
    /// the results by resource, principal, or policy name.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LKFRLSPolicyAttachmentList")]
    [OutputType("Amazon.LakeFormation.Model.RLSPolicyAttachment")]
    [AWSCmdlet("Calls the AWS Lake Formation ListRLSPolicyAttachments API operation.", Operation = new[] {"ListRLSPolicyAttachments"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.RLSPolicyAttachment or Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse",
        "This cmdlet returns a collection of Amazon.LakeFormation.Model.RLSPolicyAttachment objects.",
        "The service call response (type Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLKFRLSPolicyAttachmentListCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Resource_DataLocation_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog where the location is registered with Lake Formation.
        /// By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataLocation_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_Database_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Database_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_LFTag_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTag_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagExpression_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTagExpression_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagPolicy_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTagPolicy_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_RLSPolicy_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog that contains the policy. By default, the account
        /// ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_RLSPolicy_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_Table_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Table_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_TableWithColumns_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_TableWithColumns_CatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_TableWithColumns_ColumnName
        /// <summary>
        /// <para>
        /// <para>The list of column names for the table. At least one of <c>ColumnNames</c> or <c>ColumnWildcard</c>
        /// is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_ColumnNames")]
        public System.String[] Resource_TableWithColumns_ColumnName { get; set; }
        #endregion
        
        #region Parameter Resource_DataCellsFilter_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataCellsFilter_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Resource_Table_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database for the table. Unique to a Data Catalog. A database is a
        /// set of associated table definitions organized into a logical group. You can Grant
        /// and Revoke database privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Table_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Resource_TableWithColumns_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database for the table with columns resource. Unique to the Data Catalog.
        /// A database is a set of associated table definitions organized into a logical group.
        /// You can Grant and Revoke database privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_TableWithColumns_DatabaseName { get; set; }
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
        
        #region Parameter Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName
        /// <summary>
        /// <para>
        /// <para>Excludes column names. Any column with this name will be excluded.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_TableWithColumns_ColumnWildcard_ExcludedColumnNames")]
        public System.String[] Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagPolicy_Expression
        /// <summary>
        /// <para>
        /// <para>A list of LF-tag conditions or a saved expression that apply to the resource's LF-tag
        /// policy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LakeFormation.Model.LFTag[] Resource_LFTagPolicy_Expression { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagPolicy_ExpressionName
        /// <summary>
        /// <para>
        /// <para>If provided, permissions are granted to the Data Catalog resources whose assigned
        /// LF-Tags match the expression body of the saved expression under the provided <c>ExpressionName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTagPolicy_ExpressionName { get; set; }
        #endregion
        
        #region Parameter Resource_Catalog_Id
        /// <summary>
        /// <para>
        /// <para>An identifier for the catalog resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Catalog_Id { get; set; }
        #endregion
        
        #region Parameter Resource_DataCellsFilter_Name
        /// <summary>
        /// <para>
        /// <para>The name of the data cells filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataCellsFilter_Name { get; set; }
        #endregion
        
        #region Parameter Resource_Database_Name
        /// <summary>
        /// <para>
        /// <para>The name of the database resource. Unique to the Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Database_Name { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagExpression_Name
        /// <summary>
        /// <para>
        /// <para>The name of the LF-Tag expression to grant permissions on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTagExpression_Name { get; set; }
        #endregion
        
        #region Parameter Resource_RLSPolicy_Name
        /// <summary>
        /// <para>
        /// <para>The name of the row-level security policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_RLSPolicy_Name { get; set; }
        #endregion
        
        #region Parameter Resource_Table_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_Table_Name { get; set; }
        #endregion
        
        #region Parameter Resource_TableWithColumns_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table resource. A table is a metadata definition that represents your
        /// data. You can Grant and Revoke table privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_TableWithColumns_Name { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>If specified, returns only the attachments for the row-level security policy with
        /// this name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter Resource_DataLocation_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the data location resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataLocation_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Resource_LFTagPolicy_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type for which the LF-tag policy applies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LakeFormation.ResourceType")]
        public Amazon.LakeFormation.ResourceType Resource_LFTagPolicy_ResourceType { get; set; }
        #endregion
        
        #region Parameter Resource_DataCellsFilter_TableCatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the catalog to which the table belongs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataCellsFilter_TableCatalogId { get; set; }
        #endregion
        
        #region Parameter Resource_DataCellsFilter_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_DataCellsFilter_TableName { get; set; }
        #endregion
        
        #region Parameter Resource_Table_TableWildcard
        /// <summary>
        /// <para>
        /// <para>A wildcard object representing every table under a database.</para><para>At least one of <c>TableResource$Name</c> or <c>TableResource$TableWildcard</c> is
        /// required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LakeFormation.Model.TableWildcard Resource_Table_TableWildcard { get; set; }
        #endregion
        
        #region Parameter Resource_LFTag_TagKey
        /// <summary>
        /// <para>
        /// <para>The key-name for the LF-tag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_LFTag_TagKey { get; set; }
        #endregion
        
        #region Parameter Resource_LFTag_TagValue
        /// <summary>
        /// <para>
        /// <para>A list of possible values an attribute can take.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_LFTag_TagValues")]
        public System.String[] Resource_LFTag_TagValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of attachments to return in a single response.</para>
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
        /// <para>A continuation token, if this is a continuation call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RLSPolicyAttachments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RLSPolicyAttachments";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse, GetLKFRLSPolicyAttachmentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.PolicyName = this.PolicyName;
            context.Principal_DataLakePrincipalIdentifier = this.Principal_DataLakePrincipalIdentifier;
            context.Resource_Catalog_Id = this.Resource_Catalog_Id;
            context.Resource_DataCellsFilter_DatabaseName = this.Resource_DataCellsFilter_DatabaseName;
            context.Resource_DataCellsFilter_Name = this.Resource_DataCellsFilter_Name;
            context.Resource_DataCellsFilter_TableCatalogId = this.Resource_DataCellsFilter_TableCatalogId;
            context.Resource_DataCellsFilter_TableName = this.Resource_DataCellsFilter_TableName;
            context.Resource_DataLocation_CatalogId = this.Resource_DataLocation_CatalogId;
            context.Resource_DataLocation_ResourceArn = this.Resource_DataLocation_ResourceArn;
            context.Resource_Database_CatalogId = this.Resource_Database_CatalogId;
            context.Resource_Database_Name = this.Resource_Database_Name;
            context.Resource_LFTag_CatalogId = this.Resource_LFTag_CatalogId;
            context.Resource_LFTag_TagKey = this.Resource_LFTag_TagKey;
            if (this.Resource_LFTag_TagValue != null)
            {
                context.Resource_LFTag_TagValue = new List<System.String>(this.Resource_LFTag_TagValue);
            }
            context.Resource_LFTagExpression_CatalogId = this.Resource_LFTagExpression_CatalogId;
            context.Resource_LFTagExpression_Name = this.Resource_LFTagExpression_Name;
            context.Resource_LFTagPolicy_CatalogId = this.Resource_LFTagPolicy_CatalogId;
            if (this.Resource_LFTagPolicy_Expression != null)
            {
                context.Resource_LFTagPolicy_Expression = new List<Amazon.LakeFormation.Model.LFTag>(this.Resource_LFTagPolicy_Expression);
            }
            context.Resource_LFTagPolicy_ExpressionName = this.Resource_LFTagPolicy_ExpressionName;
            context.Resource_LFTagPolicy_ResourceType = this.Resource_LFTagPolicy_ResourceType;
            context.Resource_RLSPolicy_CatalogId = this.Resource_RLSPolicy_CatalogId;
            context.Resource_RLSPolicy_Name = this.Resource_RLSPolicy_Name;
            context.Resource_Table_CatalogId = this.Resource_Table_CatalogId;
            context.Resource_Table_DatabaseName = this.Resource_Table_DatabaseName;
            context.Resource_Table_Name = this.Resource_Table_Name;
            context.Resource_Table_TableWildcard = this.Resource_Table_TableWildcard;
            context.Resource_TableWithColumns_CatalogId = this.Resource_TableWithColumns_CatalogId;
            if (this.Resource_TableWithColumns_ColumnName != null)
            {
                context.Resource_TableWithColumns_ColumnName = new List<System.String>(this.Resource_TableWithColumns_ColumnName);
            }
            if (this.Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName != null)
            {
                context.Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName = new List<System.String>(this.Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName);
            }
            context.Resource_TableWithColumns_DatabaseName = this.Resource_TableWithColumns_DatabaseName;
            context.Resource_TableWithColumns_Name = this.Resource_TableWithColumns_Name;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
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
            
             // populate Catalog
            var requestResource_resource_CatalogIsNull = true;
            requestResource_resource_Catalog = new Amazon.LakeFormation.Model.CatalogResource();
            System.String requestResource_resource_Catalog_resource_Catalog_Id = null;
            if (cmdletContext.Resource_Catalog_Id != null)
            {
                requestResource_resource_Catalog_resource_Catalog_Id = cmdletContext.Resource_Catalog_Id;
            }
            if (requestResource_resource_Catalog_resource_Catalog_Id != null)
            {
                requestResource_resource_Catalog.Id = requestResource_resource_Catalog_resource_Catalog_Id;
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
            Amazon.LakeFormation.Model.DataLocationResource requestResource_resource_DataLocation = null;
            
             // populate DataLocation
            var requestResource_resource_DataLocationIsNull = true;
            requestResource_resource_DataLocation = new Amazon.LakeFormation.Model.DataLocationResource();
            System.String requestResource_resource_DataLocation_resource_DataLocation_CatalogId = null;
            if (cmdletContext.Resource_DataLocation_CatalogId != null)
            {
                requestResource_resource_DataLocation_resource_DataLocation_CatalogId = cmdletContext.Resource_DataLocation_CatalogId;
            }
            if (requestResource_resource_DataLocation_resource_DataLocation_CatalogId != null)
            {
                requestResource_resource_DataLocation.CatalogId = requestResource_resource_DataLocation_resource_DataLocation_CatalogId;
                requestResource_resource_DataLocationIsNull = false;
            }
            System.String requestResource_resource_DataLocation_resource_DataLocation_ResourceArn = null;
            if (cmdletContext.Resource_DataLocation_ResourceArn != null)
            {
                requestResource_resource_DataLocation_resource_DataLocation_ResourceArn = cmdletContext.Resource_DataLocation_ResourceArn;
            }
            if (requestResource_resource_DataLocation_resource_DataLocation_ResourceArn != null)
            {
                requestResource_resource_DataLocation.ResourceArn = requestResource_resource_DataLocation_resource_DataLocation_ResourceArn;
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
            Amazon.LakeFormation.Model.DatabaseResource requestResource_resource_Database = null;
            
             // populate Database
            var requestResource_resource_DatabaseIsNull = true;
            requestResource_resource_Database = new Amazon.LakeFormation.Model.DatabaseResource();
            System.String requestResource_resource_Database_resource_Database_CatalogId = null;
            if (cmdletContext.Resource_Database_CatalogId != null)
            {
                requestResource_resource_Database_resource_Database_CatalogId = cmdletContext.Resource_Database_CatalogId;
            }
            if (requestResource_resource_Database_resource_Database_CatalogId != null)
            {
                requestResource_resource_Database.CatalogId = requestResource_resource_Database_resource_Database_CatalogId;
                requestResource_resource_DatabaseIsNull = false;
            }
            System.String requestResource_resource_Database_resource_Database_Name = null;
            if (cmdletContext.Resource_Database_Name != null)
            {
                requestResource_resource_Database_resource_Database_Name = cmdletContext.Resource_Database_Name;
            }
            if (requestResource_resource_Database_resource_Database_Name != null)
            {
                requestResource_resource_Database.Name = requestResource_resource_Database_resource_Database_Name;
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
            Amazon.LakeFormation.Model.LFTagExpressionResource requestResource_resource_LFTagExpression = null;
            
             // populate LFTagExpression
            var requestResource_resource_LFTagExpressionIsNull = true;
            requestResource_resource_LFTagExpression = new Amazon.LakeFormation.Model.LFTagExpressionResource();
            System.String requestResource_resource_LFTagExpression_resource_LFTagExpression_CatalogId = null;
            if (cmdletContext.Resource_LFTagExpression_CatalogId != null)
            {
                requestResource_resource_LFTagExpression_resource_LFTagExpression_CatalogId = cmdletContext.Resource_LFTagExpression_CatalogId;
            }
            if (requestResource_resource_LFTagExpression_resource_LFTagExpression_CatalogId != null)
            {
                requestResource_resource_LFTagExpression.CatalogId = requestResource_resource_LFTagExpression_resource_LFTagExpression_CatalogId;
                requestResource_resource_LFTagExpressionIsNull = false;
            }
            System.String requestResource_resource_LFTagExpression_resource_LFTagExpression_Name = null;
            if (cmdletContext.Resource_LFTagExpression_Name != null)
            {
                requestResource_resource_LFTagExpression_resource_LFTagExpression_Name = cmdletContext.Resource_LFTagExpression_Name;
            }
            if (requestResource_resource_LFTagExpression_resource_LFTagExpression_Name != null)
            {
                requestResource_resource_LFTagExpression.Name = requestResource_resource_LFTagExpression_resource_LFTagExpression_Name;
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
            Amazon.LakeFormation.Model.RLSPolicyResource requestResource_resource_RLSPolicy = null;
            
             // populate RLSPolicy
            var requestResource_resource_RLSPolicyIsNull = true;
            requestResource_resource_RLSPolicy = new Amazon.LakeFormation.Model.RLSPolicyResource();
            System.String requestResource_resource_RLSPolicy_resource_RLSPolicy_CatalogId = null;
            if (cmdletContext.Resource_RLSPolicy_CatalogId != null)
            {
                requestResource_resource_RLSPolicy_resource_RLSPolicy_CatalogId = cmdletContext.Resource_RLSPolicy_CatalogId;
            }
            if (requestResource_resource_RLSPolicy_resource_RLSPolicy_CatalogId != null)
            {
                requestResource_resource_RLSPolicy.CatalogId = requestResource_resource_RLSPolicy_resource_RLSPolicy_CatalogId;
                requestResource_resource_RLSPolicyIsNull = false;
            }
            System.String requestResource_resource_RLSPolicy_resource_RLSPolicy_Name = null;
            if (cmdletContext.Resource_RLSPolicy_Name != null)
            {
                requestResource_resource_RLSPolicy_resource_RLSPolicy_Name = cmdletContext.Resource_RLSPolicy_Name;
            }
            if (requestResource_resource_RLSPolicy_resource_RLSPolicy_Name != null)
            {
                requestResource_resource_RLSPolicy.Name = requestResource_resource_RLSPolicy_resource_RLSPolicy_Name;
                requestResource_resource_RLSPolicyIsNull = false;
            }
             // determine if requestResource_resource_RLSPolicy should be set to null
            if (requestResource_resource_RLSPolicyIsNull)
            {
                requestResource_resource_RLSPolicy = null;
            }
            if (requestResource_resource_RLSPolicy != null)
            {
                request.Resource.RLSPolicy = requestResource_resource_RLSPolicy;
                requestResourceIsNull = false;
            }
            Amazon.LakeFormation.Model.LFTagKeyResource requestResource_resource_LFTag = null;
            
             // populate LFTag
            var requestResource_resource_LFTagIsNull = true;
            requestResource_resource_LFTag = new Amazon.LakeFormation.Model.LFTagKeyResource();
            System.String requestResource_resource_LFTag_resource_LFTag_CatalogId = null;
            if (cmdletContext.Resource_LFTag_CatalogId != null)
            {
                requestResource_resource_LFTag_resource_LFTag_CatalogId = cmdletContext.Resource_LFTag_CatalogId;
            }
            if (requestResource_resource_LFTag_resource_LFTag_CatalogId != null)
            {
                requestResource_resource_LFTag.CatalogId = requestResource_resource_LFTag_resource_LFTag_CatalogId;
                requestResource_resource_LFTagIsNull = false;
            }
            System.String requestResource_resource_LFTag_resource_LFTag_TagKey = null;
            if (cmdletContext.Resource_LFTag_TagKey != null)
            {
                requestResource_resource_LFTag_resource_LFTag_TagKey = cmdletContext.Resource_LFTag_TagKey;
            }
            if (requestResource_resource_LFTag_resource_LFTag_TagKey != null)
            {
                requestResource_resource_LFTag.TagKey = requestResource_resource_LFTag_resource_LFTag_TagKey;
                requestResource_resource_LFTagIsNull = false;
            }
            List<System.String> requestResource_resource_LFTag_resource_LFTag_TagValue = null;
            if (cmdletContext.Resource_LFTag_TagValue != null)
            {
                requestResource_resource_LFTag_resource_LFTag_TagValue = cmdletContext.Resource_LFTag_TagValue;
            }
            if (requestResource_resource_LFTag_resource_LFTag_TagValue != null)
            {
                requestResource_resource_LFTag.TagValues = requestResource_resource_LFTag_resource_LFTag_TagValue;
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
            System.String requestResource_resource_DataCellsFilter_resource_DataCellsFilter_DatabaseName = null;
            if (cmdletContext.Resource_DataCellsFilter_DatabaseName != null)
            {
                requestResource_resource_DataCellsFilter_resource_DataCellsFilter_DatabaseName = cmdletContext.Resource_DataCellsFilter_DatabaseName;
            }
            if (requestResource_resource_DataCellsFilter_resource_DataCellsFilter_DatabaseName != null)
            {
                requestResource_resource_DataCellsFilter.DatabaseName = requestResource_resource_DataCellsFilter_resource_DataCellsFilter_DatabaseName;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_resource_DataCellsFilter_Name = null;
            if (cmdletContext.Resource_DataCellsFilter_Name != null)
            {
                requestResource_resource_DataCellsFilter_resource_DataCellsFilter_Name = cmdletContext.Resource_DataCellsFilter_Name;
            }
            if (requestResource_resource_DataCellsFilter_resource_DataCellsFilter_Name != null)
            {
                requestResource_resource_DataCellsFilter.Name = requestResource_resource_DataCellsFilter_resource_DataCellsFilter_Name;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableCatalogId = null;
            if (cmdletContext.Resource_DataCellsFilter_TableCatalogId != null)
            {
                requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableCatalogId = cmdletContext.Resource_DataCellsFilter_TableCatalogId;
            }
            if (requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableCatalogId != null)
            {
                requestResource_resource_DataCellsFilter.TableCatalogId = requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableCatalogId;
                requestResource_resource_DataCellsFilterIsNull = false;
            }
            System.String requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableName = null;
            if (cmdletContext.Resource_DataCellsFilter_TableName != null)
            {
                requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableName = cmdletContext.Resource_DataCellsFilter_TableName;
            }
            if (requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableName != null)
            {
                requestResource_resource_DataCellsFilter.TableName = requestResource_resource_DataCellsFilter_resource_DataCellsFilter_TableName;
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
            System.String requestResource_resource_LFTagPolicy_resource_LFTagPolicy_CatalogId = null;
            if (cmdletContext.Resource_LFTagPolicy_CatalogId != null)
            {
                requestResource_resource_LFTagPolicy_resource_LFTagPolicy_CatalogId = cmdletContext.Resource_LFTagPolicy_CatalogId;
            }
            if (requestResource_resource_LFTagPolicy_resource_LFTagPolicy_CatalogId != null)
            {
                requestResource_resource_LFTagPolicy.CatalogId = requestResource_resource_LFTagPolicy_resource_LFTagPolicy_CatalogId;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            List<Amazon.LakeFormation.Model.LFTag> requestResource_resource_LFTagPolicy_resource_LFTagPolicy_Expression = null;
            if (cmdletContext.Resource_LFTagPolicy_Expression != null)
            {
                requestResource_resource_LFTagPolicy_resource_LFTagPolicy_Expression = cmdletContext.Resource_LFTagPolicy_Expression;
            }
            if (requestResource_resource_LFTagPolicy_resource_LFTagPolicy_Expression != null)
            {
                requestResource_resource_LFTagPolicy.Expression = requestResource_resource_LFTagPolicy_resource_LFTagPolicy_Expression;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            System.String requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ExpressionName = null;
            if (cmdletContext.Resource_LFTagPolicy_ExpressionName != null)
            {
                requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ExpressionName = cmdletContext.Resource_LFTagPolicy_ExpressionName;
            }
            if (requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ExpressionName != null)
            {
                requestResource_resource_LFTagPolicy.ExpressionName = requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ExpressionName;
                requestResource_resource_LFTagPolicyIsNull = false;
            }
            Amazon.LakeFormation.ResourceType requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ResourceType = null;
            if (cmdletContext.Resource_LFTagPolicy_ResourceType != null)
            {
                requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ResourceType = cmdletContext.Resource_LFTagPolicy_ResourceType;
            }
            if (requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ResourceType != null)
            {
                requestResource_resource_LFTagPolicy.ResourceType = requestResource_resource_LFTagPolicy_resource_LFTagPolicy_ResourceType;
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
            System.String requestResource_resource_Table_resource_Table_CatalogId = null;
            if (cmdletContext.Resource_Table_CatalogId != null)
            {
                requestResource_resource_Table_resource_Table_CatalogId = cmdletContext.Resource_Table_CatalogId;
            }
            if (requestResource_resource_Table_resource_Table_CatalogId != null)
            {
                requestResource_resource_Table.CatalogId = requestResource_resource_Table_resource_Table_CatalogId;
                requestResource_resource_TableIsNull = false;
            }
            System.String requestResource_resource_Table_resource_Table_DatabaseName = null;
            if (cmdletContext.Resource_Table_DatabaseName != null)
            {
                requestResource_resource_Table_resource_Table_DatabaseName = cmdletContext.Resource_Table_DatabaseName;
            }
            if (requestResource_resource_Table_resource_Table_DatabaseName != null)
            {
                requestResource_resource_Table.DatabaseName = requestResource_resource_Table_resource_Table_DatabaseName;
                requestResource_resource_TableIsNull = false;
            }
            System.String requestResource_resource_Table_resource_Table_Name = null;
            if (cmdletContext.Resource_Table_Name != null)
            {
                requestResource_resource_Table_resource_Table_Name = cmdletContext.Resource_Table_Name;
            }
            if (requestResource_resource_Table_resource_Table_Name != null)
            {
                requestResource_resource_Table.Name = requestResource_resource_Table_resource_Table_Name;
                requestResource_resource_TableIsNull = false;
            }
            Amazon.LakeFormation.Model.TableWildcard requestResource_resource_Table_resource_Table_TableWildcard = null;
            if (cmdletContext.Resource_Table_TableWildcard != null)
            {
                requestResource_resource_Table_resource_Table_TableWildcard = cmdletContext.Resource_Table_TableWildcard;
            }
            if (requestResource_resource_Table_resource_Table_TableWildcard != null)
            {
                requestResource_resource_Table.TableWildcard = requestResource_resource_Table_resource_Table_TableWildcard;
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
            System.String requestResource_resource_TableWithColumns_resource_TableWithColumns_CatalogId = null;
            if (cmdletContext.Resource_TableWithColumns_CatalogId != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_CatalogId = cmdletContext.Resource_TableWithColumns_CatalogId;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_CatalogId != null)
            {
                requestResource_resource_TableWithColumns.CatalogId = requestResource_resource_TableWithColumns_resource_TableWithColumns_CatalogId;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            List<System.String> requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnName = null;
            if (cmdletContext.Resource_TableWithColumns_ColumnName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnName = cmdletContext.Resource_TableWithColumns_ColumnName;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnName != null)
            {
                requestResource_resource_TableWithColumns.ColumnNames = requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnName;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            System.String requestResource_resource_TableWithColumns_resource_TableWithColumns_DatabaseName = null;
            if (cmdletContext.Resource_TableWithColumns_DatabaseName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_DatabaseName = cmdletContext.Resource_TableWithColumns_DatabaseName;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_DatabaseName != null)
            {
                requestResource_resource_TableWithColumns.DatabaseName = requestResource_resource_TableWithColumns_resource_TableWithColumns_DatabaseName;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            System.String requestResource_resource_TableWithColumns_resource_TableWithColumns_Name = null;
            if (cmdletContext.Resource_TableWithColumns_Name != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_Name = cmdletContext.Resource_TableWithColumns_Name;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_Name != null)
            {
                requestResource_resource_TableWithColumns.Name = requestResource_resource_TableWithColumns_resource_TableWithColumns_Name;
                requestResource_resource_TableWithColumnsIsNull = false;
            }
            Amazon.LakeFormation.Model.ColumnWildcard requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard = null;
            
             // populate ColumnWildcard
            var requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcardIsNull = true;
            requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard = new Amazon.LakeFormation.Model.ColumnWildcard();
            List<System.String> requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_resource_TableWithColumns_ColumnWildcard_ExcludedColumnName = null;
            if (cmdletContext.Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_resource_TableWithColumns_ColumnWildcard_ExcludedColumnName = cmdletContext.Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName;
            }
            if (requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_resource_TableWithColumns_ColumnWildcard_ExcludedColumnName != null)
            {
                requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard.ExcludedColumnNames = requestResource_resource_TableWithColumns_resource_TableWithColumns_ColumnWildcard_resource_TableWithColumns_ColumnWildcard_ExcludedColumnName;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "ListRLSPolicyAttachments");
            try
            {
                return client.ListRLSPolicyAttachmentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PolicyName { get; set; }
            public System.String Principal_DataLakePrincipalIdentifier { get; set; }
            public System.String Resource_Catalog_Id { get; set; }
            public System.String Resource_DataCellsFilter_DatabaseName { get; set; }
            public System.String Resource_DataCellsFilter_Name { get; set; }
            public System.String Resource_DataCellsFilter_TableCatalogId { get; set; }
            public System.String Resource_DataCellsFilter_TableName { get; set; }
            public System.String Resource_DataLocation_CatalogId { get; set; }
            public System.String Resource_DataLocation_ResourceArn { get; set; }
            public System.String Resource_Database_CatalogId { get; set; }
            public System.String Resource_Database_Name { get; set; }
            public System.String Resource_LFTag_CatalogId { get; set; }
            public System.String Resource_LFTag_TagKey { get; set; }
            public List<System.String> Resource_LFTag_TagValue { get; set; }
            public System.String Resource_LFTagExpression_CatalogId { get; set; }
            public System.String Resource_LFTagExpression_Name { get; set; }
            public System.String Resource_LFTagPolicy_CatalogId { get; set; }
            public List<Amazon.LakeFormation.Model.LFTag> Resource_LFTagPolicy_Expression { get; set; }
            public System.String Resource_LFTagPolicy_ExpressionName { get; set; }
            public Amazon.LakeFormation.ResourceType Resource_LFTagPolicy_ResourceType { get; set; }
            public System.String Resource_RLSPolicy_CatalogId { get; set; }
            public System.String Resource_RLSPolicy_Name { get; set; }
            public System.String Resource_Table_CatalogId { get; set; }
            public System.String Resource_Table_DatabaseName { get; set; }
            public System.String Resource_Table_Name { get; set; }
            public Amazon.LakeFormation.Model.TableWildcard Resource_Table_TableWildcard { get; set; }
            public System.String Resource_TableWithColumns_CatalogId { get; set; }
            public List<System.String> Resource_TableWithColumns_ColumnName { get; set; }
            public List<System.String> Resource_TableWithColumns_ColumnWildcard_ExcludedColumnName { get; set; }
            public System.String Resource_TableWithColumns_DatabaseName { get; set; }
            public System.String Resource_TableWithColumns_Name { get; set; }
            public System.Func<Amazon.LakeFormation.Model.ListRLSPolicyAttachmentsResponse, GetLKFRLSPolicyAttachmentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RLSPolicyAttachments;
        }
        
    }
}
