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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates the specified data source in Amazon DataZone.
    /// </summary>
    [Cmdlet("Update", "DZDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateDataSourceResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateDataSource API operation.", Operation = new[] {"UpdateDataSource"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateDataSourceResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateDataSourceResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateDataSourceResponse object containing multiple properties."
    )]
    public partial class UpdateDZDataSourceCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssetFormsInput
        /// <summary>
        /// <para>
        /// <para>The asset forms to be updated as part of the <c>UpdateDataSource</c> action.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.FormInput[] AssetFormsInput { get; set; }
        #endregion
        
        #region Parameter GlueRunConfiguration_AutoImportDataQualityResult
        /// <summary>
        /// <para>
        /// <para>Specifies whether to automatically import data quality metrics as part of the data
        /// source run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_GlueRunConfiguration_AutoImportDataQualityResult")]
        public System.Boolean? GlueRunConfiguration_AutoImportDataQualityResult { get; set; }
        #endregion
        
        #region Parameter GlueRunConfiguration_CatalogName
        /// <summary>
        /// <para>
        /// <para>The catalog name in the Amazon Web Services Glue run configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_GlueRunConfiguration_CatalogName")]
        public System.String GlueRunConfiguration_CatalogName { get; set; }
        #endregion
        
        #region Parameter RedshiftClusterSource_ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon Redshift cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource_ClusterName")]
        public System.String RedshiftClusterSource_ClusterName { get; set; }
        #endregion
        
        #region Parameter GlueRunConfiguration_DataAccessRole
        /// <summary>
        /// <para>
        /// <para>The data access role included in the configuration details of the Amazon Web Services
        /// Glue data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_GlueRunConfiguration_DataAccessRole")]
        public System.String GlueRunConfiguration_DataAccessRole { get; set; }
        #endregion
        
        #region Parameter RedshiftRunConfiguration_DataAccessRole
        /// <summary>
        /// <para>
        /// <para>The data access role included in the configuration details of the Amazon Redshift
        /// data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RedshiftRunConfiguration_DataAccessRole")]
        public System.String RedshiftRunConfiguration_DataAccessRole { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to be updated as part of the <c>UpdateDataSource</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain in which to update a data source.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Recommendation_EnableBusinessNameGeneration
        /// <summary>
        /// <para>
        /// <para>Specifies whether automatic business name generation is to be enabled or not as part
        /// of the recommendation configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recommendation_EnableBusinessNameGeneration { get; set; }
        #endregion
        
        #region Parameter EnableSetting
        /// <summary>
        /// <para>
        /// <para>The enable setting to be updated as part of the <c>UpdateDataSource</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.EnableSetting")]
        public Amazon.DataZone.EnableSetting EnableSetting { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the data source to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to be updated as part of the <c>UpdateDataSource</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PublishOnImport
        /// <summary>
        /// <para>
        /// <para>The publish on import setting to be updated as part of the <c>UpdateDataSource</c>
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublishOnImport { get; set; }
        #endregion
        
        #region Parameter GlueRunConfiguration_RelationalFilterConfiguration
        /// <summary>
        /// <para>
        /// <para>The relational filter configurations included in the configuration details of the
        /// Amazon Web Services Glue data source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_GlueRunConfiguration_RelationalFilterConfigurations")]
        public Amazon.DataZone.Model.RelationalFilterConfiguration[] GlueRunConfiguration_RelationalFilterConfiguration { get; set; }
        #endregion
        
        #region Parameter RedshiftRunConfiguration_RelationalFilterConfiguration
        /// <summary>
        /// <para>
        /// <para>The relational filger configurations included in the configuration details of the
        /// Amazon Redshift data source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RedshiftRunConfiguration_RelationalFilterConfigurations")]
        public Amazon.DataZone.Model.RelationalFilterConfiguration[] RedshiftRunConfiguration_RelationalFilterConfiguration { get; set; }
        #endregion
        
        #region Parameter RetainPermissionsOnRevokeFailure
        /// <summary>
        /// <para>
        /// <para>Specifies that the granted permissions are retained in case of a self-subscribe functionality
        /// failure for a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetainPermissionsOnRevokeFailure { get; set; }
        #endregion
        
        #region Parameter Schedule_Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule of the data source runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Schedule { get; set; }
        #endregion
        
        #region Parameter RedshiftCredentialConfiguration_SecretManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a secret manager for an Amazon Redshift cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration_SecretManagerArn")]
        public System.String RedshiftCredentialConfiguration_SecretManagerArn { get; set; }
        #endregion
        
        #region Parameter Schedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone of the data source run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.Timezone")]
        public Amazon.DataZone.Timezone Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter SageMakerRunConfiguration_TrackingAsset
        /// <summary>
        /// <para>
        /// <para>The tracking assets of the Amazon SageMaker run.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SageMakerRunConfiguration_TrackingAssets")]
        public System.Collections.Hashtable SageMakerRunConfiguration_TrackingAsset { get; set; }
        #endregion
        
        #region Parameter RedshiftServerlessSource_WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Redshift Serverless workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource_WorkgroupName")]
        public System.String RedshiftServerlessSource_WorkgroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateDataSourceResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateDataSourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZDataSource (UpdateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateDataSourceResponse, UpdateDZDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssetFormsInput != null)
            {
                context.AssetFormsInput = new List<Amazon.DataZone.Model.FormInput>(this.AssetFormsInput);
            }
            context.GlueRunConfiguration_AutoImportDataQualityResult = this.GlueRunConfiguration_AutoImportDataQualityResult;
            context.GlueRunConfiguration_CatalogName = this.GlueRunConfiguration_CatalogName;
            context.GlueRunConfiguration_DataAccessRole = this.GlueRunConfiguration_DataAccessRole;
            if (this.GlueRunConfiguration_RelationalFilterConfiguration != null)
            {
                context.GlueRunConfiguration_RelationalFilterConfiguration = new List<Amazon.DataZone.Model.RelationalFilterConfiguration>(this.GlueRunConfiguration_RelationalFilterConfiguration);
            }
            context.RedshiftRunConfiguration_DataAccessRole = this.RedshiftRunConfiguration_DataAccessRole;
            context.RedshiftCredentialConfiguration_SecretManagerArn = this.RedshiftCredentialConfiguration_SecretManagerArn;
            context.RedshiftClusterSource_ClusterName = this.RedshiftClusterSource_ClusterName;
            context.RedshiftServerlessSource_WorkgroupName = this.RedshiftServerlessSource_WorkgroupName;
            if (this.RedshiftRunConfiguration_RelationalFilterConfiguration != null)
            {
                context.RedshiftRunConfiguration_RelationalFilterConfiguration = new List<Amazon.DataZone.Model.RelationalFilterConfiguration>(this.RedshiftRunConfiguration_RelationalFilterConfiguration);
            }
            if (this.SageMakerRunConfiguration_TrackingAsset != null)
            {
                context.SageMakerRunConfiguration_TrackingAsset = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SageMakerRunConfiguration_TrackingAsset.Keys)
                {
                    object hashValue = this.SageMakerRunConfiguration_TrackingAsset[hashKey];
                    if (hashValue == null)
                    {
                        context.SageMakerRunConfiguration_TrackingAsset.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.SageMakerRunConfiguration_TrackingAsset.Add((String)hashKey, valueSet);
                }
            }
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableSetting = this.EnableSetting;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.PublishOnImport = this.PublishOnImport;
            context.Recommendation_EnableBusinessNameGeneration = this.Recommendation_EnableBusinessNameGeneration;
            context.RetainPermissionsOnRevokeFailure = this.RetainPermissionsOnRevokeFailure;
            context.Schedule_Schedule = this.Schedule_Schedule;
            context.Schedule_Timezone = this.Schedule_Timezone;
            
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
            var request = new Amazon.DataZone.Model.UpdateDataSourceRequest();
            
            if (cmdletContext.AssetFormsInput != null)
            {
                request.AssetFormsInput = cmdletContext.AssetFormsInput;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DataZone.Model.DataSourceConfigurationInput();
            Amazon.DataZone.Model.SageMakerRunConfigurationInput requestConfiguration_configuration_SageMakerRunConfiguration = null;
            
             // populate SageMakerRunConfiguration
            var requestConfiguration_configuration_SageMakerRunConfigurationIsNull = true;
            requestConfiguration_configuration_SageMakerRunConfiguration = new Amazon.DataZone.Model.SageMakerRunConfigurationInput();
            Dictionary<System.String, List<System.String>> requestConfiguration_configuration_SageMakerRunConfiguration_sageMakerRunConfiguration_TrackingAsset = null;
            if (cmdletContext.SageMakerRunConfiguration_TrackingAsset != null)
            {
                requestConfiguration_configuration_SageMakerRunConfiguration_sageMakerRunConfiguration_TrackingAsset = cmdletContext.SageMakerRunConfiguration_TrackingAsset;
            }
            if (requestConfiguration_configuration_SageMakerRunConfiguration_sageMakerRunConfiguration_TrackingAsset != null)
            {
                requestConfiguration_configuration_SageMakerRunConfiguration.TrackingAssets = requestConfiguration_configuration_SageMakerRunConfiguration_sageMakerRunConfiguration_TrackingAsset;
                requestConfiguration_configuration_SageMakerRunConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_SageMakerRunConfiguration should be set to null
            if (requestConfiguration_configuration_SageMakerRunConfigurationIsNull)
            {
                requestConfiguration_configuration_SageMakerRunConfiguration = null;
            }
            if (requestConfiguration_configuration_SageMakerRunConfiguration != null)
            {
                request.Configuration.SageMakerRunConfiguration = requestConfiguration_configuration_SageMakerRunConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.GlueRunConfigurationInput requestConfiguration_configuration_GlueRunConfiguration = null;
            
             // populate GlueRunConfiguration
            var requestConfiguration_configuration_GlueRunConfigurationIsNull = true;
            requestConfiguration_configuration_GlueRunConfiguration = new Amazon.DataZone.Model.GlueRunConfigurationInput();
            System.Boolean? requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_AutoImportDataQualityResult = null;
            if (cmdletContext.GlueRunConfiguration_AutoImportDataQualityResult != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_AutoImportDataQualityResult = cmdletContext.GlueRunConfiguration_AutoImportDataQualityResult.Value;
            }
            if (requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_AutoImportDataQualityResult != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration.AutoImportDataQualityResult = requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_AutoImportDataQualityResult.Value;
                requestConfiguration_configuration_GlueRunConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_CatalogName = null;
            if (cmdletContext.GlueRunConfiguration_CatalogName != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_CatalogName = cmdletContext.GlueRunConfiguration_CatalogName;
            }
            if (requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_CatalogName != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration.CatalogName = requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_CatalogName;
                requestConfiguration_configuration_GlueRunConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_DataAccessRole = null;
            if (cmdletContext.GlueRunConfiguration_DataAccessRole != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_DataAccessRole = cmdletContext.GlueRunConfiguration_DataAccessRole;
            }
            if (requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_DataAccessRole != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration.DataAccessRole = requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_DataAccessRole;
                requestConfiguration_configuration_GlueRunConfigurationIsNull = false;
            }
            List<Amazon.DataZone.Model.RelationalFilterConfiguration> requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_RelationalFilterConfiguration = null;
            if (cmdletContext.GlueRunConfiguration_RelationalFilterConfiguration != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_RelationalFilterConfiguration = cmdletContext.GlueRunConfiguration_RelationalFilterConfiguration;
            }
            if (requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_RelationalFilterConfiguration != null)
            {
                requestConfiguration_configuration_GlueRunConfiguration.RelationalFilterConfigurations = requestConfiguration_configuration_GlueRunConfiguration_glueRunConfiguration_RelationalFilterConfiguration;
                requestConfiguration_configuration_GlueRunConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_GlueRunConfiguration should be set to null
            if (requestConfiguration_configuration_GlueRunConfigurationIsNull)
            {
                requestConfiguration_configuration_GlueRunConfiguration = null;
            }
            if (requestConfiguration_configuration_GlueRunConfiguration != null)
            {
                request.Configuration.GlueRunConfiguration = requestConfiguration_configuration_GlueRunConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftRunConfigurationInput requestConfiguration_configuration_RedshiftRunConfiguration = null;
            
             // populate RedshiftRunConfiguration
            var requestConfiguration_configuration_RedshiftRunConfigurationIsNull = true;
            requestConfiguration_configuration_RedshiftRunConfiguration = new Amazon.DataZone.Model.RedshiftRunConfigurationInput();
            System.String requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_DataAccessRole = null;
            if (cmdletContext.RedshiftRunConfiguration_DataAccessRole != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_DataAccessRole = cmdletContext.RedshiftRunConfiguration_DataAccessRole;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_DataAccessRole != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration.DataAccessRole = requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_DataAccessRole;
                requestConfiguration_configuration_RedshiftRunConfigurationIsNull = false;
            }
            List<Amazon.DataZone.Model.RelationalFilterConfiguration> requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_RelationalFilterConfiguration = null;
            if (cmdletContext.RedshiftRunConfiguration_RelationalFilterConfiguration != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_RelationalFilterConfiguration = cmdletContext.RedshiftRunConfiguration_RelationalFilterConfiguration;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_RelationalFilterConfiguration != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration.RelationalFilterConfigurations = requestConfiguration_configuration_RedshiftRunConfiguration_redshiftRunConfiguration_RelationalFilterConfiguration;
                requestConfiguration_configuration_RedshiftRunConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftCredentialConfiguration requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration = null;
            
             // populate RedshiftCredentialConfiguration
            var requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfigurationIsNull = true;
            requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration = new Amazon.DataZone.Model.RedshiftCredentialConfiguration();
            System.String requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration_redshiftCredentialConfiguration_SecretManagerArn = null;
            if (cmdletContext.RedshiftCredentialConfiguration_SecretManagerArn != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration_redshiftCredentialConfiguration_SecretManagerArn = cmdletContext.RedshiftCredentialConfiguration_SecretManagerArn;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration_redshiftCredentialConfiguration_SecretManagerArn != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration.SecretManagerArn = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration_redshiftCredentialConfiguration_SecretManagerArn;
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration should be set to null
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfigurationIsNull)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration = null;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration.RedshiftCredentialConfiguration = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftCredentialConfiguration;
                requestConfiguration_configuration_RedshiftRunConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftStorage requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage = null;
            
             // populate RedshiftStorage
            var requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorageIsNull = true;
            requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage = new Amazon.DataZone.Model.RedshiftStorage();
            Amazon.DataZone.Model.RedshiftClusterStorage requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource = null;
            
             // populate RedshiftClusterSource
            var requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSourceIsNull = true;
            requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource = new Amazon.DataZone.Model.RedshiftClusterStorage();
            System.String requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource_redshiftClusterSource_ClusterName = null;
            if (cmdletContext.RedshiftClusterSource_ClusterName != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource_redshiftClusterSource_ClusterName = cmdletContext.RedshiftClusterSource_ClusterName;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource_redshiftClusterSource_ClusterName != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource.ClusterName = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource_redshiftClusterSource_ClusterName;
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSourceIsNull = false;
            }
             // determine if requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource should be set to null
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSourceIsNull)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource = null;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage.RedshiftClusterSource = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftClusterSource;
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorageIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftServerlessStorage requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource = null;
            
             // populate RedshiftServerlessSource
            var requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSourceIsNull = true;
            requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource = new Amazon.DataZone.Model.RedshiftServerlessStorage();
            System.String requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource_redshiftServerlessSource_WorkgroupName = null;
            if (cmdletContext.RedshiftServerlessSource_WorkgroupName != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource_redshiftServerlessSource_WorkgroupName = cmdletContext.RedshiftServerlessSource_WorkgroupName;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource_redshiftServerlessSource_WorkgroupName != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource.WorkgroupName = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource_redshiftServerlessSource_WorkgroupName;
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSourceIsNull = false;
            }
             // determine if requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource should be set to null
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSourceIsNull)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource = null;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage.RedshiftServerlessSource = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage_configuration_RedshiftRunConfiguration_RedshiftStorage_RedshiftServerlessSource;
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorageIsNull = false;
            }
             // determine if requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage should be set to null
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorageIsNull)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage = null;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage != null)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration.RedshiftStorage = requestConfiguration_configuration_RedshiftRunConfiguration_configuration_RedshiftRunConfiguration_RedshiftStorage;
                requestConfiguration_configuration_RedshiftRunConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_RedshiftRunConfiguration should be set to null
            if (requestConfiguration_configuration_RedshiftRunConfigurationIsNull)
            {
                requestConfiguration_configuration_RedshiftRunConfiguration = null;
            }
            if (requestConfiguration_configuration_RedshiftRunConfiguration != null)
            {
                request.Configuration.RedshiftRunConfiguration = requestConfiguration_configuration_RedshiftRunConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnableSetting != null)
            {
                request.EnableSetting = cmdletContext.EnableSetting;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PublishOnImport != null)
            {
                request.PublishOnImport = cmdletContext.PublishOnImport.Value;
            }
            
             // populate Recommendation
            var requestRecommendationIsNull = true;
            request.Recommendation = new Amazon.DataZone.Model.RecommendationConfiguration();
            System.Boolean? requestRecommendation_recommendation_EnableBusinessNameGeneration = null;
            if (cmdletContext.Recommendation_EnableBusinessNameGeneration != null)
            {
                requestRecommendation_recommendation_EnableBusinessNameGeneration = cmdletContext.Recommendation_EnableBusinessNameGeneration.Value;
            }
            if (requestRecommendation_recommendation_EnableBusinessNameGeneration != null)
            {
                request.Recommendation.EnableBusinessNameGeneration = requestRecommendation_recommendation_EnableBusinessNameGeneration.Value;
                requestRecommendationIsNull = false;
            }
             // determine if request.Recommendation should be set to null
            if (requestRecommendationIsNull)
            {
                request.Recommendation = null;
            }
            if (cmdletContext.RetainPermissionsOnRevokeFailure != null)
            {
                request.RetainPermissionsOnRevokeFailure = cmdletContext.RetainPermissionsOnRevokeFailure.Value;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.DataZone.Model.ScheduleConfiguration();
            System.String requestSchedule_schedule_Schedule = null;
            if (cmdletContext.Schedule_Schedule != null)
            {
                requestSchedule_schedule_Schedule = cmdletContext.Schedule_Schedule;
            }
            if (requestSchedule_schedule_Schedule != null)
            {
                request.Schedule.Schedule = requestSchedule_schedule_Schedule;
                requestScheduleIsNull = false;
            }
            Amazon.DataZone.Timezone requestSchedule_schedule_Timezone = null;
            if (cmdletContext.Schedule_Timezone != null)
            {
                requestSchedule_schedule_Timezone = cmdletContext.Schedule_Timezone;
            }
            if (requestSchedule_schedule_Timezone != null)
            {
                request.Schedule.Timezone = requestSchedule_schedule_Timezone;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
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
        
        private Amazon.DataZone.Model.UpdateDataSourceResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateDataSource");
            try
            {
                return client.UpdateDataSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.DataZone.Model.FormInput> AssetFormsInput { get; set; }
            public System.Boolean? GlueRunConfiguration_AutoImportDataQualityResult { get; set; }
            public System.String GlueRunConfiguration_CatalogName { get; set; }
            public System.String GlueRunConfiguration_DataAccessRole { get; set; }
            public List<Amazon.DataZone.Model.RelationalFilterConfiguration> GlueRunConfiguration_RelationalFilterConfiguration { get; set; }
            public System.String RedshiftRunConfiguration_DataAccessRole { get; set; }
            public System.String RedshiftCredentialConfiguration_SecretManagerArn { get; set; }
            public System.String RedshiftClusterSource_ClusterName { get; set; }
            public System.String RedshiftServerlessSource_WorkgroupName { get; set; }
            public List<Amazon.DataZone.Model.RelationalFilterConfiguration> RedshiftRunConfiguration_RelationalFilterConfiguration { get; set; }
            public Dictionary<System.String, List<System.String>> SageMakerRunConfiguration_TrackingAsset { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public Amazon.DataZone.EnableSetting EnableSetting { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PublishOnImport { get; set; }
            public System.Boolean? Recommendation_EnableBusinessNameGeneration { get; set; }
            public System.Boolean? RetainPermissionsOnRevokeFailure { get; set; }
            public System.String Schedule_Schedule { get; set; }
            public Amazon.DataZone.Timezone Schedule_Timezone { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateDataSourceResponse, UpdateDZDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
