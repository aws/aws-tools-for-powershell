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
    /// Sets the list of data lake administrators who have admin privileges on all resources
    /// managed by Lake Formation. For more information on admin privileges, see <a href="https://docs.aws.amazon.com/lake-formation/latest/dg/lake-formation-permissions.html">Granting
    /// Lake Formation Permissions</a>.
    /// 
    ///  
    /// <para>
    /// This API replaces the current list of data lake admins with the new list being passed.
    /// To add an admin, fetch the current list and add the new admin to that list and pass
    /// that list in this API.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LKFDataLakeSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lake Formation PutDataLakeSettings API operation.", Operation = new[] {"PutDataLakeSettings"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.PutDataLakeSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.LakeFormation.Model.PutDataLakeSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LakeFormation.Model.PutDataLakeSettingsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteLKFDataLakeSettingCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataLakeSettings_AllowExternalDataFiltering
        /// <summary>
        /// <para>
        /// <para>Whether to allow Amazon EMR clusters to access data managed by Lake Formation. </para><para>If true, you allow Amazon EMR clusters to access data in Amazon S3 locations that
        /// are registered with Lake Formation.</para><para>If false or null, no Amazon EMR clusters will be able to access data in Amazon S3
        /// locations that are registered with Lake Formation.</para><para>For more information, see <a href="https://docs.aws.amazon.com/lake-formation/latest/dg/initial-LF-setup.html#external-data-filter">(Optional)
        /// Allow external data filtering</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataLakeSettings_AllowExternalDataFiltering { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_AllowFullTableExternalDataAccess
        /// <summary>
        /// <para>
        /// <para>Whether to allow a third-party query engine to get data access credentials without
        /// session tags when a caller has full data access permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataLakeSettings_AllowFullTableExternalDataAccess { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_AuthorizedSessionTagValueList
        /// <summary>
        /// <para>
        /// <para>Lake Formation relies on a privileged process secured by Amazon EMR or the third party
        /// integrator to tag the user's role while assuming it. Lake Formation will publish the
        /// acceptable key-value pair, for example key = "LakeFormationTrustedCaller" and value
        /// = "TRUE" and the third party integrator must properly tag the temporary security credentials
        /// that will be used to call Lake Formation's administrative APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DataLakeSettings_AuthorizedSessionTagValueList { get; set; }
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
        
        #region Parameter DataLakeSettings_CreateDatabaseDefaultPermission
        /// <summary>
        /// <para>
        /// <para>Specifies whether access control on newly created database is managed by Lake Formation
        /// permissions or exclusively by IAM permissions.</para><para>A null value indicates access control by Lake Formation permissions. A value that
        /// assigns ALL to IAM_ALLOWED_PRINCIPALS indicates access control by IAM permissions.
        /// This is referred to as the setting "Use only IAM access control," and is for backward
        /// compatibility with the Glue permission model implemented by IAM permissions.</para><para>The only permitted values are an empty array or an array that contains a single JSON
        /// object that grants ALL to IAM_ALLOWED_PRINCIPALS.</para><para>For more information, see <a href="https://docs.aws.amazon.com/lake-formation/latest/dg/change-settings.html">Changing
        /// the Default Security Settings for Your Data Lake</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_CreateDatabaseDefaultPermissions")]
        public Amazon.LakeFormation.Model.PrincipalPermissions[] DataLakeSettings_CreateDatabaseDefaultPermission { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_CreateTableDefaultPermission
        /// <summary>
        /// <para>
        /// <para>Specifies whether access control on newly created table is managed by Lake Formation
        /// permissions or exclusively by IAM permissions.</para><para>A null value indicates access control by Lake Formation permissions. A value that
        /// assigns ALL to IAM_ALLOWED_PRINCIPALS indicates access control by IAM permissions.
        /// This is referred to as the setting "Use only IAM access control," and is for backward
        /// compatibility with the Glue permission model implemented by IAM permissions.</para><para>The only permitted values are an empty array or an array that contains a single JSON
        /// object that grants ALL to IAM_ALLOWED_PRINCIPALS.</para><para>For more information, see <a href="https://docs.aws.amazon.com/lake-formation/latest/dg/change-settings.html">Changing
        /// the Default Security Settings for Your Data Lake</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_CreateTableDefaultPermissions")]
        public Amazon.LakeFormation.Model.PrincipalPermissions[] DataLakeSettings_CreateTableDefaultPermission { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_DataLakeAdmin
        /// <summary>
        /// <para>
        /// <para>A list of Lake Formation principals. Supported principals are IAM users or IAM roles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_DataLakeAdmins")]
        public Amazon.LakeFormation.Model.DataLakePrincipal[] DataLakeSettings_DataLakeAdmin { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_ExternalDataFilteringAllowList
        /// <summary>
        /// <para>
        /// <para>A list of the account IDs of Amazon Web Services accounts with Amazon EMR clusters
        /// that are to perform data filtering.&gt;</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LakeFormation.Model.DataLakePrincipal[] DataLakeSettings_ExternalDataFilteringAllowList { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map that provides an additional configuration on your data lake. CROSS_ACCOUNT_VERSION
        /// is the key you can configure in the Parameters field. Accepted values for the CrossAccountVersion
        /// key are 1, 2, 3, and 4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_Parameters")]
        public System.Collections.Hashtable DataLakeSettings_Parameter { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_ReadOnlyAdmin
        /// <summary>
        /// <para>
        /// <para>A list of Lake Formation principals with only view access to the resources, without
        /// the ability to make changes. Supported principals are IAM users or IAM roles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_ReadOnlyAdmins")]
        public Amazon.LakeFormation.Model.DataLakePrincipal[] DataLakeSettings_ReadOnlyAdmin { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_TrustedResourceOwner
        /// <summary>
        /// <para>
        /// <para>A list of the resource-owning account IDs that the caller's account can use to share
        /// their user access details (user ARNs). The user ARNs can be logged in the resource
        /// owner's CloudTrail log.</para><para>You may want to specify this property when you are in a high-trust boundary, such
        /// as the same team or company. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_TrustedResourceOwners")]
        public System.String[] DataLakeSettings_TrustedResourceOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.PutDataLakeSettingsResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LKFDataLakeSetting (PutDataLakeSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.PutDataLakeSettingsResponse, WriteLKFDataLakeSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            context.DataLakeSettings_AllowExternalDataFiltering = this.DataLakeSettings_AllowExternalDataFiltering;
            context.DataLakeSettings_AllowFullTableExternalDataAccess = this.DataLakeSettings_AllowFullTableExternalDataAccess;
            if (this.DataLakeSettings_AuthorizedSessionTagValueList != null)
            {
                context.DataLakeSettings_AuthorizedSessionTagValueList = new List<System.String>(this.DataLakeSettings_AuthorizedSessionTagValueList);
            }
            if (this.DataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                context.DataLakeSettings_CreateDatabaseDefaultPermission = new List<Amazon.LakeFormation.Model.PrincipalPermissions>(this.DataLakeSettings_CreateDatabaseDefaultPermission);
            }
            if (this.DataLakeSettings_CreateTableDefaultPermission != null)
            {
                context.DataLakeSettings_CreateTableDefaultPermission = new List<Amazon.LakeFormation.Model.PrincipalPermissions>(this.DataLakeSettings_CreateTableDefaultPermission);
            }
            if (this.DataLakeSettings_DataLakeAdmin != null)
            {
                context.DataLakeSettings_DataLakeAdmin = new List<Amazon.LakeFormation.Model.DataLakePrincipal>(this.DataLakeSettings_DataLakeAdmin);
            }
            if (this.DataLakeSettings_ExternalDataFilteringAllowList != null)
            {
                context.DataLakeSettings_ExternalDataFilteringAllowList = new List<Amazon.LakeFormation.Model.DataLakePrincipal>(this.DataLakeSettings_ExternalDataFilteringAllowList);
            }
            if (this.DataLakeSettings_Parameter != null)
            {
                context.DataLakeSettings_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DataLakeSettings_Parameter.Keys)
                {
                    context.DataLakeSettings_Parameter.Add((String)hashKey, (System.String)(this.DataLakeSettings_Parameter[hashKey]));
                }
            }
            if (this.DataLakeSettings_ReadOnlyAdmin != null)
            {
                context.DataLakeSettings_ReadOnlyAdmin = new List<Amazon.LakeFormation.Model.DataLakePrincipal>(this.DataLakeSettings_ReadOnlyAdmin);
            }
            if (this.DataLakeSettings_TrustedResourceOwner != null)
            {
                context.DataLakeSettings_TrustedResourceOwner = new List<System.String>(this.DataLakeSettings_TrustedResourceOwner);
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
            var request = new Amazon.LakeFormation.Model.PutDataLakeSettingsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
             // populate DataLakeSettings
            var requestDataLakeSettingsIsNull = true;
            request.DataLakeSettings = new Amazon.LakeFormation.Model.DataLakeSettings();
            System.Boolean? requestDataLakeSettings_dataLakeSettings_AllowExternalDataFiltering = null;
            if (cmdletContext.DataLakeSettings_AllowExternalDataFiltering != null)
            {
                requestDataLakeSettings_dataLakeSettings_AllowExternalDataFiltering = cmdletContext.DataLakeSettings_AllowExternalDataFiltering.Value;
            }
            if (requestDataLakeSettings_dataLakeSettings_AllowExternalDataFiltering != null)
            {
                request.DataLakeSettings.AllowExternalDataFiltering = requestDataLakeSettings_dataLakeSettings_AllowExternalDataFiltering.Value;
                requestDataLakeSettingsIsNull = false;
            }
            System.Boolean? requestDataLakeSettings_dataLakeSettings_AllowFullTableExternalDataAccess = null;
            if (cmdletContext.DataLakeSettings_AllowFullTableExternalDataAccess != null)
            {
                requestDataLakeSettings_dataLakeSettings_AllowFullTableExternalDataAccess = cmdletContext.DataLakeSettings_AllowFullTableExternalDataAccess.Value;
            }
            if (requestDataLakeSettings_dataLakeSettings_AllowFullTableExternalDataAccess != null)
            {
                request.DataLakeSettings.AllowFullTableExternalDataAccess = requestDataLakeSettings_dataLakeSettings_AllowFullTableExternalDataAccess.Value;
                requestDataLakeSettingsIsNull = false;
            }
            List<System.String> requestDataLakeSettings_dataLakeSettings_AuthorizedSessionTagValueList = null;
            if (cmdletContext.DataLakeSettings_AuthorizedSessionTagValueList != null)
            {
                requestDataLakeSettings_dataLakeSettings_AuthorizedSessionTagValueList = cmdletContext.DataLakeSettings_AuthorizedSessionTagValueList;
            }
            if (requestDataLakeSettings_dataLakeSettings_AuthorizedSessionTagValueList != null)
            {
                request.DataLakeSettings.AuthorizedSessionTagValueList = requestDataLakeSettings_dataLakeSettings_AuthorizedSessionTagValueList;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.PrincipalPermissions> requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission = null;
            if (cmdletContext.DataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission = cmdletContext.DataLakeSettings_CreateDatabaseDefaultPermission;
            }
            if (requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                request.DataLakeSettings.CreateDatabaseDefaultPermissions = requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.PrincipalPermissions> requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission = null;
            if (cmdletContext.DataLakeSettings_CreateTableDefaultPermission != null)
            {
                requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission = cmdletContext.DataLakeSettings_CreateTableDefaultPermission;
            }
            if (requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission != null)
            {
                request.DataLakeSettings.CreateTableDefaultPermissions = requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.DataLakePrincipal> requestDataLakeSettings_dataLakeSettings_DataLakeAdmin = null;
            if (cmdletContext.DataLakeSettings_DataLakeAdmin != null)
            {
                requestDataLakeSettings_dataLakeSettings_DataLakeAdmin = cmdletContext.DataLakeSettings_DataLakeAdmin;
            }
            if (requestDataLakeSettings_dataLakeSettings_DataLakeAdmin != null)
            {
                request.DataLakeSettings.DataLakeAdmins = requestDataLakeSettings_dataLakeSettings_DataLakeAdmin;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.DataLakePrincipal> requestDataLakeSettings_dataLakeSettings_ExternalDataFilteringAllowList = null;
            if (cmdletContext.DataLakeSettings_ExternalDataFilteringAllowList != null)
            {
                requestDataLakeSettings_dataLakeSettings_ExternalDataFilteringAllowList = cmdletContext.DataLakeSettings_ExternalDataFilteringAllowList;
            }
            if (requestDataLakeSettings_dataLakeSettings_ExternalDataFilteringAllowList != null)
            {
                request.DataLakeSettings.ExternalDataFilteringAllowList = requestDataLakeSettings_dataLakeSettings_ExternalDataFilteringAllowList;
                requestDataLakeSettingsIsNull = false;
            }
            Dictionary<System.String, System.String> requestDataLakeSettings_dataLakeSettings_Parameter = null;
            if (cmdletContext.DataLakeSettings_Parameter != null)
            {
                requestDataLakeSettings_dataLakeSettings_Parameter = cmdletContext.DataLakeSettings_Parameter;
            }
            if (requestDataLakeSettings_dataLakeSettings_Parameter != null)
            {
                request.DataLakeSettings.Parameters = requestDataLakeSettings_dataLakeSettings_Parameter;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.DataLakePrincipal> requestDataLakeSettings_dataLakeSettings_ReadOnlyAdmin = null;
            if (cmdletContext.DataLakeSettings_ReadOnlyAdmin != null)
            {
                requestDataLakeSettings_dataLakeSettings_ReadOnlyAdmin = cmdletContext.DataLakeSettings_ReadOnlyAdmin;
            }
            if (requestDataLakeSettings_dataLakeSettings_ReadOnlyAdmin != null)
            {
                request.DataLakeSettings.ReadOnlyAdmins = requestDataLakeSettings_dataLakeSettings_ReadOnlyAdmin;
                requestDataLakeSettingsIsNull = false;
            }
            List<System.String> requestDataLakeSettings_dataLakeSettings_TrustedResourceOwner = null;
            if (cmdletContext.DataLakeSettings_TrustedResourceOwner != null)
            {
                requestDataLakeSettings_dataLakeSettings_TrustedResourceOwner = cmdletContext.DataLakeSettings_TrustedResourceOwner;
            }
            if (requestDataLakeSettings_dataLakeSettings_TrustedResourceOwner != null)
            {
                request.DataLakeSettings.TrustedResourceOwners = requestDataLakeSettings_dataLakeSettings_TrustedResourceOwner;
                requestDataLakeSettingsIsNull = false;
            }
             // determine if request.DataLakeSettings should be set to null
            if (requestDataLakeSettingsIsNull)
            {
                request.DataLakeSettings = null;
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
        
        private Amazon.LakeFormation.Model.PutDataLakeSettingsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.PutDataLakeSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "PutDataLakeSettings");
            try
            {
                #if DESKTOP
                return client.PutDataLakeSettings(request);
                #elif CORECLR
                return client.PutDataLakeSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DataLakeSettings_AllowExternalDataFiltering { get; set; }
            public System.Boolean? DataLakeSettings_AllowFullTableExternalDataAccess { get; set; }
            public List<System.String> DataLakeSettings_AuthorizedSessionTagValueList { get; set; }
            public List<Amazon.LakeFormation.Model.PrincipalPermissions> DataLakeSettings_CreateDatabaseDefaultPermission { get; set; }
            public List<Amazon.LakeFormation.Model.PrincipalPermissions> DataLakeSettings_CreateTableDefaultPermission { get; set; }
            public List<Amazon.LakeFormation.Model.DataLakePrincipal> DataLakeSettings_DataLakeAdmin { get; set; }
            public List<Amazon.LakeFormation.Model.DataLakePrincipal> DataLakeSettings_ExternalDataFilteringAllowList { get; set; }
            public Dictionary<System.String, System.String> DataLakeSettings_Parameter { get; set; }
            public List<Amazon.LakeFormation.Model.DataLakePrincipal> DataLakeSettings_ReadOnlyAdmin { get; set; }
            public List<System.String> DataLakeSettings_TrustedResourceOwner { get; set; }
            public System.Func<Amazon.LakeFormation.Model.PutDataLakeSettingsResponse, WriteLKFDataLakeSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
