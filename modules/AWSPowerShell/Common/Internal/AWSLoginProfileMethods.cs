using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Amazon.PowerShell.Utils
{
    /// <summary>
    /// Utility methods for AWS Login to use with Credentials Profile names
    /// </summary>
    public static class AWSLoginProfileMethods
    {
        private const string _loginSessionPropertyName = "login_session";
        private const string _regionPropertyName = "region";
        private const string _configFileName = "config";
        private const string ProfilePrefix = "profile";
        private const string DefaultProfileName = "default";

        /// <summary>
        /// Transforms "foo" to "profile foo"
        /// </summary>
        private static string CreateProfileName(string profileName) =>
            $"{ProfilePrefix} {profileName}";


        /// <summary>
        /// Updates profile with login session in the config file
        /// </summary>
        public static void UpdateLoginProfile(string profileName, string loginSession, string region = null)
        {
            var sharedCredentialsFile = new SharedCredentialsFile();
            var configFile = sharedCredentialsFile.GetSharedConfigFile(profileName != null && profileName == DefaultProfileName);

            var profileProperties = new SortedDictionary<string, string>
            {
                { _loginSessionPropertyName, loginSession }
            };

            ThrowOnNullOrWhiteSpace(nameof(profileName), profileName);
            ThrowOnNullOrWhiteSpace(nameof(_loginSessionPropertyName), loginSession);

            if (!string.IsNullOrWhiteSpace(region))
                profileProperties.Add(_regionPropertyName, region);

            var sectionName = profileName == "default" ? "default" : CreateProfileName(profileName);

            configFile.EnsureSectionExists(sectionName);
            configFile.EditSection(profileName, false, profileProperties);

            configFile.Persist();
        }

        /// <summary>
        /// Gets login session from profile in the config file.
        /// </summary>
        public static string GetLoginSession(string profileName)
        {
            var sharedCredentialsFile = new SharedCredentialsFile();
            var configFile = sharedCredentialsFile.GetSharedConfigFile(profileName != null && profileName == DefaultProfileName);

            if (configFile.TryGetSection(profileName, false, false, out var properties, out var _))
            {
                properties.TryGetValue(_loginSessionPropertyName, out var loginSession);
                return loginSession;
            }
            return null;
        }

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
        /// <param name="profileName"Optional profile name></param>
        /// <returns>A ProfileIniFile instance of the config file.</returns>
        private static ProfileIniFile GetSharedConfigFile(this SharedCredentialsFile @this, bool isDefaultProfile = false)
        {
            // Second parameter profileMarkerRequired is required to be true for config files, but not for general ini files.
            return new ProfileIniFile(@this.GetSharedConfigFilePath(), !isDefaultProfile);
        }

        private static void ThrowOnNullOrWhiteSpace(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{name} must have value set.", name);
            }
        }
    }
}
