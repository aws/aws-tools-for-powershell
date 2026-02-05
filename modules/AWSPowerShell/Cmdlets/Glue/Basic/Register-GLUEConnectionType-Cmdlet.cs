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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Registers a custom connection type in Glue based on the configuration provided. This
    /// operation enables customers to configure custom connectors for any data source with
    /// REST-based APIs, eliminating the need for building custom Lambda connectors.
    /// 
    ///  
    /// <para>
    /// The registered connection type stores details about how requests and responses are
    /// interpreted by REST sources, including connection properties, authentication configuration,
    /// and REST configuration with entity definitions. Once registered, customers can create
    /// connections using this connection type and work with them the same way as natively
    /// supported Glue connectors.
    /// </para><para>
    /// Supports multiple authentication types including Basic, OAuth2 (Client Credentials,
    /// JWT Bearer, Authorization Code), and Custom Auth configurations.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "GLUEConnectionType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue RegisterConnectionType API operation.", Operation = new[] {"RegisterConnectionType"}, SelectReturnType = typeof(Amazon.Glue.Model.RegisterConnectionTypeResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.RegisterConnectionTypeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.RegisterConnectionTypeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterGLUEConnectionTypeCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionProperties_AdditionalRequestParameter
        /// <summary>
        /// <para>
        /// <para>Key-value pairs of additional request parameters that may be needed during connection
        /// creation, such as API versions or service-specific configuration options.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionProperties_AdditionalRequestParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] ConnectionProperties_AdditionalRequestParameter { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionProperties_Url_AllowedValues")]
        public System.String[] ConnectionProperties_Url_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue
        /// <summary>
        /// <para>
        /// <para>A list of <c>AllowedValue</c> objects representing the values allowed for the property.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValues")]
        public System.String[] ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter
        /// <summary>
        /// <para>
        /// <para>A map of custom authentication parameters that define the specific authentication
        /// mechanism and required properties.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>A list of authentication types supported by this connection type, such as Basic, OAuth2,
        /// or Custom authentication methods.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConnectorAuthenticationConfiguration_AuthenticationTypes")]
        public System.String[] ConnectorAuthenticationConfiguration_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter ConnectionType
        /// <summary>
        /// <para>
        /// <para>The name of the connection type. Must be between 1 and 255 characters and must be
        /// prefixed with "REST-" to indicate it is a REST-based connector.</para>
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
        public System.String ConnectionType { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath
        /// <summary>
        /// <para>
        /// <para>A JSON path expression that specifies how to extract a value from the response body
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType
        /// <summary>
        /// <para>
        /// <para>The content type to use for token exchange requests, such as application/x-www-form-urlencoded
        /// or application/json.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ContentType")]
        public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType
        /// <summary>
        /// <para>
        /// <para>The content type to use for token requests, such as application/x-www-form-urlencoded
        /// or application/json.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ContentType")]
        public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType
        /// <summary>
        /// <para>
        /// <para>The content type to use for JWT bearer token requests, such as application/x-www-form-urlencoded
        /// or application/json.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ContentType")]
        public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionProperties_Url_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value for the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use if the parameter cannot be extracted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the connection type. Can be up to 2048 characters and provides details
        /// about the purpose and functionality of the connection type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_EntityConfiguration
        /// <summary>
        /// <para>
        /// <para>A map of entity configurations that define how to interact with different data entities
        /// available through the REST API, including their schemas and access patterns.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestConfiguration_EntityConfigurations")]
        public System.Collections.Hashtable RestConfiguration_EntityConfiguration { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath
        /// <summary>
        /// <para>
        /// <para>The JSON path expression that identifies where error information is located within
        /// API responses when requests fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath
        /// <summary>
        /// <para>
        /// <para>The JSON path expression that identifies where error information is located within
        /// API responses when requests fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey
        /// <summary>
        /// <para>
        /// <para>The name of an HTTP response header from which to extract the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The integration type for the connection. Currently only "REST" protocol is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.IntegrationType")]
        public Amazon.Glue.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key
        /// <summary>
        /// <para>
        /// <para>The parameter key name that will be used in subsequent requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionProperties_Url_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride
        /// <summary>
        /// <para>
        /// <para>A key name to use when sending this property in API requests, if different from the
        /// display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionProperties_Url_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name
        /// <summary>
        /// <para>
        /// <para>The name of the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType
        /// <summary>
        /// <para>
        /// <para>The OAuth2 grant type to use for authentication, such as CLIENT_CREDENTIALS, JWT_BEARER,
        /// or AUTHORIZATION_CODE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ConnectorOAuth2GrantType")]
        public Amazon.Glue.ConnectorOAuth2GrantType ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectionProperties_Url_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this property should be included in REST requests, such as in headers,
        /// query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation
        /// <summary>
        /// <para>
        /// <para>Specifies where this extracted parameter should be placed in subsequent requests,
        /// such as in headers, query parameters, or request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyLocation")]
        public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectionProperties_Url_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType
        /// <summary>
        /// <para>
        /// <para>The data type of this property</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.PropertyType")]
        public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method to use when making token exchange requests, typically POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.HTTPMethod")]
        public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method to use when making token requests, typically POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.HTTPMethod")]
        public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method to use when making JWT bearer token requests, typically POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.HTTPMethod")]
        public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method to use for requests to this endpoint, such as GET, POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.HTTPMethod")]
        public Amazon.Glue.HTTPMethod RestConfiguration_GlobalSourceConfiguration_RequestMethod { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_RequestMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method to use for requests to this endpoint, such as GET, POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.HTTPMethod")]
        public Amazon.Glue.HTTPMethod RestConfiguration_ValidationEndpointConfiguration_RequestMethod { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_RequestParameter
        /// <summary>
        /// <para>
        /// <para>Configuration for request parameters that should be included in API calls, such as
        /// query parameters, headers, or body content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestConfiguration_GlobalSourceConfiguration_RequestParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] RestConfiguration_GlobalSourceConfiguration_RequestParameter { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_RequestParameter
        /// <summary>
        /// <para>
        /// <para>Configuration for request parameters that should be included in API calls, such as
        /// query parameters, headers, or body content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestConfiguration_ValidationEndpointConfiguration_RequestParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] RestConfiguration_ValidationEndpointConfiguration_RequestParameter { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_RequestPath
        /// <summary>
        /// <para>
        /// <para>The URL path for the REST endpoint, which may include parameter placeholders that
        /// will be replaced with actual values during requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_RequestPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_RequestPath
        /// <summary>
        /// <para>
        /// <para>The URL path for the REST endpoint, which may include parameter placeholders that
        /// will be replaced with actual values during requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_RequestPath { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Url_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectionProperties_Url_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required
        /// <summary>
        /// <para>
        /// <para>Indicates whether the property is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath
        /// <summary>
        /// <para>
        /// <para>The JSON path expression that identifies where the actual result data is located within
        /// the API response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath { get; set; }
        #endregion
        
        #region Parameter RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath
        /// <summary>
        /// <para>
        /// <para>The JSON path expression that identifies where the actual result data is located within
        /// the API response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags you assign to the connection type.</para><para />
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
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters to include in token URL requests as key-value pairs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters to include in token URL requests as key-value pairs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter { get; set; }
        #endregion
        
        #region Parameter ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters to include in token URL requests as key-value pairs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameters")]
        public Amazon.Glue.Model.ConnectorProperty[] ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectionTypeArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.RegisterConnectionTypeResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.RegisterConnectionTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectionTypeArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-GLUEConnectionType (RegisterConnectionType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.RegisterConnectionTypeResponse, RegisterGLUEConnectionTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConnectionProperties_AdditionalRequestParameter != null)
            {
                context.ConnectionProperties_AdditionalRequestParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.ConnectionProperties_AdditionalRequestParameter);
            }
            if (this.ConnectionProperties_Url_AllowedValue != null)
            {
                context.ConnectionProperties_Url_AllowedValue = new List<System.String>(this.ConnectionProperties_Url_AllowedValue);
            }
            context.ConnectionProperties_Url_DefaultValue = this.ConnectionProperties_Url_DefaultValue;
            context.ConnectionProperties_Url_KeyOverride = this.ConnectionProperties_Url_KeyOverride;
            context.ConnectionProperties_Url_Name = this.ConnectionProperties_Url_Name;
            context.ConnectionProperties_Url_PropertyLocation = this.ConnectionProperties_Url_PropertyLocation;
            context.ConnectionProperties_Url_PropertyType = this.ConnectionProperties_Url_PropertyType;
            context.ConnectionProperties_Url_Required = this.ConnectionProperties_Url_Required;
            context.ConnectionType = this.ConnectionType;
            #if MODULAR
            if (this.ConnectionType == null && ParameterWasBound(nameof(this.ConnectionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConnectorAuthenticationConfiguration_AuthenticationType != null)
            {
                context.ConnectorAuthenticationConfiguration_AuthenticationType = new List<System.String>(this.ConnectorAuthenticationConfiguration_AuthenticationType);
            }
            #if MODULAR
            if (this.ConnectorAuthenticationConfiguration_AuthenticationType == null && ParameterWasBound(nameof(this.ConnectorAuthenticationConfiguration_AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorAuthenticationConfiguration_AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required;
            if (this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType;
            context.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required = this.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required;
            if (this.ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter != null)
            {
                context.ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter);
            }
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter);
            }
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue = new List<System.String>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType;
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required = this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required;
            if (this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter != null)
            {
                context.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter);
            }
            context.ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType = this.ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType;
            context.Description = this.Description;
            context.IntegrationType = this.IntegrationType;
            #if MODULAR
            if (this.IntegrationType == null && ParameterWasBound(nameof(this.IntegrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RestConfiguration_EntityConfiguration != null)
            {
                context.RestConfiguration_EntityConfiguration = new Dictionary<System.String, Amazon.Glue.Model.EntityConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.RestConfiguration_EntityConfiguration.Keys)
                {
                    context.RestConfiguration_EntityConfiguration.Add((String)hashKey, (Amazon.Glue.Model.EntityConfiguration)(this.RestConfiguration_EntityConfiguration[hashKey]));
                }
            }
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
            context.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = this.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
            context.RestConfiguration_GlobalSourceConfiguration_RequestMethod = this.RestConfiguration_GlobalSourceConfiguration_RequestMethod;
            if (this.RestConfiguration_GlobalSourceConfiguration_RequestParameter != null)
            {
                context.RestConfiguration_GlobalSourceConfiguration_RequestParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.RestConfiguration_GlobalSourceConfiguration_RequestParameter);
            }
            context.RestConfiguration_GlobalSourceConfiguration_RequestPath = this.RestConfiguration_GlobalSourceConfiguration_RequestPath;
            context.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath = this.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath;
            context.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath = this.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
            context.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = this.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
            context.RestConfiguration_ValidationEndpointConfiguration_RequestMethod = this.RestConfiguration_ValidationEndpointConfiguration_RequestMethod;
            if (this.RestConfiguration_ValidationEndpointConfiguration_RequestParameter != null)
            {
                context.RestConfiguration_ValidationEndpointConfiguration_RequestParameter = new List<Amazon.Glue.Model.ConnectorProperty>(this.RestConfiguration_ValidationEndpointConfiguration_RequestParameter);
            }
            context.RestConfiguration_ValidationEndpointConfiguration_RequestPath = this.RestConfiguration_ValidationEndpointConfiguration_RequestPath;
            context.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath = this.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath;
            context.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath = this.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath;
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
            var request = new Amazon.Glue.Model.RegisterConnectionTypeRequest();
            
            
             // populate ConnectionProperties
            var requestConnectionPropertiesIsNull = true;
            request.ConnectionProperties = new Amazon.Glue.Model.ConnectionPropertiesConfiguration();
            List<Amazon.Glue.Model.ConnectorProperty> requestConnectionProperties_connectionProperties_AdditionalRequestParameter = null;
            if (cmdletContext.ConnectionProperties_AdditionalRequestParameter != null)
            {
                requestConnectionProperties_connectionProperties_AdditionalRequestParameter = cmdletContext.ConnectionProperties_AdditionalRequestParameter;
            }
            if (requestConnectionProperties_connectionProperties_AdditionalRequestParameter != null)
            {
                request.ConnectionProperties.AdditionalRequestParameters = requestConnectionProperties_connectionProperties_AdditionalRequestParameter;
                requestConnectionPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectionProperties_connectionProperties_Url = null;
            
             // populate Url
            var requestConnectionProperties_connectionProperties_UrlIsNull = true;
            requestConnectionProperties_connectionProperties_Url = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_AllowedValue = null;
            if (cmdletContext.ConnectionProperties_Url_AllowedValue != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_AllowedValue = cmdletContext.ConnectionProperties_Url_AllowedValue;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_AllowedValue != null)
            {
                requestConnectionProperties_connectionProperties_Url.AllowedValues = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_AllowedValue;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            System.String requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_DefaultValue = null;
            if (cmdletContext.ConnectionProperties_Url_DefaultValue != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_DefaultValue = cmdletContext.ConnectionProperties_Url_DefaultValue;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_DefaultValue != null)
            {
                requestConnectionProperties_connectionProperties_Url.DefaultValue = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_DefaultValue;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            System.String requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_KeyOverride = null;
            if (cmdletContext.ConnectionProperties_Url_KeyOverride != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_KeyOverride = cmdletContext.ConnectionProperties_Url_KeyOverride;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_KeyOverride != null)
            {
                requestConnectionProperties_connectionProperties_Url.KeyOverride = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_KeyOverride;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            System.String requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Name = null;
            if (cmdletContext.ConnectionProperties_Url_Name != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Name = cmdletContext.ConnectionProperties_Url_Name;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Name != null)
            {
                requestConnectionProperties_connectionProperties_Url.Name = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Name;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyLocation = null;
            if (cmdletContext.ConnectionProperties_Url_PropertyLocation != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyLocation = cmdletContext.ConnectionProperties_Url_PropertyLocation;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyLocation != null)
            {
                requestConnectionProperties_connectionProperties_Url.PropertyLocation = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyLocation;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyType = null;
            if (cmdletContext.ConnectionProperties_Url_PropertyType != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyType = cmdletContext.ConnectionProperties_Url_PropertyType;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyType != null)
            {
                requestConnectionProperties_connectionProperties_Url.PropertyType = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_PropertyType;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
            System.Boolean? requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Required = null;
            if (cmdletContext.ConnectionProperties_Url_Required != null)
            {
                requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Required = cmdletContext.ConnectionProperties_Url_Required.Value;
            }
            if (requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Required != null)
            {
                requestConnectionProperties_connectionProperties_Url.Required = requestConnectionProperties_connectionProperties_Url_connectionProperties_Url_Required.Value;
                requestConnectionProperties_connectionProperties_UrlIsNull = false;
            }
             // determine if requestConnectionProperties_connectionProperties_Url should be set to null
            if (requestConnectionProperties_connectionProperties_UrlIsNull)
            {
                requestConnectionProperties_connectionProperties_Url = null;
            }
            if (requestConnectionProperties_connectionProperties_Url != null)
            {
                request.ConnectionProperties.Url = requestConnectionProperties_connectionProperties_Url;
                requestConnectionPropertiesIsNull = false;
            }
             // determine if request.ConnectionProperties should be set to null
            if (requestConnectionPropertiesIsNull)
            {
                request.ConnectionProperties = null;
            }
            if (cmdletContext.ConnectionType != null)
            {
                request.ConnectionType = cmdletContext.ConnectionType;
            }
            
             // populate ConnectorAuthenticationConfiguration
            var requestConnectorAuthenticationConfigurationIsNull = true;
            request.ConnectorAuthenticationConfiguration = new Amazon.Glue.Model.ConnectorAuthenticationConfiguration();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_AuthenticationType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_AuthenticationType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_AuthenticationType = cmdletContext.ConnectorAuthenticationConfiguration_AuthenticationType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_AuthenticationType != null)
            {
                request.ConnectorAuthenticationConfiguration.AuthenticationTypes = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_AuthenticationType;
                requestConnectorAuthenticationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.CustomAuthenticationProperties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties = null;
            
             // populate CustomAuthenticationProperties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationPropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties = new Amazon.Glue.Model.CustomAuthenticationProperties();
            List<Amazon.Glue.Model.ConnectorProperty> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties_connectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties_connectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter = cmdletContext.ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties_connectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties.AuthenticationParameters = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties_connectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationPropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationPropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties != null)
            {
                request.ConnectorAuthenticationConfiguration.CustomAuthenticationProperties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_CustomAuthenticationProperties;
                requestConnectorAuthenticationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.BasicAuthenticationProperties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties = null;
            
             // populate BasicAuthenticationProperties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationPropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties = new Amazon.Glue.Model.BasicAuthenticationProperties();
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password = null;
            
             // populate Password
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_PasswordIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties.Password = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Password;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username = null;
            
             // populate Username
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required = cmdletContext.ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_UsernameIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties.Username = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties_connectorAuthenticationConfiguration_BasicAuthenticationProperties_Username;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationPropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationPropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties != null)
            {
                request.ConnectorAuthenticationConfiguration.BasicAuthenticationProperties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_BasicAuthenticationProperties;
                requestConnectorAuthenticationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ConnectorOAuth2Properties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties = null;
            
             // populate OAuth2Properties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties = new Amazon.Glue.Model.ConnectorOAuth2Properties();
            Amazon.Glue.ConnectorOAuth2GrantType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties.OAuth2GrantType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.JWTBearerProperties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties = null;
            
             // populate JWTBearerProperties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties = new Amazon.Glue.Model.JWTBearerProperties();
            Amazon.Glue.ContentType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties.ContentType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = false;
            }
            Amazon.Glue.HTTPMethod requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties.RequestMethod = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = false;
            }
            List<Amazon.Glue.Model.ConnectorProperty> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties.TokenUrlParameters = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken = null;
            
             // populate JwtToken
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtTokenIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties.JwtToken = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl = null;
            
             // populate TokenUrl
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties.TokenUrl = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerPropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties.JWTBearerProperties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.ClientCredentialsProperties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties = null;
            
             // populate ClientCredentialsProperties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties = new Amazon.Glue.Model.ClientCredentialsProperties();
            Amazon.Glue.ContentType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.ContentType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            Amazon.Glue.HTTPMethod requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.RequestMethod = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            List<Amazon.Glue.Model.ConnectorProperty> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.TokenUrlParameters = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId = null;
            
             // populate ClientId
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientIdIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.ClientId = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret = null;
            
             // populate ClientSecret
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecretIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.ClientSecret = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope = null;
            
             // populate Scope
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ScopeIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.Scope = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl = null;
            
             // populate TokenUrl
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties.TokenUrl = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsPropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties.ClientCredentialsProperties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorAuthorizationCodeProperties requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            
             // populate AuthorizationCodeProperties
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = new Amazon.Glue.Model.ConnectorAuthorizationCodeProperties();
            Amazon.Glue.ContentType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.ContentType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.HTTPMethod requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.RequestMethod = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            List<Amazon.Glue.Model.ConnectorProperty> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.TokenUrlParameters = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode = null;
            
             // populate AuthorizationCode
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.AuthorizationCode = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl = null;
            
             // populate AuthorizationCodeUrl
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrlIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.AuthorizationCodeUrl = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId = null;
            
             // populate ClientId
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientIdIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.ClientId = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret = null;
            
             // populate ClientSecret
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecretIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.ClientSecret = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt = null;
            
             // populate Prompt
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_PromptIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.Prompt = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri = null;
            
             // populate RedirectUri
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUriIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.RedirectUri = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope = null;
            
             // populate Scope
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ScopeIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.Scope = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            Amazon.Glue.Model.ConnectorProperty requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl = null;
            
             // populate TokenUrl
            var requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = true;
            requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl = new Amazon.Glue.Model.ConnectorProperty();
            List<System.String> requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.AllowedValues = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.DefaultValue = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.KeyOverride = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            System.String requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.Name = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.PropertyLocation = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            Amazon.Glue.PropertyType requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.PropertyType = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
            System.Boolean? requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required = null;
            if (cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required = cmdletContext.ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required.Value;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl.Required = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required.Value;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.TokenUrl = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties != null)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties.AuthorizationCodeProperties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties_connectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties;
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
             // determine if requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties should be set to null
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2PropertiesIsNull)
            {
                requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties = null;
            }
            if (requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties != null)
            {
                request.ConnectorAuthenticationConfiguration.OAuth2Properties = requestConnectorAuthenticationConfiguration_connectorAuthenticationConfiguration_OAuth2Properties;
                requestConnectorAuthenticationConfigurationIsNull = false;
            }
             // determine if request.ConnectorAuthenticationConfiguration should be set to null
            if (requestConnectorAuthenticationConfigurationIsNull)
            {
                request.ConnectorAuthenticationConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
            }
            
             // populate RestConfiguration
            var requestRestConfigurationIsNull = true;
            request.RestConfiguration = new Amazon.Glue.Model.RestConfiguration();
            Dictionary<System.String, Amazon.Glue.Model.EntityConfiguration> requestRestConfiguration_restConfiguration_EntityConfiguration = null;
            if (cmdletContext.RestConfiguration_EntityConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_EntityConfiguration = cmdletContext.RestConfiguration_EntityConfiguration;
            }
            if (requestRestConfiguration_restConfiguration_EntityConfiguration != null)
            {
                request.RestConfiguration.EntityConfigurations = requestRestConfiguration_restConfiguration_EntityConfiguration;
                requestRestConfigurationIsNull = false;
            }
            Amazon.Glue.Model.SourceConfiguration requestRestConfiguration_restConfiguration_GlobalSourceConfiguration = null;
            
             // populate GlobalSourceConfiguration
            var requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration = new Amazon.Glue.Model.SourceConfiguration();
            Amazon.Glue.HTTPMethod requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestMethod = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestMethod != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestMethod = cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestMethod;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestMethod != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration.RequestMethod = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestMethod;
                requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = false;
            }
            List<Amazon.Glue.Model.ConnectorProperty> requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestParameter = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestParameter != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestParameter = cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestParameter;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestParameter != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration.RequestParameters = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestParameter;
                requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_RequestPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration.RequestPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_RequestPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = false;
            }
            Amazon.Glue.Model.PaginationConfiguration requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration = null;
            
             // populate PaginationConfiguration
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration = new Amazon.Glue.Model.PaginationConfiguration();
            Amazon.Glue.Model.CursorConfiguration requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration = null;
            
             // populate CursorConfiguration
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration = new Amazon.Glue.Model.CursorConfiguration();
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = null;
            
             // populate LimitParameter
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.DefaultValue = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.Key = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.PropertyLocation = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.Value = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration.LimitParameter = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = null;
            
             // populate NextPage
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.DefaultValue = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.Key = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.PropertyLocation = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value.ContentPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value.HeaderKey = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.Value = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration.NextPage = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration.CursorConfiguration = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.OffsetConfiguration requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration = null;
            
             // populate OffsetConfiguration
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration = new Amazon.Glue.Model.OffsetConfiguration();
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = null;
            
             // populate LimitParameter
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.DefaultValue = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.Key = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.PropertyLocation = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.Value = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration.LimitParameter = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = null;
            
             // populate OffsetParameter
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.DefaultValue = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.Key = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.PropertyLocation = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = cmdletContext.RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.Value = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration.OffsetParameter = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration.OffsetConfiguration = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration.PaginationConfiguration = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_PaginationConfiguration;
                requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ResponseConfiguration requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration = null;
            
             // populate ResponseConfiguration
            var requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration = new Amazon.Glue.Model.ResponseConfiguration();
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration.ErrorPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfigurationIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath = null;
            if (cmdletContext.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath = cmdletContext.RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration.ResultPath = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath;
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration.ResponseConfiguration = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration_restConfiguration_GlobalSourceConfiguration_ResponseConfiguration;
                requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_GlobalSourceConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_GlobalSourceConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_GlobalSourceConfiguration != null)
            {
                request.RestConfiguration.GlobalSourceConfiguration = requestRestConfiguration_restConfiguration_GlobalSourceConfiguration;
                requestRestConfigurationIsNull = false;
            }
            Amazon.Glue.Model.SourceConfiguration requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration = null;
            
             // populate ValidationEndpointConfiguration
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration = new Amazon.Glue.Model.SourceConfiguration();
            Amazon.Glue.HTTPMethod requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestMethod = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestMethod != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestMethod = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestMethod;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestMethod != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration.RequestMethod = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestMethod;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = false;
            }
            List<Amazon.Glue.Model.ConnectorProperty> requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestParameter = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestParameter != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestParameter = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestParameter;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestParameter != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration.RequestParameters = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestParameter;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_RequestPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration.RequestPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_RequestPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = false;
            }
            Amazon.Glue.Model.PaginationConfiguration requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration = null;
            
             // populate PaginationConfiguration
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration = new Amazon.Glue.Model.PaginationConfiguration();
            Amazon.Glue.Model.CursorConfiguration requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration = null;
            
             // populate CursorConfiguration
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration = new Amazon.Glue.Model.CursorConfiguration();
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = null;
            
             // populate LimitParameter
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.DefaultValue = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.Key = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.PropertyLocation = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter.Value = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration.LimitParameter = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = null;
            
             // populate NextPage
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.DefaultValue = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.Key = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.PropertyLocation = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value.ContentPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value.HeaderKey = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage.Value = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPageIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration.NextPage = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration.CursorConfiguration = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.OffsetConfiguration requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration = null;
            
             // populate OffsetConfiguration
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration = new Amazon.Glue.Model.OffsetConfiguration();
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = null;
            
             // populate LimitParameter
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.DefaultValue = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.Key = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.PropertyLocation = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter.Value = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration.LimitParameter = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ExtractedParameter requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = null;
            
             // populate OffsetParameter
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = new Amazon.Glue.Model.ExtractedParameter();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.DefaultValue = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.Key = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            Amazon.Glue.PropertyLocation requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.PropertyLocation = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
            Amazon.Glue.Model.ResponseExtractionMapping requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = null;
            
             // populate Value
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = new Amazon.Glue.Model.ResponseExtractionMapping();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value.ContentPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value.HeaderKey = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_ValueIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter.Value = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameterIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration.OffsetParameter = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration.OffsetConfiguration = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration.PaginationConfiguration = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_PaginationConfiguration;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = false;
            }
            Amazon.Glue.Model.ResponseConfiguration requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration = null;
            
             // populate ResponseConfiguration
            var requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfigurationIsNull = true;
            requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration = new Amazon.Glue.Model.ResponseConfiguration();
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration.ErrorPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfigurationIsNull = false;
            }
            System.String requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath = null;
            if (cmdletContext.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath = cmdletContext.RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration.ResultPath = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration != null)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration.ResponseConfiguration = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration_restConfiguration_ValidationEndpointConfiguration_ResponseConfiguration;
                requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull = false;
            }
             // determine if requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration should be set to null
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfigurationIsNull)
            {
                requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration = null;
            }
            if (requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration != null)
            {
                request.RestConfiguration.ValidationEndpointConfiguration = requestRestConfiguration_restConfiguration_ValidationEndpointConfiguration;
                requestRestConfigurationIsNull = false;
            }
             // determine if request.RestConfiguration should be set to null
            if (requestRestConfigurationIsNull)
            {
                request.RestConfiguration = null;
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
        
        private Amazon.Glue.Model.RegisterConnectionTypeResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.RegisterConnectionTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "RegisterConnectionType");
            try
            {
                return client.RegisterConnectionTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Glue.Model.ConnectorProperty> ConnectionProperties_AdditionalRequestParameter { get; set; }
            public List<System.String> ConnectionProperties_Url_AllowedValue { get; set; }
            public System.String ConnectionProperties_Url_DefaultValue { get; set; }
            public System.String ConnectionProperties_Url_KeyOverride { get; set; }
            public System.String ConnectionProperties_Url_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectionProperties_Url_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectionProperties_Url_PropertyType { get; set; }
            public System.Boolean? ConnectionProperties_Url_Required { get; set; }
            public System.String ConnectionType { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_AuthenticationType { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Password_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_BasicAuthenticationProperties_Username_Required { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> ConnectorAuthenticationConfiguration_CustomAuthenticationProperties_AuthenticationParameter { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCodeUrl_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientId_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ClientSecret_Required { get; set; }
            public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_ContentType { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Prompt_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri_Required { get; set; }
            public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RequestMethod { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_Scope_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrl_Required { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> ConnectorAuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_TokenUrlParameter { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientId_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ClientSecret_Required { get; set; }
            public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_ContentType { get; set; }
            public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_RequestMethod { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_Scope_Required { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrl_Required { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> ConnectorAuthenticationConfiguration_OAuth2Properties_ClientCredentialsProperties_TokenUrlParameter { get; set; }
            public Amazon.Glue.ContentType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_ContentType { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_JwtToken_Required { get; set; }
            public Amazon.Glue.HTTPMethod ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_RequestMethod { get; set; }
            public List<System.String> ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_AllowedValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_DefaultValue { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_KeyOverride { get; set; }
            public System.String ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Name { get; set; }
            public Amazon.Glue.PropertyLocation ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyLocation { get; set; }
            public Amazon.Glue.PropertyType ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_PropertyType { get; set; }
            public System.Boolean? ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrl_Required { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> ConnectorAuthenticationConfiguration_OAuth2Properties_JWTBearerProperties_TokenUrlParameter { get; set; }
            public Amazon.Glue.ConnectorOAuth2GrantType ConnectorAuthenticationConfiguration_OAuth2Properties_OAuth2GrantType { get; set; }
            public System.String Description { get; set; }
            public Amazon.Glue.IntegrationType IntegrationType { get; set; }
            public Dictionary<System.String, Amazon.Glue.Model.EntityConfiguration> RestConfiguration_EntityConfiguration { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey { get; set; }
            public Amazon.Glue.HTTPMethod RestConfiguration_GlobalSourceConfiguration_RequestMethod { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> RestConfiguration_GlobalSourceConfiguration_RequestParameter { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_RequestPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ErrorPath { get; set; }
            public System.String RestConfiguration_GlobalSourceConfiguration_ResponseConfiguration_ResultPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_LimitParameter_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_DefaultValue { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_PropertyLocation { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_ContentPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_CursorConfiguration_NextPage_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_LimitParameter_Value_HeaderKey { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_DefaultValue { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Key { get; set; }
            public Amazon.Glue.PropertyLocation RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_PropertyLocation { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_ContentPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_PaginationConfiguration_OffsetConfiguration_OffsetParameter_Value_HeaderKey { get; set; }
            public Amazon.Glue.HTTPMethod RestConfiguration_ValidationEndpointConfiguration_RequestMethod { get; set; }
            public List<Amazon.Glue.Model.ConnectorProperty> RestConfiguration_ValidationEndpointConfiguration_RequestParameter { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_RequestPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ErrorPath { get; set; }
            public System.String RestConfiguration_ValidationEndpointConfiguration_ResponseConfiguration_ResultPath { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Glue.Model.RegisterConnectionTypeResponse, RegisterGLUEConnectionTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectionTypeArn;
        }
        
    }
}
