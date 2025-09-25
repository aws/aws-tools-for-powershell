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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Creates a new FinSpace Dataset.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "FNSPDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the FinSpace Public API CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.FinSpaceData.Model.CreateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FinSpaceData.Model.CreateDatasetResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class NewFNSPDatasetCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The unique resource identifier for a Dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter TabularSchemaConfig_Column
        /// <summary>
        /// <para>
        /// <para>List of column definitions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_TabularSchemaConfig_Columns")]
        public Amazon.FinSpaceData.Model.ColumnDefinition[] TabularSchemaConfig_Column { get; set; }
        #endregion
        
        #region Parameter DatasetDescription
        /// <summary>
        /// <para>
        /// <para>Description of a Dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetDescription { get; set; }
        #endregion
        
        #region Parameter PermissionGroupParams_DatasetPermission
        /// <summary>
        /// <para>
        /// <para>List of resource permissions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionGroupParams_DatasetPermissions")]
        public Amazon.FinSpaceData.Model.ResourcePermission[] PermissionGroupParams_DatasetPermission { get; set; }
        #endregion
        
        #region Parameter DatasetTitle
        /// <summary>
        /// <para>
        /// <para>Display title for a FinSpace Dataset.</para>
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
        public System.String DatasetTitle { get; set; }
        #endregion
        
        #region Parameter OwnerInfo_Email
        /// <summary>
        /// <para>
        /// <para>Email address for the Dataset owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerInfo_Email { get; set; }
        #endregion
        
        #region Parameter Kind
        /// <summary>
        /// <para>
        /// <para>The format in which Dataset data is structured.</para><ul><li><para><c>TABULAR</c> – Data is structured in a tabular format.</para></li><li><para><c>NON_TABULAR</c> – Data is structured in a non-tabular format.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FinSpaceData.DatasetKind")]
        public Amazon.FinSpaceData.DatasetKind Kind { get; set; }
        #endregion
        
        #region Parameter OwnerInfo_Name
        /// <summary>
        /// <para>
        /// <para>The name of the Dataset owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerInfo_Name { get; set; }
        #endregion
        
        #region Parameter PermissionGroupParams_PermissionGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the <c>PermissionGroup</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PermissionGroupParams_PermissionGroupId { get; set; }
        #endregion
        
        #region Parameter OwnerInfo_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>Phone number for the Dataset owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerInfo_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter TabularSchemaConfig_PrimaryKeyColumn
        /// <summary>
        /// <para>
        /// <para>List of column names used for primary key.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_TabularSchemaConfig_PrimaryKeyColumns")]
        public System.String[] TabularSchemaConfig_PrimaryKeyColumn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FNSPDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.CreateDatasetResponse, NewFNSPDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            context.DatasetDescription = this.DatasetDescription;
            context.DatasetTitle = this.DatasetTitle;
            #if MODULAR
            if (this.DatasetTitle == null && ParameterWasBound(nameof(this.DatasetTitle)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetTitle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Kind = this.Kind;
            #if MODULAR
            if (this.Kind == null && ParameterWasBound(nameof(this.Kind)))
            {
                WriteWarning("You are passing $null as a value for parameter Kind which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwnerInfo_Email = this.OwnerInfo_Email;
            context.OwnerInfo_Name = this.OwnerInfo_Name;
            context.OwnerInfo_PhoneNumber = this.OwnerInfo_PhoneNumber;
            if (this.PermissionGroupParams_DatasetPermission != null)
            {
                context.PermissionGroupParams_DatasetPermission = new List<Amazon.FinSpaceData.Model.ResourcePermission>(this.PermissionGroupParams_DatasetPermission);
            }
            context.PermissionGroupParams_PermissionGroupId = this.PermissionGroupParams_PermissionGroupId;
            if (this.TabularSchemaConfig_Column != null)
            {
                context.TabularSchemaConfig_Column = new List<Amazon.FinSpaceData.Model.ColumnDefinition>(this.TabularSchemaConfig_Column);
            }
            if (this.TabularSchemaConfig_PrimaryKeyColumn != null)
            {
                context.TabularSchemaConfig_PrimaryKeyColumn = new List<System.String>(this.TabularSchemaConfig_PrimaryKeyColumn);
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
            var request = new Amazon.FinSpaceData.Model.CreateDatasetRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetDescription != null)
            {
                request.DatasetDescription = cmdletContext.DatasetDescription;
            }
            if (cmdletContext.DatasetTitle != null)
            {
                request.DatasetTitle = cmdletContext.DatasetTitle;
            }
            if (cmdletContext.Kind != null)
            {
                request.Kind = cmdletContext.Kind;
            }
            
             // populate OwnerInfo
            var requestOwnerInfoIsNull = true;
            request.OwnerInfo = new Amazon.FinSpaceData.Model.DatasetOwnerInfo();
            System.String requestOwnerInfo_ownerInfo_Email = null;
            if (cmdletContext.OwnerInfo_Email != null)
            {
                requestOwnerInfo_ownerInfo_Email = cmdletContext.OwnerInfo_Email;
            }
            if (requestOwnerInfo_ownerInfo_Email != null)
            {
                request.OwnerInfo.Email = requestOwnerInfo_ownerInfo_Email;
                requestOwnerInfoIsNull = false;
            }
            System.String requestOwnerInfo_ownerInfo_Name = null;
            if (cmdletContext.OwnerInfo_Name != null)
            {
                requestOwnerInfo_ownerInfo_Name = cmdletContext.OwnerInfo_Name;
            }
            if (requestOwnerInfo_ownerInfo_Name != null)
            {
                request.OwnerInfo.Name = requestOwnerInfo_ownerInfo_Name;
                requestOwnerInfoIsNull = false;
            }
            System.String requestOwnerInfo_ownerInfo_PhoneNumber = null;
            if (cmdletContext.OwnerInfo_PhoneNumber != null)
            {
                requestOwnerInfo_ownerInfo_PhoneNumber = cmdletContext.OwnerInfo_PhoneNumber;
            }
            if (requestOwnerInfo_ownerInfo_PhoneNumber != null)
            {
                request.OwnerInfo.PhoneNumber = requestOwnerInfo_ownerInfo_PhoneNumber;
                requestOwnerInfoIsNull = false;
            }
             // determine if request.OwnerInfo should be set to null
            if (requestOwnerInfoIsNull)
            {
                request.OwnerInfo = null;
            }
            
             // populate PermissionGroupParams
            var requestPermissionGroupParamsIsNull = true;
            request.PermissionGroupParams = new Amazon.FinSpaceData.Model.PermissionGroupParams();
            List<Amazon.FinSpaceData.Model.ResourcePermission> requestPermissionGroupParams_permissionGroupParams_DatasetPermission = null;
            if (cmdletContext.PermissionGroupParams_DatasetPermission != null)
            {
                requestPermissionGroupParams_permissionGroupParams_DatasetPermission = cmdletContext.PermissionGroupParams_DatasetPermission;
            }
            if (requestPermissionGroupParams_permissionGroupParams_DatasetPermission != null)
            {
                request.PermissionGroupParams.DatasetPermissions = requestPermissionGroupParams_permissionGroupParams_DatasetPermission;
                requestPermissionGroupParamsIsNull = false;
            }
            System.String requestPermissionGroupParams_permissionGroupParams_PermissionGroupId = null;
            if (cmdletContext.PermissionGroupParams_PermissionGroupId != null)
            {
                requestPermissionGroupParams_permissionGroupParams_PermissionGroupId = cmdletContext.PermissionGroupParams_PermissionGroupId;
            }
            if (requestPermissionGroupParams_permissionGroupParams_PermissionGroupId != null)
            {
                request.PermissionGroupParams.PermissionGroupId = requestPermissionGroupParams_permissionGroupParams_PermissionGroupId;
                requestPermissionGroupParamsIsNull = false;
            }
             // determine if request.PermissionGroupParams should be set to null
            if (requestPermissionGroupParamsIsNull)
            {
                request.PermissionGroupParams = null;
            }
            
             // populate SchemaDefinition
            var requestSchemaDefinitionIsNull = true;
            request.SchemaDefinition = new Amazon.FinSpaceData.Model.SchemaUnion();
            Amazon.FinSpaceData.Model.SchemaDefinition requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = null;
            
             // populate TabularSchemaConfig
            var requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = true;
            requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = new Amazon.FinSpaceData.Model.SchemaDefinition();
            List<Amazon.FinSpaceData.Model.ColumnDefinition> requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column = null;
            if (cmdletContext.TabularSchemaConfig_Column != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column = cmdletContext.TabularSchemaConfig_Column;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig.Columns = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column;
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = false;
            }
            List<System.String> requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn = null;
            if (cmdletContext.TabularSchemaConfig_PrimaryKeyColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn = cmdletContext.TabularSchemaConfig_PrimaryKeyColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig.PrimaryKeyColumns = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn;
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = false;
            }
             // determine if requestSchemaDefinition_schemaDefinition_TabularSchemaConfig should be set to null
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = null;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig != null)
            {
                request.SchemaDefinition.TabularSchemaConfig = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig;
                requestSchemaDefinitionIsNull = false;
            }
             // determine if request.SchemaDefinition should be set to null
            if (requestSchemaDefinitionIsNull)
            {
                request.SchemaDefinition = null;
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
        
        private Amazon.FinSpaceData.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "CreateDataset");
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
            public System.String Alias { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetDescription { get; set; }
            public System.String DatasetTitle { get; set; }
            public Amazon.FinSpaceData.DatasetKind Kind { get; set; }
            public System.String OwnerInfo_Email { get; set; }
            public System.String OwnerInfo_Name { get; set; }
            public System.String OwnerInfo_PhoneNumber { get; set; }
            public List<Amazon.FinSpaceData.Model.ResourcePermission> PermissionGroupParams_DatasetPermission { get; set; }
            public System.String PermissionGroupParams_PermissionGroupId { get; set; }
            public List<Amazon.FinSpaceData.Model.ColumnDefinition> TabularSchemaConfig_Column { get; set; }
            public List<System.String> TabularSchemaConfig_PrimaryKeyColumn { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.CreateDatasetResponse, NewFNSPDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetId;
        }
        
    }
}
