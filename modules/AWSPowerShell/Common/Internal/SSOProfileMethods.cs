using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Amazon.PowerShell.Utils
{
    /// <summary>
    /// Utility methods to use with Credentials Profile names
    /// </summary>

    public static class SSOProfileMethods
    {
        private const string _configFileName = "config";

        private const string _ssoSessionSectionName = "sso-session";

        private const string _ssoRegionPropertyName = "sso_region";

        private const string _ssoRegistrationScopesName = "sso_registration_scopes";

        private const string _ssoStartUrlPropertyName = "sso_start_url";

        private const string _ssoRegistrationScopes = "sso_registration_scopes";

        private const string _regionPropertyName = "region";

        private const string _ssoAccountIdPropertyName = "sso_account_id";

        private const string _ssoRoleNamePropertyName = "sso_role_name";

        private const string _ssoSessionPropertyName = "sso_session";

        private const string ProfilePrefix = "profile";

        private const string SsoSessionProfilePrefix = "sso-session";

        /// <summary>
        /// Regex:
        /// - Starts with "sso-session"
        /// - followed by one or more whitespaces
        /// - followed by one or more non-whitespaces, in a group called "name"
        /// </summary>
        private static readonly Regex SsoSessionProfileName = new Regex($"^{SsoSessionProfilePrefix}\\s+(?<name>\\S+)", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

        /// <summary>
        /// Whether or not the profile name represents an SSO Session (prefixed with "sso-session")
        /// </summary>
        private static bool IsSsoSession(string profileName) => SsoSessionProfileName.IsMatch(profileName);

        /// <summary>
        /// Transforms "sso-session foo" to "foo"
        /// </summary>
        private static string GetSsoSessionFromProfileName(string profileName)
        {
            var match = SsoSessionProfileName.Match(profileName);
            if (!match.Success)
            {
                throw new ArgumentException($"Not a SSO Session based profile name: {profileName}", nameof(profileName));
            }

            return match.Groups["name"].Value;
        }

        /// <summary>
        /// Transforms "foo" to "sso-session foo"
        /// </summary>
        private static string CreateSsoSessionProfileName(string ssoSessionName) =>
            $"{SsoSessionProfilePrefix} {ssoSessionName}";

        /// <summary>
        /// Transforms "foo" to "profile foo"
        /// </summary>
        private static string CreateProfileName(string profileName) =>
            $"{ProfilePrefix} {profileName}";

        private static string GetSharedConfigFilePath(this SharedCredentialsFile @this)
        {
            // Re-check if they set an explicit config file path, use that if it's set
            var awsConfigEnvironmentPath = Environment.GetEnvironmentVariable(SharedCredentialsFile.SharedConfigFileEnvVar);
            if (!string.IsNullOrEmpty(awsConfigEnvironmentPath))
            {
                return awsConfigEnvironmentPath;
            }

            // config file will be in the same location as the credentials file and no env vars are set.
            // Just return the path, if the caller cares, they can figure out if it exists or not
            return Path.Combine(Path.GetDirectoryName(@this.FilePath), _configFileName);
        }

        /// <summary>
        /// Returns a ProfileIniFile of the shared config file.
        /// </summary>
        /// <param name="this">The SharedCredentialsFile to retrieve the config file for.</param>
        /// <returns>A ProfileIniFile instance of the config file.</returns>
        private static ProfileIniFile GetSharedConfigFile(this SharedCredentialsFile @this)
        {
            // Second parameter profileMarkerRequired is required to be true for config files, but not for general ini files.
            return new ProfileIniFile(@this.GetSharedConfigFilePath(), true);
        }

        private static void ThrowOnNullOrWhiteSpace(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{name} must have value set.", name);
            }
        }

        /// <summary>
        /// Add the session info given. If the profile already exists, update it.
        /// </summary>
        public static void RegisterSsoSession(this CredentialProfile profile)
        {
            SharedCredentialsFile sharedCredentialsFile = new SharedCredentialsFile();

            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            var options = profile.Options;

            ThrowOnNullOrWhiteSpace(nameof(options.SsoSession), options.SsoSession);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoRegion), options.SsoRegion);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoStartUrl), options.SsoStartUrl);

            // Only sso_start_url and sso_region supported in sso-session sections for IAM Identity Center
            // Legacy profiles don't support sso_session sections, all Sso* keys defined directly in profile.
            var ssoSessionProperties = new SortedDictionary<string, string>()
        {
            { _ssoRegionPropertyName, options.SsoRegion },
            { _ssoStartUrlPropertyName, options.SsoStartUrl },
        };

            if (!string.IsNullOrWhiteSpace(options.SsoRegistrationScopes))
            {
                ssoSessionProperties.Add(_ssoRegistrationScopes, options.SsoRegistrationScopes);
            }

            var configFile = sharedCredentialsFile.GetSharedConfigFile();

            configFile.EnsureSectionExists(SSOProfileMethods.CreateSsoSessionProfileName(options.SsoSession));

            configFile.EditSection(options.SsoSession, true, ssoSessionProperties); // Section must already exist to edit sso-session
            configFile.Persist();
        }

        /// <summary>
        /// Add the profile and session info given. If the profile already exists, update it.
        /// </summary>
        public static void RegisterSsoProfileAndSession(this CredentialProfile profile)
        {
            SharedCredentialsFile sharedCredentialsFile = new SharedCredentialsFile();

            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            var options = profile.Options;

            ThrowOnNullOrWhiteSpace(nameof(options.SsoSession), options.SsoSession);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoRegion), options.SsoRegion);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoStartUrl), options.SsoStartUrl);
            ThrowOnNullOrWhiteSpace(nameof(profile.Region.SystemName), profile.Region.SystemName);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoAccountId), options.SsoAccountId);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoRoleName), options.SsoRoleName);
            ThrowOnNullOrWhiteSpace(nameof(options.SsoSession), options.SsoSession);

            // Only sso_start_url and sso_region supported in sso-session sections for IAM Identity Center
            // Legacy profiles don't support sso_session sections, all Sso* keys defined directly in profile.
            var ssoSessionProperties = new SortedDictionary<string, string>()
        {
            { _ssoRegionPropertyName, options.SsoRegion },
            { _ssoStartUrlPropertyName, options.SsoStartUrl },
        };

            var profileProperties = new SortedDictionary<string, string>()
        {
            { _regionPropertyName, profile.Region.SystemName },
            { _ssoAccountIdPropertyName, options.SsoAccountId },
            { _ssoRoleNamePropertyName, options.SsoRoleName },
            { _ssoSessionPropertyName, options.SsoSession },
        };

            if (!string.IsNullOrWhiteSpace(options.SsoRegistrationScopes))
            {
                ssoSessionProperties.Add(_ssoRegistrationScopes, options.SsoRegistrationScopes);
            }

            var configFile = sharedCredentialsFile.GetSharedConfigFile();
            configFile.EnsureSectionExists(SSOProfileMethods.CreateProfileName(profile.Name));
            configFile.EnsureSectionExists(SSOProfileMethods.CreateSsoSessionProfileName(options.SsoSession));

            configFile.EditSection(profile.Name, false, profileProperties); // Section must already exist to edit sso-session
            configFile.EditSection(options.SsoSession, true, ssoSessionProperties);
            configFile.Persist();
        }
    }
}
