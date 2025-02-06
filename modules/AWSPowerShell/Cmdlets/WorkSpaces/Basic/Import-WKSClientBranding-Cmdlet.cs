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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Imports client branding. Client branding allows you to customize your WorkSpace's
    /// client login portal. You can tailor your login portal company logo, the support email
    /// address, support link, link to reset password, and a custom message for users trying
    /// to sign in.
    /// 
    ///  
    /// <para>
    /// After you import client branding, the default branding experience for the specified
    /// platform type is replaced with the imported experience
    /// </para><note><ul><li><para>
    /// You must specify at least one platform type when importing client branding.
    /// </para></li><li><para>
    /// You can import up to 6 MB of data with each request. If your request exceeds this
    /// limit, you can import client branding for different platform types using separate
    /// requests.
    /// </para></li><li><para>
    /// In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
    /// mutually exclusive. You can specify only one parameter for each platform type, but
    /// not both.
    /// </para></li><li><para>
    /// Imported data can take up to a minute to appear in the WorkSpaces client.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Import", "WKSClientBranding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.ImportClientBrandingResponse")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ImportClientBranding API operation.", Operation = new[] {"ImportClientBranding"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ImportClientBrandingResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.ImportClientBrandingResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.ImportClientBrandingResponse object containing multiple properties."
    )]
    public partial class ImportWKSClientBrandingCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceTypeAndroid_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeAndroid_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeIos_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeLinux_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeLinux_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeOsx_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeOsx_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWeb_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWeb_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWindows_ForgotPasswordLink
        /// <summary>
        /// <para>
        /// <para>The forgotten password link. This is the web address that users can go to if they
        /// forget the password for their WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWindows_ForgotPasswordLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeAndroid_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeAndroid_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeIos_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeLinux_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeLinux_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeOsx_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeOsx_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWeb_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeWeb_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWindows_LoginMessage
        /// <summary>
        /// <para>
        /// <para>The login message. Specified as a key value pair, in which the key is a locale and
        /// the value is the localized message for that locale. The only key supported is <c>en_US</c>.
        /// The HTML tags supported include the following: <c>a, b, blockquote, br, cite, code,
        /// dd, dl, dt, div, em, i, li, ol, p, pre, q, small, span, strike, strong, sub, sup,
        /// u, ul</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DeviceTypeWindows_LoginMessage { get; set; }
        #endregion
        
        #region Parameter DeviceTypeAndroid_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. The only image format accepted is a binary data object that is converted
        /// from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeAndroid_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. This is the standard-resolution display that has a 1:1 pixel density (or
        /// @1x), where one pixel is equal to one point. The only image format accepted is a binary
        /// data object that is converted from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeIos_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeLinux_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. The only image format accepted is a binary data object that is converted
        /// from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeLinux_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeOsx_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. The only image format accepted is a binary data object that is converted
        /// from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeOsx_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWeb_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. The only image format accepted is a binary data object that is converted
        /// from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeWeb_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWindows_Logo
        /// <summary>
        /// <para>
        /// <para>The logo. The only image format accepted is a binary data object that is converted
        /// from a <c>.png</c> file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeWindows_Logo { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_Logo2x
        /// <summary>
        /// <para>
        /// <para>The @2x version of the logo. This is the higher resolution display that offers a scale
        /// factor of 2.0 (or @2x). The only image format accepted is a binary data object that
        /// is converted from a <c>.png</c> file.</para><note><para> For more information about iOS image size and resolution, see <a href="https://developer.apple.com/design/human-interface-guidelines/ios/icons-and-images/image-size-and-resolution/">Image
        /// Size and Resolution </a> in the <i>Apple Human Interface Guidelines</i>.</para></note>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeIos_Logo2x { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_Logo3x
        /// <summary>
        /// <para>
        /// <para>The @3x version of the logo. This is the higher resolution display that offers a scale
        /// factor of 3.0 (or @3x). The only image format accepted is a binary data object that
        /// is converted from a <c>.png</c> file.</para><note><para> For more information about iOS image size and resolution, see <a href="https://developer.apple.com/design/human-interface-guidelines/ios/icons-and-images/image-size-and-resolution/">Image
        /// Size and Resolution </a> in the <i>Apple Human Interface Guidelines</i>.</para></note>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DeviceTypeIos_Logo3x { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The directory identifier of the WorkSpace for which you want to import client branding.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter DeviceTypeAndroid_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeAndroid_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeIos_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeLinux_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeLinux_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeOsx_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeOsx_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWeb_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWeb_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWindows_SupportEmail
        /// <summary>
        /// <para>
        /// <para>The support email. The company's customer support email address.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default email is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWindows_SupportEmail { get; set; }
        #endregion
        
        #region Parameter DeviceTypeAndroid_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeAndroid_SupportLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeIos_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeIos_SupportLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeLinux_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeLinux_SupportLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeOsx_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeOsx_SupportLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWeb_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWeb_SupportLink { get; set; }
        #endregion
        
        #region Parameter DeviceTypeWindows_SupportLink
        /// <summary>
        /// <para>
        /// <para>The support link. The link for the company's customer support page for their WorkSpace.</para><note><ul><li><para>In each platform type, the <c>SupportEmail</c> and <c>SupportLink</c> parameters are
        /// mutually exclusive. You can specify one parameter for each platform type, but not
        /// both.</para></li><li><para>The default support link is <c>workspaces-feedback@amazon.com</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceTypeWindows_SupportLink { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ImportClientBrandingResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.ImportClientBrandingResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-WKSClientBranding (ImportClientBranding)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ImportClientBrandingResponse, ImportWKSClientBrandingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceTypeAndroid_ForgotPasswordLink = this.DeviceTypeAndroid_ForgotPasswordLink;
            if (this.DeviceTypeAndroid_LoginMessage != null)
            {
                context.DeviceTypeAndroid_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeAndroid_LoginMessage.Keys)
                {
                    context.DeviceTypeAndroid_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeAndroid_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeAndroid_Logo = this.DeviceTypeAndroid_Logo;
            context.DeviceTypeAndroid_SupportEmail = this.DeviceTypeAndroid_SupportEmail;
            context.DeviceTypeAndroid_SupportLink = this.DeviceTypeAndroid_SupportLink;
            context.DeviceTypeIos_ForgotPasswordLink = this.DeviceTypeIos_ForgotPasswordLink;
            if (this.DeviceTypeIos_LoginMessage != null)
            {
                context.DeviceTypeIos_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeIos_LoginMessage.Keys)
                {
                    context.DeviceTypeIos_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeIos_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeIos_Logo = this.DeviceTypeIos_Logo;
            context.DeviceTypeIos_Logo2x = this.DeviceTypeIos_Logo2x;
            context.DeviceTypeIos_Logo3x = this.DeviceTypeIos_Logo3x;
            context.DeviceTypeIos_SupportEmail = this.DeviceTypeIos_SupportEmail;
            context.DeviceTypeIos_SupportLink = this.DeviceTypeIos_SupportLink;
            context.DeviceTypeLinux_ForgotPasswordLink = this.DeviceTypeLinux_ForgotPasswordLink;
            if (this.DeviceTypeLinux_LoginMessage != null)
            {
                context.DeviceTypeLinux_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeLinux_LoginMessage.Keys)
                {
                    context.DeviceTypeLinux_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeLinux_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeLinux_Logo = this.DeviceTypeLinux_Logo;
            context.DeviceTypeLinux_SupportEmail = this.DeviceTypeLinux_SupportEmail;
            context.DeviceTypeLinux_SupportLink = this.DeviceTypeLinux_SupportLink;
            context.DeviceTypeOsx_ForgotPasswordLink = this.DeviceTypeOsx_ForgotPasswordLink;
            if (this.DeviceTypeOsx_LoginMessage != null)
            {
                context.DeviceTypeOsx_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeOsx_LoginMessage.Keys)
                {
                    context.DeviceTypeOsx_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeOsx_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeOsx_Logo = this.DeviceTypeOsx_Logo;
            context.DeviceTypeOsx_SupportEmail = this.DeviceTypeOsx_SupportEmail;
            context.DeviceTypeOsx_SupportLink = this.DeviceTypeOsx_SupportLink;
            context.DeviceTypeWeb_ForgotPasswordLink = this.DeviceTypeWeb_ForgotPasswordLink;
            if (this.DeviceTypeWeb_LoginMessage != null)
            {
                context.DeviceTypeWeb_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeWeb_LoginMessage.Keys)
                {
                    context.DeviceTypeWeb_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeWeb_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeWeb_Logo = this.DeviceTypeWeb_Logo;
            context.DeviceTypeWeb_SupportEmail = this.DeviceTypeWeb_SupportEmail;
            context.DeviceTypeWeb_SupportLink = this.DeviceTypeWeb_SupportLink;
            context.DeviceTypeWindows_ForgotPasswordLink = this.DeviceTypeWindows_ForgotPasswordLink;
            if (this.DeviceTypeWindows_LoginMessage != null)
            {
                context.DeviceTypeWindows_LoginMessage = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeviceTypeWindows_LoginMessage.Keys)
                {
                    context.DeviceTypeWindows_LoginMessage.Add((String)hashKey, (System.String)(this.DeviceTypeWindows_LoginMessage[hashKey]));
                }
            }
            context.DeviceTypeWindows_Logo = this.DeviceTypeWindows_Logo;
            context.DeviceTypeWindows_SupportEmail = this.DeviceTypeWindows_SupportEmail;
            context.DeviceTypeWindows_SupportLink = this.DeviceTypeWindows_SupportLink;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _DeviceTypeAndroid_LogoStream = null;
            System.IO.MemoryStream _DeviceTypeIos_LogoStream = null;
            System.IO.MemoryStream _DeviceTypeIos_Logo2xStream = null;
            System.IO.MemoryStream _DeviceTypeIos_Logo3xStream = null;
            System.IO.MemoryStream _DeviceTypeLinux_LogoStream = null;
            System.IO.MemoryStream _DeviceTypeOsx_LogoStream = null;
            System.IO.MemoryStream _DeviceTypeWeb_LogoStream = null;
            System.IO.MemoryStream _DeviceTypeWindows_LogoStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.WorkSpaces.Model.ImportClientBrandingRequest();
                
                
                 // populate DeviceTypeAndroid
                var requestDeviceTypeAndroidIsNull = true;
                request.DeviceTypeAndroid = new Amazon.WorkSpaces.Model.DefaultImportClientBrandingAttributes();
                System.String requestDeviceTypeAndroid_deviceTypeAndroid_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeAndroid_ForgotPasswordLink != null)
                {
                    requestDeviceTypeAndroid_deviceTypeAndroid_ForgotPasswordLink = cmdletContext.DeviceTypeAndroid_ForgotPasswordLink;
                }
                if (requestDeviceTypeAndroid_deviceTypeAndroid_ForgotPasswordLink != null)
                {
                    request.DeviceTypeAndroid.ForgotPasswordLink = requestDeviceTypeAndroid_deviceTypeAndroid_ForgotPasswordLink;
                    requestDeviceTypeAndroidIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeAndroid_deviceTypeAndroid_LoginMessage = null;
                if (cmdletContext.DeviceTypeAndroid_LoginMessage != null)
                {
                    requestDeviceTypeAndroid_deviceTypeAndroid_LoginMessage = cmdletContext.DeviceTypeAndroid_LoginMessage;
                }
                if (requestDeviceTypeAndroid_deviceTypeAndroid_LoginMessage != null)
                {
                    request.DeviceTypeAndroid.LoginMessage = requestDeviceTypeAndroid_deviceTypeAndroid_LoginMessage;
                    requestDeviceTypeAndroidIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeAndroid_deviceTypeAndroid_Logo = null;
                if (cmdletContext.DeviceTypeAndroid_Logo != null)
                {
                    _DeviceTypeAndroid_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeAndroid_Logo);
                    requestDeviceTypeAndroid_deviceTypeAndroid_Logo = _DeviceTypeAndroid_LogoStream;
                }
                if (requestDeviceTypeAndroid_deviceTypeAndroid_Logo != null)
                {
                    request.DeviceTypeAndroid.Logo = requestDeviceTypeAndroid_deviceTypeAndroid_Logo;
                    requestDeviceTypeAndroidIsNull = false;
                }
                System.String requestDeviceTypeAndroid_deviceTypeAndroid_SupportEmail = null;
                if (cmdletContext.DeviceTypeAndroid_SupportEmail != null)
                {
                    requestDeviceTypeAndroid_deviceTypeAndroid_SupportEmail = cmdletContext.DeviceTypeAndroid_SupportEmail;
                }
                if (requestDeviceTypeAndroid_deviceTypeAndroid_SupportEmail != null)
                {
                    request.DeviceTypeAndroid.SupportEmail = requestDeviceTypeAndroid_deviceTypeAndroid_SupportEmail;
                    requestDeviceTypeAndroidIsNull = false;
                }
                System.String requestDeviceTypeAndroid_deviceTypeAndroid_SupportLink = null;
                if (cmdletContext.DeviceTypeAndroid_SupportLink != null)
                {
                    requestDeviceTypeAndroid_deviceTypeAndroid_SupportLink = cmdletContext.DeviceTypeAndroid_SupportLink;
                }
                if (requestDeviceTypeAndroid_deviceTypeAndroid_SupportLink != null)
                {
                    request.DeviceTypeAndroid.SupportLink = requestDeviceTypeAndroid_deviceTypeAndroid_SupportLink;
                    requestDeviceTypeAndroidIsNull = false;
                }
                 // determine if request.DeviceTypeAndroid should be set to null
                if (requestDeviceTypeAndroidIsNull)
                {
                    request.DeviceTypeAndroid = null;
                }
                
                 // populate DeviceTypeIos
                var requestDeviceTypeIosIsNull = true;
                request.DeviceTypeIos = new Amazon.WorkSpaces.Model.IosImportClientBrandingAttributes();
                System.String requestDeviceTypeIos_deviceTypeIos_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeIos_ForgotPasswordLink != null)
                {
                    requestDeviceTypeIos_deviceTypeIos_ForgotPasswordLink = cmdletContext.DeviceTypeIos_ForgotPasswordLink;
                }
                if (requestDeviceTypeIos_deviceTypeIos_ForgotPasswordLink != null)
                {
                    request.DeviceTypeIos.ForgotPasswordLink = requestDeviceTypeIos_deviceTypeIos_ForgotPasswordLink;
                    requestDeviceTypeIosIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeIos_deviceTypeIos_LoginMessage = null;
                if (cmdletContext.DeviceTypeIos_LoginMessage != null)
                {
                    requestDeviceTypeIos_deviceTypeIos_LoginMessage = cmdletContext.DeviceTypeIos_LoginMessage;
                }
                if (requestDeviceTypeIos_deviceTypeIos_LoginMessage != null)
                {
                    request.DeviceTypeIos.LoginMessage = requestDeviceTypeIos_deviceTypeIos_LoginMessage;
                    requestDeviceTypeIosIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeIos_deviceTypeIos_Logo = null;
                if (cmdletContext.DeviceTypeIos_Logo != null)
                {
                    _DeviceTypeIos_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeIos_Logo);
                    requestDeviceTypeIos_deviceTypeIos_Logo = _DeviceTypeIos_LogoStream;
                }
                if (requestDeviceTypeIos_deviceTypeIos_Logo != null)
                {
                    request.DeviceTypeIos.Logo = requestDeviceTypeIos_deviceTypeIos_Logo;
                    requestDeviceTypeIosIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeIos_deviceTypeIos_Logo2x = null;
                if (cmdletContext.DeviceTypeIos_Logo2x != null)
                {
                    _DeviceTypeIos_Logo2xStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeIos_Logo2x);
                    requestDeviceTypeIos_deviceTypeIos_Logo2x = _DeviceTypeIos_Logo2xStream;
                }
                if (requestDeviceTypeIos_deviceTypeIos_Logo2x != null)
                {
                    request.DeviceTypeIos.Logo2x = requestDeviceTypeIos_deviceTypeIos_Logo2x;
                    requestDeviceTypeIosIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeIos_deviceTypeIos_Logo3x = null;
                if (cmdletContext.DeviceTypeIos_Logo3x != null)
                {
                    _DeviceTypeIos_Logo3xStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeIos_Logo3x);
                    requestDeviceTypeIos_deviceTypeIos_Logo3x = _DeviceTypeIos_Logo3xStream;
                }
                if (requestDeviceTypeIos_deviceTypeIos_Logo3x != null)
                {
                    request.DeviceTypeIos.Logo3x = requestDeviceTypeIos_deviceTypeIos_Logo3x;
                    requestDeviceTypeIosIsNull = false;
                }
                System.String requestDeviceTypeIos_deviceTypeIos_SupportEmail = null;
                if (cmdletContext.DeviceTypeIos_SupportEmail != null)
                {
                    requestDeviceTypeIos_deviceTypeIos_SupportEmail = cmdletContext.DeviceTypeIos_SupportEmail;
                }
                if (requestDeviceTypeIos_deviceTypeIos_SupportEmail != null)
                {
                    request.DeviceTypeIos.SupportEmail = requestDeviceTypeIos_deviceTypeIos_SupportEmail;
                    requestDeviceTypeIosIsNull = false;
                }
                System.String requestDeviceTypeIos_deviceTypeIos_SupportLink = null;
                if (cmdletContext.DeviceTypeIos_SupportLink != null)
                {
                    requestDeviceTypeIos_deviceTypeIos_SupportLink = cmdletContext.DeviceTypeIos_SupportLink;
                }
                if (requestDeviceTypeIos_deviceTypeIos_SupportLink != null)
                {
                    request.DeviceTypeIos.SupportLink = requestDeviceTypeIos_deviceTypeIos_SupportLink;
                    requestDeviceTypeIosIsNull = false;
                }
                 // determine if request.DeviceTypeIos should be set to null
                if (requestDeviceTypeIosIsNull)
                {
                    request.DeviceTypeIos = null;
                }
                
                 // populate DeviceTypeLinux
                var requestDeviceTypeLinuxIsNull = true;
                request.DeviceTypeLinux = new Amazon.WorkSpaces.Model.DefaultImportClientBrandingAttributes();
                System.String requestDeviceTypeLinux_deviceTypeLinux_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeLinux_ForgotPasswordLink != null)
                {
                    requestDeviceTypeLinux_deviceTypeLinux_ForgotPasswordLink = cmdletContext.DeviceTypeLinux_ForgotPasswordLink;
                }
                if (requestDeviceTypeLinux_deviceTypeLinux_ForgotPasswordLink != null)
                {
                    request.DeviceTypeLinux.ForgotPasswordLink = requestDeviceTypeLinux_deviceTypeLinux_ForgotPasswordLink;
                    requestDeviceTypeLinuxIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeLinux_deviceTypeLinux_LoginMessage = null;
                if (cmdletContext.DeviceTypeLinux_LoginMessage != null)
                {
                    requestDeviceTypeLinux_deviceTypeLinux_LoginMessage = cmdletContext.DeviceTypeLinux_LoginMessage;
                }
                if (requestDeviceTypeLinux_deviceTypeLinux_LoginMessage != null)
                {
                    request.DeviceTypeLinux.LoginMessage = requestDeviceTypeLinux_deviceTypeLinux_LoginMessage;
                    requestDeviceTypeLinuxIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeLinux_deviceTypeLinux_Logo = null;
                if (cmdletContext.DeviceTypeLinux_Logo != null)
                {
                    _DeviceTypeLinux_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeLinux_Logo);
                    requestDeviceTypeLinux_deviceTypeLinux_Logo = _DeviceTypeLinux_LogoStream;
                }
                if (requestDeviceTypeLinux_deviceTypeLinux_Logo != null)
                {
                    request.DeviceTypeLinux.Logo = requestDeviceTypeLinux_deviceTypeLinux_Logo;
                    requestDeviceTypeLinuxIsNull = false;
                }
                System.String requestDeviceTypeLinux_deviceTypeLinux_SupportEmail = null;
                if (cmdletContext.DeviceTypeLinux_SupportEmail != null)
                {
                    requestDeviceTypeLinux_deviceTypeLinux_SupportEmail = cmdletContext.DeviceTypeLinux_SupportEmail;
                }
                if (requestDeviceTypeLinux_deviceTypeLinux_SupportEmail != null)
                {
                    request.DeviceTypeLinux.SupportEmail = requestDeviceTypeLinux_deviceTypeLinux_SupportEmail;
                    requestDeviceTypeLinuxIsNull = false;
                }
                System.String requestDeviceTypeLinux_deviceTypeLinux_SupportLink = null;
                if (cmdletContext.DeviceTypeLinux_SupportLink != null)
                {
                    requestDeviceTypeLinux_deviceTypeLinux_SupportLink = cmdletContext.DeviceTypeLinux_SupportLink;
                }
                if (requestDeviceTypeLinux_deviceTypeLinux_SupportLink != null)
                {
                    request.DeviceTypeLinux.SupportLink = requestDeviceTypeLinux_deviceTypeLinux_SupportLink;
                    requestDeviceTypeLinuxIsNull = false;
                }
                 // determine if request.DeviceTypeLinux should be set to null
                if (requestDeviceTypeLinuxIsNull)
                {
                    request.DeviceTypeLinux = null;
                }
                
                 // populate DeviceTypeOsx
                var requestDeviceTypeOsxIsNull = true;
                request.DeviceTypeOsx = new Amazon.WorkSpaces.Model.DefaultImportClientBrandingAttributes();
                System.String requestDeviceTypeOsx_deviceTypeOsx_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeOsx_ForgotPasswordLink != null)
                {
                    requestDeviceTypeOsx_deviceTypeOsx_ForgotPasswordLink = cmdletContext.DeviceTypeOsx_ForgotPasswordLink;
                }
                if (requestDeviceTypeOsx_deviceTypeOsx_ForgotPasswordLink != null)
                {
                    request.DeviceTypeOsx.ForgotPasswordLink = requestDeviceTypeOsx_deviceTypeOsx_ForgotPasswordLink;
                    requestDeviceTypeOsxIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeOsx_deviceTypeOsx_LoginMessage = null;
                if (cmdletContext.DeviceTypeOsx_LoginMessage != null)
                {
                    requestDeviceTypeOsx_deviceTypeOsx_LoginMessage = cmdletContext.DeviceTypeOsx_LoginMessage;
                }
                if (requestDeviceTypeOsx_deviceTypeOsx_LoginMessage != null)
                {
                    request.DeviceTypeOsx.LoginMessage = requestDeviceTypeOsx_deviceTypeOsx_LoginMessage;
                    requestDeviceTypeOsxIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeOsx_deviceTypeOsx_Logo = null;
                if (cmdletContext.DeviceTypeOsx_Logo != null)
                {
                    _DeviceTypeOsx_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeOsx_Logo);
                    requestDeviceTypeOsx_deviceTypeOsx_Logo = _DeviceTypeOsx_LogoStream;
                }
                if (requestDeviceTypeOsx_deviceTypeOsx_Logo != null)
                {
                    request.DeviceTypeOsx.Logo = requestDeviceTypeOsx_deviceTypeOsx_Logo;
                    requestDeviceTypeOsxIsNull = false;
                }
                System.String requestDeviceTypeOsx_deviceTypeOsx_SupportEmail = null;
                if (cmdletContext.DeviceTypeOsx_SupportEmail != null)
                {
                    requestDeviceTypeOsx_deviceTypeOsx_SupportEmail = cmdletContext.DeviceTypeOsx_SupportEmail;
                }
                if (requestDeviceTypeOsx_deviceTypeOsx_SupportEmail != null)
                {
                    request.DeviceTypeOsx.SupportEmail = requestDeviceTypeOsx_deviceTypeOsx_SupportEmail;
                    requestDeviceTypeOsxIsNull = false;
                }
                System.String requestDeviceTypeOsx_deviceTypeOsx_SupportLink = null;
                if (cmdletContext.DeviceTypeOsx_SupportLink != null)
                {
                    requestDeviceTypeOsx_deviceTypeOsx_SupportLink = cmdletContext.DeviceTypeOsx_SupportLink;
                }
                if (requestDeviceTypeOsx_deviceTypeOsx_SupportLink != null)
                {
                    request.DeviceTypeOsx.SupportLink = requestDeviceTypeOsx_deviceTypeOsx_SupportLink;
                    requestDeviceTypeOsxIsNull = false;
                }
                 // determine if request.DeviceTypeOsx should be set to null
                if (requestDeviceTypeOsxIsNull)
                {
                    request.DeviceTypeOsx = null;
                }
                
                 // populate DeviceTypeWeb
                var requestDeviceTypeWebIsNull = true;
                request.DeviceTypeWeb = new Amazon.WorkSpaces.Model.DefaultImportClientBrandingAttributes();
                System.String requestDeviceTypeWeb_deviceTypeWeb_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeWeb_ForgotPasswordLink != null)
                {
                    requestDeviceTypeWeb_deviceTypeWeb_ForgotPasswordLink = cmdletContext.DeviceTypeWeb_ForgotPasswordLink;
                }
                if (requestDeviceTypeWeb_deviceTypeWeb_ForgotPasswordLink != null)
                {
                    request.DeviceTypeWeb.ForgotPasswordLink = requestDeviceTypeWeb_deviceTypeWeb_ForgotPasswordLink;
                    requestDeviceTypeWebIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeWeb_deviceTypeWeb_LoginMessage = null;
                if (cmdletContext.DeviceTypeWeb_LoginMessage != null)
                {
                    requestDeviceTypeWeb_deviceTypeWeb_LoginMessage = cmdletContext.DeviceTypeWeb_LoginMessage;
                }
                if (requestDeviceTypeWeb_deviceTypeWeb_LoginMessage != null)
                {
                    request.DeviceTypeWeb.LoginMessage = requestDeviceTypeWeb_deviceTypeWeb_LoginMessage;
                    requestDeviceTypeWebIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeWeb_deviceTypeWeb_Logo = null;
                if (cmdletContext.DeviceTypeWeb_Logo != null)
                {
                    _DeviceTypeWeb_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeWeb_Logo);
                    requestDeviceTypeWeb_deviceTypeWeb_Logo = _DeviceTypeWeb_LogoStream;
                }
                if (requestDeviceTypeWeb_deviceTypeWeb_Logo != null)
                {
                    request.DeviceTypeWeb.Logo = requestDeviceTypeWeb_deviceTypeWeb_Logo;
                    requestDeviceTypeWebIsNull = false;
                }
                System.String requestDeviceTypeWeb_deviceTypeWeb_SupportEmail = null;
                if (cmdletContext.DeviceTypeWeb_SupportEmail != null)
                {
                    requestDeviceTypeWeb_deviceTypeWeb_SupportEmail = cmdletContext.DeviceTypeWeb_SupportEmail;
                }
                if (requestDeviceTypeWeb_deviceTypeWeb_SupportEmail != null)
                {
                    request.DeviceTypeWeb.SupportEmail = requestDeviceTypeWeb_deviceTypeWeb_SupportEmail;
                    requestDeviceTypeWebIsNull = false;
                }
                System.String requestDeviceTypeWeb_deviceTypeWeb_SupportLink = null;
                if (cmdletContext.DeviceTypeWeb_SupportLink != null)
                {
                    requestDeviceTypeWeb_deviceTypeWeb_SupportLink = cmdletContext.DeviceTypeWeb_SupportLink;
                }
                if (requestDeviceTypeWeb_deviceTypeWeb_SupportLink != null)
                {
                    request.DeviceTypeWeb.SupportLink = requestDeviceTypeWeb_deviceTypeWeb_SupportLink;
                    requestDeviceTypeWebIsNull = false;
                }
                 // determine if request.DeviceTypeWeb should be set to null
                if (requestDeviceTypeWebIsNull)
                {
                    request.DeviceTypeWeb = null;
                }
                
                 // populate DeviceTypeWindows
                var requestDeviceTypeWindowsIsNull = true;
                request.DeviceTypeWindows = new Amazon.WorkSpaces.Model.DefaultImportClientBrandingAttributes();
                System.String requestDeviceTypeWindows_deviceTypeWindows_ForgotPasswordLink = null;
                if (cmdletContext.DeviceTypeWindows_ForgotPasswordLink != null)
                {
                    requestDeviceTypeWindows_deviceTypeWindows_ForgotPasswordLink = cmdletContext.DeviceTypeWindows_ForgotPasswordLink;
                }
                if (requestDeviceTypeWindows_deviceTypeWindows_ForgotPasswordLink != null)
                {
                    request.DeviceTypeWindows.ForgotPasswordLink = requestDeviceTypeWindows_deviceTypeWindows_ForgotPasswordLink;
                    requestDeviceTypeWindowsIsNull = false;
                }
                Dictionary<System.String, System.String> requestDeviceTypeWindows_deviceTypeWindows_LoginMessage = null;
                if (cmdletContext.DeviceTypeWindows_LoginMessage != null)
                {
                    requestDeviceTypeWindows_deviceTypeWindows_LoginMessage = cmdletContext.DeviceTypeWindows_LoginMessage;
                }
                if (requestDeviceTypeWindows_deviceTypeWindows_LoginMessage != null)
                {
                    request.DeviceTypeWindows.LoginMessage = requestDeviceTypeWindows_deviceTypeWindows_LoginMessage;
                    requestDeviceTypeWindowsIsNull = false;
                }
                System.IO.MemoryStream requestDeviceTypeWindows_deviceTypeWindows_Logo = null;
                if (cmdletContext.DeviceTypeWindows_Logo != null)
                {
                    _DeviceTypeWindows_LogoStream = new System.IO.MemoryStream(cmdletContext.DeviceTypeWindows_Logo);
                    requestDeviceTypeWindows_deviceTypeWindows_Logo = _DeviceTypeWindows_LogoStream;
                }
                if (requestDeviceTypeWindows_deviceTypeWindows_Logo != null)
                {
                    request.DeviceTypeWindows.Logo = requestDeviceTypeWindows_deviceTypeWindows_Logo;
                    requestDeviceTypeWindowsIsNull = false;
                }
                System.String requestDeviceTypeWindows_deviceTypeWindows_SupportEmail = null;
                if (cmdletContext.DeviceTypeWindows_SupportEmail != null)
                {
                    requestDeviceTypeWindows_deviceTypeWindows_SupportEmail = cmdletContext.DeviceTypeWindows_SupportEmail;
                }
                if (requestDeviceTypeWindows_deviceTypeWindows_SupportEmail != null)
                {
                    request.DeviceTypeWindows.SupportEmail = requestDeviceTypeWindows_deviceTypeWindows_SupportEmail;
                    requestDeviceTypeWindowsIsNull = false;
                }
                System.String requestDeviceTypeWindows_deviceTypeWindows_SupportLink = null;
                if (cmdletContext.DeviceTypeWindows_SupportLink != null)
                {
                    requestDeviceTypeWindows_deviceTypeWindows_SupportLink = cmdletContext.DeviceTypeWindows_SupportLink;
                }
                if (requestDeviceTypeWindows_deviceTypeWindows_SupportLink != null)
                {
                    request.DeviceTypeWindows.SupportLink = requestDeviceTypeWindows_deviceTypeWindows_SupportLink;
                    requestDeviceTypeWindowsIsNull = false;
                }
                 // determine if request.DeviceTypeWindows should be set to null
                if (requestDeviceTypeWindowsIsNull)
                {
                    request.DeviceTypeWindows = null;
                }
                if (cmdletContext.ResourceId != null)
                {
                    request.ResourceId = cmdletContext.ResourceId;
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
            finally
            {
                if( _DeviceTypeAndroid_LogoStream != null)
                {
                    _DeviceTypeAndroid_LogoStream.Dispose();
                }
                if( _DeviceTypeIos_LogoStream != null)
                {
                    _DeviceTypeIos_LogoStream.Dispose();
                }
                if( _DeviceTypeIos_Logo2xStream != null)
                {
                    _DeviceTypeIos_Logo2xStream.Dispose();
                }
                if( _DeviceTypeIos_Logo3xStream != null)
                {
                    _DeviceTypeIos_Logo3xStream.Dispose();
                }
                if( _DeviceTypeLinux_LogoStream != null)
                {
                    _DeviceTypeLinux_LogoStream.Dispose();
                }
                if( _DeviceTypeOsx_LogoStream != null)
                {
                    _DeviceTypeOsx_LogoStream.Dispose();
                }
                if( _DeviceTypeWeb_LogoStream != null)
                {
                    _DeviceTypeWeb_LogoStream.Dispose();
                }
                if( _DeviceTypeWindows_LogoStream != null)
                {
                    _DeviceTypeWindows_LogoStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WorkSpaces.Model.ImportClientBrandingResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ImportClientBrandingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ImportClientBranding");
            try
            {
                #if DESKTOP
                return client.ImportClientBranding(request);
                #elif CORECLR
                return client.ImportClientBrandingAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceTypeAndroid_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeAndroid_LoginMessage { get; set; }
            public byte[] DeviceTypeAndroid_Logo { get; set; }
            public System.String DeviceTypeAndroid_SupportEmail { get; set; }
            public System.String DeviceTypeAndroid_SupportLink { get; set; }
            public System.String DeviceTypeIos_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeIos_LoginMessage { get; set; }
            public byte[] DeviceTypeIos_Logo { get; set; }
            public byte[] DeviceTypeIos_Logo2x { get; set; }
            public byte[] DeviceTypeIos_Logo3x { get; set; }
            public System.String DeviceTypeIos_SupportEmail { get; set; }
            public System.String DeviceTypeIos_SupportLink { get; set; }
            public System.String DeviceTypeLinux_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeLinux_LoginMessage { get; set; }
            public byte[] DeviceTypeLinux_Logo { get; set; }
            public System.String DeviceTypeLinux_SupportEmail { get; set; }
            public System.String DeviceTypeLinux_SupportLink { get; set; }
            public System.String DeviceTypeOsx_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeOsx_LoginMessage { get; set; }
            public byte[] DeviceTypeOsx_Logo { get; set; }
            public System.String DeviceTypeOsx_SupportEmail { get; set; }
            public System.String DeviceTypeOsx_SupportLink { get; set; }
            public System.String DeviceTypeWeb_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeWeb_LoginMessage { get; set; }
            public byte[] DeviceTypeWeb_Logo { get; set; }
            public System.String DeviceTypeWeb_SupportEmail { get; set; }
            public System.String DeviceTypeWeb_SupportLink { get; set; }
            public System.String DeviceTypeWindows_ForgotPasswordLink { get; set; }
            public Dictionary<System.String, System.String> DeviceTypeWindows_LoginMessage { get; set; }
            public byte[] DeviceTypeWindows_Logo { get; set; }
            public System.String DeviceTypeWindows_SupportEmail { get; set; }
            public System.String DeviceTypeWindows_SupportLink { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ImportClientBrandingResponse, ImportWKSClientBrandingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
