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
using Amazon.Wickr;
using Amazon.Wickr.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Updates the properties of an existing security group in a Wickr network, such as its
    /// name or settings.
    /// </summary>
    [Cmdlet("Update", "WICSecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.SecurityGroup")]
    [AWSCmdlet("Calls the AWS Wickr Admin API UpdateSecurityGroup API operation.", Operation = new[] {"UpdateSecurityGroup"}, SelectReturnType = typeof(Amazon.Wickr.Model.UpdateSecurityGroupResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.SecurityGroup or Amazon.Wickr.Model.UpdateSecurityGroupResponse",
        "This cmdlet returns an Amazon.Wickr.Model.SecurityGroup object.",
        "The service call response (type Amazon.Wickr.Model.UpdateSecurityGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWICSecurityGroupCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SecurityGroupSettings_AlwaysReauthenticate
        /// <summary>
        /// <para>
        /// <para>Requires users to reauthenticate every time they return to the application, providing
        /// an additional layer of security.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_AlwaysReauthenticate { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_AtakPackageValue
        /// <summary>
        /// <para>
        /// <para>Configuration values for ATAK (Android Team Awareness Kit) package integration, when
        /// ATAK is enabled.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_AtakPackageValues")]
        public System.String[] SecurityGroupSettings_AtakPackageValue { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_Shredder_CanProcessManually
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can manually trigger the shredder to delete content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_Shredder_CanProcessManually { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_Calling_CanStart11Call
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can start one-to-one calls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_Calling_CanStart11Call { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_Calling_CanVideoCall
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can make video calls (as opposed to audio-only calls). Valid
        /// only when audio call(canStart11Call) is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_Calling_CanVideoCall { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_CheckForUpdate
        /// <summary>
        /// <para>
        /// <para>Enables automatic checking for Wickr client updates to ensure users stay current with
        /// the latest version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_CheckForUpdates")]
        public System.Boolean? SecurityGroupSettings_CheckForUpdate { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableAtak
        /// <summary>
        /// <para>
        /// <para>Enables ATAK (Android Team Awareness Kit) integration for tactical communication and
        /// situational awareness.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableAtak { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableCrashReport
        /// <summary>
        /// <para>
        /// <para>Allow users to report crashes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_EnableCrashReports")]
        public System.Boolean? SecurityGroupSettings_EnableCrashReport { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableFileDownload
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can download files from messages to their devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableFileDownload { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableGuestFederation
        /// <summary>
        /// <para>
        /// <para>Allows users to communicate with guest users from other Wickr networks and federated
        /// external networks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableGuestFederation { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableNotificationPreview
        /// <summary>
        /// <para>
        /// <para>Enables message preview text in push notifications, allowing users to see message
        /// content before opening the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableNotificationPreview { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableOpenAccessOption
        /// <summary>
        /// <para>
        /// <para> Allow users to avoid censorship when they are geo-blocked or have network limitations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableOpenAccessOption { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableRestrictedGlobalFederation
        /// <summary>
        /// <para>
        /// <para>Enables restricted global federation, limiting external communication to only specified
        /// permitted networks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableRestrictedGlobalFederation { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_FederationMode
        /// <summary>
        /// <para>
        /// <para>The local federation mode controlling how users can communicate with other networks.
        /// Values: 0 (none), 1 (federated), 2 (restricted).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_FederationMode { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_FilesEnabled
        /// <summary>
        /// <para>
        /// <para>Enables file sharing capabilities, allowing users to send and receive files in conversations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_FilesEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_ForceDeviceLockout
        /// <summary>
        /// <para>
        /// <para> Defines the number of failed login attempts before data stored on the device is reset.
        /// Should be less than lockoutThreshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_ForceDeviceLockout { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_ForceOpenAccess
        /// <summary>
        /// <para>
        /// <para>Automatically enable and enforce Wickr open access on all devices. Valid only if enableOpenAccessOption
        /// settings is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_ForceOpenAccess { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_ForceReadReceipt
        /// <summary>
        /// <para>
        /// <para>Allow user approved bots to read messages in rooms without using a slash command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_ForceReadReceipts")]
        public System.Boolean? SecurityGroupSettings_ForceReadReceipt { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_Calling_ForceTcpCall
        /// <summary>
        /// <para>
        /// <para>When enabled, forces all calls to use TCP protocol instead of UDP for network traversal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_Calling_ForceTcpCall { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_GlobalFederation
        /// <summary>
        /// <para>
        /// <para>Allows users to communicate with users on other Wickr instances (Wickr Enterprise)
        /// outside the current network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_GlobalFederation { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the security group to update.</para>
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
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_Shredder_Intensity
        /// <summary>
        /// <para>
        /// <para>Prevents Wickr data from being recovered by overwriting deleted Wickr data. Valid
        /// Values: Must be one of [0, 20, 60, 100]</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_Shredder_Intensity { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_IsAtoEnabled
        /// <summary>
        /// <para>
        /// <para>Enforces a two-factor authentication when a user adds a new device to their account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_IsAtoEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_IsLinkPreviewEnabled
        /// <summary>
        /// <para>
        /// <para>Enables automatic preview of links shared in messages, showing webpage thumbnails
        /// and descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_IsLinkPreviewEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_LocationAllowMap
        /// <summary>
        /// <para>
        /// <para>Allows map integration in location sharing, enabling users to view shared locations
        /// on interactive maps. Only allowed when location setting is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_LocationAllowMaps")]
        public System.Boolean? SecurityGroupSettings_LocationAllowMap { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_LocationEnabled
        /// <summary>
        /// <para>
        /// <para>Enables location sharing features, allowing users to share their current location
        /// with others.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_LocationEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_LockoutThreshold
        /// <summary>
        /// <para>
        /// <para>The number of failed password attempts before a user account is locked out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_LockoutThreshold { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PasswordRequirements_Lowercase
        /// <summary>
        /// <para>
        /// <para>The minimum number of lowercase letters required in passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_PasswordRequirements_Lowercase { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_MaxAutoDownloadSize
        /// <summary>
        /// <para>
        /// <para>The maximum file size in bytes that will be automatically downloaded without user
        /// confirmation. Only allowed if fileDownload is enabled. Valid Values [512000 (low_quality),
        /// 7340032 (high_quality) ]</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SecurityGroupSettings_MaxAutoDownloadSize { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_MaxBor
        /// <summary>
        /// <para>
        /// <para>The maximum burn-on-read (BOR) time in seconds, which determines how long messages
        /// remain visible before auto-deletion after being read.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_MaxBor { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_MaxTtl
        /// <summary>
        /// <para>
        /// <para>The maximum time-to-live (TTL) in seconds for messages, after which they will be automatically
        /// deleted from all devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SecurityGroupSettings_MaxTtl { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_MessageForwardingEnabled
        /// <summary>
        /// <para>
        /// <para>Enables message forwarding, allowing users to forward messages from one conversation
        /// to another.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_MessageForwardingEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PasswordRequirements_MinLength
        /// <summary>
        /// <para>
        /// <para>The minimum password length in characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_PasswordRequirements_MinLength { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network containing the security group to update.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PasswordRequirements_Number
        /// <summary>
        /// <para>
        /// <para>The minimum number of numeric characters required in passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PasswordRequirements_Numbers")]
        public System.Int32? SecurityGroupSettings_PasswordRequirements_Number { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedNetwork
        /// <summary>
        /// <para>
        /// <para>A list of network IDs that are permitted for local federation when federation mode
        /// is set to restricted.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedNetworks")]
        public System.String[] SecurityGroupSettings_PermittedNetwork { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedWickrAwsNetwork
        /// <summary>
        /// <para>
        /// <para>A list of permitted Wickr networks for global federation, restricting communication
        /// to specific approved networks.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedWickrAwsNetworks")]
        public Amazon.Wickr.Model.WickrAwsNetworks[] SecurityGroupSettings_PermittedWickrAwsNetwork { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedWickrEnterpriseNetwork
        /// <summary>
        /// <para>
        /// <para>A list of permitted Wickr Enterprise networks for global federation, restricting communication
        /// to specific approved networks.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedWickrEnterpriseNetworks")]
        public Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork[] SecurityGroupSettings_PermittedWickrEnterpriseNetwork { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PresenceEnabled
        /// <summary>
        /// <para>
        /// <para>Enables presence indicators that show whether users are online, away, or offline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_PresenceEnabled { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_QuickResponse
        /// <summary>
        /// <para>
        /// <para>A list of pre-defined quick response message templates that users can send with a
        /// single tap.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_QuickResponses")]
        public System.String[] SecurityGroupSettings_QuickResponse { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_ShowMasterRecoveryKey
        /// <summary>
        /// <para>
        /// <para>Users will get a master recovery key that can be used to securely sign in to their
        /// Wickr account without having access to their primary device for authentication. Available
        /// in SSO enabled network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_ShowMasterRecoveryKey { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_SsoMaxIdleMinute
        /// <summary>
        /// <para>
        /// <para>The duration for which users SSO session remains inactive before automatically logging
        /// them out for security. Available in SSO enabled network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_SsoMaxIdleMinutes")]
        public System.Int32? SecurityGroupSettings_SsoMaxIdleMinute { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PasswordRequirements_Symbol
        /// <summary>
        /// <para>
        /// <para>The minimum number of special symbol characters required in passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PasswordRequirements_Symbols")]
        public System.Int32? SecurityGroupSettings_PasswordRequirements_Symbol { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PasswordRequirements_Uppercase
        /// <summary>
        /// <para>
        /// <para>The minimum number of uppercase letters required in passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_PasswordRequirements_Uppercase { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.UpdateSecurityGroupResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.UpdateSecurityGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityGroup";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.GroupId),
                nameof(this.NetworkId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WICSecurityGroup (UpdateSecurityGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.UpdateSecurityGroupResponse, UpdateWICSecurityGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GroupId = this.GroupId;
            #if MODULAR
            if (this.GroupId == null && ParameterWasBound(nameof(this.GroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityGroupSettings_AlwaysReauthenticate = this.SecurityGroupSettings_AlwaysReauthenticate;
            if (this.SecurityGroupSettings_AtakPackageValue != null)
            {
                context.SecurityGroupSettings_AtakPackageValue = new List<System.String>(this.SecurityGroupSettings_AtakPackageValue);
            }
            context.SecurityGroupSettings_Calling_CanStart11Call = this.SecurityGroupSettings_Calling_CanStart11Call;
            context.SecurityGroupSettings_Calling_CanVideoCall = this.SecurityGroupSettings_Calling_CanVideoCall;
            context.SecurityGroupSettings_Calling_ForceTcpCall = this.SecurityGroupSettings_Calling_ForceTcpCall;
            context.SecurityGroupSettings_CheckForUpdate = this.SecurityGroupSettings_CheckForUpdate;
            context.SecurityGroupSettings_EnableAtak = this.SecurityGroupSettings_EnableAtak;
            context.SecurityGroupSettings_EnableCrashReport = this.SecurityGroupSettings_EnableCrashReport;
            context.SecurityGroupSettings_EnableFileDownload = this.SecurityGroupSettings_EnableFileDownload;
            context.SecurityGroupSettings_EnableGuestFederation = this.SecurityGroupSettings_EnableGuestFederation;
            context.SecurityGroupSettings_EnableNotificationPreview = this.SecurityGroupSettings_EnableNotificationPreview;
            context.SecurityGroupSettings_EnableOpenAccessOption = this.SecurityGroupSettings_EnableOpenAccessOption;
            context.SecurityGroupSettings_EnableRestrictedGlobalFederation = this.SecurityGroupSettings_EnableRestrictedGlobalFederation;
            context.SecurityGroupSettings_FederationMode = this.SecurityGroupSettings_FederationMode;
            context.SecurityGroupSettings_FilesEnabled = this.SecurityGroupSettings_FilesEnabled;
            context.SecurityGroupSettings_ForceDeviceLockout = this.SecurityGroupSettings_ForceDeviceLockout;
            context.SecurityGroupSettings_ForceOpenAccess = this.SecurityGroupSettings_ForceOpenAccess;
            context.SecurityGroupSettings_ForceReadReceipt = this.SecurityGroupSettings_ForceReadReceipt;
            context.SecurityGroupSettings_GlobalFederation = this.SecurityGroupSettings_GlobalFederation;
            context.SecurityGroupSettings_IsAtoEnabled = this.SecurityGroupSettings_IsAtoEnabled;
            context.SecurityGroupSettings_IsLinkPreviewEnabled = this.SecurityGroupSettings_IsLinkPreviewEnabled;
            context.SecurityGroupSettings_LocationAllowMap = this.SecurityGroupSettings_LocationAllowMap;
            context.SecurityGroupSettings_LocationEnabled = this.SecurityGroupSettings_LocationEnabled;
            context.SecurityGroupSettings_LockoutThreshold = this.SecurityGroupSettings_LockoutThreshold;
            context.SecurityGroupSettings_MaxAutoDownloadSize = this.SecurityGroupSettings_MaxAutoDownloadSize;
            context.SecurityGroupSettings_MaxBor = this.SecurityGroupSettings_MaxBor;
            context.SecurityGroupSettings_MaxTtl = this.SecurityGroupSettings_MaxTtl;
            context.SecurityGroupSettings_MessageForwardingEnabled = this.SecurityGroupSettings_MessageForwardingEnabled;
            context.SecurityGroupSettings_PasswordRequirements_Lowercase = this.SecurityGroupSettings_PasswordRequirements_Lowercase;
            context.SecurityGroupSettings_PasswordRequirements_MinLength = this.SecurityGroupSettings_PasswordRequirements_MinLength;
            context.SecurityGroupSettings_PasswordRequirements_Number = this.SecurityGroupSettings_PasswordRequirements_Number;
            context.SecurityGroupSettings_PasswordRequirements_Symbol = this.SecurityGroupSettings_PasswordRequirements_Symbol;
            context.SecurityGroupSettings_PasswordRequirements_Uppercase = this.SecurityGroupSettings_PasswordRequirements_Uppercase;
            if (this.SecurityGroupSettings_PermittedNetwork != null)
            {
                context.SecurityGroupSettings_PermittedNetwork = new List<System.String>(this.SecurityGroupSettings_PermittedNetwork);
            }
            if (this.SecurityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                context.SecurityGroupSettings_PermittedWickrAwsNetwork = new List<Amazon.Wickr.Model.WickrAwsNetworks>(this.SecurityGroupSettings_PermittedWickrAwsNetwork);
            }
            if (this.SecurityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                context.SecurityGroupSettings_PermittedWickrEnterpriseNetwork = new List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork>(this.SecurityGroupSettings_PermittedWickrEnterpriseNetwork);
            }
            context.SecurityGroupSettings_PresenceEnabled = this.SecurityGroupSettings_PresenceEnabled;
            if (this.SecurityGroupSettings_QuickResponse != null)
            {
                context.SecurityGroupSettings_QuickResponse = new List<System.String>(this.SecurityGroupSettings_QuickResponse);
            }
            context.SecurityGroupSettings_ShowMasterRecoveryKey = this.SecurityGroupSettings_ShowMasterRecoveryKey;
            context.SecurityGroupSettings_Shredder_CanProcessManually = this.SecurityGroupSettings_Shredder_CanProcessManually;
            context.SecurityGroupSettings_Shredder_Intensity = this.SecurityGroupSettings_Shredder_Intensity;
            context.SecurityGroupSettings_SsoMaxIdleMinute = this.SecurityGroupSettings_SsoMaxIdleMinute;
            
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
            var request = new Amazon.Wickr.Model.UpdateSecurityGroupRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            
             // populate SecurityGroupSettings
            var requestSecurityGroupSettingsIsNull = true;
            request.SecurityGroupSettings = new Amazon.Wickr.Model.SecurityGroupSettings();
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_AlwaysReauthenticate = null;
            if (cmdletContext.SecurityGroupSettings_AlwaysReauthenticate != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_AlwaysReauthenticate = cmdletContext.SecurityGroupSettings_AlwaysReauthenticate.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_AlwaysReauthenticate != null)
            {
                request.SecurityGroupSettings.AlwaysReauthenticate = requestSecurityGroupSettings_securityGroupSettings_AlwaysReauthenticate.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<System.String> requestSecurityGroupSettings_securityGroupSettings_AtakPackageValue = null;
            if (cmdletContext.SecurityGroupSettings_AtakPackageValue != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_AtakPackageValue = cmdletContext.SecurityGroupSettings_AtakPackageValue;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_AtakPackageValue != null)
            {
                request.SecurityGroupSettings.AtakPackageValues = requestSecurityGroupSettings_securityGroupSettings_AtakPackageValue;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_CheckForUpdate = null;
            if (cmdletContext.SecurityGroupSettings_CheckForUpdate != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_CheckForUpdate = cmdletContext.SecurityGroupSettings_CheckForUpdate.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_CheckForUpdate != null)
            {
                request.SecurityGroupSettings.CheckForUpdates = requestSecurityGroupSettings_securityGroupSettings_CheckForUpdate.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableAtak = null;
            if (cmdletContext.SecurityGroupSettings_EnableAtak != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableAtak = cmdletContext.SecurityGroupSettings_EnableAtak.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableAtak != null)
            {
                request.SecurityGroupSettings.EnableAtak = requestSecurityGroupSettings_securityGroupSettings_EnableAtak.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableCrashReport = null;
            if (cmdletContext.SecurityGroupSettings_EnableCrashReport != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableCrashReport = cmdletContext.SecurityGroupSettings_EnableCrashReport.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableCrashReport != null)
            {
                request.SecurityGroupSettings.EnableCrashReports = requestSecurityGroupSettings_securityGroupSettings_EnableCrashReport.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableFileDownload = null;
            if (cmdletContext.SecurityGroupSettings_EnableFileDownload != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableFileDownload = cmdletContext.SecurityGroupSettings_EnableFileDownload.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableFileDownload != null)
            {
                request.SecurityGroupSettings.EnableFileDownload = requestSecurityGroupSettings_securityGroupSettings_EnableFileDownload.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation = null;
            if (cmdletContext.SecurityGroupSettings_EnableGuestFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation = cmdletContext.SecurityGroupSettings_EnableGuestFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation != null)
            {
                request.SecurityGroupSettings.EnableGuestFederation = requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableNotificationPreview = null;
            if (cmdletContext.SecurityGroupSettings_EnableNotificationPreview != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableNotificationPreview = cmdletContext.SecurityGroupSettings_EnableNotificationPreview.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableNotificationPreview != null)
            {
                request.SecurityGroupSettings.EnableNotificationPreview = requestSecurityGroupSettings_securityGroupSettings_EnableNotificationPreview.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableOpenAccessOption = null;
            if (cmdletContext.SecurityGroupSettings_EnableOpenAccessOption != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableOpenAccessOption = cmdletContext.SecurityGroupSettings_EnableOpenAccessOption.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableOpenAccessOption != null)
            {
                request.SecurityGroupSettings.EnableOpenAccessOption = requestSecurityGroupSettings_securityGroupSettings_EnableOpenAccessOption.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation = null;
            if (cmdletContext.SecurityGroupSettings_EnableRestrictedGlobalFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation = cmdletContext.SecurityGroupSettings_EnableRestrictedGlobalFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation != null)
            {
                request.SecurityGroupSettings.EnableRestrictedGlobalFederation = requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_FederationMode = null;
            if (cmdletContext.SecurityGroupSettings_FederationMode != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_FederationMode = cmdletContext.SecurityGroupSettings_FederationMode.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_FederationMode != null)
            {
                request.SecurityGroupSettings.FederationMode = requestSecurityGroupSettings_securityGroupSettings_FederationMode.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_FilesEnabled = null;
            if (cmdletContext.SecurityGroupSettings_FilesEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_FilesEnabled = cmdletContext.SecurityGroupSettings_FilesEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_FilesEnabled != null)
            {
                request.SecurityGroupSettings.FilesEnabled = requestSecurityGroupSettings_securityGroupSettings_FilesEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_ForceDeviceLockout = null;
            if (cmdletContext.SecurityGroupSettings_ForceDeviceLockout != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_ForceDeviceLockout = cmdletContext.SecurityGroupSettings_ForceDeviceLockout.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_ForceDeviceLockout != null)
            {
                request.SecurityGroupSettings.ForceDeviceLockout = requestSecurityGroupSettings_securityGroupSettings_ForceDeviceLockout.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_ForceOpenAccess = null;
            if (cmdletContext.SecurityGroupSettings_ForceOpenAccess != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_ForceOpenAccess = cmdletContext.SecurityGroupSettings_ForceOpenAccess.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_ForceOpenAccess != null)
            {
                request.SecurityGroupSettings.ForceOpenAccess = requestSecurityGroupSettings_securityGroupSettings_ForceOpenAccess.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_ForceReadReceipt = null;
            if (cmdletContext.SecurityGroupSettings_ForceReadReceipt != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_ForceReadReceipt = cmdletContext.SecurityGroupSettings_ForceReadReceipt.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_ForceReadReceipt != null)
            {
                request.SecurityGroupSettings.ForceReadReceipts = requestSecurityGroupSettings_securityGroupSettings_ForceReadReceipt.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_GlobalFederation = null;
            if (cmdletContext.SecurityGroupSettings_GlobalFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_GlobalFederation = cmdletContext.SecurityGroupSettings_GlobalFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_GlobalFederation != null)
            {
                request.SecurityGroupSettings.GlobalFederation = requestSecurityGroupSettings_securityGroupSettings_GlobalFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_IsAtoEnabled = null;
            if (cmdletContext.SecurityGroupSettings_IsAtoEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_IsAtoEnabled = cmdletContext.SecurityGroupSettings_IsAtoEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_IsAtoEnabled != null)
            {
                request.SecurityGroupSettings.IsAtoEnabled = requestSecurityGroupSettings_securityGroupSettings_IsAtoEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_IsLinkPreviewEnabled = null;
            if (cmdletContext.SecurityGroupSettings_IsLinkPreviewEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_IsLinkPreviewEnabled = cmdletContext.SecurityGroupSettings_IsLinkPreviewEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_IsLinkPreviewEnabled != null)
            {
                request.SecurityGroupSettings.IsLinkPreviewEnabled = requestSecurityGroupSettings_securityGroupSettings_IsLinkPreviewEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_LocationAllowMap = null;
            if (cmdletContext.SecurityGroupSettings_LocationAllowMap != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_LocationAllowMap = cmdletContext.SecurityGroupSettings_LocationAllowMap.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_LocationAllowMap != null)
            {
                request.SecurityGroupSettings.LocationAllowMaps = requestSecurityGroupSettings_securityGroupSettings_LocationAllowMap.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_LocationEnabled = null;
            if (cmdletContext.SecurityGroupSettings_LocationEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_LocationEnabled = cmdletContext.SecurityGroupSettings_LocationEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_LocationEnabled != null)
            {
                request.SecurityGroupSettings.LocationEnabled = requestSecurityGroupSettings_securityGroupSettings_LocationEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold = null;
            if (cmdletContext.SecurityGroupSettings_LockoutThreshold != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold = cmdletContext.SecurityGroupSettings_LockoutThreshold.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold != null)
            {
                request.SecurityGroupSettings.LockoutThreshold = requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int64? requestSecurityGroupSettings_securityGroupSettings_MaxAutoDownloadSize = null;
            if (cmdletContext.SecurityGroupSettings_MaxAutoDownloadSize != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_MaxAutoDownloadSize = cmdletContext.SecurityGroupSettings_MaxAutoDownloadSize.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_MaxAutoDownloadSize != null)
            {
                request.SecurityGroupSettings.MaxAutoDownloadSize = requestSecurityGroupSettings_securityGroupSettings_MaxAutoDownloadSize.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_MaxBor = null;
            if (cmdletContext.SecurityGroupSettings_MaxBor != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_MaxBor = cmdletContext.SecurityGroupSettings_MaxBor.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_MaxBor != null)
            {
                request.SecurityGroupSettings.MaxBor = requestSecurityGroupSettings_securityGroupSettings_MaxBor.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int64? requestSecurityGroupSettings_securityGroupSettings_MaxTtl = null;
            if (cmdletContext.SecurityGroupSettings_MaxTtl != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_MaxTtl = cmdletContext.SecurityGroupSettings_MaxTtl.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_MaxTtl != null)
            {
                request.SecurityGroupSettings.MaxTtl = requestSecurityGroupSettings_securityGroupSettings_MaxTtl.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_MessageForwardingEnabled = null;
            if (cmdletContext.SecurityGroupSettings_MessageForwardingEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_MessageForwardingEnabled = cmdletContext.SecurityGroupSettings_MessageForwardingEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_MessageForwardingEnabled != null)
            {
                request.SecurityGroupSettings.MessageForwardingEnabled = requestSecurityGroupSettings_securityGroupSettings_MessageForwardingEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<System.String> requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork = cmdletContext.SecurityGroupSettings_PermittedNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork != null)
            {
                request.SecurityGroupSettings.PermittedNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<Amazon.Wickr.Model.WickrAwsNetworks> requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork = cmdletContext.SecurityGroupSettings_PermittedWickrAwsNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                request.SecurityGroupSettings.PermittedWickrAwsNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork> requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork = cmdletContext.SecurityGroupSettings_PermittedWickrEnterpriseNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                request.SecurityGroupSettings.PermittedWickrEnterpriseNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_PresenceEnabled = null;
            if (cmdletContext.SecurityGroupSettings_PresenceEnabled != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PresenceEnabled = cmdletContext.SecurityGroupSettings_PresenceEnabled.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PresenceEnabled != null)
            {
                request.SecurityGroupSettings.PresenceEnabled = requestSecurityGroupSettings_securityGroupSettings_PresenceEnabled.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<System.String> requestSecurityGroupSettings_securityGroupSettings_QuickResponse = null;
            if (cmdletContext.SecurityGroupSettings_QuickResponse != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_QuickResponse = cmdletContext.SecurityGroupSettings_QuickResponse;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_QuickResponse != null)
            {
                request.SecurityGroupSettings.QuickResponses = requestSecurityGroupSettings_securityGroupSettings_QuickResponse;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_ShowMasterRecoveryKey = null;
            if (cmdletContext.SecurityGroupSettings_ShowMasterRecoveryKey != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_ShowMasterRecoveryKey = cmdletContext.SecurityGroupSettings_ShowMasterRecoveryKey.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_ShowMasterRecoveryKey != null)
            {
                request.SecurityGroupSettings.ShowMasterRecoveryKey = requestSecurityGroupSettings_securityGroupSettings_ShowMasterRecoveryKey.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_SsoMaxIdleMinute = null;
            if (cmdletContext.SecurityGroupSettings_SsoMaxIdleMinute != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_SsoMaxIdleMinute = cmdletContext.SecurityGroupSettings_SsoMaxIdleMinute.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_SsoMaxIdleMinute != null)
            {
                request.SecurityGroupSettings.SsoMaxIdleMinutes = requestSecurityGroupSettings_securityGroupSettings_SsoMaxIdleMinute.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            Amazon.Wickr.Model.ShredderSettings requestSecurityGroupSettings_securityGroupSettings_Shredder = null;
            
             // populate Shredder
            var requestSecurityGroupSettings_securityGroupSettings_ShredderIsNull = true;
            requestSecurityGroupSettings_securityGroupSettings_Shredder = new Amazon.Wickr.Model.ShredderSettings();
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_CanProcessManually = null;
            if (cmdletContext.SecurityGroupSettings_Shredder_CanProcessManually != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_CanProcessManually = cmdletContext.SecurityGroupSettings_Shredder_CanProcessManually.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_CanProcessManually != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Shredder.CanProcessManually = requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_CanProcessManually.Value;
                requestSecurityGroupSettings_securityGroupSettings_ShredderIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_Intensity = null;
            if (cmdletContext.SecurityGroupSettings_Shredder_Intensity != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_Intensity = cmdletContext.SecurityGroupSettings_Shredder_Intensity.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_Intensity != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Shredder.Intensity = requestSecurityGroupSettings_securityGroupSettings_Shredder_securityGroupSettings_Shredder_Intensity.Value;
                requestSecurityGroupSettings_securityGroupSettings_ShredderIsNull = false;
            }
             // determine if requestSecurityGroupSettings_securityGroupSettings_Shredder should be set to null
            if (requestSecurityGroupSettings_securityGroupSettings_ShredderIsNull)
            {
                requestSecurityGroupSettings_securityGroupSettings_Shredder = null;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Shredder != null)
            {
                request.SecurityGroupSettings.Shredder = requestSecurityGroupSettings_securityGroupSettings_Shredder;
                requestSecurityGroupSettingsIsNull = false;
            }
            Amazon.Wickr.Model.CallingSettings requestSecurityGroupSettings_securityGroupSettings_Calling = null;
            
             // populate Calling
            var requestSecurityGroupSettings_securityGroupSettings_CallingIsNull = true;
            requestSecurityGroupSettings_securityGroupSettings_Calling = new Amazon.Wickr.Model.CallingSettings();
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanStart11Call = null;
            if (cmdletContext.SecurityGroupSettings_Calling_CanStart11Call != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanStart11Call = cmdletContext.SecurityGroupSettings_Calling_CanStart11Call.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanStart11Call != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling.CanStart11Call = requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanStart11Call.Value;
                requestSecurityGroupSettings_securityGroupSettings_CallingIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanVideoCall = null;
            if (cmdletContext.SecurityGroupSettings_Calling_CanVideoCall != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanVideoCall = cmdletContext.SecurityGroupSettings_Calling_CanVideoCall.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanVideoCall != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling.CanVideoCall = requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_CanVideoCall.Value;
                requestSecurityGroupSettings_securityGroupSettings_CallingIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_ForceTcpCall = null;
            if (cmdletContext.SecurityGroupSettings_Calling_ForceTcpCall != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_ForceTcpCall = cmdletContext.SecurityGroupSettings_Calling_ForceTcpCall.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_ForceTcpCall != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling.ForceTcpCall = requestSecurityGroupSettings_securityGroupSettings_Calling_securityGroupSettings_Calling_ForceTcpCall.Value;
                requestSecurityGroupSettings_securityGroupSettings_CallingIsNull = false;
            }
             // determine if requestSecurityGroupSettings_securityGroupSettings_Calling should be set to null
            if (requestSecurityGroupSettings_securityGroupSettings_CallingIsNull)
            {
                requestSecurityGroupSettings_securityGroupSettings_Calling = null;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_Calling != null)
            {
                request.SecurityGroupSettings.Calling = requestSecurityGroupSettings_securityGroupSettings_Calling;
                requestSecurityGroupSettingsIsNull = false;
            }
            Amazon.Wickr.Model.PasswordRequirements requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements = null;
            
             // populate PasswordRequirements
            var requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = true;
            requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements = new Amazon.Wickr.Model.PasswordRequirements();
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Lowercase = null;
            if (cmdletContext.SecurityGroupSettings_PasswordRequirements_Lowercase != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Lowercase = cmdletContext.SecurityGroupSettings_PasswordRequirements_Lowercase.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Lowercase != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements.Lowercase = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Lowercase.Value;
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_MinLength = null;
            if (cmdletContext.SecurityGroupSettings_PasswordRequirements_MinLength != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_MinLength = cmdletContext.SecurityGroupSettings_PasswordRequirements_MinLength.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_MinLength != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements.MinLength = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_MinLength.Value;
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Number = null;
            if (cmdletContext.SecurityGroupSettings_PasswordRequirements_Number != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Number = cmdletContext.SecurityGroupSettings_PasswordRequirements_Number.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Number != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements.Numbers = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Number.Value;
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Symbol = null;
            if (cmdletContext.SecurityGroupSettings_PasswordRequirements_Symbol != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Symbol = cmdletContext.SecurityGroupSettings_PasswordRequirements_Symbol.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Symbol != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements.Symbols = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Symbol.Value;
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Uppercase = null;
            if (cmdletContext.SecurityGroupSettings_PasswordRequirements_Uppercase != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Uppercase = cmdletContext.SecurityGroupSettings_PasswordRequirements_Uppercase.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Uppercase != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements.Uppercase = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements_securityGroupSettings_PasswordRequirements_Uppercase.Value;
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull = false;
            }
             // determine if requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements should be set to null
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirementsIsNull)
            {
                requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements = null;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements != null)
            {
                request.SecurityGroupSettings.PasswordRequirements = requestSecurityGroupSettings_securityGroupSettings_PasswordRequirements;
                requestSecurityGroupSettingsIsNull = false;
            }
             // determine if request.SecurityGroupSettings should be set to null
            if (requestSecurityGroupSettingsIsNull)
            {
                request.SecurityGroupSettings = null;
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
        
        private Amazon.Wickr.Model.UpdateSecurityGroupResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.UpdateSecurityGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "UpdateSecurityGroup");
            try
            {
                return client.UpdateSecurityGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GroupId { get; set; }
            public System.String Name { get; set; }
            public System.String NetworkId { get; set; }
            public System.Boolean? SecurityGroupSettings_AlwaysReauthenticate { get; set; }
            public List<System.String> SecurityGroupSettings_AtakPackageValue { get; set; }
            public System.Boolean? SecurityGroupSettings_Calling_CanStart11Call { get; set; }
            public System.Boolean? SecurityGroupSettings_Calling_CanVideoCall { get; set; }
            public System.Boolean? SecurityGroupSettings_Calling_ForceTcpCall { get; set; }
            public System.Boolean? SecurityGroupSettings_CheckForUpdate { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableAtak { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableCrashReport { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableFileDownload { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableGuestFederation { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableNotificationPreview { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableOpenAccessOption { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableRestrictedGlobalFederation { get; set; }
            public System.Int32? SecurityGroupSettings_FederationMode { get; set; }
            public System.Boolean? SecurityGroupSettings_FilesEnabled { get; set; }
            public System.Int32? SecurityGroupSettings_ForceDeviceLockout { get; set; }
            public System.Boolean? SecurityGroupSettings_ForceOpenAccess { get; set; }
            public System.Boolean? SecurityGroupSettings_ForceReadReceipt { get; set; }
            public System.Boolean? SecurityGroupSettings_GlobalFederation { get; set; }
            public System.Boolean? SecurityGroupSettings_IsAtoEnabled { get; set; }
            public System.Boolean? SecurityGroupSettings_IsLinkPreviewEnabled { get; set; }
            public System.Boolean? SecurityGroupSettings_LocationAllowMap { get; set; }
            public System.Boolean? SecurityGroupSettings_LocationEnabled { get; set; }
            public System.Int32? SecurityGroupSettings_LockoutThreshold { get; set; }
            public System.Int64? SecurityGroupSettings_MaxAutoDownloadSize { get; set; }
            public System.Int32? SecurityGroupSettings_MaxBor { get; set; }
            public System.Int64? SecurityGroupSettings_MaxTtl { get; set; }
            public System.Boolean? SecurityGroupSettings_MessageForwardingEnabled { get; set; }
            public System.Int32? SecurityGroupSettings_PasswordRequirements_Lowercase { get; set; }
            public System.Int32? SecurityGroupSettings_PasswordRequirements_MinLength { get; set; }
            public System.Int32? SecurityGroupSettings_PasswordRequirements_Number { get; set; }
            public System.Int32? SecurityGroupSettings_PasswordRequirements_Symbol { get; set; }
            public System.Int32? SecurityGroupSettings_PasswordRequirements_Uppercase { get; set; }
            public List<System.String> SecurityGroupSettings_PermittedNetwork { get; set; }
            public List<Amazon.Wickr.Model.WickrAwsNetworks> SecurityGroupSettings_PermittedWickrAwsNetwork { get; set; }
            public List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork> SecurityGroupSettings_PermittedWickrEnterpriseNetwork { get; set; }
            public System.Boolean? SecurityGroupSettings_PresenceEnabled { get; set; }
            public List<System.String> SecurityGroupSettings_QuickResponse { get; set; }
            public System.Boolean? SecurityGroupSettings_ShowMasterRecoveryKey { get; set; }
            public System.Boolean? SecurityGroupSettings_Shredder_CanProcessManually { get; set; }
            public System.Int32? SecurityGroupSettings_Shredder_Intensity { get; set; }
            public System.Int32? SecurityGroupSettings_SsoMaxIdleMinute { get; set; }
            public System.Func<Amazon.Wickr.Model.UpdateSecurityGroupResponse, UpdateWICSecurityGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityGroup;
        }
        
    }
}
