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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Modifies the replication instance to apply new settings. You can change one or more
    /// parameters by specifying these parameters and the new values in the request.
    /// 
    ///  
    /// <para>
    /// Some settings are applied during the maintenance window.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "DMSReplicationInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationInstance")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyReplicationInstance API operation.", Operation = new[] {"ModifyReplicationInstance"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationInstance or Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationInstance object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditDMSReplicationInstanceCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage (in gigabytes) to be allocated for the replication instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Indicates that major version upgrades are allowed. Changing this parameter does not
        /// result in an outage, and the change is asynchronously applied as soon as possible.</para><para>This parameter must be set to <c>true</c> when specifying a value for the <c>EngineVersion</c>
        /// parameter that is a different major version than the replication instance's current
        /// version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowMajorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Indicates whether the changes should be applied immediately or during the next maintenance
        /// window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>A value that indicates that minor version upgrades are applied automatically to the
        /// replication instance during the maintenance window. Changing this parameter doesn't
        /// result in an outage, except in the case described following. The change is asynchronously
        /// applied as soon as possible. </para><para>An outage does result if these factors apply: </para><ul><li><para>This parameter is set to <c>true</c> during the maintenance window.</para></li><li><para>A newer minor version is available. </para></li><li><para>DMS has enabled automatic patching for the given engine version. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version number of the replication instance.</para><para>When modifying a major engine version of an instance, also set <c>AllowMajorVersionUpgrade</c>
        /// to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter KerberosAuthenticationSettings_KeyCacheSecretIamArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the IAM role that grants Amazon Web Services
        /// DMS access to the secret containing key cache file for the kerberos authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAuthenticationSettings_KeyCacheSecretIamArn { get; set; }
        #endregion
        
        #region Parameter KerberosAuthenticationSettings_KeyCacheSecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the secret that stores the key cache file required for kerberos
        /// authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAuthenticationSettings_KeyCacheSecretId { get; set; }
        #endregion
        
        #region Parameter KerberosAuthenticationSettings_Krb5FileContent
        /// <summary>
        /// <para>
        /// <para>Specifies the contents of krb5 configuration file required for kerberos authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KerberosAuthenticationSettings_Krb5FileContents")]
        public System.String KerberosAuthenticationSettings_Krb5FileContent { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para> Specifies whether the replication instance is a Multi-AZ deployment. You can't set
        /// the <c>AvailabilityZone</c> parameter if the Multi-AZ parameter is set to <c>true</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The type of IP address protocol used by a replication instance, such as IPv4 only
        /// or Dual-stack that supports both IPv4 and IPv6 addressing. IPv6 only is not yet supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, which might
        /// result in an outage. Changing this parameter does not result in an outage, except
        /// in the following situation, and the change is asynchronously applied as soon as possible.
        /// If moving this window to the current time, there must be at least 30 minutes between
        /// the current time and end of the window to ensure pending changes are applied.</para><para>Default: Uses existing setting</para><para>Format: ddd:hh24:mi-ddd:hh24:mi</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Must be at least 30 minutes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication instance.</para>
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
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the replication instance as defined for the specified
        /// replication instance class. For example to specify the instance class dms.c4.large,
        /// set this parameter to <c>"dms.c4.large"</c>.</para><para>For more information on the settings and capacities for the available replication
        /// instance classes, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_ReplicationInstance.html#CHAP_ReplicationInstance.InDepth">
        /// Selecting the right DMS replication instance for your migration</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationInstanceClass { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The replication instance identifier. This parameter is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para> Specifies the VPC security group to be used with the replication instance. The VPC
        /// security group must work with the VPC containing the replication instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationInstance";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSReplicationInstance (ModifyReplicationInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse, EditDMSReplicationInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllocatedStorage = this.AllocatedStorage;
            context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            context.ApplyImmediately = this.ApplyImmediately;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.EngineVersion = this.EngineVersion;
            context.KerberosAuthenticationSettings_KeyCacheSecretIamArn = this.KerberosAuthenticationSettings_KeyCacheSecretIamArn;
            context.KerberosAuthenticationSettings_KeyCacheSecretId = this.KerberosAuthenticationSettings_KeyCacheSecretId;
            context.KerberosAuthenticationSettings_Krb5FileContent = this.KerberosAuthenticationSettings_Krb5FileContent;
            context.MultiAZ = this.MultiAZ;
            context.NetworkType = this.NetworkType;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            #if MODULAR
            if (this.ReplicationInstanceArn == null && ParameterWasBound(nameof(this.ReplicationInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationInstanceClass = this.ReplicationInstanceClass;
            context.ReplicationInstanceIdentifier = this.ReplicationInstanceIdentifier;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceRequest();
            
            if (cmdletContext.AllocatedStorage != null)
            {
                request.AllocatedStorage = cmdletContext.AllocatedStorage.Value;
            }
            if (cmdletContext.AllowMajorVersionUpgrade != null)
            {
                request.AllowMajorVersionUpgrade = cmdletContext.AllowMajorVersionUpgrade.Value;
            }
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            
             // populate KerberosAuthenticationSettings
            var requestKerberosAuthenticationSettingsIsNull = true;
            request.KerberosAuthenticationSettings = new Amazon.DatabaseMigrationService.Model.KerberosAuthenticationSettings();
            System.String requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretIamArn = null;
            if (cmdletContext.KerberosAuthenticationSettings_KeyCacheSecretIamArn != null)
            {
                requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretIamArn = cmdletContext.KerberosAuthenticationSettings_KeyCacheSecretIamArn;
            }
            if (requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretIamArn != null)
            {
                request.KerberosAuthenticationSettings.KeyCacheSecretIamArn = requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretIamArn;
                requestKerberosAuthenticationSettingsIsNull = false;
            }
            System.String requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretId = null;
            if (cmdletContext.KerberosAuthenticationSettings_KeyCacheSecretId != null)
            {
                requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretId = cmdletContext.KerberosAuthenticationSettings_KeyCacheSecretId;
            }
            if (requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretId != null)
            {
                request.KerberosAuthenticationSettings.KeyCacheSecretId = requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_KeyCacheSecretId;
                requestKerberosAuthenticationSettingsIsNull = false;
            }
            System.String requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_Krb5FileContent = null;
            if (cmdletContext.KerberosAuthenticationSettings_Krb5FileContent != null)
            {
                requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_Krb5FileContent = cmdletContext.KerberosAuthenticationSettings_Krb5FileContent;
            }
            if (requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_Krb5FileContent != null)
            {
                request.KerberosAuthenticationSettings.Krb5FileContents = requestKerberosAuthenticationSettings_kerberosAuthenticationSettings_Krb5FileContent;
                requestKerberosAuthenticationSettingsIsNull = false;
            }
             // determine if request.KerberosAuthenticationSettings should be set to null
            if (requestKerberosAuthenticationSettingsIsNull)
            {
                request.KerberosAuthenticationSettings = null;
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.ReplicationInstanceArn != null)
            {
                request.ReplicationInstanceArn = cmdletContext.ReplicationInstanceArn;
            }
            if (cmdletContext.ReplicationInstanceClass != null)
            {
                request.ReplicationInstanceClass = cmdletContext.ReplicationInstanceClass;
            }
            if (cmdletContext.ReplicationInstanceIdentifier != null)
            {
                request.ReplicationInstanceIdentifier = cmdletContext.ReplicationInstanceIdentifier;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyReplicationInstance");
            try
            {
                return client.ModifyReplicationInstanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KerberosAuthenticationSettings_KeyCacheSecretIamArn { get; set; }
            public System.String KerberosAuthenticationSettings_KeyCacheSecretId { get; set; }
            public System.String KerberosAuthenticationSettings_Krb5FileContent { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NetworkType { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.String ReplicationInstanceClass { get; set; }
            public System.String ReplicationInstanceIdentifier { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ModifyReplicationInstanceResponse, EditDMSReplicationInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationInstance;
        }
        
    }
}
