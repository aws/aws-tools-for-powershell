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
    /// Updates a connection. In Amazon DataZone, a connection enables you to connect your
    /// resources (domains, projects, and environments) to external resources and services.
    /// </summary>
    [Cmdlet("Update", "DZConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateConnectionResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateConnection API operation.", Operation = new[] {"UpdateConnection"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateConnectionResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateConnectionResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateConnectionResponse object containing multiple properties."
    )]
    public partial class UpdateDZConnectionCmdlet : AmazonDataZoneClientCmdlet, IExecutor
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
        
        #region Parameter AwsLocation_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsLocation_AwsAccountId { get; set; }
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
        /// <para>The compute ARN in the Spark EMR properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_ComputeArn")]
        public System.String SparkEmrProperties_ComputeArn { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_ConnectionProperty
        /// <summary>
        /// <para>
        /// <para>The properties of the Amazon Web Services Glue connection patch.</para><para />
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
        
        #region Parameter RedshiftProperties_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name in the Amazon Redshift properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_RedshiftProperties_DatabaseName")]
        public System.String RedshiftProperties_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GlueConnectionInput_Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon Web Services Glue connection patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_GlueProperties_GlueConnectionInput_Description")]
        public System.String GlueConnectionInput_Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where a connection is to be updated.</para>
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
        
        #region Parameter RedshiftProperties_Host
        /// <summary>
        /// <para>
        /// <para>The host in the Amazon Redshift properties patch.</para>
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
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID of the connection to be updated.</para>
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
        
        #region Parameter SparkEmrProperties_InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The instance profile ARN in the Spark EMR properties patch.</para>
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
        /// <para>The Java virtual evn in the Spark EMR properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_JavaVirtualEnv")]
        public System.String SparkEmrProperties_JavaVirtualEnv { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_LogUri
        /// <summary>
        /// <para>
        /// <para>The log URI in the Spark EMR properties patch.</para>
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
        /// <para>The port in the Amazon Redshift properties patch.</para>
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
        
        #region Parameter SparkEmrProperties_PythonVirtualEnv
        /// <summary>
        /// <para>
        /// <para>The Python virtual env in the Spark EMR properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_PythonVirtualEnv")]
        public System.String SparkEmrProperties_PythonVirtualEnv { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_RuntimeRole
        /// <summary>
        /// <para>
        /// <para>The runtime role in the Spark EMR properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_RuntimeRole")]
        public System.String SparkEmrProperties_RuntimeRole { get; set; }
        #endregion
        
        #region Parameter S3Properties_S3AccessGrantLocationId
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 Access Grant location ID that's part of the Amazon S3 properties patch
        /// of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_S3Properties_S3AccessGrantLocationId")]
        public System.String S3Properties_S3AccessGrantLocationId { get; set; }
        #endregion
        
        #region Parameter S3Properties_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI that's part of the Amazon S3 properties patch of a connection.</para>
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
        
        #region Parameter MlflowProperties_TrackingServerArn
        /// <summary>
        /// <para>
        /// <para>The tracking server ARN as part of the MLflow properties of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_MlflowProperties_TrackingServerArn")]
        public System.String MlflowProperties_TrackingServerArn { get; set; }
        #endregion
        
        #region Parameter MlflowProperties_TrackingServerName
        /// <summary>
        /// <para>
        /// <para>The name of the tracking server as part of the MLflow properties of a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_MlflowProperties_TrackingServerName")]
        public System.String MlflowProperties_TrackingServerName { get; set; }
        #endregion
        
        #region Parameter SparkEmrProperties_TrustedCertificatesS3Uri
        /// <summary>
        /// <para>
        /// <para>The trusted certificates S3 URI in the Spark EMR properties patch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Props_SparkEmrProperties_TrustedCertificatesS3Uri")]
        public System.String SparkEmrProperties_TrustedCertificatesS3Uri { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateConnectionResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateConnectionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZConnection (UpdateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateConnectionResponse, UpdateDZConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsLocation_AccessRole = this.AwsLocation_AccessRole;
            context.AwsLocation_AwsAccountId = this.AwsLocation_AwsAccountId;
            context.AwsLocation_AwsRegion = this.AwsLocation_AwsRegion;
            context.AwsLocation_IamConnectionId = this.AwsLocation_IamConnectionId;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmazonQProperties_AuthMode = this.AmazonQProperties_AuthMode;
            context.AmazonQProperties_IsEnabled = this.AmazonQProperties_IsEnabled;
            context.AmazonQProperties_ProfileArn = this.AmazonQProperties_ProfileArn;
            context.AthenaProperties_WorkgroupName = this.AthenaProperties_WorkgroupName;
            context.BasicAuthenticationCredentials_Password = this.BasicAuthenticationCredentials_Password;
            context.BasicAuthenticationCredentials_UserName = this.BasicAuthenticationCredentials_UserName;
            context.AuthenticationConfiguration_SecretArn = this.AuthenticationConfiguration_SecretArn;
            if (this.GlueConnectionInput_ConnectionProperty != null)
            {
                context.GlueConnectionInput_ConnectionProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueConnectionInput_ConnectionProperty.Keys)
                {
                    context.GlueConnectionInput_ConnectionProperty.Add((String)hashKey, (System.String)(this.GlueConnectionInput_ConnectionProperty[hashKey]));
                }
            }
            context.GlueConnectionInput_Description = this.GlueConnectionInput_Description;
            context.IamProperties_GlueLineageSyncEnabled = this.IamProperties_GlueLineageSyncEnabled;
            context.MlflowProperties_TrackingServerArn = this.MlflowProperties_TrackingServerArn;
            context.MlflowProperties_TrackingServerName = this.MlflowProperties_TrackingServerName;
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
            var request = new Amazon.DataZone.Model.UpdateConnectionRequest();
            
            
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate Props
            var requestPropsIsNull = true;
            request.Props = new Amazon.DataZone.Model.ConnectionPropertiesPatch();
            Amazon.DataZone.Model.AthenaPropertiesPatch requestProps_props_AthenaProperties = null;
            
             // populate AthenaProperties
            var requestProps_props_AthenaPropertiesIsNull = true;
            requestProps_props_AthenaProperties = new Amazon.DataZone.Model.AthenaPropertiesPatch();
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
            Amazon.DataZone.Model.GluePropertiesPatch requestProps_props_GlueProperties = null;
            
             // populate GlueProperties
            var requestProps_props_GluePropertiesIsNull = true;
            requestProps_props_GlueProperties = new Amazon.DataZone.Model.GluePropertiesPatch();
            Amazon.DataZone.Model.GlueConnectionPatch requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput = null;
            
             // populate GlueConnectionInput
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInputIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput = new Amazon.DataZone.Model.GlueConnectionPatch();
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
            Amazon.DataZone.Model.AuthenticationConfigurationPatch requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfigurationIsNull = true;
            requestProps_props_GlueProperties_props_GlueProperties_GlueConnectionInput_props_GlueProperties_GlueConnectionInput_AuthenticationConfiguration = new Amazon.DataZone.Model.AuthenticationConfigurationPatch();
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
            Amazon.DataZone.Model.IamPropertiesPatch requestProps_props_IamProperties = null;
            
             // populate IamProperties
            var requestProps_props_IamPropertiesIsNull = true;
            requestProps_props_IamProperties = new Amazon.DataZone.Model.IamPropertiesPatch();
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
            Amazon.DataZone.Model.MlflowPropertiesPatch requestProps_props_MlflowProperties = null;
            
             // populate MlflowProperties
            var requestProps_props_MlflowPropertiesIsNull = true;
            requestProps_props_MlflowProperties = new Amazon.DataZone.Model.MlflowPropertiesPatch();
            System.String requestProps_props_MlflowProperties_mlflowProperties_TrackingServerArn = null;
            if (cmdletContext.MlflowProperties_TrackingServerArn != null)
            {
                requestProps_props_MlflowProperties_mlflowProperties_TrackingServerArn = cmdletContext.MlflowProperties_TrackingServerArn;
            }
            if (requestProps_props_MlflowProperties_mlflowProperties_TrackingServerArn != null)
            {
                requestProps_props_MlflowProperties.TrackingServerArn = requestProps_props_MlflowProperties_mlflowProperties_TrackingServerArn;
                requestProps_props_MlflowPropertiesIsNull = false;
            }
            System.String requestProps_props_MlflowProperties_mlflowProperties_TrackingServerName = null;
            if (cmdletContext.MlflowProperties_TrackingServerName != null)
            {
                requestProps_props_MlflowProperties_mlflowProperties_TrackingServerName = cmdletContext.MlflowProperties_TrackingServerName;
            }
            if (requestProps_props_MlflowProperties_mlflowProperties_TrackingServerName != null)
            {
                requestProps_props_MlflowProperties.TrackingServerName = requestProps_props_MlflowProperties_mlflowProperties_TrackingServerName;
                requestProps_props_MlflowPropertiesIsNull = false;
            }
             // determine if requestProps_props_MlflowProperties should be set to null
            if (requestProps_props_MlflowPropertiesIsNull)
            {
                requestProps_props_MlflowProperties = null;
            }
            if (requestProps_props_MlflowProperties != null)
            {
                request.Props.MlflowProperties = requestProps_props_MlflowProperties;
                requestPropsIsNull = false;
            }
            Amazon.DataZone.Model.S3PropertiesPatch requestProps_props_S3Properties = null;
            
             // populate S3Properties
            var requestProps_props_S3PropertiesIsNull = true;
            requestProps_props_S3Properties = new Amazon.DataZone.Model.S3PropertiesPatch();
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
            Amazon.DataZone.Model.AmazonQPropertiesPatch requestProps_props_AmazonQProperties = null;
            
             // populate AmazonQProperties
            var requestProps_props_AmazonQPropertiesIsNull = true;
            requestProps_props_AmazonQProperties = new Amazon.DataZone.Model.AmazonQPropertiesPatch();
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
            Amazon.DataZone.Model.RedshiftPropertiesPatch requestProps_props_RedshiftProperties = null;
            
             // populate RedshiftProperties
            var requestProps_props_RedshiftPropertiesIsNull = true;
            requestProps_props_RedshiftProperties = new Amazon.DataZone.Model.RedshiftPropertiesPatch();
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
            Amazon.DataZone.Model.SparkEmrPropertiesPatch requestProps_props_SparkEmrProperties = null;
            
             // populate SparkEmrProperties
            var requestProps_props_SparkEmrPropertiesIsNull = true;
            requestProps_props_SparkEmrProperties = new Amazon.DataZone.Model.SparkEmrPropertiesPatch();
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
             // determine if request.Props should be set to null
            if (requestPropsIsNull)
            {
                request.Props = null;
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
        
        private Amazon.DataZone.Model.UpdateConnectionResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateConnection");
            try
            {
                return client.UpdateConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public System.String AmazonQProperties_AuthMode { get; set; }
            public System.Boolean? AmazonQProperties_IsEnabled { get; set; }
            public System.String AmazonQProperties_ProfileArn { get; set; }
            public System.String AthenaProperties_WorkgroupName { get; set; }
            public System.String BasicAuthenticationCredentials_Password { get; set; }
            public System.String BasicAuthenticationCredentials_UserName { get; set; }
            public System.String AuthenticationConfiguration_SecretArn { get; set; }
            public Dictionary<System.String, System.String> GlueConnectionInput_ConnectionProperty { get; set; }
            public System.String GlueConnectionInput_Description { get; set; }
            public System.Boolean? IamProperties_GlueLineageSyncEnabled { get; set; }
            public System.String MlflowProperties_TrackingServerArn { get; set; }
            public System.String MlflowProperties_TrackingServerName { get; set; }
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
            public System.Func<Amazon.DataZone.Model.UpdateConnectionResponse, UpdateDZConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
