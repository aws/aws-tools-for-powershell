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

using Amazon.PowerShell.Common.Internal;
using Amazon.PowerShell.Utils;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.Util;
using Amazon.Util.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Language;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// The Invoke-AWSLogin cmdlet retrieves and caches an AWS Signin access token to exchange for AWS credentials. 
    /// It will configure the named profile specified by the ProfileName parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AWSLogin")]
    [AWSCmdlet("Retrieves and caches an AWS Login access token to exchange for AWS credentials.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InvokeAWSLoginCmdlet : BaseCmdlet
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(900000); // 15 min
        private readonly ILogger _logger = Logger.GetLogger(typeof(InvokeAWSLoginCmdlet));
        private WorkflowSelector _workflowSelector;
        private const string AuthorizeEndpointPath = "/v1/authorize";
        private const string CrossDeviceRedirectUriPath = "/v1/sessions/confirmation";

        /// <summary>
        /// AWS Region to be used for login.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = false)]
        public string Region { get; set; }

        /// <summary>
        /// The name of an AWS Login profile that contains login session information. The profile is defined in the shared configuration file '~/.aws/config'.
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = false)]
        public string ProfileName { get; set; }

        /// <summary>
        /// Indicates if CmdLet should use cross-device scenario.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter NoBrowser { get; set; }

        protected override void BeginProcessing()
        {
            WriteVerbose("Executing BeginProcessing().");
            base.BeginProcessing();

            _workflowSelector = new WorkflowSelector();
        }
        protected override void StopProcessing()
        {
            // This is invoked when user presses Ctrl+C.
            // Do not attempt to write anything here since pipeline would be stopped; else subsequent statements would not be executed.
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("Executing ProcessRecord().");
            base.ProcessRecord();

            // If ProfileName is not specified, then resolve it using SDK's default profile resolution.
            if (string.IsNullOrWhiteSpace(ProfileName))
            {
                ProfileName = LoginUtils.ResolveDefaultProfile();
                Console.WriteLine($"Using profile '{ProfileName}' determined by environment defaults. To override, specify '-ProfileName' parameter.");
            }

            CredentialProfile existingProfile = null;
            if (ProfileName != null)
            {
                SettingsStore.TryGetProfile(ProfileName, null, out existingProfile);
            }

            // If Region is not specified, then try to resolve it using SDK's region resolution.
            if (string.IsNullOrWhiteSpace(Region))
            {
                Region = DetermineRegion(existingProfile);
                Console.WriteLine($"Using region '{Region}' determined by profile/environment defaults. To override, specify '-Region' parameter.");
            }

            if (Region != null && !AWSLoginUtils.IsRegionValid(Region))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException($"{nameof(Region)} {Region} is not valid."),
                    "ArgumentException", ErrorCategory.InvalidArgument, Region));
            }

            var workflow = _workflowSelector.DetermineWorkflow(NoBrowser.IsPresent);

            if (workflow == AuthorizationWorkflow.OAuth)
            {
                WriteVerbose("Executing same-device OAuth2 workflow.");
                ProcessSameDeviceWorkflow().GetAwaiter().GetResult();
            }
            else
            {
                WriteVerbose("Executing cross device workflow.");
                ProcessCrossDeviceWorkflowAsync().GetAwaiter().GetResult();
            }
        }

        private async Task ProcessSameDeviceWorkflow()
        {
            WriteVerbose("Starting same-device OAuth2 workflow");

            PkceParameters pkceParameters;
            ICoreAmazonSignin signinClient;
            string baseEndpoint;
            string redirectUri;
            string authCode;
            string clientId = LoginUtils.ClientIdSameDevice;

            // Start local web server
            HttpListenerResult httpListenerResult;
            try
            {
                WriteVerbose($"Attempting to start local HTTP listener to listen for '/oauth/callback'.");
                httpListenerResult = HttpListenerUtils.StartListenerAsync("/oauth/callback", _cancellationTokenSource.Token);
                WriteVerbose($"Local HTTP listener started listening at {httpListenerResult.RedirectUri}.");
            }
            catch (Exception ex)
            {
                WriteVerbose($"Error launching local HTTP listener. Try re-executing CmdLet with -${nameof(NoBrowser)}\n${ex}\n${ex.StackTrace}");
                Console.WriteLine($"Error launching local HTTP listener. Try re-executing CmdLet with -${nameof(NoBrowser)}");
                return;
            }

            // We may use serviceUrl parameter to override the endpoint. Setting ProfileName doesn't matter since we need it in pipeline handler only for refresh_token scenario.
            signinClient = SigninServiceClientHelpers.BuildSigninClient(RegionEndpoint.GetBySystemName(Region), null);
            baseEndpoint = signinClient.GetBaseEndpoint();
            WriteVerbose($"Base endpoint determined as '{baseEndpoint}'.");

            pkceParameters = PkceUtils.GeneratePkceParameters();

            using (httpListenerResult)
            {
                redirectUri = httpListenerResult.RedirectUri;
                Dictionary<string, string> queryStringParameters = new Dictionary<string, string>() {
                    { "response_type", "code" },
                    { "client_id", clientId },
                    { "redirect_uri", redirectUri },
                    { "state", pkceParameters.CodeVerifier },
                    { "code_challenge", pkceParameters.CodeChallenge },
                    { "code_challenge_method", pkceParameters.CodeChallengeMethod },
                    { "scope", "openid" }
                };

                string authorizeUrl = Utils.Common.ConstructUri(baseEndpoint, AuthorizeEndpointPath ,queryStringParameters);
                Console.WriteLine($"Using a browser, visit:");
                Console.WriteLine(authorizeUrl);
                Console.WriteLine();
                LaunchBrowser(authorizeUrl);

                // Wait for listener to detect redirect. If user pressed Ctrl+C, then StopProcessing() would be invoked. There we are sending cancel request via CancellationTokenSource.
                var httpListenerContext = await httpListenerResult.RequestTask;

                authCode = httpListenerContext.Request.QueryString?["code"];
                var returnedState = httpListenerContext.Request.QueryString?["state"]; // This has CSRF Prevention String
                var error = httpListenerContext.Request.QueryString["error"];

                AWSLoginUtils.SendHtmlResponse(httpListenerContext.Response);

                if (error != null)
                {
                    throw new Exception($"OAuth error: {error}");
                }

                if (returnedState != pkceParameters.CodeVerifier)
                {
                    throw new Exception("State mismatch - possible CSRF attack");
                }

                Thread.Sleep(1000); // Sleep for 1 sec. Sometimes response if not displayed on time before HTTP listener is disposed off.
            }

            // Exchange auth code for token
            var exchangeAuthCodeForTokenResponse = await AWSLoginUtils.ExchangeAuthCodeForTokenAsync(signinClient, baseEndpoint, clientId, pkceParameters.CodeVerifier, redirectUri, authCode, _cancellationTokenSource.Token);

            // Process result of CreateOAuth2Token call to update profile with login_session. Token is persisted in call to CreateOAuth2TokenAsync itself by pipeline handler.
            bool tokenAndProfileProcessed = await AWSLoginUtils.UpdateProfileAfterAuthCodeRedemptionAsync(exchangeAuthCodeForTokenResponse, ProfileName, Region, _cancellationTokenSource.Token);
            if (tokenAndProfileProcessed)
            {
                Console.WriteLine($"Login completed successfully for profile '{ProfileName}'");
            }
        }

        private async Task ProcessCrossDeviceWorkflowAsync()
        {
            WriteVerbose("Starting cross-device workflow");

            var pkceParameters = PkceUtils.GeneratePkceParameters();
            var clientId = LoginUtils.ClientIdCrossDevice;

            // We may use serviceUrl parameter to override the endpoint. Setting ProfileName doesn't matter since we need it in pipeline handler only for refresh_token scenario.
            var signinClient = SigninServiceClientHelpers.BuildSigninClient(RegionEndpoint.GetBySystemName(Region), null);
            string baseEndpoint = signinClient.GetBaseEndpoint();
            string redirectUri = (new UriBuilder(baseEndpoint) { Path = CrossDeviceRedirectUriPath }).Uri.ToString();

            WriteVerbose($"Base endpoint determined as '{baseEndpoint}'.");
            
            Dictionary<string, string> queryStringParameters = new Dictionary<string, string>() {
                { "response_type", "code" },
                { "client_id", clientId },
                { "redirect_uri", redirectUri },
                { "state", pkceParameters.CodeVerifier },
                { "code_challenge", pkceParameters.CodeChallenge },
                { "code_challenge_method", pkceParameters.CodeChallengeMethod },
                { "scope", "openid" }
            };

            string authorizeUrl = Utils.Common.ConstructUri(baseEndpoint, AuthorizeEndpointPath,queryStringParameters);
            
            Console.WriteLine("Please complete the login workflow via the following URL:\n");
            Console.WriteLine(authorizeUrl);
            Console.WriteLine();

            // Prompt for authorization code. The verification code displayed in browser is a Base64 encoded string of code=xyz&state=abc
            var base64EncodedVerificationCode = AWSLoginUtils.PromptForAuthorizationCode();
            byte[] verificationCodeData = Convert.FromBase64String(base64EncodedVerificationCode);
            var verificationCodeDataString = Encoding.UTF8.GetString(verificationCodeData);
            var verificationCodePropertyBag = verificationCodeDataString.Split('&')
                                                    .Select(part => part.Split('='))
                                                    .Where(part => part.Length == 2)
                                                    .ToDictionary(part => part[0], part => part[1]);
            var authCode = verificationCodePropertyBag["code"];
            var returnedState = verificationCodePropertyBag["state"]; // This has CSRF Prevention String

            if (returnedState != pkceParameters.CodeVerifier)
            {
                throw new Exception("State mismatch - possible CSRF attack");
            }

            // Exchange auth code for token
            var exchangeAuthCodeForTokenResponse = await AWSLoginUtils.ExchangeAuthCodeForTokenAsync(signinClient, baseEndpoint, clientId, pkceParameters.CodeVerifier, redirectUri, authCode, _cancellationTokenSource.Token);

            // Process result of CreateOAuth2Token call to update profile with login_session. Token is persisted in call to CreateOAuth2TokenAsync itself by pipeline handler.
            bool tokenAndProfileProcessed = await AWSLoginUtils.UpdateProfileAfterAuthCodeRedemptionAsync(exchangeAuthCodeForTokenResponse, ProfileName, Region, _cancellationTokenSource.Token);
            if (tokenAndProfileProcessed)
            {
                Console.WriteLine($"Login completed successfully for profile '{ProfileName}'");
            }
        }

        private void LaunchBrowser(string authorizationUrl)
        {
            if (!string.IsNullOrWhiteSpace(authorizationUrl))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = authorizationUrl,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    // Do nothing
                }
            }
        }

        private string DetermineRegion(CredentialProfile existingProfile)
        {
            // First determine region from existing profile.
            string region = existingProfile?.Region?.SystemName;

            if (string.IsNullOrWhiteSpace(region))
            {
                region = FallbackRegionFactory.GetRegionEndpoint()?.SystemName;
            }

            // If Region could not be determined using the SDK's region resolution, then prompt for Region.
            if (string.IsNullOrWhiteSpace(region))
            {
                region = PromptForRegion(existingProfile?.Region?.SystemName);
            }

            return region;
        }

        private string PromptForRegion(string currentRegion)
        {
            return PromptForInput("No AWS region has been configured. The AWS region is the geographic location of your AWS resources.\r\n\r\nIf you've used AWS before and already have resources in your account, tell us which region they were created in. If you haven't created resources in your account before, you can pick the region closest to you: https://docs.aws.amazon.com/global-infrastructure/latest/regions/aws-regions.html\r\n\r\nAWS Region", currentRegion, null, AWSLoginUtils.IsRegionValid, true);
        }

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
            }
            ;

            return enteredValue;
        }

        public enum AuthorizationWorkflow
        {
            OAuth,      // Same-device with browser
            CrossDevice // Cross-device workflow
        }

        public class WorkflowSelector
        {
            public AuthorizationWorkflow DetermineWorkflow(bool noBrowser)
            {
                if (noBrowser) return AuthorizationWorkflow.CrossDevice;

                // PowerShell-specific browser detection
                if (!CanLaunchBrowser()) return AuthorizationWorkflow.CrossDevice;

                return AuthorizationWorkflow.OAuth;
            }

            private bool CanLaunchBrowser()
            {
                try
                {
                    // Try launching the default localhost endpoint.
                    using (var process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "http://127.0.0.1/",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    }))
                    {
                        process?.Kill();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// <para>
    /// The Invoke-AWSLogout cmdlet removes cached login token for a profile. To use the profile again, run the Invoke-AWSLogin cmdlet.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AWSLogout", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [AWSCmdlet("Removes cached login token for a profile.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InvokeAWSLogoutCmdlet : BaseCmdlet
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(900000); // 15 min
        private readonly ILogger _logger = Logger.GetLogger(typeof(InvokeAWSLogoutCmdlet));

        /// <summary>
        /// <para>Name of the profile in the shared configuration file '~/.aws/config'.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public string ProfileName { get; set; }

        /// <summary>
        /// Indicates if CmdLet log out of all profiles that use Login credentials at once.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter All { get; set; }

        protected override void StopProcessing()
        {
            // This is invoked when user presses Ctrl+C.
            // Do not attempt to write anything here since pipeline would be stopped; else subsequent statements would not be executed.
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("Executing ProcessRecord().");
            base.ProcessRecord();

            var fileRetriever = new FileRetriever();
            LoginTokenFileCache loginTokenFileCache = null;
            var resourceIdentifiersText = "";

            // If All switch parameter is present, then we need to clear all cached tokens.
            if (All.IsPresent)
            {
                resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("[All Tokens]", MyInvocation.BoundParameters);
                if (!ConfirmShouldProceed(false, resourceIdentifiersText, "Invoke-AWSLogout"))
                {
                    return;
                }

                WriteVerbose($"Clearing all cached login tokens.");
                loginTokenFileCache = new LoginTokenFileCache(
                        CryptoUtilFactory.CryptoInstance,
                        fileRetriever,
                        new DirectoryRetriever());
                var allTokens = loginTokenFileCache.ScanLoginTokens(null);
                try
                {
                    foreach (var token in allTokens)
                    {
                        fileRetriever.Delete(token.LoginTokenFilePath);
                    }
                }
                catch(Exception ex)
                {
                    new IOException($"Could not remove credentials for all profiles that use 'login_session'. Some credentials might be deleted. Note, SDKs and tools who have already loaded the access tokens may continue to use them until their expiration.", ex);
                }

                Console.WriteLine($"Removed credentials for all profiles that use 'login_session'. Note, SDKs and tools who have already loaded the access tokens may continue to use them until their expiration.");
            }
            else
            {
                // If ProfileName is not specified, then resolve it using SDK's default profile resolution.
                if (string.IsNullOrWhiteSpace(ProfileName))
                {
                    ProfileName = LoginUtils.ResolveDefaultProfile();
                    Console.WriteLine($"Using profile '{ProfileName}' determined by environment defaults. To override, specify '-ProfileName' parameter.");
                }

                if (!string.IsNullOrEmpty(ProfileName))
                {
                    if (!SettingsStore.TryGetProfile(ProfileName, null, out var profile))
                    {
                        this.ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException(
                                $"Profile {ProfileName} not found in the shared config (~/.aws/config) file."),
                            "ArgumentException", ErrorCategory.InvalidArgument, this.ProfileName));
                    }

                    resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileName), MyInvocation.BoundParameters);

                    if (!ConfirmShouldProceed(false, resourceIdentifiersText, "Invoke-AWSLogout"))
                    {
                        return;
                    }

                    WriteVerbose($"Clearing cached login token for profile {this.ProfileName}");
                    var loginSession = AWSLoginProfileMethods.GetLoginSession(this.ProfileName);
                    if (string.IsNullOrEmpty(loginSession))
                    {
                        this.ThrowTerminatingError(new ErrorRecord(
                            new InvalidOperationException(
                                $"Profile {ProfileName} is not associated with a login session."),
                            "InvalidOperationException", ErrorCategory.InvalidOperation, this.ProfileName));
                    }

                    loginTokenFileCache = new LoginTokenFileCache(
                        CryptoUtilFactory.CryptoInstance,
                        fileRetriever,
                        new DirectoryRetriever());

                    loginTokenFileCache.DeleteLoginToken(loginSession, null);
                    Console.WriteLine($"Removed credentials for profile '{ProfileName}'. Note, SDKs and tools who have already loaded the access token may continue to use it until its expiration.");

                    return;
                }
            }
        }
    }
}