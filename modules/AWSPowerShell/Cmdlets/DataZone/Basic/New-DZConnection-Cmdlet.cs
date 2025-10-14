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
    /// Creates a new connection. In Amazon DataZone, a connection enables you to connect
    /// your resources (domains, projects, and environments) to external resources and services.
    /// </summary>
    [Cmdlet("New", "DZConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateConnectionResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateConnection API operation.", Operation = new[] {"CreateConnection"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateConnectionResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateConnectionResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateConnectionResponse object containing multiple properties."
    )]
    public partial class NewDZConnectionCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsLocation_AccessRole
        /// <summary>
        /// <para>
        /// <para>The access role of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsLocation_AccessRole { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_AccessToken
        /// <summary>
        /// <para>
        /// <para>The access token of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_AccessToken")]
        public System.String OAuth2Credentials_AccessToken { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_AthenaProperty
        /// <summary>
        /// <para>
        /// <para>The Amazon Athena properties of the Amazon Web Services Glue connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AthenaProperties")]
        public System.Collections.Hashtable GlueConnectionInput_AthenaProperty { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication type of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_AuthenticationType")]
        [AWSConstantClassSource("Amazon.DataZone.AuthenticationType")]
        public Amazon.DataZone.AuthenticationType AuthenticationConfiguration_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter AmazonQProperties_AuthMode
        /// <summary>
        /// <para>
        /// <para>The authentication mode of the connection's Amazon Q properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_AmazonQProperties_AuthMode")]
        public System.String AmazonQProperties_AuthMode { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeProperties_AuthorizationCode
        /// <summary>
        /// <para>
        /// <para>The authorization code of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode")]
        public System.String AuthorizationCodeProperties_AuthorizationCode { get; set; }
        #endregion
        
        #region Parameter PhysicalConnectionRequirements_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The availability zone of the physical connection requirements of a connection. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_AvailabilityZone")]
        public System.String PhysicalConnectionRequirements_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AwsLocation_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsLocation_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientApplication_AWSManagedClientApplicationReference
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services managed client application reference in the OAuth2Client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_AWSManagedClientApplicationReference")]
        public System.String OAuth2ClientApplication_AWSManagedClientApplicationReference { get; set; }
        #endregion
        
        #region Parameter AwsLocation_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The Region of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsLocation_AwsRegion { get; set; }
        #endregion
        
        #region Parameter HyperPodProperties_ClusterName
        /// <summary>
        /// <para>
        /// <para>The cluster name the hyper pod properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_HyperPodProperties_ClusterName")]
        public System.String HyperPodProperties_ClusterName { get; set; }
        #endregion
        
        #region Parameter Storage_ClusterName
        /// <summary>
        /// <para>
        /// <para>The cluster name in the Amazon Redshift storage properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Storage_ClusterName")]
        public System.String Storage_ClusterName { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_ComputeArn
        /// <summary>
        /// <para>
        /// <para>The compute ARN of Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_ComputeArn")]
        public System.String SparkEmrProperties_ComputeArn { get; set; }
        #endregion
        
        #region Parameter AdditionalArgs_Connection
        /// <summary>
        /// <para>
        /// <para>The connection in the Spark Amazon Web Services Glue args.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_AdditionalArgs_Connection")]
        public System.String AdditionalArgs_Connection { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_ConnectionProperty
        /// <summary>
        /// <para>
        /// <para>The connection properties of the Amazon Web Services Glue connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_ConnectionProperties")]
        public System.Collections.Hashtable GlueConnectionInput_ConnectionProperty { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_ConnectionType
        /// <summary>
        /// <para>
        /// <para>The connection type of the Amazon Web Services Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_ConnectionType")]
        [AWSConstantClassSource("Amazon.DataZone.GlueConnectionType")]
        public Amazon.DataZone.GlueConnectionType GlueConnectionInput_ConnectionType { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_CustomAuthenticationCredential
        /// <summary>
        /// <para>
        /// <para>The custom authentication credentials of a connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_CustomAuthenticationCredentials")]
        public System.Collections.Hashtable AuthenticationConfiguration_CustomAuthenticationCredential { get; set; }
        #endregion
        
        #region Parameter RedshiftProperties_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The Amazon Redshift database name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_DatabaseName")]
        public System.String RedshiftProperties_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A connection description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon Web Services Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_Description")]
        public System.String GlueConnectionInput_Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where the connection is created.</para>
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
        
        #region Parameter LineageSync_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the Amaon Redshift lineage sync configuration is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_LineageSync_Enabled")]
        public System.Boolean? LineageSync_Enabled { get; set; }
        #endregion
        
        #region Parameter EnableTrustedIdentityPropagation
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trusted identity propagation is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTrustedIdentityPropagation { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the environment where the connection is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_GlueConnectionName
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Glue connection name in the Spark Amazon Web Services Glue
        /// properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_GlueConnectionName")]
        public System.String SparkGlueProperties_GlueConnectionName { get; set; }
        #endregion
        
        #region Parameter IamProperties_GlueLineageSyncEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Web Services Glue lineage sync is enabled for a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_IamProperties_GlueLineageSyncEnabled")]
        public System.Boolean? IamProperties_GlueLineageSyncEnabled { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_GlueVersion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Glue version in the Spark Amazon Web Services Glue properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_GlueVersion")]
        public System.String SparkGlueProperties_GlueVersion { get; set; }
        #endregion
        
        #region Parameter RedshiftProperties_Host
        /// <summary>
        /// <para>
        /// <para>The Amazon Redshift host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Host")]
        public System.String RedshiftProperties_Host { get; set; }
        #endregion
        
        #region Parameter AwsLocation_IamConnectionId
        /// <summary>
        /// <para>
        /// <para>The IAM connection ID of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsLocation_IamConnectionId { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_IdleTimeout
        /// <summary>
        /// <para>
        /// <para>The idle timeout in the Spark Amazon Web Services Glue properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_IdleTimeout")]
        public System.Int32? SparkGlueProperties_IdleTimeout { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The instance profile ARN of Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_InstanceProfileArn")]
        public System.String SparkEmrProperties_InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter AmazonQProperties_IsEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Q is enabled for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_AmazonQProperties_IsEnabled")]
        public System.Boolean? AmazonQProperties_IsEnabled { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_JavaVirtualEnv
        /// <summary>
        /// <para>
        /// <para>The java virtual env of the Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_JavaVirtualEnv")]
        public System.String SparkEmrProperties_JavaVirtualEnv { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_JavaVirtualEnv
        /// <summary>
        /// <para>
        /// <para>The Java virtual env in the Spark Amazon Web Services Glue properties. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_JavaVirtualEnv")]
        public System.String SparkGlueProperties_JavaVirtualEnv { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_JwtToken
        /// <summary>
        /// <para>
        /// <para>The jwt token of the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_JwtToken")]
        public System.String OAuth2Credentials_JwtToken { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_KmsKeyArn")]
        public System.String AuthenticationConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_LogUri
        /// <summary>
        /// <para>
        /// <para>The log URI of the Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_LogUri")]
        public System.String SparkEmrProperties_LogUri { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_ManagedEndpointArn
        /// <summary>
        /// <para>
        /// <para>The managed endpoint ARN of the EMR on EKS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_ManagedEndpointArn")]
        public System.String SparkEmrProperties_ManagedEndpointArn { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_MatchCriterion
        /// <summary>
        /// <para>
        /// <para>The match criteria of the Amazon Web Services Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_MatchCriteria")]
        public System.String GlueConnectionInput_MatchCriterion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The connection name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_Name")]
        public System.String GlueConnectionInput_Name { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of workers in the Spark Amazon Web Services Glue properties. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_NumberOfWorkers")]
        public System.Int32? SparkGlueProperties_NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_OAuth2GrantType
        /// <summary>
        /// <para>
        /// <para>The OAuth2 grant type of the OAuth2 properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2GrantType")]
        [AWSConstantClassSource("Amazon.DataZone.OAuth2GrantType")]
        public Amazon.DataZone.OAuth2GrantType OAuth2Properties_OAuth2GrantType { get; set; }
        #endregion
        
        #region Parameter BasicAuthenticationCredentials_Password
        /// <summary>
        /// <para>
        /// <para>The password for a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_Password")]
        public System.String BasicAuthenticationCredentials_Password { get; set; }
        #endregion
        
        #region Parameter UsernamePassword_Password
        /// <summary>
        /// <para>
        /// <para>The password of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Credentials_UsernamePassword_Password")]
        public System.String UsernamePassword_Password { get; set; }
        #endregion
        
        #region Parameter RedshiftProperties_Port
        /// <summary>
        /// <para>
        /// <para>The Amaon Redshift port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Port")]
        public System.Int32? RedshiftProperties_Port { get; set; }
        #endregion
        
        #region Parameter AmazonQProperties_ProfileArn
        /// <summary>
        /// <para>
        /// <para>The profile ARN of the connection's Amazon Q properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_AmazonQProperties_ProfileArn")]
        public System.String AmazonQProperties_ProfileArn { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_PythonProperty
        /// <summary>
        /// <para>
        /// <para>The Python properties of the Amazon Web Services Glue connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_PythonProperties")]
        public System.Collections.Hashtable GlueConnectionInput_PythonProperty { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_PythonVirtualEnv
        /// <summary>
        /// <para>
        /// <para>The Python virtual env of the Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_PythonVirtualEnv")]
        public System.String SparkEmrProperties_PythonVirtualEnv { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_PythonVirtualEnv
        /// <summary>
        /// <para>
        /// <para>The Python virtual env in the Spark Amazon Web Services Glue properties. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_PythonVirtualEnv")]
        public System.String SparkGlueProperties_PythonVirtualEnv { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeProperties_RedirectUri
        /// <summary>
        /// <para>
        /// <para>The redirect URI of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri")]
        public System.String AuthorizationCodeProperties_RedirectUri { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_RefreshToken
        /// <summary>
        /// <para>
        /// <para>The refresh token of the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_RefreshToken")]
        public System.String OAuth2Credentials_RefreshToken { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_RuntimeRole
        /// <summary>
        /// <para>
        /// <para>The runtime role of the Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_RuntimeRole")]
        public System.String SparkEmrProperties_RuntimeRole { get; set; }
        #endregion
        
        #region Parameter S3Properties_S3AccessGrantLocationId
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 Access Grant location ID that's part of the Amazon S3 properties of
        /// a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_S3Properties_S3AccessGrantLocationId")]
        public System.String S3Properties_S3AccessGrantLocationId { get; set; }
        #endregion
        
        #region Parameter S3Properties_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI that's part of the Amazon S3 properties of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_S3Properties_S3Uri")]
        public System.String S3Properties_S3Uri { get; set; }
        #endregion
        
        #region Parameter Schedule_Schedule
        /// <summary>
        /// <para>
        /// <para>The lineage sync schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_LineageSync_Schedule_Schedule")]
        public System.String Schedule_Schedule { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The scope of the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.ConnectionScope")]
        public Amazon.DataZone.ConnectionScope Scope { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The secret ARN of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_SecretArn")]
        public System.String AuthenticationConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter Credentials_SecretArn
        /// <summary>
        /// <para>
        /// <para>The secret ARN of the Amazon Redshift credentials of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Credentials_SecretArn")]
        public System.String Credentials_SecretArn { get; set; }
        #endregion
        
        #region Parameter PhysicalConnectionRequirements_SecurityGroupIdList
        /// <summary>
        /// <para>
        /// <para>The group ID list of the physical connection requirements of a connection. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_SecurityGroupIdList")]
        public System.String[] PhysicalConnectionRequirements_SecurityGroupIdList { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_SparkProperty
        /// <summary>
        /// <para>
        /// <para>The Spark properties of the Amazon Web Services Glue connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_SparkProperties")]
        public System.Collections.Hashtable GlueConnectionInput_SparkProperty { get; set; }
        #endregion
        
        #region Parameter PhysicalConnectionRequirements_SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet ID of the physical connection requirements of a connection. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_SubnetId")]
        public System.String PhysicalConnectionRequirements_SubnetId { get; set; }
        #endregion
        
        #region Parameter PhysicalConnectionRequirements_SubnetIdList
        /// <summary>
        /// <para>
        /// <para>The subnet ID list of the physical connection requirements of a connection. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_SubnetIdList")]
        public System.String[] PhysicalConnectionRequirements_SubnetIdList { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_TokenUrl
        /// <summary>
        /// <para>
        /// <para>The OAuth2 token URL of the OAuth2 properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_TokenUrl")]
        public System.String OAuth2Properties_TokenUrl { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_TokenUrlParametersMap
        /// <summary>
        /// <para>
        /// <para>The OAuth2 token URL parameter map of the OAuth2 properties.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_TokenUrlParametersMap")]
        public System.Collections.Hashtable OAuth2Properties_TokenUrlParametersMap { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_TrustedCertificatesS3Uri
        /// <summary>
        /// <para>
        /// <para>The certificates S3 URI of the Spark EMR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_TrustedCertificatesS3Uri")]
        public System.String SparkEmrProperties_TrustedCertificatesS3Uri { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientApplication_UserManagedClientApplicationClientId
        /// <summary>
        /// <para>
        /// <para>The user managed client application client ID in the OAuth2Client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_UserManagedClientApplicationClientId")]
        public System.String OAuth2ClientApplication_UserManagedClientApplicationClientId { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_UserManagedClientApplicationClientSecret
        /// <summary>
        /// <para>
        /// <para>The user managed client application client secret of the connection. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_UserManagedClientApplicationClientSecret")]
        public System.String OAuth2Credentials_UserManagedClientApplicationClientSecret { get; set; }
        #endregion
        
        #region Parameter UsernamePassword_Username
        /// <summary>
        /// <para>
        /// <para>The username of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Credentials_UsernamePassword_Username")]
        public System.String UsernamePassword_Username { get; set; }
        #endregion
        
        #region Parameter BasicAuthenticationCredentials_UserName
        /// <summary>
        /// <para>
        /// <para>The user name for the connecion.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_UserName")]
        public System.String BasicAuthenticationCredentials_UserName { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_ValidateCredential
        /// <summary>
        /// <para>
        /// <para>Speciefies whether to validate credentials of the Amazon Web Services Glue connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_ValidateCredentials")]
        public System.Boolean? GlueConnectionInput_ValidateCredential { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_ValidateForComputeEnvironment
        /// <summary>
        /// <para>
        /// <para>Speciefies whether to validate for compute environments of the Amazon Web Services
        /// Glue connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_ValidateForComputeEnvironments")]
        public System.String[] GlueConnectionInput_ValidateForComputeEnvironment { get; set; }
        #endregion
        
        #region Parameter SparkGlueProperties_WorkerType
        /// <summary>
        /// <para>
        /// <para>The worker type in the Spark Amazon Web Services Glue properties. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkGlueProperties_WorkerType")]
        public System.String SparkGlueProperties_WorkerType { get; set; }
        #endregion
        
        #region Parameter AthenaProperties_WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The Amazon Athena workgroup name of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_AthenaProperties_WorkgroupName")]
        public System.String AthenaProperties_WorkgroupName { get; set; }
        #endregion
        
        #region Parameter Storage_WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The workgroup name in the Amazon Redshift storage properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_Storage_WorkgroupName")]
        public System.String Storage_WorkgroupName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateConnectionResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateConnectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZConnection (CreateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateConnectionResponse, NewDZConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsLocation_AccessRole = this.AwsLocation_AccessRole;
            context.AwsLocation_AwsAccountId = this.AwsLocation_AwsAccountId;
            context.AwsLocation_AwsRegion = this.AwsLocation_AwsRegion;
            context.AwsLocation_IamConnectionId = this.AwsLocation_IamConnectionId;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableTrustedIdentityPropagation = this.EnableTrustedIdentityPropagation;
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmazonQProperties_AuthMode = this.AmazonQProperties_AuthMode;
            context.AmazonQProperties_IsEnabled = this.AmazonQProperties_IsEnabled;
            context.AmazonQProperties_ProfileArn = this.AmazonQProperties_ProfileArn;
            context.AthenaProperties_WorkgroupName = this.AthenaProperties_WorkgroupName;
            if (this.GlueConnectionInput_AthenaProperty != null)
            {
                context.GlueConnectionInput_AthenaProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueConnectionInput_AthenaProperty.Keys)
                {
                    context.GlueConnectionInput_AthenaProperty.Add((String)hashKey, (System.String)(this.GlueConnectionInput_AthenaProperty[hashKey]));
                }
            }
            context.AuthenticationConfiguration_AuthenticationType = this.AuthenticationConfiguration_AuthenticationType;
            context.BasicAuthenticationCredentials_Password = this.BasicAuthenticationCredentials_Password;
            context.BasicAuthenticationCredentials_UserName = this.BasicAuthenticationCredentials_UserName;
            if (this.AuthenticationConfiguration_CustomAuthenticationCredential != null)
            {
                context.AuthenticationConfiguration_CustomAuthenticationCredential = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuthenticationConfiguration_CustomAuthenticationCredential.Keys)
                {
                    context.AuthenticationConfiguration_CustomAuthenticationCredential.Add((String)hashKey, (System.String)(this.AuthenticationConfiguration_CustomAuthenticationCredential[hashKey]));
                }
            }
            context.AuthenticationConfiguration_KmsKeyArn = this.AuthenticationConfiguration_KmsKeyArn;
            context.AuthorizationCodeProperties_AuthorizationCode = this.AuthorizationCodeProperties_AuthorizationCode;
            context.AuthorizationCodeProperties_RedirectUri = this.AuthorizationCodeProperties_RedirectUri;
            context.OAuth2ClientApplication_AWSManagedClientApplicationReference = this.OAuth2ClientApplication_AWSManagedClientApplicationReference;
            context.OAuth2ClientApplication_UserManagedClientApplicationClientId = this.OAuth2ClientApplication_UserManagedClientApplicationClientId;
            context.OAuth2Credentials_AccessToken = this.OAuth2Credentials_AccessToken;
            context.OAuth2Credentials_JwtToken = this.OAuth2Credentials_JwtToken;
            context.OAuth2Credentials_RefreshToken = this.OAuth2Credentials_RefreshToken;
            context.OAuth2Credentials_UserManagedClientApplicationClientSecret = this.OAuth2Credentials_UserManagedClientApplicationClientSecret;
            context.OAuth2Properties_OAuth2GrantType = this.OAuth2Properties_OAuth2GrantType;
            context.OAuth2Properties_TokenUrl = this.OAuth2Properties_TokenUrl;
            if (this.OAuth2Properties_TokenUrlParametersMap != null)
            {
                context.OAuth2Properties_TokenUrlParametersMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OAuth2Properties_TokenUrlParametersMap.Keys)
                {
                    context.OAuth2Properties_TokenUrlParametersMap.Add((String)hashKey, (System.String)(this.OAuth2Properties_TokenUrlParametersMap[hashKey]));
                }
            }
            context.AuthenticationConfiguration_SecretArn = this.AuthenticationConfiguration_SecretArn;
            if (this.GlueConnectionInput_ConnectionProperty != null)
            {
                context.GlueConnectionInput_ConnectionProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueConnectionInput_ConnectionProperty.Keys)
                {
                    context.GlueConnectionInput_ConnectionProperty.Add((String)hashKey, (System.String)(this.GlueConnectionInput_ConnectionProperty[hashKey]));
                }
            }
            context.GlueConnectionInput_ConnectionType = this.GlueConnectionInput_ConnectionType;
            context.GlueConnectionInput_Description = this.GlueConnectionInput_Description;
            context.GlueConnectionInput_MatchCriterion = this.GlueConnectionInput_MatchCriterion;
            context.GlueConnectionInput_Name = this.GlueConnectionInput_Name;
            context.PhysicalConnectionRequirements_AvailabilityZone = this.PhysicalConnectionRequirements_AvailabilityZone;
            if (this.PhysicalConnectionRequirements_SecurityGroupIdList != null)
            {
                context.PhysicalConnectionRequirements_SecurityGroupIdList = new List<System.String>(this.PhysicalConnectionRequirements_SecurityGroupIdList);
            }
            context.PhysicalConnectionRequirements_SubnetId = this.PhysicalConnectionRequirements_SubnetId;
            if (this.PhysicalConnectionRequirements_SubnetIdList != null)
            {
                context.PhysicalConnectionRequirements_SubnetIdList = new List<System.String>(this.PhysicalConnectionRequirements_SubnetIdList);
            }
            if (this.GlueConnectionInput_PythonProperty != null)
            {
                context.GlueConnectionInput_PythonProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueConnectionInput_PythonProperty.Keys)
                {
                    context.GlueConnectionInput_PythonProperty.Add((String)hashKey, (System.String)(this.GlueConnectionInput_PythonProperty[hashKey]));
                }
            }
            if (this.GlueConnectionInput_SparkProperty != null)
            {
                context.GlueConnectionInput_SparkProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueConnectionInput_SparkProperty.Keys)
                {
                    context.GlueConnectionInput_SparkProperty.Add((String)hashKey, (System.String)(this.GlueConnectionInput_SparkProperty[hashKey]));
                }
            }
            context.GlueConnectionInput_ValidateCredential = this.GlueConnectionInput_ValidateCredential;
            if (this.GlueConnectionInput_ValidateForComputeEnvironment != null)
            {
                context.GlueConnectionInput_ValidateForComputeEnvironment = new List<System.String>(this.GlueConnectionInput_ValidateForComputeEnvironment);
            }
            context.HyperPodProperties_ClusterName = this.HyperPodProperties_ClusterName;
            context.IamProperties_GlueLineageSyncEnabled = this.IamProperties_GlueLineageSyncEnabled;
            context.Credentials_SecretArn = this.Credentials_SecretArn;
            context.UsernamePassword_Password = this.UsernamePassword_Password;
            context.UsernamePassword_Username = this.UsernamePassword_Username;
            context.RedshiftProperties_DatabaseName = this.RedshiftProperties_DatabaseName;
            context.RedshiftProperties_Host = this.RedshiftProperties_Host;
            context.LineageSync_Enabled = this.LineageSync_Enabled;
            context.Schedule_Schedule = this.Schedule_Schedule;
            context.RedshiftProperties_Port = this.RedshiftProperties_Port;
            context.Storage_ClusterName = this.Storage_ClusterName;
            context.Storage_WorkgroupName = this.Storage_WorkgroupName;
            context.S3Properties_S3AccessGrantLocationId = this.S3Properties_S3AccessGrantLocationId;
            context.S3Properties_S3Uri = this.S3Properties_S3Uri;
            context.SparkEmrProperties_ComputeArn = this.SparkEmrProperties_ComputeArn;
            context.SparkEmrProperties_InstanceProfileArn = this.SparkEmrProperties_InstanceProfileArn;
            context.SparkEmrProperties_JavaVirtualEnv = this.SparkEmrProperties_JavaVirtualEnv;
            context.SparkEmrProperties_LogUri = this.SparkEmrProperties_LogUri;
            context.SparkEmrProperties_ManagedEndpointArn = this.SparkEmrProperties_ManagedEndpointArn;
            context.SparkEmrProperties_PythonVirtualEnv = this.SparkEmrProperties_PythonVirtualEnv;
            context.SparkEmrProperties_RuntimeRole = this.SparkEmrProperties_RuntimeRole;
            context.SparkEmrProperties_TrustedCertificatesS3Uri = this.SparkEmrProperties_TrustedCertificatesS3Uri;
            context.AdditionalArgs_Connection = this.AdditionalArgs_Connection;
            context.SparkGlueProperties_GlueConnectionName = this.SparkGlueProperties_GlueConnectionName;
            context.SparkGlueProperties_GlueVersion = this.SparkGlueProperties_GlueVersion;
            context.SparkGlueProperties_IdleTimeout = this.SparkGlueProperties_IdleTimeout;
            context.SparkGlueProperties_JavaVirtualEnv = this.SparkGlueProperties_JavaVirtualEnv;
            context.SparkGlueProperties_NumberOfWorker = this.SparkGlueProperties_NumberOfWorker;
            context.SparkGlueProperties_PythonVirtualEnv = this.SparkGlueProperties_PythonVirtualEnv;
            context.SparkGlueProperties_WorkerType = this.SparkGlueProperties_WorkerType;
            context.Scope = this.Scope;
            
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
            var request = new Amazon.DataZone.Model.CreateConnectionRequest();
            
            
             // populate AwsLocation
            var requestAwsLocationIsNull = true;
            request.AwsLocation = new Amazon.DataZone.Model.AwsLocation();
            System.String requestAwsLocation_awsLocation_AccessRole = null;
            if (cmdletContext.AwsLocation_AccessRole != null)
            {
                requestAwsLocation_awsLocation_AccessRole = cmdletContext.AwsLocation_AccessRole;
            }
            if (requestAwsLocation_awsLocation_AccessRole != null)
            {
                request.AwsLocation.AccessRole = requestAwsLocation_awsLocation_AccessRole;
                requestAwsLocationIsNull = false;
            }
            System.String requestAwsLocation_awsLocation_AwsAccountId = null;
            if (cmdletContext.AwsLocation_AwsAccountId != null)
            {
                requestAwsLocation_awsLocation_AwsAccountId = cmdletContext.AwsLocation_AwsAccountId;
            }
            if (requestAwsLocation_awsLocation_AwsAccountId != null)
            {
                request.AwsLocation.AwsAccountId = requestAwsLocation_awsLocation_AwsAccountId;
                requestAwsLocationIsNull = false;
            }
            System.String requestAwsLocation_awsLocation_AwsRegion = null;
            if (cmdletContext.AwsLocation_AwsRegion != null)
            {
                requestAwsLocation_awsLocation_AwsRegion = cmdletContext.AwsLocation_AwsRegion;
            }
            if (requestAwsLocation_awsLocation_AwsRegion != null)
            {
                request.AwsLocation.AwsRegion = requestAwsLocation_awsLocation_AwsRegion;
                requestAwsLocationIsNull = false;
            }
            System.String requestAwsLocation_awsLocation_IamConnectionId = null;
            if (cmdletContext.AwsLocation_IamConnectionId != null)
            {
                requestAwsLocation_awsLocation_IamConnectionId = cmdletContext.AwsLocation_IamConnectionId;
            }
            if (requestAwsLocation_awsLocation_IamConnectionId != null)
            {
                request.AwsLocation.IamConnectionId = requestAwsLocation_awsLocation_IamConnectionId;
                requestAwsLocationIsNull = false;
            }
             // determine if request.AwsLocation should be set to null
            if (requestAwsLocationIsNull)
            {
                request.AwsLocation = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnableTrustedIdentityPropagation != null)
            {
                request.EnableTrustedIdentityPropagation = cmdletContext.EnableTrustedIdentityPropagation.Value;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Props
            var requestPropsIsNull = true;
            request.Props = new Amazon.DataZone.Model.ConnectionPropertiesInput();
            Amazon.DataZone.Model.AthenaPropertiesInput requestProps_props_AthenaProperties = null;
            
             // populate AthenaProperties
            var requestProps_props_AthenaPropertiesIsNull = true;
            requestProps_props_AthenaProperties = new Amazon.DataZone.Model.AthenaPropertiesInput();
            System.String requestProps_props_AthenaProperties_athenaProperties_WorkgroupName = null;
            if (cmdletContext.AthenaProperties_WorkgroupName != null)
            {
                requestProps_props_AthenaProperties_athenaProperties_WorkgroupName = cmdletContext.AthenaProperties_WorkgroupName;
            }
            if (requestProps_props_AthenaProperties_athenaProperties_WorkgroupName != null)
            {
                requestProps_props_AthenaProperties.WorkgroupName = requestProps_props_AthenaProperties_athenaProperties_WorkgroupName;
                requestProps_props_AthenaPropertiesIsNull = false;
            }
             // determine if requestProps_props_AthenaProperties should be set to null
            if (requestProps_props_AthenaPropertiesIsNull)
            {
                requestProps_props_AthenaProperties = null;
            }
            if (requestProps_props_AthenaProperties != null)
            {
                request.Props.AthenaProperties = requestProps_props_AthenaProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.GluePropertiesInput requestProps_props_GlueProperties = null;
            
             // populate GlueProperties
            var requestProps_props_GluePropertiesIsNull = true;
            requestProps_props_GlueProperties = new Amazon.DataZone.Model.GluePropertiesInput();
            Amazon.DataZone.Model.GlueConnectionInput requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput = null;
            
             // populate GlueConnectionInput
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput = new Amazon.DataZone.Model.GlueConnectionInput();
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_AthenaProperty = null;
            if (cmdletContext.GlueConnectionInput_AthenaProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_AthenaProperty = cmdletContext.GlueConnectionInput_AthenaProperty;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_AthenaProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.AthenaProperties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_AthenaProperty;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionProperty = null;
            if (cmdletContext.GlueConnectionInput_ConnectionProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionProperty = cmdletContext.GlueConnectionInput_ConnectionProperty;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.ConnectionProperties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionProperty;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Amazon.DataZone.GlueConnectionType requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionType = null;
            if (cmdletContext.GlueConnectionInput_ConnectionType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionType = cmdletContext.GlueConnectionInput_ConnectionType;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.ConnectionType = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ConnectionType;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Description = null;
            if (cmdletContext.GlueConnectionInput_Description != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Description = cmdletContext.GlueConnectionInput_Description;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Description != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.Description = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Description;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_MatchCriterion = null;
            if (cmdletContext.GlueConnectionInput_MatchCriterion != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_MatchCriterion = cmdletContext.GlueConnectionInput_MatchCriterion;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_MatchCriterion != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.MatchCriteria = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_MatchCriterion;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Name = null;
            if (cmdletContext.GlueConnectionInput_Name != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Name = cmdletContext.GlueConnectionInput_Name;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Name != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.Name = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_Name;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_PythonProperty = null;
            if (cmdletContext.GlueConnectionInput_PythonProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_PythonProperty = cmdletContext.GlueConnectionInput_PythonProperty;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_PythonProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.PythonProperties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_PythonProperty;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_SparkProperty = null;
            if (cmdletContext.GlueConnectionInput_SparkProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_SparkProperty = cmdletContext.GlueConnectionInput_SparkProperty;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_SparkProperty != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.SparkProperties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_SparkProperty;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            System.Boolean? requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateCredential = null;
            if (cmdletContext.GlueConnectionInput_ValidateCredential != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateCredential = cmdletContext.GlueConnectionInput_ValidateCredential.Value;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateCredential != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.ValidateCredentials = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateCredential.Value;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            List<System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateForComputeEnvironment = null;
            if (cmdletContext.GlueConnectionInput_ValidateForComputeEnvironment != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateForComputeEnvironment = cmdletContext.GlueConnectionInput_ValidateForComputeEnvironment;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateForComputeEnvironment != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.ValidateForComputeEnvironments = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_glueConnectionInput_ValidateForComputeEnvironment;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Amazon.DataZone.Model.PhysicalConnectionRequirements requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements = null;
            
             // populate PhysicalConnectionRequirements
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements = new Amazon.DataZone.Model.PhysicalConnectionRequirements();
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_AvailabilityZone = null;
            if (cmdletContext.PhysicalConnectionRequirements_AvailabilityZone != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_AvailabilityZone = cmdletContext.PhysicalConnectionRequirements_AvailabilityZone;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_AvailabilityZone != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements.AvailabilityZone = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_AvailabilityZone;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull = false;
            }
            List<System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SecurityGroupIdList = null;
            if (cmdletContext.PhysicalConnectionRequirements_SecurityGroupIdList != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SecurityGroupIdList = cmdletContext.PhysicalConnectionRequirements_SecurityGroupIdList;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SecurityGroupIdList != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements.SecurityGroupIdList = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SecurityGroupIdList;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetId = null;
            if (cmdletContext.PhysicalConnectionRequirements_SubnetId != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetId = cmdletContext.PhysicalConnectionRequirements_SubnetId;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetId != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements.SubnetId = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetId;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull = false;
            }
            List<System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetIdList = null;
            if (cmdletContext.PhysicalConnectionRequirements_SubnetIdList != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetIdList = cmdletContext.PhysicalConnectionRequirements_SubnetIdList;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetIdList != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements.SubnetIdList = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements_physicalConnectionRequirements_SubnetIdList;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirementsIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.PhysicalConnectionRequirements = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_PhysicalConnectionRequirements;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
            Amazon.DataZone.Model.AuthenticationConfigurationInput requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration = new Amazon.DataZone.Model.AuthenticationConfigurationInput();
            Amazon.DataZone.AuthenticationType requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType = null;
            if (cmdletContext.AuthenticationConfiguration_AuthenticationType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType = cmdletContext.AuthenticationConfiguration_AuthenticationType;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.AuthenticationType = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential = null;
            if (cmdletContext.AuthenticationConfiguration_CustomAuthenticationCredential != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential = cmdletContext.AuthenticationConfiguration_CustomAuthenticationCredential;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.CustomAuthenticationCredentials = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn = null;
            if (cmdletContext.AuthenticationConfiguration_KmsKeyArn != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn = cmdletContext.AuthenticationConfiguration_KmsKeyArn;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.KmsKeyArn = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn = null;
            if (cmdletContext.AuthenticationConfiguration_SecretArn != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn = cmdletContext.AuthenticationConfiguration_SecretArn;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.SecretArn = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.BasicAuthenticationCredentials requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = null;
            
             // populate BasicAuthenticationCredentials
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = new Amazon.DataZone.Model.BasicAuthenticationCredentials();
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password = null;
            if (cmdletContext.BasicAuthenticationCredentials_Password != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password = cmdletContext.BasicAuthenticationCredentials_Password;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials.Password = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_UserName = null;
            if (cmdletContext.BasicAuthenticationCredentials_UserName != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_UserName = cmdletContext.BasicAuthenticationCredentials_UserName;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_UserName != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials.UserName = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_UserName;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.BasicAuthenticationCredentials = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.OAuth2Properties requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties = null;
            
             // populate OAuth2Properties
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties = new Amazon.DataZone.Model.OAuth2Properties();
            Amazon.DataZone.OAuth2GrantType requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType = null;
            if (cmdletContext.OAuth2Properties_OAuth2GrantType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType = cmdletContext.OAuth2Properties_OAuth2GrantType;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2GrantType = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl = null;
            if (cmdletContext.OAuth2Properties_TokenUrl != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl = cmdletContext.OAuth2Properties_TokenUrl;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.TokenUrl = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Dictionary<System.String, System.String> requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap = null;
            if (cmdletContext.OAuth2Properties_TokenUrlParametersMap != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap = cmdletContext.OAuth2Properties_TokenUrlParametersMap;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.TokenUrlParametersMap = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.DataZone.Model.AuthorizationCodeProperties requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            
             // populate AuthorizationCodeProperties
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = new Amazon.DataZone.Model.AuthorizationCodeProperties();
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode = null;
            if (cmdletContext.AuthorizationCodeProperties_AuthorizationCode != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode = cmdletContext.AuthorizationCodeProperties_AuthorizationCode;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.AuthorizationCode = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri = null;
            if (cmdletContext.AuthorizationCodeProperties_RedirectUri != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri = cmdletContext.AuthorizationCodeProperties_RedirectUri;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.RedirectUri = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.AuthorizationCodeProperties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.DataZone.Model.OAuth2ClientApplication requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = null;
            
             // populate OAuth2ClientApplication
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = new Amazon.DataZone.Model.OAuth2ClientApplication();
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference = null;
            if (cmdletContext.OAuth2ClientApplication_AWSManagedClientApplicationReference != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference = cmdletContext.OAuth2ClientApplication_AWSManagedClientApplicationReference;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication.AWSManagedClientApplicationReference = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId = null;
            if (cmdletContext.OAuth2ClientApplication_UserManagedClientApplicationClientId != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId = cmdletContext.OAuth2ClientApplication_UserManagedClientApplicationClientId;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication.UserManagedClientApplicationClientId = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2ClientApplication = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.DataZone.Model.GlueOAuth2Credentials requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = null;
            
             // populate OAuth2Credentials
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = new Amazon.DataZone.Model.GlueOAuth2Credentials();
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken = null;
            if (cmdletContext.OAuth2Credentials_AccessToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken = cmdletContext.OAuth2Credentials_AccessToken;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.AccessToken = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken = null;
            if (cmdletContext.OAuth2Credentials_JwtToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken = cmdletContext.OAuth2Credentials_JwtToken;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.JwtToken = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken = null;
            if (cmdletContext.OAuth2Credentials_RefreshToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken = cmdletContext.OAuth2Credentials_RefreshToken;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.RefreshToken = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret = null;
            if (cmdletContext.OAuth2Credentials_UserManagedClientApplicationClientSecret != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret = cmdletContext.OAuth2Credentials_UserManagedClientApplicationClientSecret;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.UserManagedClientApplicationClientSecret = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2Credentials = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration.OAuth2Properties = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration_OAuth2Properties;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration != null)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput.AuthenticationConfiguration = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration;
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = false;
            }
             // determine if requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput should be set to null
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull)
            {
                requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput = null;
            }
            if (requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput != null)
            {
                requestProps_props_GlueProperties.GlueConnectionInput = requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput;
                requestProps_props_GluePropertiesIsNull = false;
            }
             // determine if requestProps_props_GlueProperties should be set to null
            if (requestProps_props_GluePropertiesIsNull)
            {
                requestProps_props_GlueProperties = null;
            }
            if (requestProps_props_GlueProperties != null)
            {
                request.Props.GlueProperties = requestProps_props_GlueProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.HyperPodPropertiesInput requestProps_props_HyperPodProperties = null;
            
             // populate HyperPodProperties
            var requestProps_props_HyperPodPropertiesIsNull = true;
            requestProps_props_HyperPodProperties = new Amazon.DataZone.Model.HyperPodPropertiesInput();
            System.String requestProps_props_HyperPodProperties_hyperPodProperties_ClusterName = null;
            if (cmdletContext.HyperPodProperties_ClusterName != null)
            {
                requestProps_props_HyperPodProperties_hyperPodProperties_ClusterName = cmdletContext.HyperPodProperties_ClusterName;
            }
            if (requestProps_props_HyperPodProperties_hyperPodProperties_ClusterName != null)
            {
                requestProps_props_HyperPodProperties.ClusterName = requestProps_props_HyperPodProperties_hyperPodProperties_ClusterName;
                requestProps_props_HyperPodPropertiesIsNull = false;
            }
             // determine if requestProps_props_HyperPodProperties should be set to null
            if (requestProps_props_HyperPodPropertiesIsNull)
            {
                requestProps_props_HyperPodProperties = null;
            }
            if (requestProps_props_HyperPodProperties != null)
            {
                request.Props.HyperPodProperties = requestProps_props_HyperPodProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.IamPropertiesInput requestProps_props_IamProperties = null;
            
             // populate IamProperties
            var requestProps_props_IamPropertiesIsNull = true;
            requestProps_props_IamProperties = new Amazon.DataZone.Model.IamPropertiesInput();
            System.Boolean? requestProps_props_IamProperties_iamProperties_GlueLineageSyncEnabled = null;
            if (cmdletContext.IamProperties_GlueLineageSyncEnabled != null)
            {
                requestProps_props_IamProperties_iamProperties_GlueLineageSyncEnabled = cmdletContext.IamProperties_GlueLineageSyncEnabled.Value;
            }
            if (requestProps_props_IamProperties_iamProperties_GlueLineageSyncEnabled != null)
            {
                requestProps_props_IamProperties.GlueLineageSyncEnabled = requestProps_props_IamProperties_iamProperties_GlueLineageSyncEnabled.Value;
                requestProps_props_IamPropertiesIsNull = false;
            }
             // determine if requestProps_props_IamProperties should be set to null
            if (requestProps_props_IamPropertiesIsNull)
            {
                requestProps_props_IamProperties = null;
            }
            if (requestProps_props_IamProperties != null)
            {
                request.Props.IamProperties = requestProps_props_IamProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.S3PropertiesInput requestProps_props_S3Properties = null;
            
             // populate S3Properties
            var requestProps_props_S3PropertiesIsNull = true;
            requestProps_props_S3Properties = new Amazon.DataZone.Model.S3PropertiesInput();
            System.String requestProps_props_S3Properties_s3Properties_S3AccessGrantLocationId = null;
            if (cmdletContext.S3Properties_S3AccessGrantLocationId != null)
            {
                requestProps_props_S3Properties_s3Properties_S3AccessGrantLocationId = cmdletContext.S3Properties_S3AccessGrantLocationId;
            }
            if (requestProps_props_S3Properties_s3Properties_S3AccessGrantLocationId != null)
            {
                requestProps_props_S3Properties.S3AccessGrantLocationId = requestProps_props_S3Properties_s3Properties_S3AccessGrantLocationId;
                requestProps_props_S3PropertiesIsNull = false;
            }
            System.String requestProps_props_S3Properties_s3Properties_S3Uri = null;
            if (cmdletContext.S3Properties_S3Uri != null)
            {
                requestProps_props_S3Properties_s3Properties_S3Uri = cmdletContext.S3Properties_S3Uri;
            }
            if (requestProps_props_S3Properties_s3Properties_S3Uri != null)
            {
                requestProps_props_S3Properties.S3Uri = requestProps_props_S3Properties_s3Properties_S3Uri;
                requestProps_props_S3PropertiesIsNull = false;
            }
             // determine if requestProps_props_S3Properties should be set to null
            if (requestProps_props_S3PropertiesIsNull)
            {
                requestProps_props_S3Properties = null;
            }
            if (requestProps_props_S3Properties != null)
            {
                request.Props.S3Properties = requestProps_props_S3Properties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.AmazonQPropertiesInput requestProps_props_AmazonQProperties = null;
            
             // populate AmazonQProperties
            var requestProps_props_AmazonQPropertiesIsNull = true;
            requestProps_props_AmazonQProperties = new Amazon.DataZone.Model.AmazonQPropertiesInput();
            System.String requestProps_props_AmazonQProperties_amazonQProperties_AuthMode = null;
            if (cmdletContext.AmazonQProperties_AuthMode != null)
            {
                requestProps_props_AmazonQProperties_amazonQProperties_AuthMode = cmdletContext.AmazonQProperties_AuthMode;
            }
            if (requestProps_props_AmazonQProperties_amazonQProperties_AuthMode != null)
            {
                requestProps_props_AmazonQProperties.AuthMode = requestProps_props_AmazonQProperties_amazonQProperties_AuthMode;
                requestProps_props_AmazonQPropertiesIsNull = false;
            }
            System.Boolean? requestProps_props_AmazonQProperties_amazonQProperties_IsEnabled = null;
            if (cmdletContext.AmazonQProperties_IsEnabled != null)
            {
                requestProps_props_AmazonQProperties_amazonQProperties_IsEnabled = cmdletContext.AmazonQProperties_IsEnabled.Value;
            }
            if (requestProps_props_AmazonQProperties_amazonQProperties_IsEnabled != null)
            {
                requestProps_props_AmazonQProperties.IsEnabled = requestProps_props_AmazonQProperties_amazonQProperties_IsEnabled.Value;
                requestProps_props_AmazonQPropertiesIsNull = false;
            }
            System.String requestProps_props_AmazonQProperties_amazonQProperties_ProfileArn = null;
            if (cmdletContext.AmazonQProperties_ProfileArn != null)
            {
                requestProps_props_AmazonQProperties_amazonQProperties_ProfileArn = cmdletContext.AmazonQProperties_ProfileArn;
            }
            if (requestProps_props_AmazonQProperties_amazonQProperties_ProfileArn != null)
            {
                requestProps_props_AmazonQProperties.ProfileArn = requestProps_props_AmazonQProperties_amazonQProperties_ProfileArn;
                requestProps_props_AmazonQPropertiesIsNull = false;
            }
             // determine if requestProps_props_AmazonQProperties should be set to null
            if (requestProps_props_AmazonQPropertiesIsNull)
            {
                requestProps_props_AmazonQProperties = null;
            }
            if (requestProps_props_AmazonQProperties != null)
            {
                request.Props.AmazonQProperties = requestProps_props_AmazonQProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftPropertiesInput requestProps_props_RedshiftProperties = null;
            
             // populate RedshiftProperties
            var requestProps_props_RedshiftPropertiesIsNull = true;
            requestProps_props_RedshiftProperties = new Amazon.DataZone.Model.RedshiftPropertiesInput();
            System.String requestProps_props_RedshiftProperties_redshiftProperties_DatabaseName = null;
            if (cmdletContext.RedshiftProperties_DatabaseName != null)
            {
                requestProps_props_RedshiftProperties_redshiftProperties_DatabaseName = cmdletContext.RedshiftProperties_DatabaseName;
            }
            if (requestProps_props_RedshiftProperties_redshiftProperties_DatabaseName != null)
            {
                requestProps_props_RedshiftProperties.DatabaseName = requestProps_props_RedshiftProperties_redshiftProperties_DatabaseName;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
            System.String requestProps_props_RedshiftProperties_redshiftProperties_Host = null;
            if (cmdletContext.RedshiftProperties_Host != null)
            {
                requestProps_props_RedshiftProperties_redshiftProperties_Host = cmdletContext.RedshiftProperties_Host;
            }
            if (requestProps_props_RedshiftProperties_redshiftProperties_Host != null)
            {
                requestProps_props_RedshiftProperties.Host = requestProps_props_RedshiftProperties_redshiftProperties_Host;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
            System.Int32? requestProps_props_RedshiftProperties_redshiftProperties_Port = null;
            if (cmdletContext.RedshiftProperties_Port != null)
            {
                requestProps_props_RedshiftProperties_redshiftProperties_Port = cmdletContext.RedshiftProperties_Port.Value;
            }
            if (requestProps_props_RedshiftProperties_redshiftProperties_Port != null)
            {
                requestProps_props_RedshiftProperties.Port = requestProps_props_RedshiftProperties_redshiftProperties_Port.Value;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftCredentials requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials = null;
            
             // populate Credentials
            var requestProps_props_RedshiftProperties_props_RedshiftProperties_CredentialsIsNull = true;
            requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials = new Amazon.DataZone.Model.RedshiftCredentials();
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_credentials_SecretArn = null;
            if (cmdletContext.Credentials_SecretArn != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_credentials_SecretArn = cmdletContext.Credentials_SecretArn;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_credentials_SecretArn != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials.SecretArn = requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_credentials_SecretArn;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_CredentialsIsNull = false;
            }
            Amazon.DataZone.Model.UsernamePassword requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword = null;
            
             // populate UsernamePassword
            var requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePasswordIsNull = true;
            requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword = new Amazon.DataZone.Model.UsernamePassword();
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Password = null;
            if (cmdletContext.UsernamePassword_Password != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Password = cmdletContext.UsernamePassword_Password;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Password != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword.Password = requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Password;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePasswordIsNull = false;
            }
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Username = null;
            if (cmdletContext.UsernamePassword_Username != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Username = cmdletContext.UsernamePassword_Username;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Username != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword.Username = requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword_usernamePassword_Username;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePasswordIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword should be set to null
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePasswordIsNull)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword = null;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials.UsernamePassword = requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials_props_RedshiftProperties_Credentials_UsernamePassword;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_CredentialsIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials should be set to null
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_CredentialsIsNull)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials = null;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials != null)
            {
                requestProps_props_RedshiftProperties.Credentials = requestProps_props_RedshiftProperties_props_RedshiftProperties_Credentials;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftLineageSyncConfigurationInput requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync = null;
            
             // populate LineageSync
            var requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSyncIsNull = true;
            requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync = new Amazon.DataZone.Model.RedshiftLineageSyncConfigurationInput();
            System.Boolean? requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_lineageSync_Enabled = null;
            if (cmdletContext.LineageSync_Enabled != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_lineageSync_Enabled = cmdletContext.LineageSync_Enabled.Value;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_lineageSync_Enabled != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync.Enabled = requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_lineageSync_Enabled.Value;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSyncIsNull = false;
            }
            Amazon.DataZone.Model.LineageSyncSchedule requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule = null;
            
             // populate Schedule
            var requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_ScheduleIsNull = true;
            requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule = new Amazon.DataZone.Model.LineageSyncSchedule();
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule_schedule_Schedule = null;
            if (cmdletContext.Schedule_Schedule != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule_schedule_Schedule = cmdletContext.Schedule_Schedule;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule_schedule_Schedule != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule.Schedule = requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule_schedule_Schedule;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_ScheduleIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule should be set to null
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_ScheduleIsNull)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule = null;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync.Schedule = requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync_props_RedshiftProperties_LineageSync_Schedule;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSyncIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync should be set to null
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSyncIsNull)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync = null;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync != null)
            {
                requestProps_props_RedshiftProperties.LineageSync = requestProps_props_RedshiftProperties_props_RedshiftProperties_LineageSync;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
            Amazon.DataZone.Model.RedshiftStorageProperties requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage = null;
            
             // populate Storage
            var requestProps_props_RedshiftProperties_props_RedshiftProperties_StorageIsNull = true;
            requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage = new Amazon.DataZone.Model.RedshiftStorageProperties();
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_ClusterName = null;
            if (cmdletContext.Storage_ClusterName != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_ClusterName = cmdletContext.Storage_ClusterName;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_ClusterName != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage.ClusterName = requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_ClusterName;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_StorageIsNull = false;
            }
            System.String requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_WorkgroupName = null;
            if (cmdletContext.Storage_WorkgroupName != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_WorkgroupName = cmdletContext.Storage_WorkgroupName;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_WorkgroupName != null)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage.WorkgroupName = requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage_storage_WorkgroupName;
                requestProps_props_RedshiftProperties_props_RedshiftProperties_StorageIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage should be set to null
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_StorageIsNull)
            {
                requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage = null;
            }
            if (requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage != null)
            {
                requestProps_props_RedshiftProperties.Storage = requestProps_props_RedshiftProperties_props_RedshiftProperties_Storage;
                requestProps_props_RedshiftPropertiesIsNull = false;
            }
             // determine if requestProps_props_RedshiftProperties should be set to null
            if (requestProps_props_RedshiftPropertiesIsNull)
            {
                requestProps_props_RedshiftProperties = null;
            }
            if (requestProps_props_RedshiftProperties != null)
            {
                request.Props.RedshiftProperties = requestProps_props_RedshiftProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.SparkEmrPropertiesInput requestProps_props_SparkEmrProperties = null;
            
             // populate SparkEmrProperties
            var requestProps_props_SparkEmrPropertiesIsNull = true;
            requestProps_props_SparkEmrProperties = new Amazon.DataZone.Model.SparkEmrPropertiesInput();
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_ComputeArn = null;
            if (cmdletContext.SparkEmrProperties_ComputeArn != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_ComputeArn = cmdletContext.SparkEmrProperties_ComputeArn;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_ComputeArn != null)
            {
                requestProps_props_SparkEmrProperties.ComputeArn = requestProps_props_SparkEmrProperties_sparkEmrProperties_ComputeArn;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_InstanceProfileArn = null;
            if (cmdletContext.SparkEmrProperties_InstanceProfileArn != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_InstanceProfileArn = cmdletContext.SparkEmrProperties_InstanceProfileArn;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_InstanceProfileArn != null)
            {
                requestProps_props_SparkEmrProperties.InstanceProfileArn = requestProps_props_SparkEmrProperties_sparkEmrProperties_InstanceProfileArn;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_JavaVirtualEnv = null;
            if (cmdletContext.SparkEmrProperties_JavaVirtualEnv != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_JavaVirtualEnv = cmdletContext.SparkEmrProperties_JavaVirtualEnv;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_JavaVirtualEnv != null)
            {
                requestProps_props_SparkEmrProperties.JavaVirtualEnv = requestProps_props_SparkEmrProperties_sparkEmrProperties_JavaVirtualEnv;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_LogUri = null;
            if (cmdletContext.SparkEmrProperties_LogUri != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_LogUri = cmdletContext.SparkEmrProperties_LogUri;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_LogUri != null)
            {
                requestProps_props_SparkEmrProperties.LogUri = requestProps_props_SparkEmrProperties_sparkEmrProperties_LogUri;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_ManagedEndpointArn = null;
            if (cmdletContext.SparkEmrProperties_ManagedEndpointArn != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_ManagedEndpointArn = cmdletContext.SparkEmrProperties_ManagedEndpointArn;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_ManagedEndpointArn != null)
            {
                requestProps_props_SparkEmrProperties.ManagedEndpointArn = requestProps_props_SparkEmrProperties_sparkEmrProperties_ManagedEndpointArn;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_PythonVirtualEnv = null;
            if (cmdletContext.SparkEmrProperties_PythonVirtualEnv != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_PythonVirtualEnv = cmdletContext.SparkEmrProperties_PythonVirtualEnv;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_PythonVirtualEnv != null)
            {
                requestProps_props_SparkEmrProperties.PythonVirtualEnv = requestProps_props_SparkEmrProperties_sparkEmrProperties_PythonVirtualEnv;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_RuntimeRole = null;
            if (cmdletContext.SparkEmrProperties_RuntimeRole != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_RuntimeRole = cmdletContext.SparkEmrProperties_RuntimeRole;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_RuntimeRole != null)
            {
                requestProps_props_SparkEmrProperties.RuntimeRole = requestProps_props_SparkEmrProperties_sparkEmrProperties_RuntimeRole;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
            System.String requestProps_props_SparkEmrProperties_sparkEmrProperties_TrustedCertificatesS3Uri = null;
            if (cmdletContext.SparkEmrProperties_TrustedCertificatesS3Uri != null)
            {
                requestProps_props_SparkEmrProperties_sparkEmrProperties_TrustedCertificatesS3Uri = cmdletContext.SparkEmrProperties_TrustedCertificatesS3Uri;
            }
            if (requestProps_props_SparkEmrProperties_sparkEmrProperties_TrustedCertificatesS3Uri != null)
            {
                requestProps_props_SparkEmrProperties.TrustedCertificatesS3Uri = requestProps_props_SparkEmrProperties_sparkEmrProperties_TrustedCertificatesS3Uri;
                requestProps_props_SparkEmrPropertiesIsNull = false;
            }
             // determine if requestProps_props_SparkEmrProperties should be set to null
            if (requestProps_props_SparkEmrPropertiesIsNull)
            {
                requestProps_props_SparkEmrProperties = null;
            }
            if (requestProps_props_SparkEmrProperties != null)
            {
                request.Props.SparkEmrProperties = requestProps_props_SparkEmrProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.SparkGluePropertiesInput requestProps_props_SparkGlueProperties = null;
            
             // populate SparkGlueProperties
            var requestProps_props_SparkGluePropertiesIsNull = true;
            requestProps_props_SparkGlueProperties = new Amazon.DataZone.Model.SparkGluePropertiesInput();
            System.String requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueConnectionName = null;
            if (cmdletContext.SparkGlueProperties_GlueConnectionName != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueConnectionName = cmdletContext.SparkGlueProperties_GlueConnectionName;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueConnectionName != null)
            {
                requestProps_props_SparkGlueProperties.GlueConnectionName = requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueConnectionName;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.String requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueVersion = null;
            if (cmdletContext.SparkGlueProperties_GlueVersion != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueVersion = cmdletContext.SparkGlueProperties_GlueVersion;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueVersion != null)
            {
                requestProps_props_SparkGlueProperties.GlueVersion = requestProps_props_SparkGlueProperties_sparkGlueProperties_GlueVersion;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.Int32? requestProps_props_SparkGlueProperties_sparkGlueProperties_IdleTimeout = null;
            if (cmdletContext.SparkGlueProperties_IdleTimeout != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_IdleTimeout = cmdletContext.SparkGlueProperties_IdleTimeout.Value;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_IdleTimeout != null)
            {
                requestProps_props_SparkGlueProperties.IdleTimeout = requestProps_props_SparkGlueProperties_sparkGlueProperties_IdleTimeout.Value;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.String requestProps_props_SparkGlueProperties_sparkGlueProperties_JavaVirtualEnv = null;
            if (cmdletContext.SparkGlueProperties_JavaVirtualEnv != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_JavaVirtualEnv = cmdletContext.SparkGlueProperties_JavaVirtualEnv;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_JavaVirtualEnv != null)
            {
                requestProps_props_SparkGlueProperties.JavaVirtualEnv = requestProps_props_SparkGlueProperties_sparkGlueProperties_JavaVirtualEnv;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.Int32? requestProps_props_SparkGlueProperties_sparkGlueProperties_NumberOfWorker = null;
            if (cmdletContext.SparkGlueProperties_NumberOfWorker != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_NumberOfWorker = cmdletContext.SparkGlueProperties_NumberOfWorker.Value;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_NumberOfWorker != null)
            {
                requestProps_props_SparkGlueProperties.NumberOfWorkers = requestProps_props_SparkGlueProperties_sparkGlueProperties_NumberOfWorker.Value;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.String requestProps_props_SparkGlueProperties_sparkGlueProperties_PythonVirtualEnv = null;
            if (cmdletContext.SparkGlueProperties_PythonVirtualEnv != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_PythonVirtualEnv = cmdletContext.SparkGlueProperties_PythonVirtualEnv;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_PythonVirtualEnv != null)
            {
                requestProps_props_SparkGlueProperties.PythonVirtualEnv = requestProps_props_SparkGlueProperties_sparkGlueProperties_PythonVirtualEnv;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            System.String requestProps_props_SparkGlueProperties_sparkGlueProperties_WorkerType = null;
            if (cmdletContext.SparkGlueProperties_WorkerType != null)
            {
                requestProps_props_SparkGlueProperties_sparkGlueProperties_WorkerType = cmdletContext.SparkGlueProperties_WorkerType;
            }
            if (requestProps_props_SparkGlueProperties_sparkGlueProperties_WorkerType != null)
            {
                requestProps_props_SparkGlueProperties.WorkerType = requestProps_props_SparkGlueProperties_sparkGlueProperties_WorkerType;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
            Amazon.DataZone.Model.SparkGlueArgs requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs = null;
            
             // populate AdditionalArgs
            var requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgsIsNull = true;
            requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs = new Amazon.DataZone.Model.SparkGlueArgs();
            System.String requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs_additionalArgs_Connection = null;
            if (cmdletContext.AdditionalArgs_Connection != null)
            {
                requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs_additionalArgs_Connection = cmdletContext.AdditionalArgs_Connection;
            }
            if (requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs_additionalArgs_Connection != null)
            {
                requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs.Connection = requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs_additionalArgs_Connection;
                requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgsIsNull = false;
            }
             // determine if requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs should be set to null
            if (requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgsIsNull)
            {
                requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs = null;
            }
            if (requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs != null)
            {
                requestProps_props_SparkGlueProperties.AdditionalArgs = requestProps_props_SparkGlueProperties_props_SparkGlueProperties_AdditionalArgs;
                requestProps_props_SparkGluePropertiesIsNull = false;
            }
             // determine if requestProps_props_SparkGlueProperties should be set to null
            if (requestProps_props_SparkGluePropertiesIsNull)
            {
                requestProps_props_SparkGlueProperties = null;
            }
            if (requestProps_props_SparkGlueProperties != null)
            {
                request.Props.SparkGlueProperties = requestProps_props_SparkGlueProperties;
                requestPropsIsNull = false;
            }
             // determine if request.Props should be set to null
            if (requestPropsIsNull)
            {
                request.Props = null;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
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
        
        private Amazon.DataZone.Model.CreateConnectionResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateConnection");
            try
            {
                return client.CreateConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsLocation_AccessRole { get; set; }
            public System.String AwsLocation_AwsAccountId { get; set; }
            public System.String AwsLocation_AwsRegion { get; set; }
            public System.String AwsLocation_IamConnectionId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.Boolean? EnableTrustedIdentityPropagation { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String AmazonQProperties_AuthMode { get; set; }
            public System.Boolean? AmazonQProperties_IsEnabled { get; set; }
            public System.String AmazonQProperties_ProfileArn { get; set; }
            public System.String AthenaProperties_WorkgroupName { get; set; }
            public Dictionary<System.String, System.String> GlueConnectionInput_AthenaProperty { get; set; }
            public Amazon.DataZone.AuthenticationType AuthenticationConfiguration_AuthenticationType { get; set; }
            public System.String BasicAuthenticationCredentials_Password { get; set; }
            public System.String BasicAuthenticationCredentials_UserName { get; set; }
            public Dictionary<System.String, System.String> AuthenticationConfiguration_CustomAuthenticationCredential { get; set; }
            public System.String AuthenticationConfiguration_KmsKeyArn { get; set; }
            public System.String AuthorizationCodeProperties_AuthorizationCode { get; set; }
            public System.String AuthorizationCodeProperties_RedirectUri { get; set; }
            public System.String OAuth2ClientApplication_AWSManagedClientApplicationReference { get; set; }
            public System.String OAuth2ClientApplication_UserManagedClientApplicationClientId { get; set; }
            public System.String OAuth2Credentials_AccessToken { get; set; }
            public System.String OAuth2Credentials_JwtToken { get; set; }
            public System.String OAuth2Credentials_RefreshToken { get; set; }
            public System.String OAuth2Credentials_UserManagedClientApplicationClientSecret { get; set; }
            public Amazon.DataZone.OAuth2GrantType OAuth2Properties_OAuth2GrantType { get; set; }
            public System.String OAuth2Properties_TokenUrl { get; set; }
            public Dictionary<System.String, System.String> OAuth2Properties_TokenUrlParametersMap { get; set; }
            public System.String AuthenticationConfiguration_SecretArn { get; set; }
            public Dictionary<System.String, System.String> GlueConnectionInput_ConnectionProperty { get; set; }
            public Amazon.DataZone.GlueConnectionType GlueConnectionInput_ConnectionType { get; set; }
            public System.String GlueConnectionInput_Description { get; set; }
            public System.String GlueConnectionInput_MatchCriterion { get; set; }
            public System.String GlueConnectionInput_Name { get; set; }
            public System.String PhysicalConnectionRequirements_AvailabilityZone { get; set; }
            public List<System.String> PhysicalConnectionRequirements_SecurityGroupIdList { get; set; }
            public System.String PhysicalConnectionRequirements_SubnetId { get; set; }
            public List<System.String> PhysicalConnectionRequirements_SubnetIdList { get; set; }
            public Dictionary<System.String, System.String> GlueConnectionInput_PythonProperty { get; set; }
            public Dictionary<System.String, System.String> GlueConnectionInput_SparkProperty { get; set; }
            public System.Boolean? GlueConnectionInput_ValidateCredential { get; set; }
            public List<System.String> GlueConnectionInput_ValidateForComputeEnvironment { get; set; }
            public System.String HyperPodProperties_ClusterName { get; set; }
            public System.Boolean? IamProperties_GlueLineageSyncEnabled { get; set; }
            public System.String Credentials_SecretArn { get; set; }
            public System.String UsernamePassword_Password { get; set; }
            public System.String UsernamePassword_Username { get; set; }
            public System.String RedshiftProperties_DatabaseName { get; set; }
            public System.String RedshiftProperties_Host { get; set; }
            public System.Boolean? LineageSync_Enabled { get; set; }
            public System.String Schedule_Schedule { get; set; }
            public System.Int32? RedshiftProperties_Port { get; set; }
            public System.String Storage_ClusterName { get; set; }
            public System.String Storage_WorkgroupName { get; set; }
            public System.String S3Properties_S3AccessGrantLocationId { get; set; }
            public System.String S3Properties_S3Uri { get; set; }
            public System.String SparkEmrProperties_ComputeArn { get; set; }
            public System.String SparkEmrProperties_InstanceProfileArn { get; set; }
            public System.String SparkEmrProperties_JavaVirtualEnv { get; set; }
            public System.String SparkEmrProperties_LogUri { get; set; }
            public System.String SparkEmrProperties_ManagedEndpointArn { get; set; }
            public System.String SparkEmrProperties_PythonVirtualEnv { get; set; }
            public System.String SparkEmrProperties_RuntimeRole { get; set; }
            public System.String SparkEmrProperties_TrustedCertificatesS3Uri { get; set; }
            public System.String AdditionalArgs_Connection { get; set; }
            public System.String SparkGlueProperties_GlueConnectionName { get; set; }
            public System.String SparkGlueProperties_GlueVersion { get; set; }
            public System.Int32? SparkGlueProperties_IdleTimeout { get; set; }
            public System.String SparkGlueProperties_JavaVirtualEnv { get; set; }
            public System.Int32? SparkGlueProperties_NumberOfWorker { get; set; }
            public System.String SparkGlueProperties_PythonVirtualEnv { get; set; }
            public System.String SparkGlueProperties_WorkerType { get; set; }
            public Amazon.DataZone.ConnectionScope Scope { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateConnectionResponse, NewDZConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
