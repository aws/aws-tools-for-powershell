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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Updates the user settings.
    /// </summary>
    [Cmdlet("Update", "WSWUserSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpacesWeb.Model.UserSettings")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web UpdateUserSettings API operation.", Operation = new[] {"UpdateUserSettings"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse))]
    [AWSCmdletOutput("Amazon.WorkSpacesWeb.Model.UserSettings or Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse",
        "This cmdlet returns an Amazon.WorkSpacesWeb.Model.UserSettings object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWSWUserSettingCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CookieSynchronizationConfiguration_Allowlist
        /// <summary>
        /// <para>
        /// <para>The list of cookie specifications that are allowed to be synchronized to the remote
        /// browser.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkSpacesWeb.Model.CookieSpecification[] CookieSynchronizationConfiguration_Allowlist { get; set; }
        #endregion
        
        #region Parameter Favicon_Blob
        /// <summary>
        /// <para>
        /// <para>The image provided as a binary image file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Favicon_Blob")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Favicon_Blob { get; set; }
        #endregion
        
        #region Parameter Logo_Blob
        /// <summary>
        /// <para>
        /// <para>The image provided as a binary image file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Logo_Blob")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Logo_Blob { get; set; }
        #endregion
        
        #region Parameter Wallpaper_Blob
        /// <summary>
        /// <para>
        /// <para>The image provided as a binary image file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Wallpaper_Blob")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Wallpaper_Blob { get; set; }
        #endregion
        
        #region Parameter CookieSynchronizationConfiguration_Blocklist
        /// <summary>
        /// <para>
        /// <para>The list of cookie specifications that are blocked from being synchronized to the
        /// remote browser.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkSpacesWeb.Model.CookieSpecification[] CookieSynchronizationConfiguration_Blocklist { get; set; }
        #endregion
        
        #region Parameter BrandingConfigurationInput_ColorTheme
        /// <summary>
        /// <para>
        /// <para>The color theme for components on the web portal. Choose <c>Light</c> if you upload
        /// a dark wallpaper, or <c>Dark</c> for a light wallpaper.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.ColorTheme")]
        public Amazon.WorkSpacesWeb.ColorTheme BrandingConfigurationInput_ColorTheme { get; set; }
        #endregion
        
        #region Parameter CopyAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can copy text from the streaming session to the local device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType CopyAllowed { get; set; }
        #endregion
        
        #region Parameter DeepLinkAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can use deep links that open automatically when connecting
        /// to a session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType DeepLinkAllowed { get; set; }
        #endregion
        
        #region Parameter DisconnectTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time that a streaming session remains active after users disconnect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisconnectTimeoutInMinutes")]
        public System.Int32? DisconnectTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter DownloadAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can download files from the streaming session to the local
        /// device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType DownloadAllowed { get; set; }
        #endregion
        
        #region Parameter ToolbarConfiguration_HiddenToolbarItem
        /// <summary>
        /// <para>
        /// <para>The list of toolbar items to be hidden.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolbarConfiguration_HiddenToolbarItems")]
        public System.String[] ToolbarConfiguration_HiddenToolbarItem { get; set; }
        #endregion
        
        #region Parameter IdleDisconnectTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time that users can be idle (inactive) before they are disconnected
        /// from their streaming session and the disconnect timeout interval begins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdleDisconnectTimeoutInMinutes")]
        public System.Int32? IdleDisconnectTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter BrandingConfigurationInput_LocalizedString
        /// <summary>
        /// <para>
        /// <para>A map of localized text strings for different supported languages. Each locale must
        /// provide the required fields <c>browserTabTitle</c> and <c>welcomeText</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_LocalizedStrings")]
        public System.Collections.Hashtable BrandingConfigurationInput_LocalizedString { get; set; }
        #endregion
        
        #region Parameter ToolbarConfiguration_MaxDisplayResolution
        /// <summary>
        /// <para>
        /// <para>The maximum display resolution that is allowed for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.MaxDisplayResolution")]
        public Amazon.WorkSpacesWeb.MaxDisplayResolution ToolbarConfiguration_MaxDisplayResolution { get; set; }
        #endregion
        
        #region Parameter PasteAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can paste text from the local device to the streaming session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType PasteAllowed { get; set; }
        #endregion
        
        #region Parameter PrintAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can print to the local device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType PrintAllowed { get; set; }
        #endregion
        
        #region Parameter Favicon_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI pointing to the image file. The URI must use the format <c>s3://bucket-name/key-name</c>.
        /// You must have read access to the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Favicon_S3Uri")]
        public System.String Favicon_S3Uri { get; set; }
        #endregion
        
        #region Parameter Logo_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI pointing to the image file. The URI must use the format <c>s3://bucket-name/key-name</c>.
        /// You must have read access to the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Logo_S3Uri")]
        public System.String Logo_S3Uri { get; set; }
        #endregion
        
        #region Parameter Wallpaper_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI pointing to the image file. The URI must use the format <c>s3://bucket-name/key-name</c>.
        /// You must have read access to the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandingConfigurationInput_Wallpaper_S3Uri")]
        public System.String Wallpaper_S3Uri { get; set; }
        #endregion
        
        #region Parameter BrandingConfigurationInput_TermsOfService
        /// <summary>
        /// <para>
        /// <para>The terms of service text in Markdown format. To remove existing terms of service,
        /// provide an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrandingConfigurationInput_TermsOfService { get; set; }
        #endregion
        
        #region Parameter ToolbarConfiguration_ToolbarType
        /// <summary>
        /// <para>
        /// <para>The type of toolbar displayed during the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.ToolbarType")]
        public Amazon.WorkSpacesWeb.ToolbarType ToolbarConfiguration_ToolbarType { get; set; }
        #endregion
        
        #region Parameter UploadAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can upload files from the local device to the streaming
        /// session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType UploadAllowed { get; set; }
        #endregion
        
        #region Parameter UserSettingsArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the user settings.</para>
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
        public System.String UserSettingsArn { get; set; }
        #endregion
        
        #region Parameter ToolbarConfiguration_VisualMode
        /// <summary>
        /// <para>
        /// <para>The visual mode of the toolbar.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.VisualMode")]
        public Amazon.WorkSpacesWeb.VisualMode ToolbarConfiguration_VisualMode { get; set; }
        #endregion
        
        #region Parameter WebAuthnAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can use WebAuthn redirection for passwordless login to
        /// websites within the streaming session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType WebAuthnAllowed { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token return the result from the original successful request.
        /// </para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserSettings";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserSettingsArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSWUserSetting (UpdateUserSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse, UpdateWSWUserSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrandingConfigurationInput_ColorTheme = this.BrandingConfigurationInput_ColorTheme;
            context.Favicon_Blob = this.Favicon_Blob;
            context.Favicon_S3Uri = this.Favicon_S3Uri;
            if (this.BrandingConfigurationInput_LocalizedString != null)
            {
                context.BrandingConfigurationInput_LocalizedString = new Dictionary<System.String, Amazon.WorkSpacesWeb.Model.LocalizedBrandingStrings>(StringComparer.Ordinal);
                foreach (var hashKey in this.BrandingConfigurationInput_LocalizedString.Keys)
                {
                    context.BrandingConfigurationInput_LocalizedString.Add((String)hashKey, (Amazon.WorkSpacesWeb.Model.LocalizedBrandingStrings)(this.BrandingConfigurationInput_LocalizedString[hashKey]));
                }
            }
            context.Logo_Blob = this.Logo_Blob;
            context.Logo_S3Uri = this.Logo_S3Uri;
            context.BrandingConfigurationInput_TermsOfService = this.BrandingConfigurationInput_TermsOfService;
            context.Wallpaper_Blob = this.Wallpaper_Blob;
            context.Wallpaper_S3Uri = this.Wallpaper_S3Uri;
            context.ClientToken = this.ClientToken;
            if (this.CookieSynchronizationConfiguration_Allowlist != null)
            {
                context.CookieSynchronizationConfiguration_Allowlist = new List<Amazon.WorkSpacesWeb.Model.CookieSpecification>(this.CookieSynchronizationConfiguration_Allowlist);
            }
            if (this.CookieSynchronizationConfiguration_Blocklist != null)
            {
                context.CookieSynchronizationConfiguration_Blocklist = new List<Amazon.WorkSpacesWeb.Model.CookieSpecification>(this.CookieSynchronizationConfiguration_Blocklist);
            }
            context.CopyAllowed = this.CopyAllowed;
            context.DeepLinkAllowed = this.DeepLinkAllowed;
            context.DisconnectTimeoutInMinute = this.DisconnectTimeoutInMinute;
            context.DownloadAllowed = this.DownloadAllowed;
            context.IdleDisconnectTimeoutInMinute = this.IdleDisconnectTimeoutInMinute;
            context.PasteAllowed = this.PasteAllowed;
            context.PrintAllowed = this.PrintAllowed;
            if (this.ToolbarConfiguration_HiddenToolbarItem != null)
            {
                context.ToolbarConfiguration_HiddenToolbarItem = new List<System.String>(this.ToolbarConfiguration_HiddenToolbarItem);
            }
            context.ToolbarConfiguration_MaxDisplayResolution = this.ToolbarConfiguration_MaxDisplayResolution;
            context.ToolbarConfiguration_ToolbarType = this.ToolbarConfiguration_ToolbarType;
            context.ToolbarConfiguration_VisualMode = this.ToolbarConfiguration_VisualMode;
            context.UploadAllowed = this.UploadAllowed;
            context.UserSettingsArn = this.UserSettingsArn;
            #if MODULAR
            if (this.UserSettingsArn == null && ParameterWasBound(nameof(this.UserSettingsArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UserSettingsArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebAuthnAllowed = this.WebAuthnAllowed;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Favicon_BlobStream = null;
            System.IO.MemoryStream _Logo_BlobStream = null;
            System.IO.MemoryStream _Wallpaper_BlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.WorkSpacesWeb.Model.UpdateUserSettingsRequest();
                
                
                 // populate BrandingConfigurationInput
                var requestBrandingConfigurationInputIsNull = true;
                request.BrandingConfigurationInput = new Amazon.WorkSpacesWeb.Model.BrandingConfigurationUpdateInput();
                Amazon.WorkSpacesWeb.ColorTheme requestBrandingConfigurationInput_brandingConfigurationInput_ColorTheme = null;
                if (cmdletContext.BrandingConfigurationInput_ColorTheme != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_ColorTheme = cmdletContext.BrandingConfigurationInput_ColorTheme;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_ColorTheme != null)
                {
                    request.BrandingConfigurationInput.ColorTheme = requestBrandingConfigurationInput_brandingConfigurationInput_ColorTheme;
                    requestBrandingConfigurationInputIsNull = false;
                }
                Dictionary<System.String, Amazon.WorkSpacesWeb.Model.LocalizedBrandingStrings> requestBrandingConfigurationInput_brandingConfigurationInput_LocalizedString = null;
                if (cmdletContext.BrandingConfigurationInput_LocalizedString != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_LocalizedString = cmdletContext.BrandingConfigurationInput_LocalizedString;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_LocalizedString != null)
                {
                    request.BrandingConfigurationInput.LocalizedStrings = requestBrandingConfigurationInput_brandingConfigurationInput_LocalizedString;
                    requestBrandingConfigurationInputIsNull = false;
                }
                System.String requestBrandingConfigurationInput_brandingConfigurationInput_TermsOfService = null;
                if (cmdletContext.BrandingConfigurationInput_TermsOfService != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_TermsOfService = cmdletContext.BrandingConfigurationInput_TermsOfService;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_TermsOfService != null)
                {
                    request.BrandingConfigurationInput.TermsOfService = requestBrandingConfigurationInput_brandingConfigurationInput_TermsOfService;
                    requestBrandingConfigurationInputIsNull = false;
                }
                Amazon.WorkSpacesWeb.Model.IconImageInput requestBrandingConfigurationInput_brandingConfigurationInput_Favicon = null;
                
                 // populate Favicon
                var requestBrandingConfigurationInput_brandingConfigurationInput_FaviconIsNull = true;
                requestBrandingConfigurationInput_brandingConfigurationInput_Favicon = new Amazon.WorkSpacesWeb.Model.IconImageInput();
                System.IO.MemoryStream requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_Blob = null;
                if (cmdletContext.Favicon_Blob != null)
                {
                    _Favicon_BlobStream = new System.IO.MemoryStream(cmdletContext.Favicon_Blob);
                    requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_Blob = _Favicon_BlobStream;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_Blob != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Favicon.Blob = requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_Blob;
                    requestBrandingConfigurationInput_brandingConfigurationInput_FaviconIsNull = false;
                }
                System.String requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_S3Uri = null;
                if (cmdletContext.Favicon_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_S3Uri = cmdletContext.Favicon_S3Uri;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Favicon.S3Uri = requestBrandingConfigurationInput_brandingConfigurationInput_Favicon_favicon_S3Uri;
                    requestBrandingConfigurationInput_brandingConfigurationInput_FaviconIsNull = false;
                }
                 // determine if requestBrandingConfigurationInput_brandingConfigurationInput_Favicon should be set to null
                if (requestBrandingConfigurationInput_brandingConfigurationInput_FaviconIsNull)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Favicon = null;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Favicon != null)
                {
                    request.BrandingConfigurationInput.Favicon = requestBrandingConfigurationInput_brandingConfigurationInput_Favicon;
                    requestBrandingConfigurationInputIsNull = false;
                }
                Amazon.WorkSpacesWeb.Model.IconImageInput requestBrandingConfigurationInput_brandingConfigurationInput_Logo = null;
                
                 // populate Logo
                var requestBrandingConfigurationInput_brandingConfigurationInput_LogoIsNull = true;
                requestBrandingConfigurationInput_brandingConfigurationInput_Logo = new Amazon.WorkSpacesWeb.Model.IconImageInput();
                System.IO.MemoryStream requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_Blob = null;
                if (cmdletContext.Logo_Blob != null)
                {
                    _Logo_BlobStream = new System.IO.MemoryStream(cmdletContext.Logo_Blob);
                    requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_Blob = _Logo_BlobStream;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_Blob != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Logo.Blob = requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_Blob;
                    requestBrandingConfigurationInput_brandingConfigurationInput_LogoIsNull = false;
                }
                System.String requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_S3Uri = null;
                if (cmdletContext.Logo_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_S3Uri = cmdletContext.Logo_S3Uri;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Logo.S3Uri = requestBrandingConfigurationInput_brandingConfigurationInput_Logo_logo_S3Uri;
                    requestBrandingConfigurationInput_brandingConfigurationInput_LogoIsNull = false;
                }
                 // determine if requestBrandingConfigurationInput_brandingConfigurationInput_Logo should be set to null
                if (requestBrandingConfigurationInput_brandingConfigurationInput_LogoIsNull)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Logo = null;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Logo != null)
                {
                    request.BrandingConfigurationInput.Logo = requestBrandingConfigurationInput_brandingConfigurationInput_Logo;
                    requestBrandingConfigurationInputIsNull = false;
                }
                Amazon.WorkSpacesWeb.Model.WallpaperImageInput requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper = null;
                
                 // populate Wallpaper
                var requestBrandingConfigurationInput_brandingConfigurationInput_WallpaperIsNull = true;
                requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper = new Amazon.WorkSpacesWeb.Model.WallpaperImageInput();
                System.IO.MemoryStream requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_Blob = null;
                if (cmdletContext.Wallpaper_Blob != null)
                {
                    _Wallpaper_BlobStream = new System.IO.MemoryStream(cmdletContext.Wallpaper_Blob);
                    requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_Blob = _Wallpaper_BlobStream;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_Blob != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper.Blob = requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_Blob;
                    requestBrandingConfigurationInput_brandingConfigurationInput_WallpaperIsNull = false;
                }
                System.String requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_S3Uri = null;
                if (cmdletContext.Wallpaper_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_S3Uri = cmdletContext.Wallpaper_S3Uri;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_S3Uri != null)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper.S3Uri = requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper_wallpaper_S3Uri;
                    requestBrandingConfigurationInput_brandingConfigurationInput_WallpaperIsNull = false;
                }
                 // determine if requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper should be set to null
                if (requestBrandingConfigurationInput_brandingConfigurationInput_WallpaperIsNull)
                {
                    requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper = null;
                }
                if (requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper != null)
                {
                    request.BrandingConfigurationInput.Wallpaper = requestBrandingConfigurationInput_brandingConfigurationInput_Wallpaper;
                    requestBrandingConfigurationInputIsNull = false;
                }
                 // determine if request.BrandingConfigurationInput should be set to null
                if (requestBrandingConfigurationInputIsNull)
                {
                    request.BrandingConfigurationInput = null;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                
                 // populate CookieSynchronizationConfiguration
                var requestCookieSynchronizationConfigurationIsNull = true;
                request.CookieSynchronizationConfiguration = new Amazon.WorkSpacesWeb.Model.CookieSynchronizationConfiguration();
                List<Amazon.WorkSpacesWeb.Model.CookieSpecification> requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Allowlist = null;
                if (cmdletContext.CookieSynchronizationConfiguration_Allowlist != null)
                {
                    requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Allowlist = cmdletContext.CookieSynchronizationConfiguration_Allowlist;
                }
                if (requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Allowlist != null)
                {
                    request.CookieSynchronizationConfiguration.Allowlist = requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Allowlist;
                    requestCookieSynchronizationConfigurationIsNull = false;
                }
                List<Amazon.WorkSpacesWeb.Model.CookieSpecification> requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Blocklist = null;
                if (cmdletContext.CookieSynchronizationConfiguration_Blocklist != null)
                {
                    requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Blocklist = cmdletContext.CookieSynchronizationConfiguration_Blocklist;
                }
                if (requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Blocklist != null)
                {
                    request.CookieSynchronizationConfiguration.Blocklist = requestCookieSynchronizationConfiguration_cookieSynchronizationConfiguration_Blocklist;
                    requestCookieSynchronizationConfigurationIsNull = false;
                }
                 // determine if request.CookieSynchronizationConfiguration should be set to null
                if (requestCookieSynchronizationConfigurationIsNull)
                {
                    request.CookieSynchronizationConfiguration = null;
                }
                if (cmdletContext.CopyAllowed != null)
                {
                    request.CopyAllowed = cmdletContext.CopyAllowed;
                }
                if (cmdletContext.DeepLinkAllowed != null)
                {
                    request.DeepLinkAllowed = cmdletContext.DeepLinkAllowed;
                }
                if (cmdletContext.DisconnectTimeoutInMinute != null)
                {
                    request.DisconnectTimeoutInMinutes = cmdletContext.DisconnectTimeoutInMinute.Value;
                }
                if (cmdletContext.DownloadAllowed != null)
                {
                    request.DownloadAllowed = cmdletContext.DownloadAllowed;
                }
                if (cmdletContext.IdleDisconnectTimeoutInMinute != null)
                {
                    request.IdleDisconnectTimeoutInMinutes = cmdletContext.IdleDisconnectTimeoutInMinute.Value;
                }
                if (cmdletContext.PasteAllowed != null)
                {
                    request.PasteAllowed = cmdletContext.PasteAllowed;
                }
                if (cmdletContext.PrintAllowed != null)
                {
                    request.PrintAllowed = cmdletContext.PrintAllowed;
                }
                
                 // populate ToolbarConfiguration
                var requestToolbarConfigurationIsNull = true;
                request.ToolbarConfiguration = new Amazon.WorkSpacesWeb.Model.ToolbarConfiguration();
                List<System.String> requestToolbarConfiguration_toolbarConfiguration_HiddenToolbarItem = null;
                if (cmdletContext.ToolbarConfiguration_HiddenToolbarItem != null)
                {
                    requestToolbarConfiguration_toolbarConfiguration_HiddenToolbarItem = cmdletContext.ToolbarConfiguration_HiddenToolbarItem;
                }
                if (requestToolbarConfiguration_toolbarConfiguration_HiddenToolbarItem != null)
                {
                    request.ToolbarConfiguration.HiddenToolbarItems = requestToolbarConfiguration_toolbarConfiguration_HiddenToolbarItem;
                    requestToolbarConfigurationIsNull = false;
                }
                Amazon.WorkSpacesWeb.MaxDisplayResolution requestToolbarConfiguration_toolbarConfiguration_MaxDisplayResolution = null;
                if (cmdletContext.ToolbarConfiguration_MaxDisplayResolution != null)
                {
                    requestToolbarConfiguration_toolbarConfiguration_MaxDisplayResolution = cmdletContext.ToolbarConfiguration_MaxDisplayResolution;
                }
                if (requestToolbarConfiguration_toolbarConfiguration_MaxDisplayResolution != null)
                {
                    request.ToolbarConfiguration.MaxDisplayResolution = requestToolbarConfiguration_toolbarConfiguration_MaxDisplayResolution;
                    requestToolbarConfigurationIsNull = false;
                }
                Amazon.WorkSpacesWeb.ToolbarType requestToolbarConfiguration_toolbarConfiguration_ToolbarType = null;
                if (cmdletContext.ToolbarConfiguration_ToolbarType != null)
                {
                    requestToolbarConfiguration_toolbarConfiguration_ToolbarType = cmdletContext.ToolbarConfiguration_ToolbarType;
                }
                if (requestToolbarConfiguration_toolbarConfiguration_ToolbarType != null)
                {
                    request.ToolbarConfiguration.ToolbarType = requestToolbarConfiguration_toolbarConfiguration_ToolbarType;
                    requestToolbarConfigurationIsNull = false;
                }
                Amazon.WorkSpacesWeb.VisualMode requestToolbarConfiguration_toolbarConfiguration_VisualMode = null;
                if (cmdletContext.ToolbarConfiguration_VisualMode != null)
                {
                    requestToolbarConfiguration_toolbarConfiguration_VisualMode = cmdletContext.ToolbarConfiguration_VisualMode;
                }
                if (requestToolbarConfiguration_toolbarConfiguration_VisualMode != null)
                {
                    request.ToolbarConfiguration.VisualMode = requestToolbarConfiguration_toolbarConfiguration_VisualMode;
                    requestToolbarConfigurationIsNull = false;
                }
                 // determine if request.ToolbarConfiguration should be set to null
                if (requestToolbarConfigurationIsNull)
                {
                    request.ToolbarConfiguration = null;
                }
                if (cmdletContext.UploadAllowed != null)
                {
                    request.UploadAllowed = cmdletContext.UploadAllowed;
                }
                if (cmdletContext.UserSettingsArn != null)
                {
                    request.UserSettingsArn = cmdletContext.UserSettingsArn;
                }
                if (cmdletContext.WebAuthnAllowed != null)
                {
                    request.WebAuthnAllowed = cmdletContext.WebAuthnAllowed;
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
                if( _Favicon_BlobStream != null)
                {
                    _Favicon_BlobStream.Dispose();
                }
                if( _Logo_BlobStream != null)
                {
                    _Logo_BlobStream.Dispose();
                }
                if( _Wallpaper_BlobStream != null)
                {
                    _Wallpaper_BlobStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.UpdateUserSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "UpdateUserSettings");
            try
            {
                return client.UpdateUserSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.WorkSpacesWeb.ColorTheme BrandingConfigurationInput_ColorTheme { get; set; }
            public byte[] Favicon_Blob { get; set; }
            public System.String Favicon_S3Uri { get; set; }
            public Dictionary<System.String, Amazon.WorkSpacesWeb.Model.LocalizedBrandingStrings> BrandingConfigurationInput_LocalizedString { get; set; }
            public byte[] Logo_Blob { get; set; }
            public System.String Logo_S3Uri { get; set; }
            public System.String BrandingConfigurationInput_TermsOfService { get; set; }
            public byte[] Wallpaper_Blob { get; set; }
            public System.String Wallpaper_S3Uri { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.CookieSpecification> CookieSynchronizationConfiguration_Allowlist { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.CookieSpecification> CookieSynchronizationConfiguration_Blocklist { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType CopyAllowed { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType DeepLinkAllowed { get; set; }
            public System.Int32? DisconnectTimeoutInMinute { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType DownloadAllowed { get; set; }
            public System.Int32? IdleDisconnectTimeoutInMinute { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType PasteAllowed { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType PrintAllowed { get; set; }
            public List<System.String> ToolbarConfiguration_HiddenToolbarItem { get; set; }
            public Amazon.WorkSpacesWeb.MaxDisplayResolution ToolbarConfiguration_MaxDisplayResolution { get; set; }
            public Amazon.WorkSpacesWeb.ToolbarType ToolbarConfiguration_ToolbarType { get; set; }
            public Amazon.WorkSpacesWeb.VisualMode ToolbarConfiguration_VisualMode { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType UploadAllowed { get; set; }
            public System.String UserSettingsArn { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType WebAuthnAllowed { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.UpdateUserSettingsResponse, UpdateWSWUserSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserSettings;
        }
        
    }
}
