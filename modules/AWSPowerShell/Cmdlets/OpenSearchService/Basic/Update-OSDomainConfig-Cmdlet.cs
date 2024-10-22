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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Modifies the cluster configuration of the specified Amazon OpenSearch Service domain.
    /// </summary>
    [Cmdlet("Update", "OSDomainConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.DomainConfig")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service UpdateDomainConfig API operation.", Operation = new[] {"UpdateDomainConfig"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.UpdateDomainConfigResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.DomainConfig or Amazon.OpenSearchService.Model.UpdateDomainConfigResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.DomainConfig object.",
        "The service call response (type Amazon.OpenSearchService.Model.UpdateDomainConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateOSDomainConfigCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessPolicy
        /// <summary>
        /// <para>
        /// <para>Identity and Access Management (IAM) access policy as a JSON-formatted string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicies")]
        public System.String AccessPolicy { get; set; }
        #endregion
        
        #region Parameter AdvancedOption
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to specify advanced configuration options. The following key-value
        /// pairs are supported:</para><ul><li><para><c>"rest.action.multi.allow_explicit_index": "true" | "false"</c> - Note the use
        /// of a string rather than a boolean. Specifies whether explicit references to indexes
        /// are allowed inside the body of HTTP requests. If you want to configure access policies
        /// for domain sub-resources, such as specific indexes and domain APIs, you must disable
        /// this property. Default is true.</para></li><li><para><c>"indices.fielddata.cache.size": "80" </c> - Note the use of a string rather than
        /// a boolean. Specifies the percentage of heap space allocated to field data. Default
        /// is unbounded.</para></li><li><para><c>"indices.query.bool.max_clause_count": "1024"</c> - Note the use of a string rather
        /// than a boolean. Specifies the maximum number of clauses allowed in a Lucene boolean
        /// query. Default is 1,024. Queries with more than the permitted number of clauses result
        /// in a <c>TooManyClauses</c> error.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/createupdatedomains.html#createdomain-configure-advanced-options">Advanced
        /// cluster parameters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedOptions")]
        public System.Collections.Hashtable AdvancedOption { get; set; }
        #endregion
        
        #region Parameter AdvancedSecurityOptions_AnonymousAuthEnabled
        /// <summary>
        /// <para>
        /// <para>True to enable a 30-day migration period during which administrators can create role
        /// mappings. Only necessary when <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/fgac.html#fgac-enabling-existing">enabling
        /// fine-grained access control on an existing domain</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdvancedSecurityOptions_AnonymousAuthEnabled { get; set; }
        #endregion
        
        #region Parameter SnapshotOptions_AutomatedSnapshotStartHour
        /// <summary>
        /// <para>
        /// <para>The time, in UTC format, when OpenSearch Service takes a daily automated snapshot
        /// of the specified domain. Default is <c>0</c> hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
        #endregion
        
        #region Parameter SoftwareUpdateOptions_AutoSoftwareUpdateEnabled
        /// <summary>
        /// <para>
        /// <para>Whether automatic service software updates are enabled for the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SoftwareUpdateOptions_AutoSoftwareUpdateEnabled { get; set; }
        #endregion
        
        #region Parameter ZoneAwarenessConfig_AvailabilityZoneCount
        /// <summary>
        /// <para>
        /// <para>If you enabled multiple Availability Zones, this value is the number of zones that
        /// you want the domain to use. Valid values are <c>2</c> and <c>3</c>. If your domain
        /// is provisioned within a VPC, this value be equal to number of subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClusterConfig_ZoneAwarenessConfig_AvailabilityZoneCount")]
        public System.Int32? ZoneAwarenessConfig_AvailabilityZoneCount { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_CustomEndpoint
        /// <summary>
        /// <para>
        /// <para>The fully qualified URL for the custom endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEndpointOptions_CustomEndpoint { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_CustomEndpointCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN for your security certificate, managed in Amazon Web Services Certificate
        /// Manager (ACM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEndpointOptions_CustomEndpointCertificateArn { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_CustomEndpointEnabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable a custom endpoint for the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DomainEndpointOptions_CustomEndpointEnabled { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_DedicatedMasterCount
        /// <summary>
        /// <para>
        /// <para>Number of dedicated master nodes in the cluster. This number must be greater than
        /// 2 and not 4, otherwise you receive a validation exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ClusterConfig_DedicatedMasterCount { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_DedicatedMasterEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether dedicated master nodes are enabled for the cluster.<c>True</c> if
        /// the cluster will use a dedicated master node.<c>False</c> if the cluster will not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClusterConfig_DedicatedMasterEnabled { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_DedicatedMasterType
        /// <summary>
        /// <para>
        /// <para>OpenSearch Service instance type of the dedicated master nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.OpenSearchPartitionInstanceType")]
        public Amazon.OpenSearchService.OpenSearchPartitionInstanceType ClusterConfig_DedicatedMasterType { get; set; }
        #endregion
        
        #region Parameter NaturalLanguageQueryGenerationOptions_DesiredState
        /// <summary>
        /// <para>
        /// <para>The desired state of the natural language query generation feature. Valid values are
        /// ENABLED and DISABLED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AIMLOptions_NaturalLanguageQueryGenerationOptions_DesiredState")]
        [AWSConstantClassSource("Amazon.OpenSearchService.NaturalLanguageQueryGenerationDesiredState")]
        public Amazon.OpenSearchService.NaturalLanguageQueryGenerationDesiredState NaturalLanguageQueryGenerationOptions_DesiredState { get; set; }
        #endregion
        
        #region Parameter AutoTuneOptions_DesiredState
        /// <summary>
        /// <para>
        /// <para>Whether Auto-Tune is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.AutoTuneDesiredState")]
        public Amazon.OpenSearchService.AutoTuneDesiredState AutoTuneOptions_DesiredState { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you're updating.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>This flag, when set to True, specifies whether the <c>UpdateDomain</c> request should
        /// return the results of a dry run analysis without actually applying the change. A dry
        /// run determines what type of deployment the update will cause.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter DryRunMode
        /// <summary>
        /// <para>
        /// <para>The type of dry run to perform.</para><ul><li><para><c>Basic</c> only returns the type of deployment (blue/green or dynamic) that the
        /// update will cause.</para></li><li><para><c>Verbose</c> runs an additional check to validate the changes you're making. For
        /// more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/managedomains-configuration-changes#validation-check">Validating
        /// a domain update</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.DryRunMode")]
        public Amazon.OpenSearchService.DryRunMode DryRunMode { get; set; }
        #endregion
        
        #region Parameter EBSOptions_EBSEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether EBS volumes are attached to data nodes in an OpenSearch Service
        /// domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EBSOptions_EBSEnabled { get; set; }
        #endregion
        
        #region Parameter AdvancedSecurityOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable fine-grained access control.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdvancedSecurityOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter JWTOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable JWT authentication and authorization for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_JWTOptions_Enabled")]
        public System.Boolean? JWTOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable SAML authentication for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_Enabled")]
        public System.Boolean? SAMLOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ColdStorageOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable cold storage on the domain. You must enable UltraWarm
        /// storage to enable cold storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClusterConfig_ColdStorageOptions_Enabled")]
        public System.Boolean? ColdStorageOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable Amazon Cognito authentication for OpenSearch Dashboards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CognitoOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRestOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable encryption at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EncryptionAtRestOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter NodeToNodeEncryptionOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable node-to-node encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NodeToNodeEncryptionOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter OffPeakWindowOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable an off-peak window.</para><para>This option is only available when modifying a domain created prior to February 16,
        /// 2023, not when creating a new domain. All domains created after this date have the
        /// off-peak window enabled by default. You can't disable the off-peak window after it's
        /// enabled for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OffPeakWindowOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_EnforceHTTPS
        /// <summary>
        /// <para>
        /// <para>True to require that all traffic to the domain arrive over HTTPS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DomainEndpointOptions_EnforceHTTPS { get; set; }
        #endregion
        
        #region Parameter Idp_EntityId
        /// <summary>
        /// <para>
        /// <para>The unique entity ID of the application in the SAML identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_Idp_EntityId")]
        public System.String Idp_EntityId { get; set; }
        #endregion
        
        #region Parameter WindowStartTime_Hour
        /// <summary>
        /// <para>
        /// <para>The start hour of the window in Coordinated Universal Time (UTC), using 24-hour time.
        /// For example, <c>17</c> refers to 5:00 P.M. UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OffPeakWindowOptions_OffPeakWindow_WindowStartTime_Hours")]
        public System.Int64? WindowStartTime_Hour { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito identity pool ID that you want OpenSearch Service to use for OpenSearch
        /// Dashboards authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>Number of data nodes in the cluster. This number must be greater than 1, otherwise
        /// you receive a validation exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ClusterConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>Instance type of data nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.OpenSearchPartitionInstanceType")]
        public Amazon.OpenSearchService.OpenSearchPartitionInstanceType ClusterConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter AdvancedSecurityOptions_InternalUserDatabaseEnabled
        /// <summary>
        /// <para>
        /// <para>True to enable the internal user database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdvancedSecurityOptions_InternalUserDatabaseEnabled { get; set; }
        #endregion
        
        #region Parameter EBSOptions_Iops
        /// <summary>
        /// <para>
        /// <para>Specifies the baseline input/output (I/O) performance of EBS volumes attached to data
        /// nodes. Applicable only for the <c>gp3</c> and provisioned IOPS EBS volume types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EBSOptions_Iops { get; set; }
        #endregion
        
        #region Parameter IPAddressType
        /// <summary>
        /// <para>
        /// <para>Specify either dual stack or IPv4 as your IP address type. Dual stack allows you to
        /// share domain resources across IPv4 and IPv6 address types, and is the recommended
        /// option. If your IP address type is currently set to dual stack, you can't change it.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.IPAddressType")]
        public Amazon.OpenSearchService.IPAddressType IPAddressType { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRestOptions_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key ID. Takes the form <c>1a2a3a4-1a2a-3a4a-5a6a-1a2a3a4a5a6a</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionAtRestOptions_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LogPublishingOption
        /// <summary>
        /// <para>
        /// <para>Options to publish OpenSearch logs to Amazon CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPublishingOptions")]
        public System.Collections.Hashtable LogPublishingOption { get; set; }
        #endregion
        
        #region Parameter AutoTuneOptions_MaintenanceSchedule
        /// <summary>
        /// <para>
        /// <para>DEPRECATED. Use <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/off-peak.html">off-peak
        /// window</a> instead.</para><para>A list of maintenance schedules during which Auto-Tune can deploy changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoTuneOptions_MaintenanceSchedules")]
        public Amazon.OpenSearchService.Model.AutoTuneMaintenanceSchedule[] AutoTuneOptions_MaintenanceSchedule { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_MasterBackendRole
        /// <summary>
        /// <para>
        /// <para>The backend role that the SAML master user is mapped to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_MasterBackendRole")]
        public System.String SAMLOptions_MasterBackendRole { get; set; }
        #endregion
        
        #region Parameter MasterUserOptions_MasterUserARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) for the master user. Only specify if <c>InternalUserDatabaseEnabled</c>
        /// is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_MasterUserOptions_MasterUserARN")]
        public System.String MasterUserOptions_MasterUserARN { get; set; }
        #endregion
        
        #region Parameter MasterUserOptions_MasterUserName
        /// <summary>
        /// <para>
        /// <para>User name for the master user. Only specify if <c>InternalUserDatabaseEnabled</c>
        /// is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_MasterUserOptions_MasterUserName")]
        public System.String MasterUserOptions_MasterUserName { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_MasterUserName
        /// <summary>
        /// <para>
        /// <para>The SAML master user name, which is stored in the domain's internal user database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_MasterUserName")]
        public System.String SAMLOptions_MasterUserName { get; set; }
        #endregion
        
        #region Parameter MasterUserOptions_MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Password for the master user. Only specify if <c>InternalUserDatabaseEnabled</c> is
        /// <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_MasterUserOptions_MasterUserPassword")]
        public System.String MasterUserOptions_MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter Idp_MetadataContent
        /// <summary>
        /// <para>
        /// <para>The metadata of the SAML application, in XML format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_Idp_MetadataContent")]
        public System.String Idp_MetadataContent { get; set; }
        #endregion
        
        #region Parameter WindowStartTime_Minute
        /// <summary>
        /// <para>
        /// <para>The start minute of the window, in UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OffPeakWindowOptions_OffPeakWindow_WindowStartTime_Minutes")]
        public System.Int64? WindowStartTime_Minute { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_MultiAZWithStandbyEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean that indicates whether a multi-AZ domain is turned on with a standby AZ.
        /// For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/managedomains-multiaz.html">Configuring
        /// a multi-AZ domain in Amazon OpenSearch Service</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClusterConfig_MultiAZWithStandbyEnabled { get; set; }
        #endregion
        
        #region Parameter JWTOptions_PublicKey
        /// <summary>
        /// <para>
        /// <para>Element of the JWT assertion used by the cluster to verify JWT signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_JWTOptions_PublicKey")]
        public System.String JWTOptions_PublicKey { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_RoleArn
        /// <summary>
        /// <para>
        /// <para>The <c>AmazonOpenSearchServiceCognitoAccess</c> role that allows OpenSearch Service
        /// to configure your user pool and identity pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_RoleArn { get; set; }
        #endregion
        
        #region Parameter JWTOptions_RolesKey
        /// <summary>
        /// <para>
        /// <para>Element of the JWT assertion to use for roles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_JWTOptions_RolesKey")]
        public System.String JWTOptions_RolesKey { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_RolesKey
        /// <summary>
        /// <para>
        /// <para>Element of the SAML assertion to use for backend roles. Default is <c>roles</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_RolesKey")]
        public System.String SAMLOptions_RolesKey { get; set; }
        #endregion
        
        #region Parameter AutoTuneOptions_RollbackOnDisable
        /// <summary>
        /// <para>
        /// <para>When disabling Auto-Tune, specify <c>NO_ROLLBACK</c> to retain all prior Auto-Tune
        /// settings or <c>DEFAULT_ROLLBACK</c> to revert to the OpenSearch Service defaults.
        /// If you specify <c>DEFAULT_ROLLBACK</c>, you must include a <c>MaintenanceSchedule</c>
        /// in the request. Otherwise, OpenSearch Service is unable to perform the rollback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.RollbackOnDisable")]
        public Amazon.OpenSearchService.RollbackOnDisable AutoTuneOptions_RollbackOnDisable { get; set; }
        #endregion
        
        #region Parameter VPCOptions_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The list of security group IDs associated with the VPC endpoints for the domain. If
        /// you do not provide a security group ID, OpenSearch Service uses the default security
        /// group for the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VPCOptions_SecurityGroupIds")]
        public System.String[] VPCOptions_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_SessionTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The duration, in minutes, after which a user session becomes inactive. Acceptable
        /// values are between 1 and 1440, and the default value is 60.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_SessionTimeoutMinutes")]
        public System.Int32? SAMLOptions_SessionTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter JWTOptions_SubjectKey
        /// <summary>
        /// <para>
        /// <para>Element of the JWT assertion to use for the user name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_JWTOptions_SubjectKey")]
        public System.String JWTOptions_SubjectKey { get; set; }
        #endregion
        
        #region Parameter SAMLOptions_SubjectKey
        /// <summary>
        /// <para>
        /// <para>Element of the SAML assertion to use for the user name. Default is <c>NameID</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedSecurityOptions_SAMLOptions_SubjectKey")]
        public System.String SAMLOptions_SubjectKey { get; set; }
        #endregion
        
        #region Parameter VPCOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs associated with the VPC endpoints for the domain. If your domain
        /// uses multiple Availability Zones, you need to provide two subnet IDs, one per zone.
        /// Otherwise, provide only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VPCOptions_SubnetIds")]
        public System.String[] VPCOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter EBSOptions_Throughput
        /// <summary>
        /// <para>
        /// <para>Specifies the throughput (in MiB/s) of the EBS volumes attached to data nodes. Applicable
        /// only for the <c>gp3</c> volume type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EBSOptions_Throughput { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_TLSSecurityPolicy
        /// <summary>
        /// <para>
        /// <para>Specify the TLS security policy to apply to the HTTPS endpoint of the domain. The
        /// policy can be one of the following values:</para><ul><li><para><b>Policy-Min-TLS-1-0-2019-07:</b> TLS security policy that supports TLS version
        /// 1.0 to TLS version 1.2</para></li><li><para><b>Policy-Min-TLS-1-2-2019-07:</b> TLS security policy that supports only TLS version
        /// 1.2</para></li><li><para><b>Policy-Min-TLS-1-2-PFS-2023-10:</b> TLS security policy that supports TLS version
        /// 1.2 to TLS version 1.3 with perfect forward secrecy cipher suites</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.TLSSecurityPolicy")]
        public Amazon.OpenSearchService.TLSSecurityPolicy DomainEndpointOptions_TLSSecurityPolicy { get; set; }
        #endregion
        
        #region Parameter AutoTuneOptions_UseOffPeakWindow
        /// <summary>
        /// <para>
        /// <para>Whether to use the domain's <a href="https://docs.aws.amazon.com/opensearch-service/latest/APIReference/API_OffPeakWindow.html">off-peak
        /// window</a> to deploy configuration changes on the domain rather than a maintenance
        /// schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoTuneOptions_UseOffPeakWindow { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_UserPoolId
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito user pool ID that you want OpenSearch Service to use for OpenSearch
        /// Dashboards authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_UserPoolId { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeSize
        /// <summary>
        /// <para>
        /// <para>Specifies the size (in GiB) of EBS volumes attached to data nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EBSOptions_VolumeSize { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of EBS volumes attached to data nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.VolumeType")]
        public Amazon.OpenSearchService.VolumeType EBSOptions_VolumeType { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_WarmCount
        /// <summary>
        /// <para>
        /// <para>The number of warm nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ClusterConfig_WarmCount { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_WarmEnabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable warm storage for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClusterConfig_WarmEnabled { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_WarmType
        /// <summary>
        /// <para>
        /// <para>The instance type for the cluster's warm nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.OpenSearchWarmPartitionInstanceType")]
        public Amazon.OpenSearchService.OpenSearchWarmPartitionInstanceType ClusterConfig_WarmType { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_ZoneAwarenessEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether multiple Availability Zones are enabled. For more information, see
        /// <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/managedomains-multiaz.html">Configuring
        /// a multi-AZ domain in Amazon OpenSearch Service</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClusterConfig_ZoneAwarenessEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.UpdateDomainConfigResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.UpdateDomainConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainConfig";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSDomainConfig (UpdateDomainConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.UpdateDomainConfigResponse, UpdateOSDomainConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessPolicy = this.AccessPolicy;
            if (this.AdvancedOption != null)
            {
                context.AdvancedOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdvancedOption.Keys)
                {
                    context.AdvancedOption.Add((String)hashKey, (System.String)(this.AdvancedOption[hashKey]));
                }
            }
            context.AdvancedSecurityOptions_AnonymousAuthEnabled = this.AdvancedSecurityOptions_AnonymousAuthEnabled;
            context.AdvancedSecurityOptions_Enabled = this.AdvancedSecurityOptions_Enabled;
            context.AdvancedSecurityOptions_InternalUserDatabaseEnabled = this.AdvancedSecurityOptions_InternalUserDatabaseEnabled;
            context.JWTOptions_Enabled = this.JWTOptions_Enabled;
            context.JWTOptions_PublicKey = this.JWTOptions_PublicKey;
            context.JWTOptions_RolesKey = this.JWTOptions_RolesKey;
            context.JWTOptions_SubjectKey = this.JWTOptions_SubjectKey;
            context.MasterUserOptions_MasterUserARN = this.MasterUserOptions_MasterUserARN;
            context.MasterUserOptions_MasterUserName = this.MasterUserOptions_MasterUserName;
            context.MasterUserOptions_MasterUserPassword = this.MasterUserOptions_MasterUserPassword;
            context.SAMLOptions_Enabled = this.SAMLOptions_Enabled;
            context.Idp_EntityId = this.Idp_EntityId;
            context.Idp_MetadataContent = this.Idp_MetadataContent;
            context.SAMLOptions_MasterBackendRole = this.SAMLOptions_MasterBackendRole;
            context.SAMLOptions_MasterUserName = this.SAMLOptions_MasterUserName;
            context.SAMLOptions_RolesKey = this.SAMLOptions_RolesKey;
            context.SAMLOptions_SessionTimeoutMinute = this.SAMLOptions_SessionTimeoutMinute;
            context.SAMLOptions_SubjectKey = this.SAMLOptions_SubjectKey;
            context.NaturalLanguageQueryGenerationOptions_DesiredState = this.NaturalLanguageQueryGenerationOptions_DesiredState;
            context.AutoTuneOptions_DesiredState = this.AutoTuneOptions_DesiredState;
            if (this.AutoTuneOptions_MaintenanceSchedule != null)
            {
                context.AutoTuneOptions_MaintenanceSchedule = new List<Amazon.OpenSearchService.Model.AutoTuneMaintenanceSchedule>(this.AutoTuneOptions_MaintenanceSchedule);
            }
            context.AutoTuneOptions_RollbackOnDisable = this.AutoTuneOptions_RollbackOnDisable;
            context.AutoTuneOptions_UseOffPeakWindow = this.AutoTuneOptions_UseOffPeakWindow;
            context.ColdStorageOptions_Enabled = this.ColdStorageOptions_Enabled;
            context.ClusterConfig_DedicatedMasterCount = this.ClusterConfig_DedicatedMasterCount;
            context.ClusterConfig_DedicatedMasterEnabled = this.ClusterConfig_DedicatedMasterEnabled;
            context.ClusterConfig_DedicatedMasterType = this.ClusterConfig_DedicatedMasterType;
            context.ClusterConfig_InstanceCount = this.ClusterConfig_InstanceCount;
            context.ClusterConfig_InstanceType = this.ClusterConfig_InstanceType;
            context.ClusterConfig_MultiAZWithStandbyEnabled = this.ClusterConfig_MultiAZWithStandbyEnabled;
            context.ClusterConfig_WarmCount = this.ClusterConfig_WarmCount;
            context.ClusterConfig_WarmEnabled = this.ClusterConfig_WarmEnabled;
            context.ClusterConfig_WarmType = this.ClusterConfig_WarmType;
            context.ZoneAwarenessConfig_AvailabilityZoneCount = this.ZoneAwarenessConfig_AvailabilityZoneCount;
            context.ClusterConfig_ZoneAwarenessEnabled = this.ClusterConfig_ZoneAwarenessEnabled;
            context.CognitoOptions_Enabled = this.CognitoOptions_Enabled;
            context.CognitoOptions_IdentityPoolId = this.CognitoOptions_IdentityPoolId;
            context.CognitoOptions_RoleArn = this.CognitoOptions_RoleArn;
            context.CognitoOptions_UserPoolId = this.CognitoOptions_UserPoolId;
            context.DomainEndpointOptions_CustomEndpoint = this.DomainEndpointOptions_CustomEndpoint;
            context.DomainEndpointOptions_CustomEndpointCertificateArn = this.DomainEndpointOptions_CustomEndpointCertificateArn;
            context.DomainEndpointOptions_CustomEndpointEnabled = this.DomainEndpointOptions_CustomEndpointEnabled;
            context.DomainEndpointOptions_EnforceHTTPS = this.DomainEndpointOptions_EnforceHTTPS;
            context.DomainEndpointOptions_TLSSecurityPolicy = this.DomainEndpointOptions_TLSSecurityPolicy;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.DryRunMode = this.DryRunMode;
            context.EBSOptions_EBSEnabled = this.EBSOptions_EBSEnabled;
            context.EBSOptions_Iops = this.EBSOptions_Iops;
            context.EBSOptions_Throughput = this.EBSOptions_Throughput;
            context.EBSOptions_VolumeSize = this.EBSOptions_VolumeSize;
            context.EBSOptions_VolumeType = this.EBSOptions_VolumeType;
            context.EncryptionAtRestOptions_Enabled = this.EncryptionAtRestOptions_Enabled;
            context.EncryptionAtRestOptions_KmsKeyId = this.EncryptionAtRestOptions_KmsKeyId;
            context.IPAddressType = this.IPAddressType;
            if (this.LogPublishingOption != null)
            {
                context.LogPublishingOption = new Dictionary<System.String, Amazon.OpenSearchService.Model.LogPublishingOption>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogPublishingOption.Keys)
                {
                    context.LogPublishingOption.Add((String)hashKey, (Amazon.OpenSearchService.Model.LogPublishingOption)(this.LogPublishingOption[hashKey]));
                }
            }
            context.NodeToNodeEncryptionOptions_Enabled = this.NodeToNodeEncryptionOptions_Enabled;
            context.OffPeakWindowOptions_Enabled = this.OffPeakWindowOptions_Enabled;
            context.WindowStartTime_Hour = this.WindowStartTime_Hour;
            context.WindowStartTime_Minute = this.WindowStartTime_Minute;
            context.SnapshotOptions_AutomatedSnapshotStartHour = this.SnapshotOptions_AutomatedSnapshotStartHour;
            context.SoftwareUpdateOptions_AutoSoftwareUpdateEnabled = this.SoftwareUpdateOptions_AutoSoftwareUpdateEnabled;
            if (this.VPCOptions_SecurityGroupId != null)
            {
                context.VPCOptions_SecurityGroupId = new List<System.String>(this.VPCOptions_SecurityGroupId);
            }
            if (this.VPCOptions_SubnetId != null)
            {
                context.VPCOptions_SubnetId = new List<System.String>(this.VPCOptions_SubnetId);
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
            var request = new Amazon.OpenSearchService.Model.UpdateDomainConfigRequest();
            
            if (cmdletContext.AccessPolicy != null)
            {
                request.AccessPolicies = cmdletContext.AccessPolicy;
            }
            if (cmdletContext.AdvancedOption != null)
            {
                request.AdvancedOptions = cmdletContext.AdvancedOption;
            }
            
             // populate AdvancedSecurityOptions
            var requestAdvancedSecurityOptionsIsNull = true;
            request.AdvancedSecurityOptions = new Amazon.OpenSearchService.Model.AdvancedSecurityOptionsInput();
            System.Boolean? requestAdvancedSecurityOptions_advancedSecurityOptions_AnonymousAuthEnabled = null;
            if (cmdletContext.AdvancedSecurityOptions_AnonymousAuthEnabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_AnonymousAuthEnabled = cmdletContext.AdvancedSecurityOptions_AnonymousAuthEnabled.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_AnonymousAuthEnabled != null)
            {
                request.AdvancedSecurityOptions.AnonymousAuthEnabled = requestAdvancedSecurityOptions_advancedSecurityOptions_AnonymousAuthEnabled.Value;
                requestAdvancedSecurityOptionsIsNull = false;
            }
            System.Boolean? requestAdvancedSecurityOptions_advancedSecurityOptions_Enabled = null;
            if (cmdletContext.AdvancedSecurityOptions_Enabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_Enabled = cmdletContext.AdvancedSecurityOptions_Enabled.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_Enabled != null)
            {
                request.AdvancedSecurityOptions.Enabled = requestAdvancedSecurityOptions_advancedSecurityOptions_Enabled.Value;
                requestAdvancedSecurityOptionsIsNull = false;
            }
            System.Boolean? requestAdvancedSecurityOptions_advancedSecurityOptions_InternalUserDatabaseEnabled = null;
            if (cmdletContext.AdvancedSecurityOptions_InternalUserDatabaseEnabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_InternalUserDatabaseEnabled = cmdletContext.AdvancedSecurityOptions_InternalUserDatabaseEnabled.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_InternalUserDatabaseEnabled != null)
            {
                request.AdvancedSecurityOptions.InternalUserDatabaseEnabled = requestAdvancedSecurityOptions_advancedSecurityOptions_InternalUserDatabaseEnabled.Value;
                requestAdvancedSecurityOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.MasterUserOptions requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions = null;
            
             // populate MasterUserOptions
            var requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptionsIsNull = true;
            requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions = new Amazon.OpenSearchService.Model.MasterUserOptions();
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserARN = null;
            if (cmdletContext.MasterUserOptions_MasterUserARN != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserARN = cmdletContext.MasterUserOptions_MasterUserARN;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserARN != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions.MasterUserARN = requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserARN;
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserName = null;
            if (cmdletContext.MasterUserOptions_MasterUserName != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserName = cmdletContext.MasterUserOptions_MasterUserName;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserName != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions.MasterUserName = requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserName;
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserPassword = null;
            if (cmdletContext.MasterUserOptions_MasterUserPassword != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserPassword = cmdletContext.MasterUserOptions_MasterUserPassword;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserPassword != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions.MasterUserPassword = requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions_masterUserOptions_MasterUserPassword;
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptionsIsNull = false;
            }
             // determine if requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions should be set to null
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptionsIsNull)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions = null;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions != null)
            {
                request.AdvancedSecurityOptions.MasterUserOptions = requestAdvancedSecurityOptions_advancedSecurityOptions_MasterUserOptions;
                requestAdvancedSecurityOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.JWTOptionsInput requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions = null;
            
             // populate JWTOptions
            var requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull = true;
            requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions = new Amazon.OpenSearchService.Model.JWTOptionsInput();
            System.Boolean? requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_Enabled = null;
            if (cmdletContext.JWTOptions_Enabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_Enabled = cmdletContext.JWTOptions_Enabled.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_Enabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions.Enabled = requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_Enabled.Value;
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_PublicKey = null;
            if (cmdletContext.JWTOptions_PublicKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_PublicKey = cmdletContext.JWTOptions_PublicKey;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_PublicKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions.PublicKey = requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_PublicKey;
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_RolesKey = null;
            if (cmdletContext.JWTOptions_RolesKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_RolesKey = cmdletContext.JWTOptions_RolesKey;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_RolesKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions.RolesKey = requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_RolesKey;
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_SubjectKey = null;
            if (cmdletContext.JWTOptions_SubjectKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_SubjectKey = cmdletContext.JWTOptions_SubjectKey;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_SubjectKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions.SubjectKey = requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions_jWTOptions_SubjectKey;
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull = false;
            }
             // determine if requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions should be set to null
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptionsIsNull)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions = null;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions != null)
            {
                request.AdvancedSecurityOptions.JWTOptions = requestAdvancedSecurityOptions_advancedSecurityOptions_JWTOptions;
                requestAdvancedSecurityOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.SAMLOptionsInput requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions = null;
            
             // populate SAMLOptions
            var requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = true;
            requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions = new Amazon.OpenSearchService.Model.SAMLOptionsInput();
            System.Boolean? requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_Enabled = null;
            if (cmdletContext.SAMLOptions_Enabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_Enabled = cmdletContext.SAMLOptions_Enabled.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_Enabled != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.Enabled = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_Enabled.Value;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterBackendRole = null;
            if (cmdletContext.SAMLOptions_MasterBackendRole != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterBackendRole = cmdletContext.SAMLOptions_MasterBackendRole;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterBackendRole != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.MasterBackendRole = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterBackendRole;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterUserName = null;
            if (cmdletContext.SAMLOptions_MasterUserName != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterUserName = cmdletContext.SAMLOptions_MasterUserName;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterUserName != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.MasterUserName = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_MasterUserName;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_RolesKey = null;
            if (cmdletContext.SAMLOptions_RolesKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_RolesKey = cmdletContext.SAMLOptions_RolesKey;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_RolesKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.RolesKey = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_RolesKey;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            System.Int32? requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SessionTimeoutMinute = null;
            if (cmdletContext.SAMLOptions_SessionTimeoutMinute != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SessionTimeoutMinute = cmdletContext.SAMLOptions_SessionTimeoutMinute.Value;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SessionTimeoutMinute != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.SessionTimeoutMinutes = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SessionTimeoutMinute.Value;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SubjectKey = null;
            if (cmdletContext.SAMLOptions_SubjectKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SubjectKey = cmdletContext.SAMLOptions_SubjectKey;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SubjectKey != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.SubjectKey = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_sAMLOptions_SubjectKey;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.SAMLIdp requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp = null;
            
             // populate Idp
            var requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_IdpIsNull = true;
            requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp = new Amazon.OpenSearchService.Model.SAMLIdp();
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_EntityId = null;
            if (cmdletContext.Idp_EntityId != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_EntityId = cmdletContext.Idp_EntityId;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_EntityId != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp.EntityId = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_EntityId;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_IdpIsNull = false;
            }
            System.String requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_MetadataContent = null;
            if (cmdletContext.Idp_MetadataContent != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_MetadataContent = cmdletContext.Idp_MetadataContent;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_MetadataContent != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp.MetadataContent = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp_idp_MetadataContent;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_IdpIsNull = false;
            }
             // determine if requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp should be set to null
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_IdpIsNull)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp = null;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp != null)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions.Idp = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions_advancedSecurityOptions_SAMLOptions_Idp;
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull = false;
            }
             // determine if requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions should be set to null
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptionsIsNull)
            {
                requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions = null;
            }
            if (requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions != null)
            {
                request.AdvancedSecurityOptions.SAMLOptions = requestAdvancedSecurityOptions_advancedSecurityOptions_SAMLOptions;
                requestAdvancedSecurityOptionsIsNull = false;
            }
             // determine if request.AdvancedSecurityOptions should be set to null
            if (requestAdvancedSecurityOptionsIsNull)
            {
                request.AdvancedSecurityOptions = null;
            }
            
             // populate AIMLOptions
            var requestAIMLOptionsIsNull = true;
            request.AIMLOptions = new Amazon.OpenSearchService.Model.AIMLOptionsInput();
            Amazon.OpenSearchService.Model.NaturalLanguageQueryGenerationOptionsInput requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions = null;
            
             // populate NaturalLanguageQueryGenerationOptions
            var requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptionsIsNull = true;
            requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions = new Amazon.OpenSearchService.Model.NaturalLanguageQueryGenerationOptionsInput();
            Amazon.OpenSearchService.NaturalLanguageQueryGenerationDesiredState requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions_naturalLanguageQueryGenerationOptions_DesiredState = null;
            if (cmdletContext.NaturalLanguageQueryGenerationOptions_DesiredState != null)
            {
                requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions_naturalLanguageQueryGenerationOptions_DesiredState = cmdletContext.NaturalLanguageQueryGenerationOptions_DesiredState;
            }
            if (requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions_naturalLanguageQueryGenerationOptions_DesiredState != null)
            {
                requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions.DesiredState = requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions_naturalLanguageQueryGenerationOptions_DesiredState;
                requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptionsIsNull = false;
            }
             // determine if requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions should be set to null
            if (requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptionsIsNull)
            {
                requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions = null;
            }
            if (requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions != null)
            {
                request.AIMLOptions.NaturalLanguageQueryGenerationOptions = requestAIMLOptions_aIMLOptions_NaturalLanguageQueryGenerationOptions;
                requestAIMLOptionsIsNull = false;
            }
             // determine if request.AIMLOptions should be set to null
            if (requestAIMLOptionsIsNull)
            {
                request.AIMLOptions = null;
            }
            
             // populate AutoTuneOptions
            var requestAutoTuneOptionsIsNull = true;
            request.AutoTuneOptions = new Amazon.OpenSearchService.Model.AutoTuneOptions();
            Amazon.OpenSearchService.AutoTuneDesiredState requestAutoTuneOptions_autoTuneOptions_DesiredState = null;
            if (cmdletContext.AutoTuneOptions_DesiredState != null)
            {
                requestAutoTuneOptions_autoTuneOptions_DesiredState = cmdletContext.AutoTuneOptions_DesiredState;
            }
            if (requestAutoTuneOptions_autoTuneOptions_DesiredState != null)
            {
                request.AutoTuneOptions.DesiredState = requestAutoTuneOptions_autoTuneOptions_DesiredState;
                requestAutoTuneOptionsIsNull = false;
            }
            List<Amazon.OpenSearchService.Model.AutoTuneMaintenanceSchedule> requestAutoTuneOptions_autoTuneOptions_MaintenanceSchedule = null;
            if (cmdletContext.AutoTuneOptions_MaintenanceSchedule != null)
            {
                requestAutoTuneOptions_autoTuneOptions_MaintenanceSchedule = cmdletContext.AutoTuneOptions_MaintenanceSchedule;
            }
            if (requestAutoTuneOptions_autoTuneOptions_MaintenanceSchedule != null)
            {
                request.AutoTuneOptions.MaintenanceSchedules = requestAutoTuneOptions_autoTuneOptions_MaintenanceSchedule;
                requestAutoTuneOptionsIsNull = false;
            }
            Amazon.OpenSearchService.RollbackOnDisable requestAutoTuneOptions_autoTuneOptions_RollbackOnDisable = null;
            if (cmdletContext.AutoTuneOptions_RollbackOnDisable != null)
            {
                requestAutoTuneOptions_autoTuneOptions_RollbackOnDisable = cmdletContext.AutoTuneOptions_RollbackOnDisable;
            }
            if (requestAutoTuneOptions_autoTuneOptions_RollbackOnDisable != null)
            {
                request.AutoTuneOptions.RollbackOnDisable = requestAutoTuneOptions_autoTuneOptions_RollbackOnDisable;
                requestAutoTuneOptionsIsNull = false;
            }
            System.Boolean? requestAutoTuneOptions_autoTuneOptions_UseOffPeakWindow = null;
            if (cmdletContext.AutoTuneOptions_UseOffPeakWindow != null)
            {
                requestAutoTuneOptions_autoTuneOptions_UseOffPeakWindow = cmdletContext.AutoTuneOptions_UseOffPeakWindow.Value;
            }
            if (requestAutoTuneOptions_autoTuneOptions_UseOffPeakWindow != null)
            {
                request.AutoTuneOptions.UseOffPeakWindow = requestAutoTuneOptions_autoTuneOptions_UseOffPeakWindow.Value;
                requestAutoTuneOptionsIsNull = false;
            }
             // determine if request.AutoTuneOptions should be set to null
            if (requestAutoTuneOptionsIsNull)
            {
                request.AutoTuneOptions = null;
            }
            
             // populate ClusterConfig
            var requestClusterConfigIsNull = true;
            request.ClusterConfig = new Amazon.OpenSearchService.Model.ClusterConfig();
            System.Int32? requestClusterConfig_clusterConfig_DedicatedMasterCount = null;
            if (cmdletContext.ClusterConfig_DedicatedMasterCount != null)
            {
                requestClusterConfig_clusterConfig_DedicatedMasterCount = cmdletContext.ClusterConfig_DedicatedMasterCount.Value;
            }
            if (requestClusterConfig_clusterConfig_DedicatedMasterCount != null)
            {
                request.ClusterConfig.DedicatedMasterCount = requestClusterConfig_clusterConfig_DedicatedMasterCount.Value;
                requestClusterConfigIsNull = false;
            }
            System.Boolean? requestClusterConfig_clusterConfig_DedicatedMasterEnabled = null;
            if (cmdletContext.ClusterConfig_DedicatedMasterEnabled != null)
            {
                requestClusterConfig_clusterConfig_DedicatedMasterEnabled = cmdletContext.ClusterConfig_DedicatedMasterEnabled.Value;
            }
            if (requestClusterConfig_clusterConfig_DedicatedMasterEnabled != null)
            {
                request.ClusterConfig.DedicatedMasterEnabled = requestClusterConfig_clusterConfig_DedicatedMasterEnabled.Value;
                requestClusterConfigIsNull = false;
            }
            Amazon.OpenSearchService.OpenSearchPartitionInstanceType requestClusterConfig_clusterConfig_DedicatedMasterType = null;
            if (cmdletContext.ClusterConfig_DedicatedMasterType != null)
            {
                requestClusterConfig_clusterConfig_DedicatedMasterType = cmdletContext.ClusterConfig_DedicatedMasterType;
            }
            if (requestClusterConfig_clusterConfig_DedicatedMasterType != null)
            {
                request.ClusterConfig.DedicatedMasterType = requestClusterConfig_clusterConfig_DedicatedMasterType;
                requestClusterConfigIsNull = false;
            }
            System.Int32? requestClusterConfig_clusterConfig_InstanceCount = null;
            if (cmdletContext.ClusterConfig_InstanceCount != null)
            {
                requestClusterConfig_clusterConfig_InstanceCount = cmdletContext.ClusterConfig_InstanceCount.Value;
            }
            if (requestClusterConfig_clusterConfig_InstanceCount != null)
            {
                request.ClusterConfig.InstanceCount = requestClusterConfig_clusterConfig_InstanceCount.Value;
                requestClusterConfigIsNull = false;
            }
            Amazon.OpenSearchService.OpenSearchPartitionInstanceType requestClusterConfig_clusterConfig_InstanceType = null;
            if (cmdletContext.ClusterConfig_InstanceType != null)
            {
                requestClusterConfig_clusterConfig_InstanceType = cmdletContext.ClusterConfig_InstanceType;
            }
            if (requestClusterConfig_clusterConfig_InstanceType != null)
            {
                request.ClusterConfig.InstanceType = requestClusterConfig_clusterConfig_InstanceType;
                requestClusterConfigIsNull = false;
            }
            System.Boolean? requestClusterConfig_clusterConfig_MultiAZWithStandbyEnabled = null;
            if (cmdletContext.ClusterConfig_MultiAZWithStandbyEnabled != null)
            {
                requestClusterConfig_clusterConfig_MultiAZWithStandbyEnabled = cmdletContext.ClusterConfig_MultiAZWithStandbyEnabled.Value;
            }
            if (requestClusterConfig_clusterConfig_MultiAZWithStandbyEnabled != null)
            {
                request.ClusterConfig.MultiAZWithStandbyEnabled = requestClusterConfig_clusterConfig_MultiAZWithStandbyEnabled.Value;
                requestClusterConfigIsNull = false;
            }
            System.Int32? requestClusterConfig_clusterConfig_WarmCount = null;
            if (cmdletContext.ClusterConfig_WarmCount != null)
            {
                requestClusterConfig_clusterConfig_WarmCount = cmdletContext.ClusterConfig_WarmCount.Value;
            }
            if (requestClusterConfig_clusterConfig_WarmCount != null)
            {
                request.ClusterConfig.WarmCount = requestClusterConfig_clusterConfig_WarmCount.Value;
                requestClusterConfigIsNull = false;
            }
            System.Boolean? requestClusterConfig_clusterConfig_WarmEnabled = null;
            if (cmdletContext.ClusterConfig_WarmEnabled != null)
            {
                requestClusterConfig_clusterConfig_WarmEnabled = cmdletContext.ClusterConfig_WarmEnabled.Value;
            }
            if (requestClusterConfig_clusterConfig_WarmEnabled != null)
            {
                request.ClusterConfig.WarmEnabled = requestClusterConfig_clusterConfig_WarmEnabled.Value;
                requestClusterConfigIsNull = false;
            }
            Amazon.OpenSearchService.OpenSearchWarmPartitionInstanceType requestClusterConfig_clusterConfig_WarmType = null;
            if (cmdletContext.ClusterConfig_WarmType != null)
            {
                requestClusterConfig_clusterConfig_WarmType = cmdletContext.ClusterConfig_WarmType;
            }
            if (requestClusterConfig_clusterConfig_WarmType != null)
            {
                request.ClusterConfig.WarmType = requestClusterConfig_clusterConfig_WarmType;
                requestClusterConfigIsNull = false;
            }
            System.Boolean? requestClusterConfig_clusterConfig_ZoneAwarenessEnabled = null;
            if (cmdletContext.ClusterConfig_ZoneAwarenessEnabled != null)
            {
                requestClusterConfig_clusterConfig_ZoneAwarenessEnabled = cmdletContext.ClusterConfig_ZoneAwarenessEnabled.Value;
            }
            if (requestClusterConfig_clusterConfig_ZoneAwarenessEnabled != null)
            {
                request.ClusterConfig.ZoneAwarenessEnabled = requestClusterConfig_clusterConfig_ZoneAwarenessEnabled.Value;
                requestClusterConfigIsNull = false;
            }
            Amazon.OpenSearchService.Model.ColdStorageOptions requestClusterConfig_clusterConfig_ColdStorageOptions = null;
            
             // populate ColdStorageOptions
            var requestClusterConfig_clusterConfig_ColdStorageOptionsIsNull = true;
            requestClusterConfig_clusterConfig_ColdStorageOptions = new Amazon.OpenSearchService.Model.ColdStorageOptions();
            System.Boolean? requestClusterConfig_clusterConfig_ColdStorageOptions_coldStorageOptions_Enabled = null;
            if (cmdletContext.ColdStorageOptions_Enabled != null)
            {
                requestClusterConfig_clusterConfig_ColdStorageOptions_coldStorageOptions_Enabled = cmdletContext.ColdStorageOptions_Enabled.Value;
            }
            if (requestClusterConfig_clusterConfig_ColdStorageOptions_coldStorageOptions_Enabled != null)
            {
                requestClusterConfig_clusterConfig_ColdStorageOptions.Enabled = requestClusterConfig_clusterConfig_ColdStorageOptions_coldStorageOptions_Enabled.Value;
                requestClusterConfig_clusterConfig_ColdStorageOptionsIsNull = false;
            }
             // determine if requestClusterConfig_clusterConfig_ColdStorageOptions should be set to null
            if (requestClusterConfig_clusterConfig_ColdStorageOptionsIsNull)
            {
                requestClusterConfig_clusterConfig_ColdStorageOptions = null;
            }
            if (requestClusterConfig_clusterConfig_ColdStorageOptions != null)
            {
                request.ClusterConfig.ColdStorageOptions = requestClusterConfig_clusterConfig_ColdStorageOptions;
                requestClusterConfigIsNull = false;
            }
            Amazon.OpenSearchService.Model.ZoneAwarenessConfig requestClusterConfig_clusterConfig_ZoneAwarenessConfig = null;
            
             // populate ZoneAwarenessConfig
            var requestClusterConfig_clusterConfig_ZoneAwarenessConfigIsNull = true;
            requestClusterConfig_clusterConfig_ZoneAwarenessConfig = new Amazon.OpenSearchService.Model.ZoneAwarenessConfig();
            System.Int32? requestClusterConfig_clusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount = null;
            if (cmdletContext.ZoneAwarenessConfig_AvailabilityZoneCount != null)
            {
                requestClusterConfig_clusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount = cmdletContext.ZoneAwarenessConfig_AvailabilityZoneCount.Value;
            }
            if (requestClusterConfig_clusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount != null)
            {
                requestClusterConfig_clusterConfig_ZoneAwarenessConfig.AvailabilityZoneCount = requestClusterConfig_clusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount.Value;
                requestClusterConfig_clusterConfig_ZoneAwarenessConfigIsNull = false;
            }
             // determine if requestClusterConfig_clusterConfig_ZoneAwarenessConfig should be set to null
            if (requestClusterConfig_clusterConfig_ZoneAwarenessConfigIsNull)
            {
                requestClusterConfig_clusterConfig_ZoneAwarenessConfig = null;
            }
            if (requestClusterConfig_clusterConfig_ZoneAwarenessConfig != null)
            {
                request.ClusterConfig.ZoneAwarenessConfig = requestClusterConfig_clusterConfig_ZoneAwarenessConfig;
                requestClusterConfigIsNull = false;
            }
             // determine if request.ClusterConfig should be set to null
            if (requestClusterConfigIsNull)
            {
                request.ClusterConfig = null;
            }
            
             // populate CognitoOptions
            var requestCognitoOptionsIsNull = true;
            request.CognitoOptions = new Amazon.OpenSearchService.Model.CognitoOptions();
            System.Boolean? requestCognitoOptions_cognitoOptions_Enabled = null;
            if (cmdletContext.CognitoOptions_Enabled != null)
            {
                requestCognitoOptions_cognitoOptions_Enabled = cmdletContext.CognitoOptions_Enabled.Value;
            }
            if (requestCognitoOptions_cognitoOptions_Enabled != null)
            {
                request.CognitoOptions.Enabled = requestCognitoOptions_cognitoOptions_Enabled.Value;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_IdentityPoolId = null;
            if (cmdletContext.CognitoOptions_IdentityPoolId != null)
            {
                requestCognitoOptions_cognitoOptions_IdentityPoolId = cmdletContext.CognitoOptions_IdentityPoolId;
            }
            if (requestCognitoOptions_cognitoOptions_IdentityPoolId != null)
            {
                request.CognitoOptions.IdentityPoolId = requestCognitoOptions_cognitoOptions_IdentityPoolId;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_RoleArn = null;
            if (cmdletContext.CognitoOptions_RoleArn != null)
            {
                requestCognitoOptions_cognitoOptions_RoleArn = cmdletContext.CognitoOptions_RoleArn;
            }
            if (requestCognitoOptions_cognitoOptions_RoleArn != null)
            {
                request.CognitoOptions.RoleArn = requestCognitoOptions_cognitoOptions_RoleArn;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_UserPoolId = null;
            if (cmdletContext.CognitoOptions_UserPoolId != null)
            {
                requestCognitoOptions_cognitoOptions_UserPoolId = cmdletContext.CognitoOptions_UserPoolId;
            }
            if (requestCognitoOptions_cognitoOptions_UserPoolId != null)
            {
                request.CognitoOptions.UserPoolId = requestCognitoOptions_cognitoOptions_UserPoolId;
                requestCognitoOptionsIsNull = false;
            }
             // determine if request.CognitoOptions should be set to null
            if (requestCognitoOptionsIsNull)
            {
                request.CognitoOptions = null;
            }
            
             // populate DomainEndpointOptions
            var requestDomainEndpointOptionsIsNull = true;
            request.DomainEndpointOptions = new Amazon.OpenSearchService.Model.DomainEndpointOptions();
            System.String requestDomainEndpointOptions_domainEndpointOptions_CustomEndpoint = null;
            if (cmdletContext.DomainEndpointOptions_CustomEndpoint != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_CustomEndpoint = cmdletContext.DomainEndpointOptions_CustomEndpoint;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_CustomEndpoint != null)
            {
                request.DomainEndpointOptions.CustomEndpoint = requestDomainEndpointOptions_domainEndpointOptions_CustomEndpoint;
                requestDomainEndpointOptionsIsNull = false;
            }
            System.String requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointCertificateArn = null;
            if (cmdletContext.DomainEndpointOptions_CustomEndpointCertificateArn != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointCertificateArn = cmdletContext.DomainEndpointOptions_CustomEndpointCertificateArn;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointCertificateArn != null)
            {
                request.DomainEndpointOptions.CustomEndpointCertificateArn = requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointCertificateArn;
                requestDomainEndpointOptionsIsNull = false;
            }
            System.Boolean? requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointEnabled = null;
            if (cmdletContext.DomainEndpointOptions_CustomEndpointEnabled != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointEnabled = cmdletContext.DomainEndpointOptions_CustomEndpointEnabled.Value;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointEnabled != null)
            {
                request.DomainEndpointOptions.CustomEndpointEnabled = requestDomainEndpointOptions_domainEndpointOptions_CustomEndpointEnabled.Value;
                requestDomainEndpointOptionsIsNull = false;
            }
            System.Boolean? requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS = null;
            if (cmdletContext.DomainEndpointOptions_EnforceHTTPS != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS = cmdletContext.DomainEndpointOptions_EnforceHTTPS.Value;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS != null)
            {
                request.DomainEndpointOptions.EnforceHTTPS = requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS.Value;
                requestDomainEndpointOptionsIsNull = false;
            }
            Amazon.OpenSearchService.TLSSecurityPolicy requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy = null;
            if (cmdletContext.DomainEndpointOptions_TLSSecurityPolicy != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy = cmdletContext.DomainEndpointOptions_TLSSecurityPolicy;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy != null)
            {
                request.DomainEndpointOptions.TLSSecurityPolicy = requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy;
                requestDomainEndpointOptionsIsNull = false;
            }
             // determine if request.DomainEndpointOptions should be set to null
            if (requestDomainEndpointOptionsIsNull)
            {
                request.DomainEndpointOptions = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.DryRunMode != null)
            {
                request.DryRunMode = cmdletContext.DryRunMode;
            }
            
             // populate EBSOptions
            var requestEBSOptionsIsNull = true;
            request.EBSOptions = new Amazon.OpenSearchService.Model.EBSOptions();
            System.Boolean? requestEBSOptions_eBSOptions_EBSEnabled = null;
            if (cmdletContext.EBSOptions_EBSEnabled != null)
            {
                requestEBSOptions_eBSOptions_EBSEnabled = cmdletContext.EBSOptions_EBSEnabled.Value;
            }
            if (requestEBSOptions_eBSOptions_EBSEnabled != null)
            {
                request.EBSOptions.EBSEnabled = requestEBSOptions_eBSOptions_EBSEnabled.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_Iops = null;
            if (cmdletContext.EBSOptions_Iops != null)
            {
                requestEBSOptions_eBSOptions_Iops = cmdletContext.EBSOptions_Iops.Value;
            }
            if (requestEBSOptions_eBSOptions_Iops != null)
            {
                request.EBSOptions.Iops = requestEBSOptions_eBSOptions_Iops.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_Throughput = null;
            if (cmdletContext.EBSOptions_Throughput != null)
            {
                requestEBSOptions_eBSOptions_Throughput = cmdletContext.EBSOptions_Throughput.Value;
            }
            if (requestEBSOptions_eBSOptions_Throughput != null)
            {
                request.EBSOptions.Throughput = requestEBSOptions_eBSOptions_Throughput.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_VolumeSize = null;
            if (cmdletContext.EBSOptions_VolumeSize != null)
            {
                requestEBSOptions_eBSOptions_VolumeSize = cmdletContext.EBSOptions_VolumeSize.Value;
            }
            if (requestEBSOptions_eBSOptions_VolumeSize != null)
            {
                request.EBSOptions.VolumeSize = requestEBSOptions_eBSOptions_VolumeSize.Value;
                requestEBSOptionsIsNull = false;
            }
            Amazon.OpenSearchService.VolumeType requestEBSOptions_eBSOptions_VolumeType = null;
            if (cmdletContext.EBSOptions_VolumeType != null)
            {
                requestEBSOptions_eBSOptions_VolumeType = cmdletContext.EBSOptions_VolumeType;
            }
            if (requestEBSOptions_eBSOptions_VolumeType != null)
            {
                request.EBSOptions.VolumeType = requestEBSOptions_eBSOptions_VolumeType;
                requestEBSOptionsIsNull = false;
            }
             // determine if request.EBSOptions should be set to null
            if (requestEBSOptionsIsNull)
            {
                request.EBSOptions = null;
            }
            
             // populate EncryptionAtRestOptions
            var requestEncryptionAtRestOptionsIsNull = true;
            request.EncryptionAtRestOptions = new Amazon.OpenSearchService.Model.EncryptionAtRestOptions();
            System.Boolean? requestEncryptionAtRestOptions_encryptionAtRestOptions_Enabled = null;
            if (cmdletContext.EncryptionAtRestOptions_Enabled != null)
            {
                requestEncryptionAtRestOptions_encryptionAtRestOptions_Enabled = cmdletContext.EncryptionAtRestOptions_Enabled.Value;
            }
            if (requestEncryptionAtRestOptions_encryptionAtRestOptions_Enabled != null)
            {
                request.EncryptionAtRestOptions.Enabled = requestEncryptionAtRestOptions_encryptionAtRestOptions_Enabled.Value;
                requestEncryptionAtRestOptionsIsNull = false;
            }
            System.String requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyId = null;
            if (cmdletContext.EncryptionAtRestOptions_KmsKeyId != null)
            {
                requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyId = cmdletContext.EncryptionAtRestOptions_KmsKeyId;
            }
            if (requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyId != null)
            {
                request.EncryptionAtRestOptions.KmsKeyId = requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyId;
                requestEncryptionAtRestOptionsIsNull = false;
            }
             // determine if request.EncryptionAtRestOptions should be set to null
            if (requestEncryptionAtRestOptionsIsNull)
            {
                request.EncryptionAtRestOptions = null;
            }
            if (cmdletContext.IPAddressType != null)
            {
                request.IPAddressType = cmdletContext.IPAddressType;
            }
            if (cmdletContext.LogPublishingOption != null)
            {
                request.LogPublishingOptions = cmdletContext.LogPublishingOption;
            }
            
             // populate NodeToNodeEncryptionOptions
            var requestNodeToNodeEncryptionOptionsIsNull = true;
            request.NodeToNodeEncryptionOptions = new Amazon.OpenSearchService.Model.NodeToNodeEncryptionOptions();
            System.Boolean? requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled = null;
            if (cmdletContext.NodeToNodeEncryptionOptions_Enabled != null)
            {
                requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled = cmdletContext.NodeToNodeEncryptionOptions_Enabled.Value;
            }
            if (requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled != null)
            {
                request.NodeToNodeEncryptionOptions.Enabled = requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled.Value;
                requestNodeToNodeEncryptionOptionsIsNull = false;
            }
             // determine if request.NodeToNodeEncryptionOptions should be set to null
            if (requestNodeToNodeEncryptionOptionsIsNull)
            {
                request.NodeToNodeEncryptionOptions = null;
            }
            
             // populate OffPeakWindowOptions
            var requestOffPeakWindowOptionsIsNull = true;
            request.OffPeakWindowOptions = new Amazon.OpenSearchService.Model.OffPeakWindowOptions();
            System.Boolean? requestOffPeakWindowOptions_offPeakWindowOptions_Enabled = null;
            if (cmdletContext.OffPeakWindowOptions_Enabled != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_Enabled = cmdletContext.OffPeakWindowOptions_Enabled.Value;
            }
            if (requestOffPeakWindowOptions_offPeakWindowOptions_Enabled != null)
            {
                request.OffPeakWindowOptions.Enabled = requestOffPeakWindowOptions_offPeakWindowOptions_Enabled.Value;
                requestOffPeakWindowOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.OffPeakWindow requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow = null;
            
             // populate OffPeakWindow
            var requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindowIsNull = true;
            requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow = new Amazon.OpenSearchService.Model.OffPeakWindow();
            Amazon.OpenSearchService.Model.WindowStartTime requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime = null;
            
             // populate WindowStartTime
            var requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTimeIsNull = true;
            requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime = new Amazon.OpenSearchService.Model.WindowStartTime();
            System.Int64? requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Hour = null;
            if (cmdletContext.WindowStartTime_Hour != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Hour = cmdletContext.WindowStartTime_Hour.Value;
            }
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Hour != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime.Hours = requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Hour.Value;
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTimeIsNull = false;
            }
            System.Int64? requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Minute = null;
            if (cmdletContext.WindowStartTime_Minute != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Minute = cmdletContext.WindowStartTime_Minute.Value;
            }
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Minute != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime.Minutes = requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime_windowStartTime_Minute.Value;
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTimeIsNull = false;
            }
             // determine if requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime should be set to null
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTimeIsNull)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime = null;
            }
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime != null)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow.WindowStartTime = requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow_offPeakWindowOptions_OffPeakWindow_WindowStartTime;
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindowIsNull = false;
            }
             // determine if requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow should be set to null
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindowIsNull)
            {
                requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow = null;
            }
            if (requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow != null)
            {
                request.OffPeakWindowOptions.OffPeakWindow = requestOffPeakWindowOptions_offPeakWindowOptions_OffPeakWindow;
                requestOffPeakWindowOptionsIsNull = false;
            }
             // determine if request.OffPeakWindowOptions should be set to null
            if (requestOffPeakWindowOptionsIsNull)
            {
                request.OffPeakWindowOptions = null;
            }
            
             // populate SnapshotOptions
            var requestSnapshotOptionsIsNull = true;
            request.SnapshotOptions = new Amazon.OpenSearchService.Model.SnapshotOptions();
            System.Int32? requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = null;
            if (cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour != null)
            {
                requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour.Value;
            }
            if (requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour != null)
            {
                request.SnapshotOptions.AutomatedSnapshotStartHour = requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour.Value;
                requestSnapshotOptionsIsNull = false;
            }
             // determine if request.SnapshotOptions should be set to null
            if (requestSnapshotOptionsIsNull)
            {
                request.SnapshotOptions = null;
            }
            
             // populate SoftwareUpdateOptions
            var requestSoftwareUpdateOptionsIsNull = true;
            request.SoftwareUpdateOptions = new Amazon.OpenSearchService.Model.SoftwareUpdateOptions();
            System.Boolean? requestSoftwareUpdateOptions_softwareUpdateOptions_AutoSoftwareUpdateEnabled = null;
            if (cmdletContext.SoftwareUpdateOptions_AutoSoftwareUpdateEnabled != null)
            {
                requestSoftwareUpdateOptions_softwareUpdateOptions_AutoSoftwareUpdateEnabled = cmdletContext.SoftwareUpdateOptions_AutoSoftwareUpdateEnabled.Value;
            }
            if (requestSoftwareUpdateOptions_softwareUpdateOptions_AutoSoftwareUpdateEnabled != null)
            {
                request.SoftwareUpdateOptions.AutoSoftwareUpdateEnabled = requestSoftwareUpdateOptions_softwareUpdateOptions_AutoSoftwareUpdateEnabled.Value;
                requestSoftwareUpdateOptionsIsNull = false;
            }
             // determine if request.SoftwareUpdateOptions should be set to null
            if (requestSoftwareUpdateOptionsIsNull)
            {
                request.SoftwareUpdateOptions = null;
            }
            
             // populate VPCOptions
            var requestVPCOptionsIsNull = true;
            request.VPCOptions = new Amazon.OpenSearchService.Model.VPCOptions();
            List<System.String> requestVPCOptions_vPCOptions_SecurityGroupId = null;
            if (cmdletContext.VPCOptions_SecurityGroupId != null)
            {
                requestVPCOptions_vPCOptions_SecurityGroupId = cmdletContext.VPCOptions_SecurityGroupId;
            }
            if (requestVPCOptions_vPCOptions_SecurityGroupId != null)
            {
                request.VPCOptions.SecurityGroupIds = requestVPCOptions_vPCOptions_SecurityGroupId;
                requestVPCOptionsIsNull = false;
            }
            List<System.String> requestVPCOptions_vPCOptions_SubnetId = null;
            if (cmdletContext.VPCOptions_SubnetId != null)
            {
                requestVPCOptions_vPCOptions_SubnetId = cmdletContext.VPCOptions_SubnetId;
            }
            if (requestVPCOptions_vPCOptions_SubnetId != null)
            {
                request.VPCOptions.SubnetIds = requestVPCOptions_vPCOptions_SubnetId;
                requestVPCOptionsIsNull = false;
            }
             // determine if request.VPCOptions should be set to null
            if (requestVPCOptionsIsNull)
            {
                request.VPCOptions = null;
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
        
        private Amazon.OpenSearchService.Model.UpdateDomainConfigResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.UpdateDomainConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "UpdateDomainConfig");
            try
            {
                #if DESKTOP
                return client.UpdateDomainConfig(request);
                #elif CORECLR
                return client.UpdateDomainConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessPolicy { get; set; }
            public Dictionary<System.String, System.String> AdvancedOption { get; set; }
            public System.Boolean? AdvancedSecurityOptions_AnonymousAuthEnabled { get; set; }
            public System.Boolean? AdvancedSecurityOptions_Enabled { get; set; }
            public System.Boolean? AdvancedSecurityOptions_InternalUserDatabaseEnabled { get; set; }
            public System.Boolean? JWTOptions_Enabled { get; set; }
            public System.String JWTOptions_PublicKey { get; set; }
            public System.String JWTOptions_RolesKey { get; set; }
            public System.String JWTOptions_SubjectKey { get; set; }
            public System.String MasterUserOptions_MasterUserARN { get; set; }
            public System.String MasterUserOptions_MasterUserName { get; set; }
            public System.String MasterUserOptions_MasterUserPassword { get; set; }
            public System.Boolean? SAMLOptions_Enabled { get; set; }
            public System.String Idp_EntityId { get; set; }
            public System.String Idp_MetadataContent { get; set; }
            public System.String SAMLOptions_MasterBackendRole { get; set; }
            public System.String SAMLOptions_MasterUserName { get; set; }
            public System.String SAMLOptions_RolesKey { get; set; }
            public System.Int32? SAMLOptions_SessionTimeoutMinute { get; set; }
            public System.String SAMLOptions_SubjectKey { get; set; }
            public Amazon.OpenSearchService.NaturalLanguageQueryGenerationDesiredState NaturalLanguageQueryGenerationOptions_DesiredState { get; set; }
            public Amazon.OpenSearchService.AutoTuneDesiredState AutoTuneOptions_DesiredState { get; set; }
            public List<Amazon.OpenSearchService.Model.AutoTuneMaintenanceSchedule> AutoTuneOptions_MaintenanceSchedule { get; set; }
            public Amazon.OpenSearchService.RollbackOnDisable AutoTuneOptions_RollbackOnDisable { get; set; }
            public System.Boolean? AutoTuneOptions_UseOffPeakWindow { get; set; }
            public System.Boolean? ColdStorageOptions_Enabled { get; set; }
            public System.Int32? ClusterConfig_DedicatedMasterCount { get; set; }
            public System.Boolean? ClusterConfig_DedicatedMasterEnabled { get; set; }
            public Amazon.OpenSearchService.OpenSearchPartitionInstanceType ClusterConfig_DedicatedMasterType { get; set; }
            public System.Int32? ClusterConfig_InstanceCount { get; set; }
            public Amazon.OpenSearchService.OpenSearchPartitionInstanceType ClusterConfig_InstanceType { get; set; }
            public System.Boolean? ClusterConfig_MultiAZWithStandbyEnabled { get; set; }
            public System.Int32? ClusterConfig_WarmCount { get; set; }
            public System.Boolean? ClusterConfig_WarmEnabled { get; set; }
            public Amazon.OpenSearchService.OpenSearchWarmPartitionInstanceType ClusterConfig_WarmType { get; set; }
            public System.Int32? ZoneAwarenessConfig_AvailabilityZoneCount { get; set; }
            public System.Boolean? ClusterConfig_ZoneAwarenessEnabled { get; set; }
            public System.Boolean? CognitoOptions_Enabled { get; set; }
            public System.String CognitoOptions_IdentityPoolId { get; set; }
            public System.String CognitoOptions_RoleArn { get; set; }
            public System.String CognitoOptions_UserPoolId { get; set; }
            public System.String DomainEndpointOptions_CustomEndpoint { get; set; }
            public System.String DomainEndpointOptions_CustomEndpointCertificateArn { get; set; }
            public System.Boolean? DomainEndpointOptions_CustomEndpointEnabled { get; set; }
            public System.Boolean? DomainEndpointOptions_EnforceHTTPS { get; set; }
            public Amazon.OpenSearchService.TLSSecurityPolicy DomainEndpointOptions_TLSSecurityPolicy { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.OpenSearchService.DryRunMode DryRunMode { get; set; }
            public System.Boolean? EBSOptions_EBSEnabled { get; set; }
            public System.Int32? EBSOptions_Iops { get; set; }
            public System.Int32? EBSOptions_Throughput { get; set; }
            public System.Int32? EBSOptions_VolumeSize { get; set; }
            public Amazon.OpenSearchService.VolumeType EBSOptions_VolumeType { get; set; }
            public System.Boolean? EncryptionAtRestOptions_Enabled { get; set; }
            public System.String EncryptionAtRestOptions_KmsKeyId { get; set; }
            public Amazon.OpenSearchService.IPAddressType IPAddressType { get; set; }
            public Dictionary<System.String, Amazon.OpenSearchService.Model.LogPublishingOption> LogPublishingOption { get; set; }
            public System.Boolean? NodeToNodeEncryptionOptions_Enabled { get; set; }
            public System.Boolean? OffPeakWindowOptions_Enabled { get; set; }
            public System.Int64? WindowStartTime_Hour { get; set; }
            public System.Int64? WindowStartTime_Minute { get; set; }
            public System.Int32? SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
            public System.Boolean? SoftwareUpdateOptions_AutoSoftwareUpdateEnabled { get; set; }
            public List<System.String> VPCOptions_SecurityGroupId { get; set; }
            public List<System.String> VPCOptions_SubnetId { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.UpdateDomainConfigResponse, UpdateOSDomainConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainConfig;
        }
        
    }
}
