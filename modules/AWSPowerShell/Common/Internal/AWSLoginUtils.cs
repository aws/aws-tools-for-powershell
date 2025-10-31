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


using Amazon.PowerShell.Utils;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.SharedInterfaces;
using Amazon.SSO;
using Amazon.SSO.Model;
using Amazon.Util;
using Amazon.Util.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using static Amazon.PowerShell.Common.InvokeAWSLoginCmdlet;

#pragma warning disable CS0168
namespace Amazon.PowerShell.Common.Internal
{
    internal class AWSLoginUtils
    {
        /// <summary>
        /// Verifies the login token persisted after call to CreateOAuth2Token and updates the specified profile with login session and region.
        /// </summary>
        /// <param name="createOAuth2TokenResponse">Response received from CreateOAuth2Toke API.</param>
        /// <param name="profileName">Profile which needs to be updated or created.</param>
        /// <param name="region"></param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        internal static async Task<bool> UpdateProfileAfterAuthCodeRedemptionAsync(CoreCreateOAuth2TokenResponse createOAuth2TokenResponse, string profileName, string region, CancellationToken cancellationToken = default)
        {
            // Token is persisted in call to CreateOAuth2TokenAsync itself. We can try getting new token persisted in cache
            var loginSession = LoginUtils.ExtractLoginSessionFromIdentityToken(createOAuth2TokenResponse.TokenOutput.IdToken);
            var loginTokenFileCache = new LoginTokenFileCache(
                CryptoUtilFactory.CryptoInstance,
                new FileRetriever(),
                new DirectoryRetriever());
            var tryGetLoginTokenResponse = await loginTokenFileCache.TryGetLoginTokenAsync(loginSession, null, cancellationToken);

            // If new token was successfully retrieved based on login_session, then update the profile.
            if (tryGetLoginTokenResponse.Success)
            {
                return UpdateProfile(profileName, loginSession, region);
            }
            return false;
        }

        internal static async Task<CoreCreateOAuth2TokenResponse> ExchangeAuthCodeForTokenAsync(ICoreAmazonSignin signinClient, string baseEndpoint, string clientId, string codeVerifier, string redirectUri, string authCode, CancellationToken cancellation = default)
        {
            //UriBuilder uriBuilder = new UriBuilder(new Uri(baseEndpoint));
            //uriBuilder.Path = "/v1/token";

            //string dpopKeyPem = null;
            //tring dpopProof = signinClient.GenerateDPoPProof("POST", uriBuilder.Uri.ToString(), ref dpopKeyPem);

            return await signinClient.CreateOAuth2TokenAsync(new CoreCreateOAuth2TokenRequest()
            {
                //DpopProof = dpopProof,
                TokenInput = new CoreCreateOAuth2TokenRequestBody()
                {
                    ClientId = clientId,
                    GrantType = "authorization_code",
                    RedirectUri = redirectUri,
                    CodeVerifier = codeVerifier,
                    Code = authCode
                }
            }, true, cancellation);
        }

        internal static bool UpdateProfile(string profileName, string loginSession, string region)
        {
            // Check for profile identity change
            var existingLoginSession = AWSLoginProfileMethods.GetLoginSession(profileName);
            if (!string.IsNullOrEmpty(existingLoginSession) && existingLoginSession != loginSession)
            {
                if (!PromptForProfileIdentityChange(profileName, existingLoginSession, loginSession))
                {
                    Console.WriteLine("Login workflow aborted by user.");
                    return false;
                }
            }

            AWSLoginProfileMethods.UpdateLoginProfile(profileName, loginSession, region);
            return true;
        }

        internal static bool PromptForProfileIdentityChange(string profileName, string oldLoginSession, string newLoginSession)
        {
            Console.Write($"WARNING: Previously profile {profileName} was configured for {oldLoginSession}, ");
            Console.Write($"and is now being updated to {newLoginSession}.");
            Console.WriteLine();
            Console.Write($"Do you wish to change the identity that {profileName} is associated with? (y/n): ");

            var response = Console.ReadLine();
            return response?.ToLowerInvariant() == "y" || response?.ToLowerInvariant() == "yes";
        }

        internal static string PromptForAuthorizationCode()
        {
            Console.Write("Please enter the authorization code displayed in the browser:\n");
            return Console.ReadLine();
        }

        internal static bool IsRegionValid(string region)
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

        internal static void SendHtmlResponse(HttpListenerResponse response)
        {
            string html = string.Empty;

            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get the names of all embedded resources in the assembly
            string[] resourceNames = assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                if (resourceName.ToLower().EndsWith("AWSLoginPKCEResponse.html".ToLower()))
                {
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                html = reader.ReadToEnd();
                            }
                        }
                    }

                    break;
                }
            }

            var buffer = System.Text.Encoding.UTF8.GetBytes(html);
            response.ContentLength64 = buffer.Length;
            response.ContentType = "text/html; charset=utf-8";
            response.StatusCode = 200;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Flush();
            response.OutputStream.Close();
            response.KeepAlive = true;
        }
    }

}
