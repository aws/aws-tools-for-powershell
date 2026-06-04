/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 * 
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *  
 */

using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using Amazon.Runtime.Credentials.Internal;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Amazon.PowerShell.Common.Internal;
using Amazon.PowerShell.Utils;
using Amazon.Runtime;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq.Expressions;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// The Invoke-AWSSSOLogin cmdlet retrieves and caches an AWS IAM Identity Center SSO access token to exchange for AWS credentials. 
    /// To login, the requested profile must have first been set up , typically by using the Initialize-AWSSSOConfiguration Cmdlet.
    /// Login will be initiated only when the token or device registration has expired. 
    /// Please note that only one login session can be active for a given SSO Session, and 
    /// creating multiple profiles does not allow for multiple users to be authenticated against the same SSO Session.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AWSSSOLogin", DefaultParameterSetName = ProfileNameParameterSet)]
    [AWSCmdlet("Retrieves and caches an AWS SSO access token to exchange for AWS credentials.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InvokeAWSSSOLoginCmdlet : BaseCmdlet
    {
        private const int DefaultExecutionTimeoutMs = 900000; // 15 min.
        private CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger _logger = Logger.GetLogger(typeof(InvokeAWSSSOLoginCmdlet));

        public const string ProfileNameParameterSet = "Profile";
        public const string SessionNameParameterSet = "Session";


        /// <summary>
        /// The name of an SSO-based profile that contains SSO configuration information. The profile is defined in the shared configuration file '~/.aws/config'.
        /// The profile can be set up by using the Initialize-AWSSSOConfiguration cmdlet.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, ParameterSetName = ProfileNameParameterSet)]
        public string ProfileName { get; set; }

        /// <summary>
        /// <para>Name of an sso-session section of the configuration file that is used to group configuration variables for acquiring SSO access tokens, which can then be used to acquire AWS credentials.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = SessionNameParameterSet)]
        public string SessionName { get; set; }

        /// <summary>
        /// <para>Forces the cmdlet to invalidate the cached token and retrieve a new token.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// <para>Falls back to the Device Authorization flow instead of the default Authorization Code + PKCE flow.
        /// Use this when you cannot launch a browser on the device (e.g. over SSH) or are unable to start the local web server required for the authorization code flow.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseDeviceCode { get; set; }

        /// <summary>
        /// Execution timeout value in milliseconds. Default is 15 minutes.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "ExecutionTimeout (in milliseconds)")]
        public int? ExecutionTimeout { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _cancellationTokenSource = new CancellationTokenSource(ExecutionTimeout ?? DefaultExecutionTimeoutMs);
            WriteVerbose($"CancellationToken timeout: {ExecutionTimeout ?? DefaultExecutionTimeoutMs}ms");
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CredentialProfileOptions profileOptions = null;

            if (this.ParameterSetName.Equals(SessionNameParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                profileOptions = SSOProfileMethods.GetSsoSessionSection(SessionName);
                if (profileOptions == null)
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException($"session {SessionName} not found in the shared config (~/.aws/config) file."),
                        "ArgumentException", ErrorCategory.InvalidArgument, this.SessionName));
                }
            }
            else if (this.ParameterSetName.Equals(ProfileNameParameterSet, StringComparison.OrdinalIgnoreCase) && MyInvocation.BoundParameters.ContainsKey("ProfileName"))
            {

                if (!SettingsStore.TryGetProfile(ProfileName, null, out var profile))
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException($"profile {ProfileName} not found in the shared config (~/.aws/config) file."),
                        "ArgumentException", ErrorCategory.InvalidArgument, this.ProfileName));
                }

                // validate if SSO options are set. if not error out
                ValidateSSOOptions(profile.Options);
                profileOptions = profile.Options;

            }
            else
            {
                // check if default is an SSO profile
                if (!SettingsStore.TryGetProfile("default", null, out var profile))
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException($"default profile not found in the shared config (~/.aws/config) file."),
                        "ArgumentException", ErrorCategory.InvalidArgument, this));
                }

                if (profile.Options.SsoSession != null && profile.Options.SsoStartUrl != null &&
                    profile.Options.SsoRegion != null)
                {
                    profileOptions = profile.Options;
                }
                else
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException($"Either ProfileName or SessionName or a default profile with SSO configuration is required."),
                        "ArgumentException", ErrorCategory.InvalidArgument, this));
                }
            }

            // Re-resolve the start URL to detect region changes (e.g., vanity domain failover).
            // When the resolved region differs from stored sso_region, update the config.
            // If the URL is a vanity domain and resolution fails, raise an error.
            SSOResolvedEndpoint resolvedEndpoint;
            WriteVerbose($"Resolving start URL: {profileOptions.SsoStartUrl}");
            try
            {
                resolvedEndpoint = SSOEndpointResolver.ResolveAsync(profileOptions.SsoStartUrl, null).GetAwaiter().GetResult();
                WriteVerbose($"Start URL '{resolvedEndpoint.StartUrl}' resolved to '{resolvedEndpoint.ResolvedUrl}'");
                WriteVerbose($"Resolved region: {resolvedEndpoint.Region ?? "(not available from URL)"}, configured sso_region: {profileOptions.SsoRegion}");
                if (!string.IsNullOrEmpty(resolvedEndpoint.Region) && !string.Equals(resolvedEndpoint.Region, profileOptions.SsoRegion, StringComparison.OrdinalIgnoreCase))
                {
                    WriteVerbose($"Resolved region '{resolvedEndpoint.Region}' differs from configured sso_region '{profileOptions.SsoRegion}'. Updating configuration.");
                    profileOptions.SsoRegion = resolvedEndpoint.Region;
                    profileOptions.RegisterSsoSession();
                }
            }
            catch (ArgumentException ex)
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    ex, "ArgumentException", ErrorCategory.InvalidArgument, profileOptions.SsoStartUrl));
                return;
            }

            if (Force.IsPresent)
            {
                // Logoff
                SSOUtils.LogoutAsync(profileOptions, cancellationToken: _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }

            var cachedSsoToken = SSOUtils.GetCachedTokenAsync(profileOptions, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            if (cachedSsoToken != null)
            {
                if (!cachedSsoToken.IsExpired())
                {
                    Console.WriteLine($"SSO re-authentication is not necessary since a cached token exists for sso-session {profileOptions.SsoSession}. Use -Force to re-authenticate and retrieve a new token.");
                    return;
                }
                else if (!cachedSsoToken.RegisteredClientExpired() && cachedSsoToken.CanRefresh())
                {
                    Console.WriteLine("Attempting to refresh SSO Token. If the refresh fails, the SSO authorization will be initiated.");
                }
            }

            // Authorization Code + PKCE is the default for profiles with sso-session.
            // Device code if: -UseDeviceCode is set, or legacy profile (no sso-session).
            bool useAuthCodeFlow = !UseDeviceCode.IsPresent && !string.IsNullOrEmpty(profileOptions.SsoSession);

            SsoToken ssoToken;
            if (useAuthCodeFlow)
            {
                ssoToken = ProcessAuthCodeFlowAsync(profileOptions, resolvedEndpoint).GetAwaiter().GetResult();
            }
            else
            {
                ssoToken = ProcessDeviceCodeFlow(profileOptions, resolvedEndpoint);
            }

            if (ssoToken != null)
            {
                string associatedProfileMessage = ProfileName != null ? $" associated with the profile {ProfileName}" : "";
                Console.WriteLine($"SSO authentication successful for the sso-session {profileOptions.SsoSession}{associatedProfileMessage}.");
                Console.WriteLine();
            }
        }

        private SsoToken ProcessDeviceCodeFlow(CredentialProfileOptions profileOptions, SSOResolvedEndpoint resolvedEndpoint)
        {
            Action<SsoVerificationArguments> ssoVerificationCallback = args =>
            {
                Console.WriteLine(GetSSOLoginMessage(args.UserCode, args.VerificationUri));
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = args.VerificationUriComplete,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Unable to open browser.");
                }
            };
            return SSOUtils.LoginAsync(profileOptions, resolvedEndpoint, ssoVerificationCallback, _cancellationTokenSource.Token).GetAwaiter().GetResult();
        }

        private async Task<SsoToken> ProcessAuthCodeFlowAsync(CredentialProfileOptions profileOptions, SSOResolvedEndpoint resolvedEndpoint)
        {
            HttpListenerResult httpListenerResult;
            try
            {
                httpListenerResult = HttpListenerUtils.StartListenerAsync("/oauth/callback", _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to start local web server for authorization code flow.");
                throw new AmazonClientException(
                    "Failed to start local web server. Use -UseDeviceCode parameter to fall back to the device code authorization flow.", ex);
            }

            using (httpListenerResult)
            {
                // OIDC API will not accept RedirectUri with trailing slash
                var redirectUri = httpListenerResult.RedirectUri.TrimEnd('/');

                var pkceFlowOptions = new PkceFlowOptions
                {
                    RedirectUri = redirectUri,
                    IssuerUrl = profileOptions.SsoStartUrl,
                    RetrieveAuthorizationCodeCallbackAsync = async (authorizationUrl, ct) =>
                    {
                        return await RetrieveAuthorizationCodeAsync(authorizationUrl, httpListenerResult, ct).ConfigureAwait(false);
                    }
                };

                return await SSOUtils.LoginWithPkceAsync(profileOptions, resolvedEndpoint, pkceFlowOptions, _cancellationTokenSource.Token).ConfigureAwait(false);
            }
        }

        private async Task<string> RetrieveAuthorizationCodeAsync(Uri authorizationUrl, HttpListenerResult httpListenerResult, CancellationToken cancellationToken)
        {
            var authUrlString = authorizationUrl.ToString();

            Console.WriteLine();
            Console.WriteLine("Attempting to open your default browser. If the browser does not open, open the following URL.");
            Console.WriteLine("If you are unable to open the URL on this device, run this command again with the '-UseDeviceCode' option.");
            Console.WriteLine();
            Console.WriteLine(authUrlString);
            Console.WriteLine();

            // Extract the state parameter from the authorization URL for CSRF validation
            var expectedState = ExtractQueryParameter(authorizationUrl, "state");

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = authUrlString,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unable to open browser.");
            }

            // Wait for the authorization callback
            var context = await httpListenerResult.RequestTask.ConfigureAwait(false);

            var authCode = context.Request.QueryString?["code"];
            var returnedState = context.Request.QueryString?["state"];
            var error = context.Request.QueryString?["error"];

            // Step 1: Handle error response from the authorization server (RFC 6749 §4.1.2.1)
            if (error != null)
            {
                if (error.Length > 300 || !System.Text.RegularExpressions.Regex.IsMatch(error, @"^[a-zA-Z0-9_]+$"))
                {
                    error = "invalid_error_format";
                }
                var safeError = WebUtility.HtmlEncode(error);
                HttpListenerUtils.SendHtmlResponse(context.Response, safeError);
                throw new Exception($"SSO authorization error: {safeError}");
            }

            // Step 2: Validate CSRF state parameter
            if (!string.IsNullOrEmpty(expectedState) && returnedState != expectedState)
            {
                HttpListenerUtils.SendHtmlResponse(context.Response, "State parameter mismatch");
                throw new Exception($"State parameter mismatch. Expected: {expectedState}, Received: {returnedState}");
            }

            if (string.IsNullOrWhiteSpace(authCode))
            {
                HttpListenerUtils.SendHtmlResponse(context.Response, "Authorization code missing");
                throw new Exception("Authorization code is missing from the SSO redirect.");
            }

            // Step 3: Display success page only after validation passes
            HttpListenerUtils.SendHtmlResponse(context.Response, null);

            return authCode;
        }

        private void ValidateSSOOptions(CredentialProfileOptions options)
        {
            var missingProperties = SSOUtils.GetSSOMissingProperties(options);

            //it's possible that the source_profile contains the information needed.
            if (string.IsNullOrEmpty(options.SourceProfile) && missingProperties.Any())
            {
                string beginErrorMessage = $"There are missing SSO properties for the profile {ProfileName}. Use Initialize-AWSSSOConfiguration to configure SSO profile.";
                string missingPropertiesMessage = "missing SSO properties: " + string.Join(", ", missingProperties) + ".";
                this.ThrowTerminatingError(new ErrorRecord(
                               new ArgumentException(beginErrorMessage + Environment.NewLine + missingPropertiesMessage),
                               "ArgumentException", ErrorCategory.InvalidArgument, this));
            }
        }

        private string GetSSOLoginMessage(string userCode, string verificationUri)
        {
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("Attempting to open your default browser.");
            sb.Append(Environment.NewLine);
            sb.Append("If the browser does not open or you wish to use a different device to authorize this request, open the following URL:");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append($"{verificationUri.TrimEnd('/')}/?user_code={userCode}");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Then enter the code:");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(userCode);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        private static string ExtractQueryParameter(Uri uri, string parameterName)
        {
            var query = uri.Query.TrimStart('?');
            foreach (var part in query.Split('&'))
            {
                var keyValue = part.Split(new[] { '=' }, 2);
                if (keyValue.Length == 2 && WebUtility.UrlDecode(keyValue[0]) == parameterName)
                {
                    return WebUtility.UrlDecode(keyValue[1]);
                }
            }
            return null;
        }
    }

    /// <summary>
    /// <para>
    /// The Initialize-AWSSSOConfiguration cmdlet creates or updates a profile with the configuration values required to use AWS IAM Identity Center for single sign-on (SSO).
    /// The configuration is saved in the shared configuration file '~/.aws/config'.
    /// When any of the following parameters are omitted, the cmdlet prompts for their values interactively: ProfileName, SessionName, AccountId, RoleName, StartUrl, and SSORegion.
    /// When profile configuration is complete, login flow is automatically initiated by calling the Invoke-AWSSSOLogin cmdlet.
    /// </para>
    /// </summary>
    [Cmdlet("Initialize", "AWSSSOConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [AWSCmdlet("Creates or updates a profile with the configuration values required to use AWS SSO.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InitializeAWSSSOConfigurationCmdlet : BaseCmdlet
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ILogger _logger = Logger.GetLogger(typeof(InitializeAWSSSOConfigurationCmdlet));

        /// <summary>
        /// <para>Name of the profile that will be saved in the shared configuration file '~/.aws/config'.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        /// <summary>
        /// <para>Name of an sso-session section of the configuration file that is used to group configuration variables for acquiring SSO access tokens, which can then be used to acquire AWS credentials.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        /// <summary>
        /// <para>Identifier for the AWS account that is assigned to the user.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        /// <summary>
        /// <para>Name of the IAM Identity Center permission set that is assigned to the user.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        /// <summary>
        /// <para>URL that points to the organization's AWS access portal.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string StartUrl { get; set; }

        /// <summary>
        /// <para>AWS Region that contains the AWS access portal host. This is separate from, and can be a different Region than, the profile region parameter.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SSORegion { get; set; }

        /// <summary>
        /// <para>List of scopes to be authorized for the SSO session. Scopes authorize access to IAM Identity Center bearer token authorized endpoints. Default value is sso:account:access.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] RegistrationScopes { get; set; }
        //"sso:account:access"
        /// <summary>
        /// <para>System name of an AWS Region that will be set for a specified profile.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        /// <summary>
        /// <para>Falls back to the Device Authorization flow instead of the default Authorization Code + PKCE flow.
        /// Use this when you cannot launch a browser on the device (e.g. over SSH) or are unable to start the local web server required for the authorization code flow.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseDeviceCode { get; set; }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            // When any of the required parameters are not passed, interactively prompt for the values.

            #region ExistingProfile
            // if Profile is passed
            CredentialProfile existingProfile = null;
            if (ProfileName != null)
            {
                SettingsStore.TryGetProfile(ProfileName, null, out existingProfile);
            }
            #endregion

            if (StartUrl == null)
            {
                StartUrl = PromptForStartUrl(existingProfile?.Options?.SsoStartUrl);
            }

            if (IsInteractiveMode() && RegistrationScopes == null)
            {
                RegistrationScopes = PromptForRegistrationScopes();
            }

            // validate arguments
            #region Validate StartUrl

            if (!Uri.IsWellFormedUriString(StartUrl, UriKind.Absolute))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException($"{nameof(StartUrl)} {StartUrl} is not valid."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this.StartUrl));
            }
            // Remove trailing slash "/" for consistency
            if (StartUrl.EndsWith("/")) StartUrl = StartUrl.TrimEnd('/');

            #endregion

            #region Resolve StartUrl to Issuer URL and Region

            // Resolve the provided URL (which may be a vanity domain, portal URL, or issuer URL)
            // into the canonical issuer URL and region in a single resolution pass.
            WriteVerbose($"Resolving start URL: {StartUrl}");
            SSOResolvedEndpoint resolvedEndpoint;
            try
            {
                resolvedEndpoint = SSOEndpointResolver.ResolveAsync(StartUrl, SSORegion).GetAwaiter().GetResult();
            }
            catch (ArgumentException ex)
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    ex, "ArgumentException", ErrorCategory.InvalidArgument, this.StartUrl));
                return;
            }

            WriteVerbose($"Start URL '{resolvedEndpoint.StartUrl}' resolved to '{resolvedEndpoint.ResolvedUrl}'");
            WriteVerbose($"Resolved region: {resolvedEndpoint.Region ?? "(not available from URL)"}");

            // When the URL carries region, it takes precedence (user-provided SSORegion is ignored).
            // Only prompt/use user-provided value for region-less URL forms.
            if (!string.IsNullOrEmpty(resolvedEndpoint.Region))
            {
                if (SSORegion != null && !string.Equals(SSORegion, resolvedEndpoint.Region, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Note: SSO region from URL ({resolvedEndpoint.Region}) takes precedence over provided region ({SSORegion}).");
                }
                SSORegion = resolvedEndpoint.Region;
            }
            else if (SSORegion == null)
            {
                SSORegion = PromptForSSORegion(existingProfile?.Options?.SsoRegion);
            }

            #endregion

            #region RegistrationScopes

            if (!(RegistrationScopes?.Length > 0))
            {
                RegistrationScopes = new string[] { "sso:account:access" };
            }
            var registrationScopesString = string.Join(",", RegistrationScopes);

            #endregion

            #region SSORegion

            // validate SSORegion
            if (!IsRegionValid(SSORegion))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException($"{nameof(SSORegion)} {SSORegion} is not valid."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this.SSORegion));
            }
            #endregion

            #region Region

            // validate Region

            if (Region != null && !IsRegionValid(Region))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException($"{nameof(Region)} {Region} is not valid."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this.Region));
            }
            #endregion


            if (SessionName == null)
            {
                SessionName = PromptForSessionName(existingProfile?.Options?.SsoSession);
            }

            var profileOptions = new CredentialProfileOptions
            {
                SsoRegistrationScopes = registrationScopesString,
                SsoSession = SessionName,
                // Store original URL; to switch to issuer URL, replace StartUrl with resolvedEndpoint.IssuerUrl
                SsoStartUrl = StartUrl,
                SsoRegion = SSORegion
            };

            // Register sso-session section to the config and then initiate login flow.
            profileOptions.RegisterSsoSession();

            WriteVerbose("Calling Invoke-AWSSSOLogin Cmdlet");
            var useDeviceCodeFlag = UseDeviceCode.IsPresent ? " -UseDeviceCode" : "";
            var verboseFlag = MyInvocation.BoundParameters.ContainsKey("Verbose") ? " -Verbose" : "";
            ScriptBlock.Create($"param($Cmdlet, $SessionName) & $Cmdlet -SessionName $SessionName -Force{useDeviceCodeFlag}{verboseFlag}").Invoke("Invoke-AWSSSOLogin", SessionName);


            var cachedSsoToken = SSOUtils.GetCachedTokenAsync(profileOptions, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            var accountIds = SSOUtils.GetAccountIdsAsync(cachedSsoToken.AccessToken, SSORegion).GetAwaiter().GetResult();
            var promptForAccountId = true;

            if (AccountId != null)
            {
                if (accountIds.Contains(AccountId))
                {
                    promptForAccountId = false;
                    profileOptions.SsoAccountId = AccountId;
                }
                else
                {
                    Console.WriteLine($"AccountId {AccountId} is invalid.");
                }
            }

            if (promptForAccountId)
            {
                profileOptions.SsoAccountId = PromptForAccountId(accountIds, existingProfile?.Options?.SsoAccountId);
            }

            var roles = SSOUtils.GetAccountRolesAsync(profileOptions.SsoAccountId, cachedSsoToken.AccessToken, SSORegion).GetAwaiter().GetResult();
            var promptForRoleName = true;

            if (RoleName != null)
            {
                if (roles.Contains(RoleName))
                {
                    promptForRoleName = false;
                    profileOptions.SsoRoleName = RoleName;
                }
                else
                {
                    Console.WriteLine($"RoleName {RoleName} is invalid.");
                }
            }

            if (promptForRoleName)
            {
                profileOptions.SsoRoleName = PromptForRoleName(roles, existingProfile?.Options?.SsoRoleName);
            }

            if (IsInteractiveMode() && Region == null)
            {
                Region = PromptForRegion(existingProfile?.Region?.SystemName);
            }

            if (ProfileName == null)
            {
                ProfileName = PromptForProfileName(profileOptions.SsoAccountId, profileOptions.SsoRoleName);
            }

            var profile = new CredentialProfile(ProfileName, profileOptions);

            if (Region != null)
            {
                profile.Region = RegionEndpoint.GetBySystemName(Region);
            }

            profile.RegisterSsoProfileAndSession();

            Console.WriteLine();
            Console.WriteLine("To use this profile, specify the profile name using -ProfileName, as shown:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Get-S3Bucket -ProfileName '{ProfileName}'");
            Console.WriteLine();
        }

        private bool IsInteractiveMode()
        {
            // The cmdlet will be in an interactive mode when any of the required parameter values are not set.
            return !(MyInvocation.BoundParameters.ContainsKey(nameof(ProfileName)) && MyInvocation.BoundParameters.ContainsKey(nameof(AccountId))
                    && MyInvocation.BoundParameters.ContainsKey(nameof(RoleName)) && MyInvocation.BoundParameters.ContainsKey(nameof(SessionName))
                    && MyInvocation.BoundParameters.ContainsKey(nameof(StartUrl)) && MyInvocation.BoundParameters.ContainsKey(nameof(SSORegion)));
        }

        private string PromptForProfileName(string accountId, string roleName)
        {
            var defaultProfileName = $"{accountId}-{roleName}";
            bool IsProfileNameValid(string profileName) => !string.IsNullOrEmpty(profileName);
            return PromptForInput("ProfileName", null, defaultProfileName, IsProfileNameValid, false);
        }

        private string PromptForStartUrl(string currentStartUrl)
        {
            bool IsUrlValid(string url) => !string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute);
            return PromptForInput("SSO start URL", currentStartUrl, null, IsUrlValid, false);
        }

        private string PromptForSSORegion(string currentSSORegion)
        {
            return PromptForInput("SSO Region", currentSSORegion, null, IsRegionValid, false);
        }

        private string PromptForRegion(string currentRegion)
        {
            return PromptForInput("Profile region", currentRegion, null, IsRegionValid, true);
        }

        private string PromptForSessionName(string currentSessionName)
        {
            string defaultSessionName = "sso-session-" + new Uri(StartUrl).Host.Split('.')[0];
            bool IsSessionNameValid(string sessionName) => !string.IsNullOrEmpty(sessionName);
            return PromptForInput("SessionName", currentSessionName, defaultSessionName, IsSessionNameValid, false);
        }

        private string[] PromptForRegistrationScopes()
        {
            var defaultRegistrationScope = $"sso:account:access";
            var registrationScopes = new List<string>();

            var descriptions = new Collection<FieldDescription> { new FieldDescription($"SSO registration scopes [{defaultRegistrationScope}]") };
            var promptValue = Host.UI.Prompt("", "", descriptions);
            var enteredRegistrationScopes = promptValue.Values.First().ToString();

            if (string.IsNullOrEmpty(enteredRegistrationScopes))
            {
                registrationScopes.Add(defaultRegistrationScope);

            }
            else
            {
                registrationScopes = enteredRegistrationScopes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Replace("'", "").Replace("\"", "").Trim()).ToList();
            }

            return registrationScopes.ToArray();
        }

        private bool IsRegionValid(string region)
        {
            var isRegionValid = false;
            try
            {
                if (!string.IsNullOrEmpty(region) && RegionEndpoint.GetBySystemName(region).DisplayName != "Unknown")
                {
                    isRegionValid = true;
                }
            }
            catch { }

            return isRegionValid;
        }

        private string PromptForChoice(List<string> choiceValues, string currentValue, string label, string labelPlural, object targetObject)
        {
            string choiceValue = null;
            switch (choiceValues.Count)
            {
                case 0:
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException($"No {labelPlural} are set up for SSO. Please refer to https://docs.aws.amazon.com/powershell/latest/userguide/creds-idc.html for instructions."),
                        "ArgumentException", ErrorCategory.InvalidArgument, targetObject));

                    break;
                case 1:
                    choiceValue = choiceValues[0];
                    Console.WriteLine($"The only AWS {label} available to you is: {choiceValue}");
                    Console.WriteLine($"Using the {label} : {choiceValue}");
                    break;
                default:
                    {
                        bool IsChoiceValid(string choice) => !string.IsNullOrEmpty(choice) && choiceValues.Contains(choice);
                        var sb = new StringBuilder();
                        sb.Append($"The following {choiceValues.Count} AWS {labelPlural} are available to you.");
                        sb.Append(Environment.NewLine);
                        foreach (var choice in choiceValues.OrderBy(x => x))
                        {
                            sb.Append($"    {choice}");
                            sb.Append(Environment.NewLine);
                        }

                        var caption = sb.ToString();
                        choiceValue = PromptForInput($"Enter {label}", currentValue, null, IsChoiceValid, false, caption);
                        Console.WriteLine($"Using the {label} : {choiceValue}");

                        break;
                    }
            }

            return choiceValue;
        }

        // Prompts for input until the entered value is valid.
        private string PromptForInput(string fieldDescription, string currentValue, string defaultValue, Func<string, bool> isValueValid, bool optionalInput, string caption = "")
        {
            var displayDefault = currentValue ?? defaultValue;

            if (isValueValid(displayDefault))
            {
                fieldDescription += $" [{displayDefault}]";
            }

            if (displayDefault == null && optionalInput)
            {
                // When there is no current value or default for an optional input, append [None] in the display
                fieldDescription += $" [None]";
            }

            string enteredValue;
            var descriptions = new Collection<FieldDescription> { new FieldDescription(fieldDescription) };
            while (true)
            {
                enteredValue = Host.UI.Prompt(caption, "", descriptions).Values.First().ToString().Trim();

                if (string.IsNullOrEmpty(enteredValue))
                {
                    if (displayDefault != null)
                    {
                        enteredValue = displayDefault;
                    }
                    else if (optionalInput)
                    {
                        enteredValue = null;
                        break;
                    }
                }

                if (isValueValid(enteredValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input: {enteredValue}");
                }
            };

            return enteredValue;
        }
        private string PromptForAccountId(List<string> accountIds, string currentAccountId)
        {
            return PromptForChoice(accountIds, currentAccountId, "account Id", "accounts", this.AccountId);
        }

        private string PromptForRoleName(List<string> roles, string currentRoleName)
        {
            return PromptForChoice(roles, currentRoleName, "role name", "roles", this.RoleName);
        }
    }

    /// <summary>
    /// <para>
    /// The Set-AWSSSOSessionConfiguration cmdlet creates or updates an sso-session section in a configuration file.
    /// The SSO session can then be associated with a profile to retrieve SSO access tokens and AWS credentials.
    /// The configuration is saved in the shared configuration file '~/.aws/config'.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "AWSSSOSessionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [AWSCmdlet("Creates or updates an SSO profile with the configuration values required to use AWS SSO."
    )]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetAWSSSOSessionConfigurationCmdlet : BaseCmdlet
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ILogger _logger = Logger.GetLogger(typeof(SetAWSSSOSessionConfigurationCmdlet));

        /// <summary>
        /// <para>Name of an sso-session section of the configuration file that is used to group configuration variables for acquiring SSO access tokens, which can then be used to acquire AWS credentials.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public string SessionName { get; set; }

        /// <summary>
        /// <para>URL that points to the organization's AWS access portal.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public string StartUrl { get; set; }

        /// <summary>
        /// <para>AWS Region that contains the AWS access portal host. This is separate from, and can be a different Region than, the profile region parameter.
        /// When the start URL contains region information (new portal formats or vanity domains that redirect to them), this parameter is optional.
        /// The region derived from the URL takes precedence; this parameter is only used for URL forms that do not carry region (e.g., awsapps.com, issuer URL).</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SSORegion { get; set; }

        /// <summary>
        /// <para>List of scopes to be authorized for the SSO session. Scopes authorize access to IAM Identity Center bearer token authorized endpoints. Default value is sso:account:access.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string[] RegistrationScopes { get; set; }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!(RegistrationScopes?.Length > 0))
            {
                RegistrationScopes = new string[] { "sso:account:access" };
            }
            var registrationScopesString = string.Join(",", RegistrationScopes);

            // validate StartUrl
            if (!Uri.IsWellFormedUriString(StartUrl, UriKind.Absolute))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException($"StartUrl {StartUrl} is not valid."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this.StartUrl));
            }
            // Remove trailing slash for consistency
            if (StartUrl.EndsWith("/")) StartUrl = StartUrl.TrimEnd('/');

            // Resolve the provided URL into the canonical issuer URL and region in a single pass
            WriteVerbose($"Resolving start URL: {StartUrl}");
            SSOResolvedEndpoint resolvedEndpoint;
            try
            {
                resolvedEndpoint = SSOEndpointResolver.ResolveAsync(StartUrl, SSORegion).GetAwaiter().GetResult();
            }
            catch (ArgumentException ex)
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    ex, "ArgumentException", ErrorCategory.InvalidArgument, this.StartUrl));
                return;
            }

            WriteVerbose($"Start URL '{resolvedEndpoint.StartUrl}' resolved to '{resolvedEndpoint.ResolvedUrl}'");
            WriteVerbose($"Resolved region: {resolvedEndpoint.Region ?? "(not available from URL)"}");

            // When the URL carries region, it takes precedence (user-provided SSORegion is ignored).
            // Only use user-provided value for region-less URL forms.
            if (!string.IsNullOrEmpty(resolvedEndpoint.Region))
            {
                if (!string.IsNullOrEmpty(SSORegion) && !string.Equals(SSORegion, resolvedEndpoint.Region, StringComparison.OrdinalIgnoreCase))
                {
                    WriteVerbose($"SSO region from URL ({resolvedEndpoint.Region}) takes precedence over provided region ({SSORegion}).");
                }
                SSORegion = resolvedEndpoint.Region;
            }
            else if (string.IsNullOrEmpty(SSORegion))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("SSORegion is required. The region could not be determined from the start URL. " +
                        "Please provide the -SSORegion parameter."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this.StartUrl));
            }

            var profileOptions = new CredentialProfileOptions
            {
                SsoRegistrationScopes = registrationScopesString,
                SsoSession = SessionName,
                // Store original URL; to switch to issuer URL, replace StartUrl with resolvedEndpoint.IssuerUrl
                SsoStartUrl = StartUrl,
                SsoRegion = SSORegion
            };

            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionName), MyInvocation.BoundParameters);

            if (!ConfirmShouldProceed(false, resourceIdentifiersText, "Set-AWSSSOSessionConfiguration"))
            {
                return;
            }

            profileOptions.RegisterSsoSession();
        }
    }

    /// <summary>
    /// <para>
    /// The Invoke-AWSSSOLogout cmdlet removes cached IAM Identity Center SSO tokens. By default, it removes tokens across all profiles.
    /// Optionally, the cached token associated with a particular profile can be removed by using the -ProfileName parameter.
    /// To use these profiles again, run the Invoke-AWSSSOLogin cmdlet.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AWSSSOLogout", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [AWSCmdlet("By default, removes all cached AWS SSO tokens across all profiles."
    )]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InvokeAWSSSOLogoutCmdlet : BaseCmdlet
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ILogger _logger = Logger.GetLogger(typeof(InvokeAWSSSOLogoutCmdlet));

        /// <summary>
        /// <para>Name of the profile in the shared configuration file '~/.aws/config'.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public string ProfileName { get; set; }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var resourceIdentifiersText = "";
            if (!string.IsNullOrEmpty(ProfileName))
            {
                if (!SettingsStore.TryGetProfile(ProfileName, null, out var profile))
                {
                    this.ThrowTerminatingError(new ErrorRecord(
                        new ArgumentException(
                            $"profile {ProfileName} not found in the shared config (~/.aws/config) file."),
                        "ArgumentException", ErrorCategory.InvalidArgument, this.ProfileName));
                }

                ValidateSSOProfile(profile.Options);

                resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileName), MyInvocation.BoundParameters);

                if (!ConfirmShouldProceed(false, resourceIdentifiersText, "Invoke-AWSSSOLogout"))
                {
                    return;
                }

                WriteVerbose($"Logging out cached SSO token for profile {this.ProfileName}");
                SSOUtils.LogoutAsync(profile: profile, cancellationToken: _cancellationTokenSource.Token).GetAwaiter().GetResult();
                return;
            }

            resourceIdentifiersText = "All SSO tokens";
            if (!ConfirmShouldProceed(false, resourceIdentifiersText, "Invoke-AWSSSOLogout"))
            {
                return;
            }

            WriteVerbose($"Logging out all cached SSO tokens.");
            SSOUtils.LogoutAsync(cancellationToken: _cancellationTokenSource.Token).GetAwaiter().GetResult();
        }
        private void ValidateSSOProfile(CredentialProfileOptions options)
        {
            var missingProperties = SSOUtils.GetSSOMissingProperties(options);

            if (string.IsNullOrEmpty(options.SourceProfile) && missingProperties.Any())
            {
                var beginErrorMessage = $"There are missing SSO properties for the profile {ProfileName}. Update profile to add the following properties or use Invoke-AWSSSOLogoff to logoff all SSO tokens.";
                var missingPropertiesMessage = "missing SSO properties: " + string.Join(", ", missingProperties) + ".";
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException(beginErrorMessage + Environment.NewLine + missingPropertiesMessage),
                    "ArgumentException", ErrorCategory.InvalidArgument, this));
            }
        }
    }
}