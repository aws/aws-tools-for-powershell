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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Creates a filter using the specified finding criteria. The maximum number of saved
    /// filters per Amazon Web Services account per Region is 100. For more information, see
    /// <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_limits.html">Quotas
    /// for GuardDuty</a>.
    /// </summary>
    [Cmdlet("New", "GDFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GuardDuty CreateFilter API operation.", Operation = new[] {"CreateFilter"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.CreateFilterResponse))]
    [AWSCmdletOutput("System.String or Amazon.GuardDuty.Model.CreateFilterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GuardDuty.Model.CreateFilterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDFilterCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>Specifies the action that is to be applied to the findings that match the filter.</para><para>Default: NOOP</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.FilterAction")]
        public Amazon.GuardDuty.FilterAction Action { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the filter. Valid characters include alphanumeric characters, and
        /// special characters such as hyphen, period, colon, underscore, parentheses (<c>{ }</c>,
        /// <c>[ ]</c>, and <c>( )</c>), forward slash, horizontal tab, vertical tab, newline,
        /// form feed, return, and whitespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The detector ID associated with the GuardDuty account for which you want to create
        /// a filter.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
        /// GuardDuty console, or run the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_ListDetectors.html">ListDetectors</a>
        /// API.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter FindingCriterion
        /// <summary>
        /// <para>
        /// <para>Represents the criteria to be used in the filter for querying findings. The following
        /// fields are available for filtering:</para><ul><li><para>accountId</para></li><li><para>arn</para></li><li><para>associatedAttackSequenceArn</para></li><li><para>confidence</para></li><li><para>createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>description</para></li><li><para>id</para></li><li><para>partition</para></li><li><para>region</para></li><li><para>resource.accessKeyDetails.accessKeyId</para></li><li><para>resource.accessKeyDetails.principalId</para></li><li><para>resource.accessKeyDetails.userIdentity.accessKeyId</para></li><li><para>resource.accessKeyDetails.userIdentity.accountId</para></li><li><para>resource.accessKeyDetails.userIdentity.arn</para></li><li><para>resource.accessKeyDetails.userIdentity.principalId</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.attributes.mfaAuthenticated</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.ec2RoleDelivery</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.invokedBy</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sessionIssuer.accountId</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sessionIssuer.arn</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sessionIssuer.principalId</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sessionIssuer.type</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sessionIssuer.userName</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.sourceIdentity</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.webIdFederationData.attributes</para></li><li><para>resource.accessKeyDetails.userIdentity.sessionContext.webIdFederationData.federatedProvider</para></li><li><para>resource.accessKeyDetails.userIdentity.type</para></li><li><para>resource.accessKeyDetails.userIdentity.userName</para></li><li><para>resource.accessKeyDetails.userName</para></li><li><para>resource.accessKeyDetails.userType</para></li><li><para>resource.bedrockGuardrailDetails.guardrailArn</para></li><li><para>resource.bedrockGuardrailDetails.guardrailVersion</para></li><li><para>resource.containerDetails.containerRuntime</para></li><li><para>resource.containerDetails.id</para></li><li><para>resource.containerDetails.image</para></li><li><para>resource.containerDetails.imagePrefix</para></li><li><para>resource.containerDetails.name</para></li><li><para>resource.containerDetails.securityContext.allowPrivilegeEscalation</para></li><li><para>resource.containerDetails.securityContext.privileged</para></li><li><para>resource.containerDetails.volumeMounts.mountPath</para></li><li><para>resource.containerDetails.volumeMounts.name</para></li><li><para>resource.ebsSnapshotDetails.snapshotArn</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.deviceName</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.encryptionType</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.kmsKeyArn</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.snapshotArn</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.volumeArn</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.volumeSizeInGB</para></li><li><para>resource.ebsVolumeDetails.scannedVolumeDetails.volumeType</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.deviceName</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.encryptionType</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.kmsKeyArn</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.snapshotArn</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.volumeArn</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.volumeSizeInGB</para></li><li><para>resource.ebsVolumeDetails.skippedVolumeDetails.volumeType</para></li><li><para>resource.ec2ImageDetails.imageArn</para></li><li><para>resource.ecsClusterDetails.activeServicesCount</para></li><li><para>resource.ecsClusterDetails.arn</para></li><li><para>resource.ecsClusterDetails.name</para></li><li><para>resource.ecsClusterDetails.registeredContainerInstancesCount</para></li><li><para>resource.ecsClusterDetails.runningTasksCount</para></li><li><para>resource.ecsClusterDetails.status</para></li><li><para>resource.ecsClusterDetails.tags.key</para></li><li><para>resource.ecsClusterDetails.tags.value</para></li><li><para>resource.ecsClusterDetails.taskDetails.arn</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.containerRuntime</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.id</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.image</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.imagePrefix</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.name</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.securityContext.allowPrivilegeEscalation</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.securityContext.privileged</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.volumeMounts.mountPath</para></li><li><para>resource.ecsClusterDetails.taskDetails.containers.volumeMounts.name</para></li><li><para>resource.ecsClusterDetails.taskDetails.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.ecsClusterDetails.taskDetails.definitionArn</para></li><li><para>resource.ecsClusterDetails.taskDetails.group</para></li><li><para>resource.ecsClusterDetails.taskDetails.launchType</para></li><li><para>resource.ecsClusterDetails.taskDetails.startedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.ecsClusterDetails.taskDetails.startedBy</para></li><li><para>resource.ecsClusterDetails.taskDetails.tags.key</para></li><li><para>resource.ecsClusterDetails.taskDetails.tags.value</para></li><li><para>resource.ecsClusterDetails.taskDetails.version</para></li><li><para>resource.ecsClusterDetails.taskDetails.volumes.hostPath.path</para></li><li><para>resource.ecsClusterDetails.taskDetails.volumes.name</para></li><li><para>resource.eksClusterDetails.arn</para></li><li><para>resource.eksClusterDetails.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.eksClusterDetails.name</para></li><li><para>resource.eksClusterDetails.status</para></li><li><para>resource.eksClusterDetails.tags.key</para></li><li><para>resource.eksClusterDetails.tags.value</para></li><li><para>resource.eksClusterDetails.vpcId</para></li><li><para>resource.instanceDetails.availabilityZone</para></li><li><para>resource.instanceDetails.iamInstanceProfile.arn</para></li><li><para>resource.instanceDetails.iamInstanceProfile.id</para></li><li><para>resource.instanceDetails.imageDescription</para></li><li><para>resource.instanceDetails.imageId</para></li><li><para>resource.instanceDetails.instanceId</para></li><li><para>resource.instanceDetails.instanceState</para></li><li><para>resource.instanceDetails.instanceType</para></li><li><para>resource.instanceDetails.launchTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.instanceDetails.networkInterfaces.ipv6Addresses</para></li><li><para>resource.instanceDetails.networkInterfaces.networkInterfaceId</para></li><li><para>resource.instanceDetails.networkInterfaces.privateDnsName</para></li><li><para>resource.instanceDetails.networkInterfaces.privateIpAddress</para></li><li><para>resource.instanceDetails.networkInterfaces.privateIpAddresses.privateDnsName</para></li><li><para>resource.instanceDetails.networkInterfaces.privateIpAddresses.privateIpAddress</para></li><li><para>resource.instanceDetails.networkInterfaces.publicDnsName</para></li><li><para>resource.instanceDetails.networkInterfaces.publicIp</para></li><li><para>resource.instanceDetails.networkInterfaces.securityGroups.groupId</para></li><li><para>resource.instanceDetails.networkInterfaces.securityGroups.groupName</para></li><li><para>resource.instanceDetails.networkInterfaces.subnetId</para></li><li><para>resource.instanceDetails.networkInterfaces.vpcId</para></li><li><para>resource.instanceDetails.outpostArn</para></li><li><para>resource.instanceDetails.platform</para></li><li><para>resource.instanceDetails.productCodes.productCodeId</para></li><li><para>resource.instanceDetails.productCodes.productCodeType</para></li><li><para>resource.instanceDetails.tags.key</para></li><li><para>resource.instanceDetails.tags.value</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.groups</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.impersonatedUser.groups</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.impersonatedUser.username</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.sessionName</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.uid</para></li><li><para>resource.kubernetesDetails.kubernetesUserDetails.username</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.containerRuntime</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.id</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.image</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.imagePrefix</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.name</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.securityContext.allowPrivilegeEscalation</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.securityContext.privileged</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.volumeMounts.mountPath</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.containers.volumeMounts.name</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.hostIpc</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.hostNetwork</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.hostPid</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.name</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.namespace</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.serviceAccountName</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.type</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.uid</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.volumes.hostPath.path</para></li><li><para>resource.kubernetesDetails.kubernetesWorkloadDetails.volumes.name</para></li><li><para>resource.lambdaDetails.description</para></li><li><para>resource.lambdaDetails.functionArn</para></li><li><para>resource.lambdaDetails.functionName</para></li><li><para>resource.lambdaDetails.functionVersion</para></li><li><para>resource.lambdaDetails.lastModifiedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.lambdaDetails.revisionId</para></li><li><para>resource.lambdaDetails.role</para></li><li><para>resource.lambdaDetails.tags.key</para></li><li><para>resource.lambdaDetails.tags.value</para></li><li><para>resource.lambdaDetails.vpcConfig.securityGroups.groupId</para></li><li><para>resource.lambdaDetails.vpcConfig.securityGroups.groupName</para></li><li><para>resource.lambdaDetails.vpcConfig.subnetIds</para></li><li><para>resource.lambdaDetails.vpcConfig.vpcId</para></li><li><para>resource.rdsDbInstanceDetails.dbClusterIdentifier</para></li><li><para>resource.rdsDbInstanceDetails.dbInstanceArn</para></li><li><para>resource.rdsDbInstanceDetails.dbInstanceIdentifier</para></li><li><para>resource.rdsDbInstanceDetails.dbSecurityGroups.name</para></li><li><para>resource.rdsDbInstanceDetails.dbSecurityGroups.status</para></li><li><para>resource.rdsDbInstanceDetails.dbiResourceId</para></li><li><para>resource.rdsDbInstanceDetails.engine</para></li><li><para>resource.rdsDbInstanceDetails.engineVersion</para></li><li><para>resource.rdsDbInstanceDetails.iamDatabaseAuthenticationEnabled</para></li><li><para>resource.rdsDbInstanceDetails.publiclyAccessible</para></li><li><para>resource.rdsDbInstanceDetails.tags.key</para></li><li><para>resource.rdsDbInstanceDetails.tags.value</para></li><li><para>resource.rdsDbInstanceDetails.vpcId</para></li><li><para>resource.rdsDbInstanceDetails.vpcSecurityGroups.status</para></li><li><para>resource.rdsDbInstanceDetails.vpcSecurityGroups.vpcSecurityGroupId</para></li><li><para>resource.rdsDbUserDetails.application</para></li><li><para>resource.rdsDbUserDetails.authMethod</para></li><li><para>resource.rdsDbUserDetails.database</para></li><li><para>resource.rdsDbUserDetails.ssl</para></li><li><para>resource.rdsDbUserDetails.user</para></li><li><para>resource.rdsLimitlessDbDetails.dbClusterIdentifier</para></li><li><para>resource.rdsLimitlessDbDetails.dbShardGroupArn</para></li><li><para>resource.rdsLimitlessDbDetails.dbShardGroupIdentifier</para></li><li><para>resource.rdsLimitlessDbDetails.dbShardGroupResourceId</para></li><li><para>resource.rdsLimitlessDbDetails.engine</para></li><li><para>resource.rdsLimitlessDbDetails.engineVersion</para></li><li><para>resource.rdsLimitlessDbDetails.tags.key</para></li><li><para>resource.rdsLimitlessDbDetails.tags.value</para></li><li><para>resource.recoveryPointDetails.backupVaultName</para></li><li><para>resource.recoveryPointDetails.recoveryPointArn</para></li><li><para>resource.resourceType</para></li><li><para>resource.s3BucketDetails.arn</para></li><li><para>resource.s3BucketDetails.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>resource.s3BucketDetails.defaultServerSideEncryption.encryptionType</para></li><li><para>resource.s3BucketDetails.defaultServerSideEncryption.kmsMasterKeyArn</para></li><li><para>resource.s3BucketDetails.name</para></li><li><para>resource.s3BucketDetails.owner.id</para></li><li><para>resource.s3BucketDetails.publicAccess.effectivePermission</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.accountLevelPermissions.blockPublicAccess.blockPublicAcls</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.accountLevelPermissions.blockPublicAccess.blockPublicPolicy</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.accountLevelPermissions.blockPublicAccess.ignorePublicAcls</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.accountLevelPermissions.blockPublicAccess.restrictPublicBuckets</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.accessControlList.allowsPublicReadAccess</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.accessControlList.allowsPublicWriteAccess</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.blockPublicAccess.blockPublicAcls</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.blockPublicAccess.blockPublicPolicy</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.blockPublicAccess.ignorePublicAcls</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.blockPublicAccess.restrictPublicBuckets</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.bucketPolicy.allowsPublicReadAccess</para></li><li><para>resource.s3BucketDetails.publicAccess.permissionConfiguration.bucketLevelPermissions.bucketPolicy.allowsPublicWriteAccess</para></li><li><para>resource.s3BucketDetails.s3ObjectDetails.eTag</para></li><li><para>resource.s3BucketDetails.s3ObjectDetails.hash</para></li><li><para>resource.s3BucketDetails.s3ObjectDetails.key</para></li><li><para>resource.s3BucketDetails.s3ObjectDetails.objectArn</para></li><li><para>resource.s3BucketDetails.s3ObjectDetails.versionId</para></li><li><para>resource.s3BucketDetails.tags.key</para></li><li><para>resource.s3BucketDetails.tags.value</para></li><li><para>resource.s3BucketDetails.type</para></li><li><para>schemaVersion</para></li><li><para>service.action.actionType</para></li><li><para>service.action.awsApiCallAction.affectedResources</para></li><li><para>service.action.awsApiCallAction.api</para></li><li><para>service.action.awsApiCallAction.callerType</para></li><li><para>service.action.awsApiCallAction.domainDetails.domain</para></li><li><para>service.action.awsApiCallAction.errorCode</para></li><li><para>service.action.awsApiCallAction.remoteAccountDetails.accountId</para></li><li><para>service.action.awsApiCallAction.remoteAccountDetails.affiliated</para></li><li><para>service.action.awsApiCallAction.remoteAccountDetails.awsServiceName</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.country.countryCode</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.geoLocation.lat</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.geoLocation.lon</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.ipAddressV6</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.isp</para></li><li><para>service.action.awsApiCallAction.remoteIpDetails.organization.org</para></li><li><para>service.action.awsApiCallAction.serviceName</para></li><li><para>service.action.awsApiCallAction.userAgent</para></li><li><para>service.action.dnsRequestAction.blocked</para></li><li><para>service.action.dnsRequestAction.domain</para></li><li><para>service.action.dnsRequestAction.domainWithSuffix</para></li><li><para>service.action.dnsRequestAction.protocol</para></li><li><para>service.action.dnsRequestAction.vpcOwnerAccountId</para></li><li><para>service.action.kubernetesApiCallAction.namespace</para></li><li><para>service.action.kubernetesApiCallAction.parameters</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.country.countryCode</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.geoLocation.lat</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.geoLocation.lon</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.ipAddressV6</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.organization.isp</para></li><li><para>service.action.kubernetesApiCallAction.remoteIpDetails.organization.org</para></li><li><para>service.action.kubernetesApiCallAction.requestUri</para></li><li><para>service.action.kubernetesApiCallAction.resource</para></li><li><para>service.action.kubernetesApiCallAction.resourceName</para></li><li><para>service.action.kubernetesApiCallAction.sourceIPs</para></li><li><para>service.action.kubernetesApiCallAction.statusCode</para></li><li><para>service.action.kubernetesApiCallAction.subresource</para></li><li><para>service.action.kubernetesApiCallAction.userAgent</para></li><li><para>service.action.kubernetesApiCallAction.verb</para></li><li><para>service.action.kubernetesPermissionCheckedDetails.allowed</para></li><li><para>service.action.kubernetesPermissionCheckedDetails.namespace</para></li><li><para>service.action.kubernetesPermissionCheckedDetails.resource</para></li><li><para>service.action.kubernetesPermissionCheckedDetails.verb</para></li><li><para>service.action.kubernetesRoleBindingDetails.kind</para></li><li><para>service.action.kubernetesRoleBindingDetails.name</para></li><li><para>service.action.kubernetesRoleBindingDetails.roleRefKind</para></li><li><para>service.action.kubernetesRoleBindingDetails.roleRefName</para></li><li><para>service.action.kubernetesRoleBindingDetails.uid</para></li><li><para>service.action.kubernetesRoleDetails.kind</para></li><li><para>service.action.kubernetesRoleDetails.name</para></li><li><para>service.action.kubernetesRoleDetails.uid</para></li><li><para>service.action.networkConnectionAction.blocked</para></li><li><para>service.action.networkConnectionAction.connectionDirection</para></li><li><para>service.action.networkConnectionAction.localIpDetails.ipAddressV4</para></li><li><para>service.action.networkConnectionAction.localIpDetails.ipAddressV6</para></li><li><para>service.action.networkConnectionAction.localNetworkInterface</para></li><li><para>service.action.networkConnectionAction.localPortDetails.port</para></li><li><para>service.action.networkConnectionAction.localPortDetails.portName</para></li><li><para>service.action.networkConnectionAction.protocol</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.country.countryCode</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.geoLocation.lat</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.geoLocation.lon</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.ipAddressV6</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.isp</para></li><li><para>service.action.networkConnectionAction.remoteIpDetails.organization.org</para></li><li><para>service.action.networkConnectionAction.remotePortDetails.port</para></li><li><para>service.action.networkConnectionAction.remotePortDetails.portName</para></li><li><para>service.action.portProbeAction.blocked</para></li><li><para>service.action.portProbeAction.portProbeDetails.localIpDetails.ipAddressV4</para></li><li><para>service.action.portProbeAction.portProbeDetails.localIpDetails.ipAddressV6</para></li><li><para>service.action.portProbeAction.portProbeDetails.localPortDetails.port</para></li><li><para>service.action.portProbeAction.portProbeDetails.localPortDetails.portName</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.city.cityName</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.country.countryCode</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.country.countryName</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.geoLocation.lat</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.geoLocation.lon</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.ipAddressV6</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.organization.asn</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.organization.isp</para></li><li><para>service.action.portProbeAction.portProbeDetails.remoteIpDetails.organization.org</para></li><li><para>service.action.rdsLoginAttemptAction.loginAttributes.application</para></li><li><para>service.action.rdsLoginAttemptAction.loginAttributes.failedLoginAttempts</para></li><li><para>service.action.rdsLoginAttemptAction.loginAttributes.successfulLoginAttempts</para></li><li><para>service.action.rdsLoginAttemptAction.loginAttributes.user</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.city.cityName</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.country.countryCode</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.country.countryName</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.geoLocation.lat</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.geoLocation.lon</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.ipAddressV4</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.ipAddressV6</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.organization.asn</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.organization.asnOrg</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.organization.isp</para></li><li><para>service.action.rdsLoginAttemptAction.remoteIpDetails.organization.org</para></li><li><para>service.additionalInfo.agentDetails.agentId</para></li><li><para>service.additionalInfo.agentDetails.agentVersion</para></li><li><para>service.additionalInfo.anomalies.anomalousAPIs</para></li><li><para>service.additionalInfo.authenticationMethod</para></li><li><para>service.additionalInfo.averagePacketSizeIn</para></li><li><para>service.additionalInfo.averagePacketSizeOut</para></li><li><para>service.additionalInfo.context</para></li><li><para>service.additionalInfo.domain</para></li><li><para>service.additionalInfo.inBytes</para></li><li><para>service.additionalInfo.localNetworkInterfaceOwner</para></li><li><para>service.additionalInfo.localPort</para></li><li><para>service.additionalInfo.outBytes</para></li><li><para>service.additionalInfo.packetsIn</para></li><li><para>service.additionalInfo.packetsOut</para></li><li><para>service.additionalInfo.policyArn</para></li><li><para>service.additionalInfo.policyName</para></li><li><para>service.additionalInfo.remotePort</para></li><li><para>service.additionalInfo.sample</para></li><li><para>service.additionalInfo.scannedPort</para></li><li><para>service.additionalInfo.threatFileSha256</para></li><li><para>service.additionalInfo.threatListName</para></li><li><para>service.additionalInfo.threatName</para></li><li><para>service.additionalInfo.totalBytesIn</para></li><li><para>service.additionalInfo.totalBytesOut</para></li><li><para>service.additionalInfo.type</para></li><li><para>service.additionalInfo.unusual.asnOrg</para></li><li><para>service.additionalInfo.unusual.port</para></li><li><para>service.additionalInfo.unusualProtocol</para></li><li><para>service.additionalInfo.userAgent.fullUserAgent</para></li><li><para>service.additionalInfo.userAgent.userAgentCategory</para></li><li><para>service.additionalInfo.value</para></li><li><para>service.additionalInfo.vpcOwnerAccountId</para></li><li><para>service.archived</para></li><li><para>service.count</para></li><li><para>service.detection.anomaly.profiles</para></li><li><para>service.detection.anomaly.unusual.behavior</para></li><li><para>service.detection.sequence.actors.id</para></li><li><para>service.detection.sequence.actors.process.name</para></li><li><para>service.detection.sequence.actors.process.path</para></li><li><para>service.detection.sequence.actors.process.sha256</para></li><li><para>service.detection.sequence.actors.session.createdTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.actors.session.issuer</para></li><li><para>service.detection.sequence.actors.session.mfaStatus</para></li><li><para>service.detection.sequence.actors.session.uid</para></li><li><para>service.detection.sequence.actors.user.account.account</para></li><li><para>service.detection.sequence.actors.user.account.uid</para></li><li><para>service.detection.sequence.actors.user.credentialUid</para></li><li><para>service.detection.sequence.actors.user.name</para></li><li><para>service.detection.sequence.actors.user.type</para></li><li><para>service.detection.sequence.actors.user.uid</para></li><li><para>service.detection.sequence.additionalSequenceTypes</para></li><li><para>service.detection.sequence.description</para></li><li><para>service.detection.sequence.endpoints.autonomousSystem.name</para></li><li><para>service.detection.sequence.endpoints.autonomousSystem.number</para></li><li><para>service.detection.sequence.endpoints.connection.direction</para></li><li><para>service.detection.sequence.endpoints.domain</para></li><li><para>service.detection.sequence.endpoints.id</para></li><li><para>service.detection.sequence.endpoints.ip</para></li><li><para>service.detection.sequence.endpoints.location.city</para></li><li><para>service.detection.sequence.endpoints.location.country</para></li><li><para>service.detection.sequence.endpoints.location.lat</para></li><li><para>service.detection.sequence.endpoints.location.lon</para></li><li><para>service.detection.sequence.endpoints.port</para></li><li><para>service.detection.sequence.resources.accountId</para></li><li><para>service.detection.sequence.resources.cloudPartition</para></li><li><para>service.detection.sequence.resources.data.accessKey.principalId</para></li><li><para>service.detection.sequence.resources.data.accessKey.userName</para></li><li><para>service.detection.sequence.resources.data.accessKey.userType</para></li><li><para>service.detection.sequence.resources.data.autoscalingAutoScalingGroup.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.cloudformationStack.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.container.image</para></li><li><para>service.detection.sequence.resources.data.container.imageUid</para></li><li><para>service.detection.sequence.resources.data.ec2Image.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.availabilityZone</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.ec2NetworkInterfaceUids</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.iamInstanceProfile.arn</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.iamInstanceProfile.id</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.imageDescription</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.instanceState</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.instanceType</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.outpostArn</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.platform</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.productCodes.productCodeId</para></li><li><para>service.detection.sequence.resources.data.ec2Instance.productCodes.productCodeType</para></li><li><para>service.detection.sequence.resources.data.ec2LaunchTemplate.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.ec2LaunchTemplate.version</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.ipv6Addresses</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.privateIpAddresses.privateDnsName</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.privateIpAddresses.privateIpAddress</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.publicIp</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.securityGroups.groupId</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.securityGroups.groupName</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.subNetId</para></li><li><para>service.detection.sequence.resources.data.ec2NetworkInterface.vpcId</para></li><li><para>service.detection.sequence.resources.data.ec2Vpc.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.ecsCluster.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.ecsCluster.status</para></li><li><para>service.detection.sequence.resources.data.ecsTask.containerUids</para></li><li><para>service.detection.sequence.resources.data.ecsTask.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.resources.data.ecsTask.launchType</para></li><li><para>service.detection.sequence.resources.data.ecsTask.taskDefinitionArn</para></li><li><para>service.detection.sequence.resources.data.eksCluster.arn</para></li><li><para>service.detection.sequence.resources.data.eksCluster.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.resources.data.eksCluster.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.eksCluster.status</para></li><li><para>service.detection.sequence.resources.data.eksCluster.vpcId</para></li><li><para>service.detection.sequence.resources.data.iamInstanceProfile.ec2InstanceUids</para></li><li><para>service.detection.sequence.resources.data.iamInstanceProfile.id</para></li><li><para>service.detection.sequence.resources.data.kubernetesWorkload.containerUids</para></li><li><para>service.detection.sequence.resources.data.kubernetesWorkload.namespace</para></li><li><para>service.detection.sequence.resources.data.kubernetesWorkload.type</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.accountPublicAccess.publicAclAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.accountPublicAccess.publicAclIgnoreBehavior</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.accountPublicAccess.publicBucketRestrictBehavior</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.accountPublicAccess.publicPolicyAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.bucketPublicAccess.publicAclAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.bucketPublicAccess.publicAclIgnoreBehavior</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.bucketPublicAccess.publicBucketRestrictBehavior</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.bucketPublicAccess.publicPolicyAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.effectivePermission</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.encryptionKeyArn</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.encryptionType</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.ownerId</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.publicReadAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.publicWriteAccess</para></li><li><para>service.detection.sequence.resources.data.s3Bucket.s3ObjectUids</para></li><li><para>service.detection.sequence.resources.data.s3Object.eTag</para></li><li><para>service.detection.sequence.resources.data.s3Object.key</para></li><li><para>service.detection.sequence.resources.data.s3Object.versionId</para></li><li><para>service.detection.sequence.resources.name</para></li><li><para>service.detection.sequence.resources.region</para></li><li><para>service.detection.sequence.resources.resourceType</para></li><li><para>service.detection.sequence.resources.service</para></li><li><para>service.detection.sequence.resources.tags.key</para></li><li><para>service.detection.sequence.resources.tags.value</para></li><li><para>service.detection.sequence.resources.uid</para></li><li><para>service.detection.sequence.sequenceIndicators.key</para></li><li><para>service.detection.sequence.sequenceIndicators.title</para></li><li><para>service.detection.sequence.sequenceIndicators.values</para></li><li><para>service.detection.sequence.signals.actorIds</para></li><li><para>service.detection.sequence.signals.count</para></li><li><para>service.detection.sequence.signals.createdAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.signals.description</para></li><li><para>service.detection.sequence.signals.endpointIds</para></li><li><para>service.detection.sequence.signals.firstSeenAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.signals.lastSeenAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.signals.name</para></li><li><para>service.detection.sequence.signals.resourceUids</para></li><li><para>service.detection.sequence.signals.severity</para></li><li><para>service.detection.sequence.signals.signalIndicators.key</para></li><li><para>service.detection.sequence.signals.signalIndicators.title</para></li><li><para>service.detection.sequence.signals.signalIndicators.values</para></li><li><para>service.detection.sequence.signals.type</para></li><li><para>service.detection.sequence.signals.uid</para></li><li><para>service.detection.sequence.signals.updatedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.detection.sequence.uid</para></li><li><para>service.detectorId</para></li><li><para>service.ebsVolumeScanDetails.scanCompletedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.highestSeverityThreatDetails.count</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.highestSeverityThreatDetails.severity</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.highestSeverityThreatDetails.threatName</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.scannedItemCount.files</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.scannedItemCount.totalGb</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.scannedItemCount.volumes</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.itemCount</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.shortened</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.filePaths.fileName</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.filePaths.filePath</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.filePaths.hash</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.filePaths.volumeArn</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.itemCount</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.name</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.threatNames.severity</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatDetectedByName.uniqueThreatNameCount</para></li><li><para>service.ebsVolumeScanDetails.scanDetections.threatsDetectedItemCount.files</para></li><li><para>service.ebsVolumeScanDetails.scanId</para></li><li><para>service.ebsVolumeScanDetails.scanStartedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.ebsVolumeScanDetails.scanType</para></li><li><para>service.ebsVolumeScanDetails.sources</para></li><li><para>service.ebsVolumeScanDetails.triggerFindingId</para></li><li><para>service.eventFirstSeen</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.eventLastSeen</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.evidence.threatIntelligenceDetails.threatFileSha256</para></li><li><para>service.evidence.threatIntelligenceDetails.threatListName</para></li><li><para>service.evidence.threatIntelligenceDetails.threatNames</para></li><li><para>service.featureName</para></li><li><para>service.malwareScanDetails.scanCategory</para></li><li><para>service.malwareScanDetails.scanConfiguration.incrementalScanDetails.baselineResourceArn</para></li><li><para>service.malwareScanDetails.scanConfiguration.triggerType</para></li><li><para>service.malwareScanDetails.scanId</para></li><li><para>service.malwareScanDetails.scanType</para></li><li><para>service.malwareScanDetails.threats.count</para></li><li><para>service.malwareScanDetails.threats.hash</para></li><li><para>service.malwareScanDetails.threats.itemDetails.additionalInfo.deviceName</para></li><li><para>service.malwareScanDetails.threats.itemDetails.additionalInfo.versionId</para></li><li><para>service.malwareScanDetails.threats.itemDetails.hash</para></li><li><para>service.malwareScanDetails.threats.itemDetails.itemPath</para></li><li><para>service.malwareScanDetails.threats.itemDetails.resourceArn</para></li><li><para>service.malwareScanDetails.threats.itemPaths.hash</para></li><li><para>service.malwareScanDetails.threats.itemPaths.nestedItemPath</para></li><li><para>service.malwareScanDetails.threats.name</para></li><li><para>service.malwareScanDetails.threats.source</para></li><li><para>service.malwareScanDetails.uniqueThreatCount</para></li><li><para>service.resourceRole</para></li><li><para>service.runtimeDetails.context.addressFamily</para></li><li><para>service.runtimeDetails.context.commandLineExample</para></li><li><para>service.runtimeDetails.context.fileOperation</para></li><li><para>service.runtimeDetails.context.filePath</para></li><li><para>service.runtimeDetails.context.fileSystemType</para></li><li><para>service.runtimeDetails.context.flags</para></li><li><para>service.runtimeDetails.context.ianaProtocolNumber</para></li><li><para>service.runtimeDetails.context.ldPreloadValue</para></li><li><para>service.runtimeDetails.context.libraryPath</para></li><li><para>service.runtimeDetails.context.memoryRegions</para></li><li><para>service.runtimeDetails.context.modifiedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.context.modifyingProcess.euid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.executablePath</para></li><li><para>service.runtimeDetails.context.modifyingProcess.executableSha256</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.euid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.executablePath</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.name</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.namespacePid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.parentUuid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.pid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.userId</para></li><li><para>service.runtimeDetails.context.modifyingProcess.lineage.uuid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.name</para></li><li><para>service.runtimeDetails.context.modifyingProcess.namespacePid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.parentUuid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.pid</para></li><li><para>service.runtimeDetails.context.modifyingProcess.pwd</para></li><li><para>service.runtimeDetails.context.modifyingProcess.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.context.modifyingProcess.user</para></li><li><para>service.runtimeDetails.context.modifyingProcess.userId</para></li><li><para>service.runtimeDetails.context.modifyingProcess.uuid</para></li><li><para>service.runtimeDetails.context.moduleFilePath</para></li><li><para>service.runtimeDetails.context.moduleName</para></li><li><para>service.runtimeDetails.context.moduleSha256</para></li><li><para>service.runtimeDetails.context.mountSource</para></li><li><para>service.runtimeDetails.context.mountTarget</para></li><li><para>service.runtimeDetails.context.relatedFilePaths</para></li><li><para>service.runtimeDetails.context.releaseAgentPath</para></li><li><para>service.runtimeDetails.context.runcBinaryPath</para></li><li><para>service.runtimeDetails.context.scriptPath</para></li><li><para>service.runtimeDetails.context.serviceName</para></li><li><para>service.runtimeDetails.context.shellHistoryFilePath</para></li><li><para>service.runtimeDetails.context.socketPath</para></li><li><para>service.runtimeDetails.context.targetProcess.euid</para></li><li><para>service.runtimeDetails.context.targetProcess.executablePath</para></li><li><para>service.runtimeDetails.context.targetProcess.executableSha256</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.euid</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.executablePath</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.name</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.namespacePid</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.parentUuid</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.pid</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.userId</para></li><li><para>service.runtimeDetails.context.targetProcess.lineage.uuid</para></li><li><para>service.runtimeDetails.context.targetProcess.name</para></li><li><para>service.runtimeDetails.context.targetProcess.namespacePid</para></li><li><para>service.runtimeDetails.context.targetProcess.parentUuid</para></li><li><para>service.runtimeDetails.context.targetProcess.pid</para></li><li><para>service.runtimeDetails.context.targetProcess.pwd</para></li><li><para>service.runtimeDetails.context.targetProcess.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.context.targetProcess.user</para></li><li><para>service.runtimeDetails.context.targetProcess.userId</para></li><li><para>service.runtimeDetails.context.targetProcess.uuid</para></li><li><para>service.runtimeDetails.context.threatFilePath</para></li><li><para>service.runtimeDetails.context.toolCategory</para></li><li><para>service.runtimeDetails.context.toolName</para></li><li><para>service.runtimeDetails.process.euid</para></li><li><para>service.runtimeDetails.process.executablePath</para></li><li><para>service.runtimeDetails.process.executableSha256</para></li><li><para>service.runtimeDetails.process.lineage.euid</para></li><li><para>service.runtimeDetails.process.lineage.executablePath</para></li><li><para>service.runtimeDetails.process.lineage.name</para></li><li><para>service.runtimeDetails.process.lineage.namespacePid</para></li><li><para>service.runtimeDetails.process.lineage.parentUuid</para></li><li><para>service.runtimeDetails.process.lineage.pid</para></li><li><para>service.runtimeDetails.process.lineage.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.process.lineage.userId</para></li><li><para>service.runtimeDetails.process.lineage.uuid</para></li><li><para>service.runtimeDetails.process.name</para></li><li><para>service.runtimeDetails.process.namespacePid</para></li><li><para>service.runtimeDetails.process.parentUuid</para></li><li><para>service.runtimeDetails.process.pid</para></li><li><para>service.runtimeDetails.process.pwd</para></li><li><para>service.runtimeDetails.process.startTime</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li><li><para>service.runtimeDetails.process.user</para></li><li><para>service.runtimeDetails.process.userId</para></li><li><para>service.runtimeDetails.process.uuid</para></li><li><para>service.serviceName</para></li><li><para>service.userFeedback</para></li><li><para>severity</para><para>To configure severity based filters, use the following for the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_FindingCriteria.html">FindingCriteria</a>
        /// condition:</para><ul><li><para><b>Low</b>: <c>["1", "2", "3"]</c></para></li><li><para><b>Medium</b>: <c>["4", "5", "6"]</c></para></li><li><para><b>High</b>: <c>["7", "8"]</c></para></li><li><para><b>Critical</b>: <c>["9", "10"]</c></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_findings-severity.html">Findings
        /// severity levels</a> in the <i>Amazon GuardDuty User Guide</i>.</para></li><li><para>title</para></li><li><para>type</para></li><li><para>updatedAt</para><para>Type: Timestamp in Unix Epoch millisecond format. Ex: 1486685375000</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FindingCriteria")]
        public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the filter. Valid characters include period (.), underscore (_), dash
        /// (-), and alphanumeric characters. A whitespace is considered to be an invalid character.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Rank
        /// <summary>
        /// <para>
        /// <para>Specifies the position of the filter in the list of current filters. Also specifies
        /// the order in which this filter is applied to the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Rank { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be added to a new filter resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the create request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.CreateFilterResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.CreateFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDFilter (CreateFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.CreateFilterResponse, NewGDFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FindingCriterion = this.FindingCriterion;
            #if MODULAR
            if (this.FindingCriterion == null && ParameterWasBound(nameof(this.FindingCriterion)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingCriterion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rank = this.Rank;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.GuardDuty.Model.CreateFilterRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.FindingCriterion != null)
            {
                request.FindingCriteria = cmdletContext.FindingCriterion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Rank != null)
            {
                request.Rank = cmdletContext.Rank.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.GuardDuty.Model.CreateFilterResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.CreateFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "CreateFilter");
            try
            {
                return client.CreateFilterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GuardDuty.FilterAction Action { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DetectorId { get; set; }
            public Amazon.GuardDuty.Model.FindingCriteria FindingCriterion { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Rank { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GuardDuty.Model.CreateFilterResponse, NewGDFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
