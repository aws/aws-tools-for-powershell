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

namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Creates a user settings resource that can be associated with a web portal. Once associated
    /// with a web portal, user settings control how users can transfer data between a streaming
    /// session and the their local devices.
    /// </summary>
    [Cmdlet("New", "WSWUserSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web CreateUserSettings API operation.", Operation = new[] {"CreateUserSettings"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWSWUserSettingCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalEncryptionContext
        /// <summary>
        /// <para>
        /// <para>The additional encryption context of the user settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AdditionalEncryptionContext { get; set; }
        #endregion
        
        #region Parameter CookieSynchronizationConfiguration_Allowlist
        /// <summary>
        /// <para>
        /// <para>The list of cookie specifications that are allowed to be synchronized to the remote
        /// browser.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkSpacesWeb.Model.CookieSpecification[] CookieSynchronizationConfiguration_Allowlist { get; set; }
        #endregion
        
        #region Parameter CookieSynchronizationConfiguration_Blocklist
        /// <summary>
        /// <para>
        /// <para>The list of cookie specifications that are blocked from being synchronized to the
        /// remote browser.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkSpacesWeb.Model.CookieSpecification[] CookieSynchronizationConfiguration_Blocklist { get; set; }
        #endregion
        
        #region Parameter CopyAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can copy text from the streaming session to the local device.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType CopyAllowed { get; set; }
        #endregion
        
        #region Parameter CustomerManagedKey
        /// <summary>
        /// <para>
        /// <para>The customer managed key used to encrypt sensitive information in the user settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerManagedKey { get; set; }
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType DownloadAllowed { get; set; }
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
        
        #region Parameter PasteAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can paste text from the local device to the streaming session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType PasteAllowed { get; set; }
        #endregion
        
        #region Parameter PrintAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can print to the local device.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType PrintAllowed { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the user settings resource. A tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpacesWeb.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UploadAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user can upload files from the local device to the streaming
        /// session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.EnabledType")]
        public Amazon.WorkSpacesWeb.EnabledType UploadAllowed { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token returns the result from the original successful request.
        /// </para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserSettingsArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserSettingsArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WSWUserSetting (CreateUserSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse, NewWSWUserSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalEncryptionContext != null)
            {
                context.AdditionalEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalEncryptionContext.Keys)
                {
                    context.AdditionalEncryptionContext.Add((String)hashKey, (System.String)(this.AdditionalEncryptionContext[hashKey]));
                }
            }
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
            #if MODULAR
            if (this.CopyAllowed == null && ParameterWasBound(nameof(this.CopyAllowed)))
            {
                WriteWarning("You are passing $null as a value for parameter CopyAllowed which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerManagedKey = this.CustomerManagedKey;
            context.DeepLinkAllowed = this.DeepLinkAllowed;
            context.DisconnectTimeoutInMinute = this.DisconnectTimeoutInMinute;
            context.DownloadAllowed = this.DownloadAllowed;
            #if MODULAR
            if (this.DownloadAllowed == null && ParameterWasBound(nameof(this.DownloadAllowed)))
            {
                WriteWarning("You are passing $null as a value for parameter DownloadAllowed which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdleDisconnectTimeoutInMinute = this.IdleDisconnectTimeoutInMinute;
            context.PasteAllowed = this.PasteAllowed;
            #if MODULAR
            if (this.PasteAllowed == null && ParameterWasBound(nameof(this.PasteAllowed)))
            {
                WriteWarning("You are passing $null as a value for parameter PasteAllowed which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrintAllowed = this.PrintAllowed;
            #if MODULAR
            if (this.PrintAllowed == null && ParameterWasBound(nameof(this.PrintAllowed)))
            {
                WriteWarning("You are passing $null as a value for parameter PrintAllowed which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkSpacesWeb.Model.Tag>(this.Tag);
            }
            context.UploadAllowed = this.UploadAllowed;
            #if MODULAR
            if (this.UploadAllowed == null && ParameterWasBound(nameof(this.UploadAllowed)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadAllowed which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WorkSpacesWeb.Model.CreateUserSettingsRequest();
            
            if (cmdletContext.AdditionalEncryptionContext != null)
            {
                request.AdditionalEncryptionContext = cmdletContext.AdditionalEncryptionContext;
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
            if (cmdletContext.CustomerManagedKey != null)
            {
                request.CustomerManagedKey = cmdletContext.CustomerManagedKey;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UploadAllowed != null)
            {
                request.UploadAllowed = cmdletContext.UploadAllowed;
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
        
        private Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.CreateUserSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "CreateUserSettings");
            try
            {
                return client.CreateUserSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalEncryptionContext { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.CookieSpecification> CookieSynchronizationConfiguration_Allowlist { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.CookieSpecification> CookieSynchronizationConfiguration_Blocklist { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType CopyAllowed { get; set; }
            public System.String CustomerManagedKey { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType DeepLinkAllowed { get; set; }
            public System.Int32? DisconnectTimeoutInMinute { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType DownloadAllowed { get; set; }
            public System.Int32? IdleDisconnectTimeoutInMinute { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType PasteAllowed { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType PrintAllowed { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.Tag> Tag { get; set; }
            public Amazon.WorkSpacesWeb.EnabledType UploadAllowed { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.CreateUserSettingsResponse, NewWSWUserSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserSettingsArn;
        }
        
    }
}
