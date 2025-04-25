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


using System;
using System.Collections.Generic;
using Amazon.Util.Internal;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.CredentialManagement;
using Amazon.Util;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using Amazon.Runtime.Internal;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SSO;
using Amazon.SSO.Model;

#pragma warning disable CS0168
namespace Amazon.PowerShell.Common.Internal
{
    internal class SSOUtils
    {
        private const string clientName = "AWSPowerShell";

        /// <summary>
        /// Initiates the SSO login flow for a given CredentialProfile and ssoVerificationCallback.
        /// The login flow is initiated by using .NET SDK's SSOTokenManager class by setting SSOTokenManagerGetTokenOptions' ssoVerificationCallback and supportsGettingNewToken to true.
        /// </summary>
        internal static async Task<SsoToken> LoginAsync(CredentialProfile profile, Action<SsoVerificationArguments> ssoVerificationCallback, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profile, supportsGettingNewToken: true, ssoVerificationCallback);
            return await GetTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initiates the SSO login flow for a given CredentialProfileOptions and ssoVerificationCallback.
        /// The login flow is initiated by using .NET SDK's SSOTokenManager class by setting SSOTokenManagerGetTokenOptions' ssoVerificationCallback and supportsGettingNewToken to true.
        /// </summary>
        internal static async Task<SsoToken> LoginAsync(CredentialProfileOptions profileOptions, Action<SsoVerificationArguments> ssoVerificationCallback, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profileOptions, supportsGettingNewToken: true, ssoVerificationCallback);
            return await GetTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initiates the SSO logout flow for a cached sso token associated with a CredentialProfile.
        /// </summary>
        internal static async Task LogoutAsync(CredentialProfile profile, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profile, supportsGettingNewToken: false, ssoVerificationCallback: null);
            var ssoTokenManager = new SSOTokenManager(
                null,
                new SSOTokenFileCache(
                    CryptoUtilFactory.CryptoInstance,
                    new FileRetriever(),
                    new DirectoryRetriever())
            );
            await ssoTokenManager.LogoutAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initiates the SSO logout flow for a cached sso token associated with a CredentialProfileOptions.
        /// </summary>
        internal static async Task LogoutAsync(CredentialProfileOptions profileOptions, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profileOptions, supportsGettingNewToken: false, ssoVerificationCallback: null);
            var ssoTokenManager = new SSOTokenManager(
                null,
                new SSOTokenFileCache(
                    CryptoUtilFactory.CryptoInstance,
                    new FileRetriever(),
                    new DirectoryRetriever())
            );
            await ssoTokenManager.LogoutAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initiates the SSO login flow for all cached sso tokens.
        /// </summary>
        internal static async Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            var ssoTokenManager = new SSOTokenManager(
                null,
                new SSOTokenFileCache(
                    CryptoUtilFactory.CryptoInstance,
                    new FileRetriever(),
                    new DirectoryRetriever())
            );
            await ssoTokenManager.LogoutAsync(ssoCacheDirectory: null, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves a cached token located at .aws/sso/cache for a given CredentialProfile.
        /// </summary>
        internal static async Task<SsoToken> GetCachedTokenAsync(CredentialProfile profile, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profile, supportsGettingNewToken: false, ssoVerificationCallback: null);
            return await GetCachedTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a cached token located at .aws/sso/cache for a given CredentialProfileOptions.
        /// </summary>
        internal static async Task<SsoToken> GetCachedTokenAsync(CredentialProfileOptions profileOptions, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profileOptions, supportsGettingNewToken: false, ssoVerificationCallback: null);
            return await GetCachedTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a cached token located at .aws/sso/cache for a given SSOTokenManagerGetTokenOptions.
        /// </summary>
        internal static async Task<SsoToken> GetCachedTokenAsync(SSOTokenManagerGetTokenOptions ssoTokenManagerGetTokenOptions, CancellationToken cancellationToken = default)
        {
            SsoToken ssoToken = null;
            SSOTokenFileCache ssoTokenFileCache = new SSOTokenFileCache(CryptoUtilFactory.CryptoInstance, new FileRetriever(), new DirectoryRetriever());
            var ssoTokenResponse = await ssoTokenFileCache.TryGetSsoTokenAsync(ssoTokenManagerGetTokenOptions, ssoCacheDirectory: null, cancellationToken).ConfigureAwait(false);
            if (ssoTokenResponse.Success)
            {
                ssoToken = ssoTokenResponse.Value;
            }
            return ssoToken;
        }

        /// <summary>
        /// Retrieves an SSO token using .NET SDK's SSOTokenManager based on SSOTokenManagerGetTokenOptions.
        /// </summary>
        internal static async Task<SsoToken> GetTokenAsync(SSOTokenManagerGetTokenOptions ssoTokenManagerGetTokenOptions, CancellationToken cancellationToken = default)
        {
            var ssoTokenManager = new SSOTokenManager(
                SSOServiceClientHelpers.BuildSSOIDCClient(RegionEndpoint.GetBySystemName(ssoTokenManagerGetTokenOptions.Region), null),
                new SSOTokenFileCache(
                    CryptoUtilFactory.CryptoInstance,
                    new FileRetriever(),
                    new DirectoryRetriever())
            );
            return await ssoTokenManager.GetTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns true if SSO Token refresh succeeded given a CredentialProfile.
        /// There is no good way to determine when a session session has expired.
        /// The only way is to try and refresh the SSO Token and check for exception.
        /// </summary>
        internal static async Task<bool> TryRefreshTokenAsync(CredentialProfile profile, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profile, supportsGettingNewToken: false, ssoVerificationCallback: null);
            return await TryRefreshTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns true if SSO Token refresh succeeded given SSOTokenManagerGetTokenOptions.
        /// There is no good way to determine when a session session has expired.
        /// The only way is to try and refresh the SSO Token and check for exception.
        /// </summary>
        internal static async Task<bool> TryRefreshTokenAsync(SSOTokenManagerGetTokenOptions ssoTokenManagerGetTokenOptions, CancellationToken cancellationToken = default)
        {
            bool refreshSuccessful = false;
            try
            {
                var accessToken = await GetTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken).ConfigureAwait(false);
                refreshSuccessful = true;
            }
            catch (AmazonClientException ex)
            {
                // this is expected when the token has expired.
            }
            return refreshSuccessful;
        }

        /// <summary>
        /// Returns true if the SSO Token has expired and SSO Login is required.
        /// </summary>
        internal static async Task<bool> IsSsoLoginRequiredAsync(CredentialProfile profile, CancellationToken cancellationToken = default)
        {
            var ssoTokenManagerGetTokenOptions = SSOUtils.BuildSSOTokenManagerGetTokenOptions(profile, supportsGettingNewToken: false, ssoVerificationCallback: null);
            return await IsSsoLoginRequiredAsync(ssoTokenManagerGetTokenOptions).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns true if the SSO Token has expired and SSO Login is required.
        /// </summary>
        internal static async Task<bool> IsSsoLoginRequiredAsync(SSOTokenManagerGetTokenOptions ssoTokenManagerGetTokenOptions, CancellationToken cancellationToken = default)
        {
            var cachedSsoToken = await GetCachedTokenAsync(ssoTokenManagerGetTokenOptions, cancellationToken);

            if (cachedSsoToken == null) return true;

            if (cachedSsoToken.RegisteredClientExpired()) return true;

            // non-refreshable token
            if (cachedSsoToken.IsExpired() && !cachedSsoToken.CanRefresh()) return true;

            // refreshable token but session expired.
            // the only way to check for this condition is to try to refresh token.
            if (cachedSsoToken.IsExpired() && cachedSsoToken.CanRefresh())
            {
                bool refreshTokenSucceeded = await TryRefreshTokenAsync(ssoTokenManagerGetTokenOptions).ConfigureAwait(false);
                if (!refreshTokenSucceeded)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Builds SSOTokenManagerGetTokenOptions using CredentialProfile.
        /// </summary>
        internal static SSOTokenManagerGetTokenOptions BuildSSOTokenManagerGetTokenOptions(CredentialProfile profile, bool supportsGettingNewToken, Action<SsoVerificationArguments> ssoVerificationCallback)
        {
            return BuildSSOTokenManagerGetTokenOptions(profile.Options, supportsGettingNewToken, ssoVerificationCallback);
        }

        /// <summary>
        /// Builds SSOTokenManagerGetTokenOptions using CredentialProfileOptions.
        /// </summary>
        internal static SSOTokenManagerGetTokenOptions BuildSSOTokenManagerGetTokenOptions(CredentialProfileOptions profileOptions, bool supportsGettingNewToken, Action<SsoVerificationArguments> ssoVerificationCallback)
        {
            return new SSOTokenManagerGetTokenOptions()
            {
                ClientName = clientName,
                Region = profileOptions.SsoRegion,
                StartUrl = profileOptions.SsoStartUrl,
                Session = profileOptions.SsoSession,
                Scopes = profileOptions.SsoRegistrationScopes?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList(),
                SsoVerificationCallback = ssoVerificationCallback,
                SupportsGettingNewToken = supportsGettingNewToken
            };
        }

        /// <summary>
        /// Builds SSOTokenManagerGetTokenOptions using SSOAWSCredentials.
        /// </summary>
        internal static SSOTokenManagerGetTokenOptions BuildSSOTokenManagerGetTokenOptions(SSOAWSCredentials ssoAwsCredentials, bool supportsGettingNewToken, Action<SsoVerificationArguments> ssoVerificationCallback)
        {
            return new SSOTokenManagerGetTokenOptions()
            {
                ClientName = clientName,
                Region = ssoAwsCredentials.Region,
                StartUrl = ssoAwsCredentials.StartUrl,
                Session = ssoAwsCredentials.Options.SessionName,
                Scopes = ssoAwsCredentials.Options.Scopes,
                SsoVerificationCallback = ssoVerificationCallback,
                SupportsGettingNewToken = supportsGettingNewToken
            };
        }

        /// <summary>
        /// Gets list of required properties that are missing from an existing SSO profile options.
        /// </summary>
        internal static List<string> GetSSOMissingProperties(CredentialProfileOptions options)
        {
            var missingProperties = new List<string>();
            if (string.IsNullOrEmpty(options?.SsoSession))
            {
                missingProperties.Add("sso_session");
            }
            if (string.IsNullOrEmpty(options?.SsoAccountId))
            {
                missingProperties.Add("sso_account_id");
            }
            if (string.IsNullOrEmpty(options?.SsoRoleName))
            {
                missingProperties.Add("sso_role_name");
            }
            if (string.IsNullOrEmpty(options?.SsoStartUrl))
            {
                missingProperties.Add("sso_start_url");
            }
            if (string.IsNullOrEmpty(options?.SsoRegion))
            {
                missingProperties.Add("sso_region");
            }
            if (string.IsNullOrEmpty(options?.SsoRegistrationScopes))
            {
                missingProperties.Add("sso_registration_scopes");
            }

            return missingProperties;
        }

        internal static async Task<List<string>> GetAccountIdsAsync(string accessToken, string ssoRegion, CancellationToken cancellationToken = default)
        {
            var ssoClient = new AmazonSSOClient(new AnonymousAWSCredentials(), RegionEndpoint.GetBySystemName(ssoRegion));
            var listAccountsRequest = new ListAccountsRequest { AccessToken = accessToken };
            var accounts = await ssoClient.ListAccountsAsync(listAccountsRequest, cancellationToken).ConfigureAwait(false);

            return accounts.AccountList.Select(account => account.AccountId).OrderBy(a => a).ToList();
        }

        internal static async Task<List<string>> GetAccountRolesAsync(string accountId, string accessToken, string ssoRegion, CancellationToken cancellationToken = default)
        {
            var ssoClient = new AmazonSSOClient(new AnonymousAWSCredentials(), region: RegionEndpoint.GetBySystemName(ssoRegion));
            var listAccountRolesRequest = new ListAccountRolesRequest { AccountId = accountId, AccessToken = accessToken };
            var accountRoles = await ssoClient.ListAccountRolesAsync(listAccountRolesRequest, cancellationToken).ConfigureAwait(false);

            return accountRoles.RoleList.Select(accountRole => accountRole.RoleName).OrderBy(r => r).ToList();
        }
    }

}