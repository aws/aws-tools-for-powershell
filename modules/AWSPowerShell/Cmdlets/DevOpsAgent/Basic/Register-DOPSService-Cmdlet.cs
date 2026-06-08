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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// This operation registers the specified service
    /// </summary>
    [Cmdlet("Register", "DOPSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.RegisterServiceResponse")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service RegisterService API operation.", Operation = new[] {"RegisterService"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.RegisterServiceResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.RegisterServiceResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.RegisterServiceResponse object containing multiple properties."
    )]
    public partial class RegisterDOPSServiceCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId
        /// <summary>
        /// <para>
        /// <para>New Relic Account ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Dynatrace_AccountUrn
        /// <summary>
        /// <para>
        /// <para>Dynatrace resource account urn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Dynatrace_AccountUrn { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId
        /// <summary>
        /// <para>
        /// <para>List of alert policy IDs grouping related conditions</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyIds")]
        public System.String[] ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey
        /// <summary>
        /// <para>
        /// <para>New Relic User API Key</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the API key in requests to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the API key in requests to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the API key in requests to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName
        /// <summary>
        /// <para>
        /// <para>User friendly API key name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName
        /// <summary>
        /// <para>
        /// <para>User friendly API key name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName
        /// <summary>
        /// <para>
        /// <para>User friendly API key name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue
        /// <summary>
        /// <para>
        /// <para>API key value for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue
        /// <summary>
        /// <para>
        /// <para>API key value for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue
        /// <summary>
        /// <para>
        /// <para>API key value for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId
        /// <summary>
        /// <para>
        /// <para>List of monitored APM application IDs in New Relic</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationIds")]
        public System.String[] ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the bearer token in requests to the service. Defaults to
        /// 'Authorization' per RFC 6750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the bearer token in requests to the service. Defaults to
        /// 'Authorization' per RFC 6750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader
        /// <summary>
        /// <para>
        /// <para>HTTP header name to send the bearer token in requests to the service. Defaults to
        /// 'Authorization' per RFC 6750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl
        /// <summary>
        /// <para>
        /// <para>OAuth authorization URL for 3LO authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl
        /// <summary>
        /// <para>
        /// <para>OAuth authorization URL for 3LO authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl
        /// <summary>
        /// <para>
        /// <para>OAuth authorization URL for 3LO authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Azureidentity_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of the service principal or managed identity used for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Azureidentity_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId
        /// <summary>
        /// <para>
        /// <para>OAuth client ID for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName
        /// <summary>
        /// <para>
        /// <para>User friendly OAuth client name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service. Required for confidential
        /// clients or when PKCE is not supported. Optional for public clients using PKCE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service. Required for confidential
        /// clients or when PKCE is not supported. Optional for public clients using PKCE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service. Required for confidential
        /// clients or when PKCE is not supported. Optional for public clients using PKCE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret
        /// <summary>
        /// <para>
        /// <para>OAuth client secret for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader
        /// <summary>
        /// <para>
        /// <para>Custom headers for the SigV4 MCP server.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeaders")]
        public System.Collections.Hashtable ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the MCP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_Description { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserverdatadog_Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the MCP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserverdatadog_Description { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the MCP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_Description { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the MCP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_Description { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the MCP server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_Description { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_Endpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserverdatadog_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserverdatadog_Endpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_Endpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_Endpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_Endpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid
        /// <summary>
        /// <para>
        /// <para>List of globally unique IDs for New Relic resources (apps, hosts, services)</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuids")]
        public System.String[] ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange parameters for authenticating with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameters")]
        public System.Collections.Hashtable ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl
        /// <summary>
        /// <para>
        /// <para>OAuth token exchange URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
        #endregion
        
        #region Parameter ExchangeUrlPrivateConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the private connection to use for OAuth token exchange requests only.
        /// Cannot be specified when privateConnectionName is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExchangeUrlPrivateConnectionName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Gitlab_GroupId
        /// <summary>
        /// <para>
        /// <para>Optional GitLab group ID for group-level access tokens</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Gitlab_GroupId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Servicenow_InstanceUrl
        /// <summary>
        /// <para>
        /// <para>ServiceNow instance URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Servicenow_InstanceUrl { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Key Management Service (AWS KMS) customer managed key that's used
        /// to encrypt resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn
        /// <summary>
        /// <para>
        /// <para>IAM role ARN to assume for SigV4 signing. Optional — when omitted, credentials are
        /// resolved at runtime via a monitor account association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for the service registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_Name
        /// <summary>
        /// <para>
        /// <para>MCP server name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_Name { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserverdatadog_Name
        /// <summary>
        /// <para>
        /// <para>MCP server name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserverdatadog_Name { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_Name
        /// <summary>
        /// <para>
        /// <para>MCP server name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_Name { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_Name
        /// <summary>
        /// <para>
        /// <para>MCP server name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_Name { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_Name
        /// <summary>
        /// <para>
        /// <para>MCP server name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_Name { get; set; }
        #endregion
        
        #region Parameter PrivateConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the private connection to use for VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateConnectionName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region
        /// <summary>
        /// <para>
        /// <para>New Relic region (US or EU)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.NewRelicRegion")]
        public Amazon.DevOpsAgent.NewRelicRegion ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region
        /// <summary>
        /// <para>
        /// <para>AWS region for SigV4 signing. Use '*' for SigV4a multi-region signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to return to after OAuth flow completes (must be AWS console domain)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scopes")]
        public System.String[] ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scopes")]
        public System.String[] ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scopes")]
        public System.String[] ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scopes")]
        public System.String[] ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scopes")]
        public System.String[] ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope
        /// <summary>
        /// <para>
        /// <para>OAuth scopes for 3LO authentication. The service will always request scope offline_access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scopes")]
        public System.String[] ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Pagerduty_Scope
        /// <summary>
        /// <para>
        /// <para>PagerDuty scopes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Pagerduty_Scopes")]
        public System.String[] ServiceDetails_Pagerduty_Scope { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsAgent.PostRegisterServiceSupportedService")]
        public Amazon.DevOpsAgent.PostRegisterServiceSupportedService Service { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service
        /// <summary>
        /// <para>
        /// <para>AWS service name for SigV4 signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge
        /// <summary>
        /// <para>
        /// <para>Whether the service supports PKCE (Proof Key for Code Exchange) for enhanced security
        /// during the OAuth flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge
        /// <summary>
        /// <para>
        /// <para>Whether the service supports PKCE (Proof Key for Code Exchange) for enhanced security
        /// during the OAuth flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge
        /// <summary>
        /// <para>
        /// <para>Whether the service supports PKCE (Proof Key for Code Exchange) for enhanced security
        /// during the OAuth flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to add to the Service at registration time.</para><para />
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
        
        #region Parameter ServiceDetails_Gitlab_TargetUrl
        /// <summary>
        /// <para>
        /// <para>GitLab instance URL (e.g., https://gitlab.com or self-hosted instance).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Gitlab_TargetUrl { get; set; }
        #endregion
        
        #region Parameter TargetUrlPrivateConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the private connection to use for API calls (target URL) only. Cannot
        /// be specified when privateConnectionName is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetUrlPrivateConnectionName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Azureidentity_TenantId
        /// <summary>
        /// <para>
        /// <para>The Azure Active Directory tenant ID for the identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Azureidentity_TenantId { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName
        /// <summary>
        /// <para>
        /// <para>User friendly bearer token name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName
        /// <summary>
        /// <para>
        /// <para>User friendly bearer token name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName
        /// <summary>
        /// <para>
        /// <para>User friendly bearer token name specified by end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Gitlab_TokenType
        /// <summary>
        /// <para>
        /// <para>Type of GitLab access token</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.GitLabTokenType")]
        public Amazon.DevOpsAgent.GitLabTokenType ServiceDetails_Gitlab_TokenType { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Gitlab_TokenValue
        /// <summary>
        /// <para>
        /// <para>GitLab access token value</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Gitlab_TokenValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue
        /// <summary>
        /// <para>
        /// <para>Bearer token value in alphanumeric for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue
        /// <summary>
        /// <para>
        /// <para>Bearer token value in alphanumeric for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue
        /// <summary>
        /// <para>
        /// <para>Bearer token value in alphanumeric for authenticating with the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_EventChannel_Type
        /// <summary>
        /// <para>
        /// <para>The type of event channel</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.EventChannelType")]
        public Amazon.DevOpsAgent.EventChannelType ServiceDetails_EventChannel_Type { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Azureidentity_WebIdentityRoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN to be assumed by DevOps Agent for requesting Web Identity Token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceDetails_Azureidentity_WebIdentityRoleArn { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Azureidentity_WebIdentityTokenAudience
        /// <summary>
        /// <para>
        /// <para>The audiences for the Web Identity Token.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceDetails_Azureidentity_WebIdentityTokenAudiences")]
        public System.String[] ServiceDetails_Azureidentity_WebIdentityTokenAudience { get; set; }
        #endregion
        
        #region Parameter ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>Deprecated — use mcpRoleArn instead. IAM role ARN to assume for SigV4 signing.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use mcpRoleArn instead.")]
        public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.RegisterServiceResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.RegisterServiceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Service), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-DOPSService (RegisterService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.RegisterServiceResponse, RegisterDOPSServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExchangeUrlPrivateConnectionName = this.ExchangeUrlPrivateConnectionName;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            context.PrivateConnectionName = this.PrivateConnectionName;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceDetails_Azureidentity_ClientId = this.ServiceDetails_Azureidentity_ClientId;
            context.ServiceDetails_Azureidentity_TenantId = this.ServiceDetails_Azureidentity_TenantId;
            context.ServiceDetails_Azureidentity_WebIdentityRoleArn = this.ServiceDetails_Azureidentity_WebIdentityRoleArn;
            if (this.ServiceDetails_Azureidentity_WebIdentityTokenAudience != null)
            {
                context.ServiceDetails_Azureidentity_WebIdentityTokenAudience = new List<System.String>(this.ServiceDetails_Azureidentity_WebIdentityTokenAudience);
            }
            context.ServiceDetails_Dynatrace_AccountUrn = this.ServiceDetails_Dynatrace_AccountUrn;
            context.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_EventChannel_Type = this.ServiceDetails_EventChannel_Type;
            context.ServiceDetails_Gitlab_GroupId = this.ServiceDetails_Gitlab_GroupId;
            context.ServiceDetails_Gitlab_TargetUrl = this.ServiceDetails_Gitlab_TargetUrl;
            context.ServiceDetails_Gitlab_TokenType = this.ServiceDetails_Gitlab_TokenType;
            context.ServiceDetails_Gitlab_TokenValue = this.ServiceDetails_Gitlab_TokenValue;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader = this.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName = this.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue = this.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = this.ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader = this.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName = this.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue = this.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret;
            if (this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            if (this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope = new List<System.String>(this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope);
            }
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            if (this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                context.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope = new List<System.String>(this.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope);
            }
            context.ServiceDetails_Mcpserver_Description = this.ServiceDetails_Mcpserver_Description;
            context.ServiceDetails_Mcpserver_Endpoint = this.ServiceDetails_Mcpserver_Endpoint;
            context.ServiceDetails_Mcpserver_Name = this.ServiceDetails_Mcpserver_Name;
            context.ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = this.ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            context.ServiceDetails_Mcpserverdatadog_Description = this.ServiceDetails_Mcpserverdatadog_Description;
            context.ServiceDetails_Mcpserverdatadog_Endpoint = this.ServiceDetails_Mcpserverdatadog_Endpoint;
            context.ServiceDetails_Mcpserverdatadog_Name = this.ServiceDetails_Mcpserverdatadog_Name;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret;
            if (this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            if (this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope = new List<System.String>(this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope);
            }
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            if (this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                context.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope = new List<System.String>(this.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope);
            }
            context.ServiceDetails_Mcpservergrafana_Description = this.ServiceDetails_Mcpservergrafana_Description;
            context.ServiceDetails_Mcpservergrafana_Endpoint = this.ServiceDetails_Mcpservergrafana_Endpoint;
            context.ServiceDetails_Mcpservergrafana_Name = this.ServiceDetails_Mcpservergrafana_Name;
            context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId = this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId;
            if (this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId != null)
            {
                context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId = new List<System.String>(this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId);
            }
            context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey = this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey;
            if (this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId != null)
            {
                context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId = new List<System.String>(this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId);
            }
            if (this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid != null)
            {
                context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid = new List<System.String>(this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid);
            }
            context.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region = this.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region;
            if (this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader != null)
            {
                context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader.Keys)
                {
                    context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader[hashKey]));
                }
            }
            context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn = this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn;
            context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region = this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region;
            context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn = this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn;
            context.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service = this.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service;
            context.ServiceDetails_Mcpserversigv4_Description = this.ServiceDetails_Mcpserversigv4_Description;
            context.ServiceDetails_Mcpserversigv4_Endpoint = this.ServiceDetails_Mcpserversigv4_Endpoint;
            context.ServiceDetails_Mcpserversigv4_Name = this.ServiceDetails_Mcpserversigv4_Name;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret;
            if (this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            if (this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope = new List<System.String>(this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope);
            }
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            if (this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                context.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope = new List<System.String>(this.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope);
            }
            context.ServiceDetails_Mcpserversplunk_Description = this.ServiceDetails_Mcpserversplunk_Description;
            context.ServiceDetails_Mcpserversplunk_Endpoint = this.ServiceDetails_Mcpserversplunk_Endpoint;
            context.ServiceDetails_Mcpserversplunk_Name = this.ServiceDetails_Mcpserversplunk_Name;
            context.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            if (this.ServiceDetails_Pagerduty_Scope != null)
            {
                context.ServiceDetails_Pagerduty_Scope = new List<System.String>(this.ServiceDetails_Pagerduty_Scope);
            }
            context.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId = this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId;
            context.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName = this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName;
            context.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret = this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            if (this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                context.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Keys)
                {
                    context.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter.Add((String)hashKey, (System.String)(this.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter[hashKey]));
                }
            }
            context.ServiceDetails_Servicenow_InstanceUrl = this.ServiceDetails_Servicenow_InstanceUrl;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetUrlPrivateConnectionName = this.TargetUrlPrivateConnectionName;
            
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
            var request = new Amazon.DevOpsAgent.Model.RegisterServiceRequest();
            
            if (cmdletContext.ExchangeUrlPrivateConnectionName != null)
            {
                request.ExchangeUrlPrivateConnectionName = cmdletContext.ExchangeUrlPrivateConnectionName;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PrivateConnectionName != null)
            {
                request.PrivateConnectionName = cmdletContext.PrivateConnectionName;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            
             // populate ServiceDetails
            var requestServiceDetailsIsNull = true;
            request.ServiceDetails = new Amazon.DevOpsAgent.Model.ServiceDetails();
            Amazon.DevOpsAgent.Model.EventChannelDetails requestServiceDetails_serviceDetails_EventChannel = null;
            
             // populate EventChannel
            var requestServiceDetails_serviceDetails_EventChannelIsNull = true;
            requestServiceDetails_serviceDetails_EventChannel = new Amazon.DevOpsAgent.Model.EventChannelDetails();
            Amazon.DevOpsAgent.EventChannelType requestServiceDetails_serviceDetails_EventChannel_serviceDetails_EventChannel_Type = null;
            if (cmdletContext.ServiceDetails_EventChannel_Type != null)
            {
                requestServiceDetails_serviceDetails_EventChannel_serviceDetails_EventChannel_Type = cmdletContext.ServiceDetails_EventChannel_Type;
            }
            if (requestServiceDetails_serviceDetails_EventChannel_serviceDetails_EventChannel_Type != null)
            {
                requestServiceDetails_serviceDetails_EventChannel.Type = requestServiceDetails_serviceDetails_EventChannel_serviceDetails_EventChannel_Type;
                requestServiceDetails_serviceDetails_EventChannelIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_EventChannel should be set to null
            if (requestServiceDetails_serviceDetails_EventChannelIsNull)
            {
                requestServiceDetails_serviceDetails_EventChannel = null;
            }
            if (requestServiceDetails_serviceDetails_EventChannel != null)
            {
                request.ServiceDetails.EventChannel = requestServiceDetails_serviceDetails_EventChannel;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.NewRelicServiceDetails requestServiceDetails_serviceDetails_Mcpservernewrelic = null;
            
             // populate Mcpservernewrelic
            var requestServiceDetails_serviceDetails_McpservernewrelicIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservernewrelic = new Amazon.DevOpsAgent.Model.NewRelicServiceDetails();
            Amazon.DevOpsAgent.Model.NewRelicServiceAuthorizationConfig requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig = new Amazon.DevOpsAgent.Model.NewRelicServiceAuthorizationConfig();
            Amazon.DevOpsAgent.Model.NewRelicApiKeyConfig requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey = null;
            
             // populate ApiKey
            var requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey = new Amazon.DevOpsAgent.Model.NewRelicApiKeyConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.AccountId = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.AlertPolicyIds = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.ApiKey = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.ApplicationIds = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.EntityGuids = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
            Amazon.DevOpsAgent.NewRelicRegion requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region = null;
            if (cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region = cmdletContext.ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey.Region = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKeyIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig.ApiKey = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig_serviceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey;
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpservernewrelic_serviceDetails_Mcpservernewrelic_AuthorizationConfig;
                requestServiceDetails_serviceDetails_McpservernewrelicIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservernewrelic should be set to null
            if (requestServiceDetails_serviceDetails_McpservernewrelicIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservernewrelic = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservernewrelic != null)
            {
                request.ServiceDetails.Mcpservernewrelic = requestServiceDetails_serviceDetails_Mcpservernewrelic;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.DynatraceServiceDetails requestServiceDetails_serviceDetails_Dynatrace = null;
            
             // populate Dynatrace
            var requestServiceDetails_serviceDetails_DynatraceIsNull = true;
            requestServiceDetails_serviceDetails_Dynatrace = new Amazon.DevOpsAgent.Model.DynatraceServiceDetails();
            System.String requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AccountUrn = null;
            if (cmdletContext.ServiceDetails_Dynatrace_AccountUrn != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AccountUrn = cmdletContext.ServiceDetails_Dynatrace_AccountUrn;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AccountUrn != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace.AccountUrn = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AccountUrn;
                requestServiceDetails_serviceDetails_DynatraceIsNull = false;
            }
            Amazon.DevOpsAgent.Model.DynatraceServiceAuthorizationConfig requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig = new Amazon.DevOpsAgent.Model.DynatraceServiceAuthorizationConfig();
            Amazon.DevOpsAgent.Model.DynatraceOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.DynatraceOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig_serviceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Dynatrace.AuthorizationConfig = requestServiceDetails_serviceDetails_Dynatrace_serviceDetails_Dynatrace_AuthorizationConfig;
                requestServiceDetails_serviceDetails_DynatraceIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Dynatrace should be set to null
            if (requestServiceDetails_serviceDetails_DynatraceIsNull)
            {
                requestServiceDetails_serviceDetails_Dynatrace = null;
            }
            if (requestServiceDetails_serviceDetails_Dynatrace != null)
            {
                request.ServiceDetails.Dynatrace = requestServiceDetails_serviceDetails_Dynatrace;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.PagerDutyDetails requestServiceDetails_serviceDetails_Pagerduty = null;
            
             // populate Pagerduty
            var requestServiceDetails_serviceDetails_PagerdutyIsNull = true;
            requestServiceDetails_serviceDetails_Pagerduty = new Amazon.DevOpsAgent.Model.PagerDutyDetails();
            List<System.String> requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_Scope = null;
            if (cmdletContext.ServiceDetails_Pagerduty_Scope != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_Scope = cmdletContext.ServiceDetails_Pagerduty_Scope;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_Scope != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty.Scopes = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_Scope;
                requestServiceDetails_serviceDetails_PagerdutyIsNull = false;
            }
            Amazon.DevOpsAgent.Model.PagerDutyAuthorizationConfig requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig = new Amazon.DevOpsAgent.Model.PagerDutyAuthorizationConfig();
            Amazon.DevOpsAgent.Model.PagerDutyOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.PagerDutyOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig_serviceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Pagerduty.AuthorizationConfig = requestServiceDetails_serviceDetails_Pagerduty_serviceDetails_Pagerduty_AuthorizationConfig;
                requestServiceDetails_serviceDetails_PagerdutyIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Pagerduty should be set to null
            if (requestServiceDetails_serviceDetails_PagerdutyIsNull)
            {
                requestServiceDetails_serviceDetails_Pagerduty = null;
            }
            if (requestServiceDetails_serviceDetails_Pagerduty != null)
            {
                request.ServiceDetails.Pagerduty = requestServiceDetails_serviceDetails_Pagerduty;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ServiceNowServiceDetails requestServiceDetails_serviceDetails_Servicenow = null;
            
             // populate Servicenow
            var requestServiceDetails_serviceDetails_ServicenowIsNull = true;
            requestServiceDetails_serviceDetails_Servicenow = new Amazon.DevOpsAgent.Model.ServiceNowServiceDetails();
            System.String requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_InstanceUrl = null;
            if (cmdletContext.ServiceDetails_Servicenow_InstanceUrl != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_InstanceUrl = cmdletContext.ServiceDetails_Servicenow_InstanceUrl;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_InstanceUrl != null)
            {
                requestServiceDetails_serviceDetails_Servicenow.InstanceUrl = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_InstanceUrl;
                requestServiceDetails_serviceDetails_ServicenowIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ServiceNowServiceAuthorizationConfig requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig = new Amazon.DevOpsAgent.Model.ServiceNowServiceAuthorizationConfig();
            Amazon.DevOpsAgent.Model.ServiceNowOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.ServiceNowOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig_serviceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Servicenow.AuthorizationConfig = requestServiceDetails_serviceDetails_Servicenow_serviceDetails_Servicenow_AuthorizationConfig;
                requestServiceDetails_serviceDetails_ServicenowIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Servicenow should be set to null
            if (requestServiceDetails_serviceDetails_ServicenowIsNull)
            {
                requestServiceDetails_serviceDetails_Servicenow = null;
            }
            if (requestServiceDetails_serviceDetails_Servicenow != null)
            {
                request.ServiceDetails.Servicenow = requestServiceDetails_serviceDetails_Servicenow;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.RegisteredAzureIdentityDetails requestServiceDetails_serviceDetails_Azureidentity = null;
            
             // populate Azureidentity
            var requestServiceDetails_serviceDetails_AzureidentityIsNull = true;
            requestServiceDetails_serviceDetails_Azureidentity = new Amazon.DevOpsAgent.Model.RegisteredAzureIdentityDetails();
            System.String requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_ClientId = null;
            if (cmdletContext.ServiceDetails_Azureidentity_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_ClientId = cmdletContext.ServiceDetails_Azureidentity_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity.ClientId = requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_ClientId;
                requestServiceDetails_serviceDetails_AzureidentityIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_TenantId = null;
            if (cmdletContext.ServiceDetails_Azureidentity_TenantId != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_TenantId = cmdletContext.ServiceDetails_Azureidentity_TenantId;
            }
            if (requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_TenantId != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity.TenantId = requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_TenantId;
                requestServiceDetails_serviceDetails_AzureidentityIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityRoleArn = null;
            if (cmdletContext.ServiceDetails_Azureidentity_WebIdentityRoleArn != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityRoleArn = cmdletContext.ServiceDetails_Azureidentity_WebIdentityRoleArn;
            }
            if (requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityRoleArn != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity.WebIdentityRoleArn = requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityRoleArn;
                requestServiceDetails_serviceDetails_AzureidentityIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityTokenAudience = null;
            if (cmdletContext.ServiceDetails_Azureidentity_WebIdentityTokenAudience != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityTokenAudience = cmdletContext.ServiceDetails_Azureidentity_WebIdentityTokenAudience;
            }
            if (requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityTokenAudience != null)
            {
                requestServiceDetails_serviceDetails_Azureidentity.WebIdentityTokenAudiences = requestServiceDetails_serviceDetails_Azureidentity_serviceDetails_Azureidentity_WebIdentityTokenAudience;
                requestServiceDetails_serviceDetails_AzureidentityIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Azureidentity should be set to null
            if (requestServiceDetails_serviceDetails_AzureidentityIsNull)
            {
                requestServiceDetails_serviceDetails_Azureidentity = null;
            }
            if (requestServiceDetails_serviceDetails_Azureidentity != null)
            {
                request.ServiceDetails.Azureidentity = requestServiceDetails_serviceDetails_Azureidentity;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.GitLabDetails requestServiceDetails_serviceDetails_Gitlab = null;
            
             // populate Gitlab
            var requestServiceDetails_serviceDetails_GitlabIsNull = true;
            requestServiceDetails_serviceDetails_Gitlab = new Amazon.DevOpsAgent.Model.GitLabDetails();
            System.String requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_GroupId = null;
            if (cmdletContext.ServiceDetails_Gitlab_GroupId != null)
            {
                requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_GroupId = cmdletContext.ServiceDetails_Gitlab_GroupId;
            }
            if (requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_GroupId != null)
            {
                requestServiceDetails_serviceDetails_Gitlab.GroupId = requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_GroupId;
                requestServiceDetails_serviceDetails_GitlabIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TargetUrl = null;
            if (cmdletContext.ServiceDetails_Gitlab_TargetUrl != null)
            {
                requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TargetUrl = cmdletContext.ServiceDetails_Gitlab_TargetUrl;
            }
            if (requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TargetUrl != null)
            {
                requestServiceDetails_serviceDetails_Gitlab.TargetUrl = requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TargetUrl;
                requestServiceDetails_serviceDetails_GitlabIsNull = false;
            }
            Amazon.DevOpsAgent.GitLabTokenType requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenType = null;
            if (cmdletContext.ServiceDetails_Gitlab_TokenType != null)
            {
                requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenType = cmdletContext.ServiceDetails_Gitlab_TokenType;
            }
            if (requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenType != null)
            {
                requestServiceDetails_serviceDetails_Gitlab.TokenType = requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenType;
                requestServiceDetails_serviceDetails_GitlabIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenValue = null;
            if (cmdletContext.ServiceDetails_Gitlab_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenValue = cmdletContext.ServiceDetails_Gitlab_TokenValue;
            }
            if (requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Gitlab.TokenValue = requestServiceDetails_serviceDetails_Gitlab_serviceDetails_Gitlab_TokenValue;
                requestServiceDetails_serviceDetails_GitlabIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Gitlab should be set to null
            if (requestServiceDetails_serviceDetails_GitlabIsNull)
            {
                requestServiceDetails_serviceDetails_Gitlab = null;
            }
            if (requestServiceDetails_serviceDetails_Gitlab != null)
            {
                request.ServiceDetails.Gitlab = requestServiceDetails_serviceDetails_Gitlab;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerDetails requestServiceDetails_serviceDetails_Mcpserver = null;
            
             // populate Mcpserver
            var requestServiceDetails_serviceDetails_McpserverIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver = new Amazon.DevOpsAgent.Model.MCPServerDetails();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Description = null;
            if (cmdletContext.ServiceDetails_Mcpserver_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Description = cmdletContext.ServiceDetails_Mcpserver_Description;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver.Description = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Description;
                requestServiceDetails_serviceDetails_McpserverIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Endpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserver_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Endpoint = cmdletContext.ServiceDetails_Mcpserver_Endpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver.Endpoint = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Endpoint;
                requestServiceDetails_serviceDetails_McpserverIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Name = null;
            if (cmdletContext.ServiceDetails_Mcpserver_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Name = cmdletContext.ServiceDetails_Mcpserver_Name;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver.Name = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_Name;
                requestServiceDetails_serviceDetails_McpserverIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig();
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery = null;
            
             // populate AuthorizationDiscovery
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscoveryIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscoveryIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscoveryIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig.AuthorizationDiscovery = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey = null;
            
             // populate ApiKey
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKeyIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey = new Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey.ApiKeyHeader = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey.ApiKeyName = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey.ApiKeyValue = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKeyIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKeyIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig.ApiKey = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_ApiKey;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken = null;
            
             // populate BearerToken
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerTokenIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken = new Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken.AuthorizationHeader = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken.TokenName = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken.TokenValue = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerTokenIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerTokenIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig.BearerToken = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_BearerToken;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials.Scopes = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO = null;
            
             // populate OAuth3LO
            var requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO = new Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.AuthorizationUrl = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ClientId = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ClientName = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ClientSecret = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.Scopes = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.Boolean? requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = null;
            if (cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = cmdletContext.ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO.SupportCodeChallenge = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LOIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig.OAuth3LO = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig_serviceDetails_Mcpserver_AuthorizationConfig_OAuth3LO;
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpserver.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpserver_serviceDetails_Mcpserver_AuthorizationConfig;
                requestServiceDetails_serviceDetails_McpserverIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserver should be set to null
            if (requestServiceDetails_serviceDetails_McpserverIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserver = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserver != null)
            {
                request.ServiceDetails.Mcpserver = requestServiceDetails_serviceDetails_Mcpserver;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.DatadogServiceDetails requestServiceDetails_serviceDetails_Mcpserverdatadog = null;
            
             // populate Mcpserverdatadog
            var requestServiceDetails_serviceDetails_McpserverdatadogIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserverdatadog = new Amazon.DevOpsAgent.Model.DatadogServiceDetails();
            System.String requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Description = null;
            if (cmdletContext.ServiceDetails_Mcpserverdatadog_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Description = cmdletContext.ServiceDetails_Mcpserverdatadog_Description;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog.Description = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Description;
                requestServiceDetails_serviceDetails_McpserverdatadogIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Endpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserverdatadog_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Endpoint = cmdletContext.ServiceDetails_Mcpserverdatadog_Endpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog.Endpoint = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Endpoint;
                requestServiceDetails_serviceDetails_McpserverdatadogIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Name = null;
            if (cmdletContext.ServiceDetails_Mcpserverdatadog_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Name = cmdletContext.ServiceDetails_Mcpserverdatadog_Name;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog.Name = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_Name;
                requestServiceDetails_serviceDetails_McpserverdatadogIsNull = false;
            }
            Amazon.DevOpsAgent.Model.DatadogAuthorizationConfig requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig = new Amazon.DevOpsAgent.Model.DatadogAuthorizationConfig();
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery = null;
            
             // populate AuthorizationDiscovery
            var requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscoveryIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscoveryIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscoveryIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig.AuthorizationDiscovery = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig_serviceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery;
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpserverdatadog_serviceDetails_Mcpserverdatadog_AuthorizationConfig;
                requestServiceDetails_serviceDetails_McpserverdatadogIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserverdatadog should be set to null
            if (requestServiceDetails_serviceDetails_McpserverdatadogIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserverdatadog = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserverdatadog != null)
            {
                request.ServiceDetails.Mcpserverdatadog = requestServiceDetails_serviceDetails_Mcpserverdatadog;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.GrafanaServiceDetails requestServiceDetails_serviceDetails_Mcpservergrafana = null;
            
             // populate Mcpservergrafana
            var requestServiceDetails_serviceDetails_McpservergrafanaIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana = new Amazon.DevOpsAgent.Model.GrafanaServiceDetails();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Description = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Description = cmdletContext.ServiceDetails_Mcpservergrafana_Description;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana.Description = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Description;
                requestServiceDetails_serviceDetails_McpservergrafanaIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Endpoint = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Endpoint = cmdletContext.ServiceDetails_Mcpservergrafana_Endpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana.Endpoint = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Endpoint;
                requestServiceDetails_serviceDetails_McpservergrafanaIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Name = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Name = cmdletContext.ServiceDetails_Mcpservergrafana_Name;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana.Name = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_Name;
                requestServiceDetails_serviceDetails_McpservergrafanaIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig();
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery = null;
            
             // populate AuthorizationDiscovery
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscoveryIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscoveryIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscoveryIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig.AuthorizationDiscovery = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey = null;
            
             // populate ApiKey
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKeyIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey = new Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey.ApiKeyHeader = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey.ApiKeyName = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey.ApiKeyValue = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKeyIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKeyIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig.ApiKey = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken = null;
            
             // populate BearerToken
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerTokenIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken = new Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken.AuthorizationHeader = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken.TokenName = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken.TokenValue = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerTokenIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerTokenIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig.BearerToken = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials.Scopes = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO = null;
            
             // populate OAuth3LO
            var requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = true;
            requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO = new Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig();
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.AuthorizationUrl = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ClientId = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ClientName = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ClientSecret = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.Scopes = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.Boolean? requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = null;
            if (cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = cmdletContext.ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO.SupportCodeChallenge = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LOIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig.OAuth3LO = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig_serviceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO;
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpservergrafana_serviceDetails_Mcpservergrafana_AuthorizationConfig;
                requestServiceDetails_serviceDetails_McpservergrafanaIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpservergrafana should be set to null
            if (requestServiceDetails_serviceDetails_McpservergrafanaIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpservergrafana = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpservergrafana != null)
            {
                request.ServiceDetails.Mcpservergrafana = requestServiceDetails_serviceDetails_Mcpservergrafana;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerSigV4ServiceDetails requestServiceDetails_serviceDetails_Mcpserversigv4 = null;
            
             // populate Mcpserversigv4
            var requestServiceDetails_serviceDetails_Mcpserversigv4IsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversigv4 = new Amazon.DevOpsAgent.Model.MCPServerSigV4ServiceDetails();
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Description = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Description = cmdletContext.ServiceDetails_Mcpserversigv4_Description;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4.Description = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Description;
                requestServiceDetails_serviceDetails_Mcpserversigv4IsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Endpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Endpoint = cmdletContext.ServiceDetails_Mcpserversigv4_Endpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4.Endpoint = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Endpoint;
                requestServiceDetails_serviceDetails_Mcpserversigv4IsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Name = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Name = cmdletContext.ServiceDetails_Mcpserversigv4_Name;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4.Name = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_Name;
                requestServiceDetails_serviceDetails_Mcpserversigv4IsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerSigV4AuthorizationConfig requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig = new Amazon.DevOpsAgent.Model.MCPServerSigV4AuthorizationConfig();
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader = cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig.CustomHeaders = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader;
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn = cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig.McpRoleArn = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn;
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Region = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Region = cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Region != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig.Region = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Region;
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn = cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig.RoleArn = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn;
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Service = null;
            if (cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Service = cmdletContext.ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Service != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig.Service = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig_serviceDetails_Mcpserversigv4_AuthorizationConfig_Service;
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpserversigv4_serviceDetails_Mcpserversigv4_AuthorizationConfig;
                requestServiceDetails_serviceDetails_Mcpserversigv4IsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversigv4 should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversigv4IsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversigv4 = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversigv4 != null)
            {
                request.ServiceDetails.Mcpserversigv4 = requestServiceDetails_serviceDetails_Mcpserversigv4;
                requestServiceDetailsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerDetails requestServiceDetails_serviceDetails_Mcpserversplunk = null;
            
             // populate Mcpserversplunk
            var requestServiceDetails_serviceDetails_McpserversplunkIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk = new Amazon.DevOpsAgent.Model.MCPServerDetails();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Description = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Description = cmdletContext.ServiceDetails_Mcpserversplunk_Description;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Description != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk.Description = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Description;
                requestServiceDetails_serviceDetails_McpserversplunkIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Endpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Endpoint = cmdletContext.ServiceDetails_Mcpserversplunk_Endpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Endpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk.Endpoint = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Endpoint;
                requestServiceDetails_serviceDetails_McpserversplunkIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Name = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Name = cmdletContext.ServiceDetails_Mcpserversplunk_Name;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Name != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk.Name = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_Name;
                requestServiceDetails_serviceDetails_McpserversplunkIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationConfig();
            Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery = null;
            
             // populate AuthorizationDiscovery
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscoveryIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery = new Amazon.DevOpsAgent.Model.MCPServerAuthorizationDiscoveryConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscoveryIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscoveryIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig.AuthorizationDiscovery = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey = null;
            
             // populate ApiKey
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKeyIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey = new Amazon.DevOpsAgent.Model.MCPServerAPIKeyConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey.ApiKeyHeader = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey.ApiKeyName = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKeyIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey.ApiKeyValue = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKeyIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKeyIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig.ApiKey = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken = null;
            
             // populate BearerToken
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerTokenIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken = new Amazon.DevOpsAgent.Model.MCPServerBearerTokenConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken.AuthorizationHeader = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken.TokenName = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerTokenIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken.TokenValue = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerTokenIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerTokenIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig.BearerToken = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials = null;
            
             // populate OAuthClientCredentials
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials = new Amazon.DevOpsAgent.Model.MCPServerOAuthClientCredentialsConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.ClientId = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.ClientName = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.ClientSecret = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials.Scopes = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentialsIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig.OAuthClientCredentials = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO = null;
            
             // populate OAuth3LO
            var requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = true;
            requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO = new Amazon.DevOpsAgent.Model.MCPServerOAuth3LOConfig();
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.AuthorizationUrl = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ClientId = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ClientName = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ClientSecret = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ExchangeParameters = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ExchangeUrl = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.String requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.ReturnToEndpoint = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            List<System.String> requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.Scopes = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
            System.Boolean? requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = null;
            if (cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge = cmdletContext.ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO.SupportCodeChallenge = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge.Value;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LOIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig.OAuth3LO = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig_serviceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO;
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig should be set to null
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfigIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig != null)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk.AuthorizationConfig = requestServiceDetails_serviceDetails_Mcpserversplunk_serviceDetails_Mcpserversplunk_AuthorizationConfig;
                requestServiceDetails_serviceDetails_McpserversplunkIsNull = false;
            }
             // determine if requestServiceDetails_serviceDetails_Mcpserversplunk should be set to null
            if (requestServiceDetails_serviceDetails_McpserversplunkIsNull)
            {
                requestServiceDetails_serviceDetails_Mcpserversplunk = null;
            }
            if (requestServiceDetails_serviceDetails_Mcpserversplunk != null)
            {
                request.ServiceDetails.Mcpserversplunk = requestServiceDetails_serviceDetails_Mcpserversplunk;
                requestServiceDetailsIsNull = false;
            }
             // determine if request.ServiceDetails should be set to null
            if (requestServiceDetailsIsNull)
            {
                request.ServiceDetails = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetUrlPrivateConnectionName != null)
            {
                request.TargetUrlPrivateConnectionName = cmdletContext.TargetUrlPrivateConnectionName;
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
        
        private Amazon.DevOpsAgent.Model.RegisterServiceResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.RegisterServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "RegisterService");
            try
            {
                return client.RegisterServiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExchangeUrlPrivateConnectionName { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String PrivateConnectionName { get; set; }
            public Amazon.DevOpsAgent.PostRegisterServiceSupportedService Service { get; set; }
            public System.String ServiceDetails_Azureidentity_ClientId { get; set; }
            public System.String ServiceDetails_Azureidentity_TenantId { get; set; }
            public System.String ServiceDetails_Azureidentity_WebIdentityRoleArn { get; set; }
            public List<System.String> ServiceDetails_Azureidentity_WebIdentityTokenAudience { get; set; }
            public System.String ServiceDetails_Dynatrace_AccountUrn { get; set; }
            public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Dynatrace_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public Amazon.DevOpsAgent.EventChannelType ServiceDetails_EventChannel_Type { get; set; }
            public System.String ServiceDetails_Gitlab_GroupId { get; set; }
            public System.String ServiceDetails_Gitlab_TargetUrl { get; set; }
            public Amazon.DevOpsAgent.GitLabTokenType ServiceDetails_Gitlab_TokenType { get; set; }
            public System.String ServiceDetails_Gitlab_TokenValue { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenName { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_BearerToken_TokenValue { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
            public List<System.String> ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_Scope { get; set; }
            public System.Boolean? ServiceDetails_Mcpserver_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
            public List<System.String> ServiceDetails_Mcpserver_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
            public System.String ServiceDetails_Mcpserver_Description { get; set; }
            public System.String ServiceDetails_Mcpserver_Endpoint { get; set; }
            public System.String ServiceDetails_Mcpserver_Name { get; set; }
            public System.String ServiceDetails_Mcpserverdatadog_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
            public System.String ServiceDetails_Mcpserverdatadog_Description { get; set; }
            public System.String ServiceDetails_Mcpserverdatadog_Endpoint { get; set; }
            public System.String ServiceDetails_Mcpserverdatadog_Name { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenName { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_BearerToken_TokenValue { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
            public List<System.String> ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_Scope { get; set; }
            public System.Boolean? ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
            public List<System.String> ServiceDetails_Mcpservergrafana_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_Description { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_Endpoint { get; set; }
            public System.String ServiceDetails_Mcpservergrafana_Name { get; set; }
            public System.String ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AccountId { get; set; }
            public List<System.String> ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_AlertPolicyId { get; set; }
            public System.String ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApiKey { get; set; }
            public List<System.String> ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_ApplicationId { get; set; }
            public List<System.String> ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_EntityGuid { get; set; }
            public Amazon.DevOpsAgent.NewRelicRegion ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpserversigv4_AuthorizationConfig_CustomHeader { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_McpRoleArn { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region { get; set; }
            [System.ObsoleteAttribute]
            public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_Description { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_Endpoint { get; set; }
            public System.String ServiceDetails_Mcpserversigv4_Name { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyHeader { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyName { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_ApiKey_ApiKeyValue { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_AuthorizationDiscovery_ReturnToEndpoint { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_AuthorizationHeader { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenName { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_BearerToken_TokenValue { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_AuthorizationUrl { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientId { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientName { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ExchangeUrl { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_ReturnToEndpoint { get; set; }
            public List<System.String> ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_Scope { get; set; }
            public System.Boolean? ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuth3LO_SupportCodeChallenge { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_ExchangeUrl { get; set; }
            public List<System.String> ServiceDetails_Mcpserversplunk_AuthorizationConfig_OAuthClientCredentials_Scope { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_Description { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_Endpoint { get; set; }
            public System.String ServiceDetails_Mcpserversplunk_Name { get; set; }
            public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Pagerduty_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public List<System.String> ServiceDetails_Pagerduty_Scope { get; set; }
            public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientId { get; set; }
            public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientName { get; set; }
            public System.String ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ClientSecret { get; set; }
            public Dictionary<System.String, System.String> ServiceDetails_Servicenow_AuthorizationConfig_OAuthClientCredentials_ExchangeParameter { get; set; }
            public System.String ServiceDetails_Servicenow_InstanceUrl { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetUrlPrivateConnectionName { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.RegisterServiceResponse, RegisterDOPSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
