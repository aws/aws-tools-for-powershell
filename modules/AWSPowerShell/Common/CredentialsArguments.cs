/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Runtime.InteropServices;
using System.Security;

using Amazon.Runtime.Internal.Settings;
using Amazon.Runtime;
using System.Text;
using Amazon.PowerShell.Utils;

namespace Amazon.PowerShell.Common
{
    #region Credentials arguments

    internal enum CredentialsSource
    {
        Strings, Saved, CredentialsObject, Session, InstanceProfile, Unknown
    }

    internal interface IAWSCredentialsArguments
    {
        SessionState SessionState { get; }
        string AccessKey { get; }
        string SecretKey { get; }
        string SessionToken { get; }
        string ProfileName { get; }
        string ProfilesLocation { get; }
        AWSCredentials Credential { get; }
    }

    /// <summary>
    /// Wrapper around a set of AWSCredentials (various leaf types) carrying credential data,
    /// logical name and source info. $StoredAWSCredentials points to an instance of this and
    /// the ToString() override allows us to display more useful info (the set name) than
    /// what AWSCredentials on its own can at present.
    /// </summary>
    public class AWSPSCredentials
    {
        internal AWSCredentials Credentials { get; private set; }
        internal string Name { get; private set; }
        internal CredentialsSource Source { get; private set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
                return this.Name;
            else
                return Credentials != null ? Credentials.ToString() : base.ToString();
        }

        internal AWSPSCredentials(AWSCredentials credentials, string name, CredentialsSource source)
        {
            this.Credentials = credentials;
            this.Name = name;
            this.Source = source;
        }

        private AWSPSCredentials() { }
    }

    internal static class IAWSCredentialsArgumentsMethods
    {
        public static bool TryGetCredentials(this IAWSCredentialsArguments self, out AWSPSCredentials credentials)
        {
            if (self == null) throw new ArgumentNullException("self");

            credentials = null;

            AWSCredentials innerCredentials = null;
            string name = null;
            CredentialsSource source = CredentialsSource.Unknown;
            bool explicitStoredLookup = !string.IsNullOrEmpty(self.ProfileName) || !string.IsNullOrEmpty(self.ProfilesLocation);

            if (!string.IsNullOrEmpty(self.AccessKey) && !string.IsNullOrEmpty(self.SecretKey))
            {
                innerCredentials = string.IsNullOrEmpty(self.SessionToken) ?
                    new BasicAWSCredentials(self.AccessKey, self.SecretKey) as AWSCredentials :
                    new SessionAWSCredentials(self.AccessKey, self.SecretKey, self.SessionToken) as AWSCredentials;
                source = CredentialsSource.Strings;
                name = "Supplied Key Parameters";
            }

            // if profile or profile location explicitly specified, try lookup now
            if (innerCredentials == null && explicitStoredLookup)
                TryLoadStored(self, explicitStoredLookup, ref innerCredentials, ref name, ref source);

            if (innerCredentials == null && self.Credential != null)
            {
                innerCredentials = self.Credential;
                source = CredentialsSource.CredentialsObject;
                name = "Credentials Object";
            }

            if (innerCredentials == null && self.SessionState != null)
            {
                object variableValue = self.SessionState.PSVariable.GetValue(SessionKeys.AWSCredentialsVariableName);
                if (variableValue is AWSPSCredentials)
                {
                    credentials = variableValue as AWSPSCredentials;
                    innerCredentials = credentials.Credentials; // so remaining probes are skipped
                    source = CredentialsSource.Session;
                }
            }

            // if profile or profile location not specified, try lookup for defaults now
            if (innerCredentials == null && !explicitStoredLookup)
                TryLoadStored(self, explicitStoredLookup, ref innerCredentials, ref name, ref source);

            // load credentials from legacy settings store
            if (innerCredentials == null)
            {
                try
                {
                    var storedCredentials = new StoredProfileAWSCredentials(SettingsStore.PSLegacyDefaultSettingName);
                    innerCredentials = storedCredentials.ToKeyedCredentials();
                    source = CredentialsSource.Saved;
                    name = SettingsStore.PSLegacyDefaultSettingName;
                }
                catch { }
            }

            // load credentials from EC2 Instance Profile
            if (innerCredentials == null)
            {
                try
                {
                    innerCredentials = new InstanceProfileAWSCredentials();
                    source = CredentialsSource.InstanceProfile;
                    name = "Instance Profile";
                }
                catch
                {
                    innerCredentials = null;
                }
            }

            if (credentials == null && innerCredentials != null)
            {
                credentials = new AWSPSCredentials(innerCredentials, name, source);
            }

            return (credentials != null); // && source != CredentialsSource.Unknown);
        }

        private static void TryLoadStored(IAWSCredentialsArguments self, bool explicitStoredLookup, ref AWSCredentials innerCredentials, ref string name, ref CredentialsSource source)
        {
            try
            {
                var storedCredentials = new StoredProfileAWSCredentials(self.ProfileName, self.ProfilesLocation);
                innerCredentials = storedCredentials.ToKeyedCredentials();
                source = CredentialsSource.Saved;
                name = string.IsNullOrEmpty(self.ProfileName) ? SettingsStore.PSDefaultSettingName : self.ProfileName;
            }
            catch (Exception e)
            {
                if (explicitStoredLookup)
                {
                    string message = "Unable to load stored credentials for ";
                    if (!string.IsNullOrEmpty(self.ProfileName))
                        message += "profile = [" + self.ProfileName + "], ";
                    if (!string.IsNullOrEmpty(self.ProfilesLocation))
                        message += "profile location = [" + self.ProfilesLocation + "]";
                    throw new ArgumentException(message, e);
                }
            }
        }
    }

    #endregion


    #region Region arguments

    internal enum RegionSource
    {
        String, Saved, RegionObject, Session, Unknown
    }

    internal interface IAWSRegionArguments
    {
        SessionState SessionState { get; }
        object Region { get; }
    }

    internal static class IAWSRegionArgumentsMethods
    {
        public static bool TryGetRegion(this IAWSRegionArguments self, out RegionEndpoint region, out RegionSource source)
        {
            if (self == null) throw new ArgumentNullException("self");

            region = null;
            source = RegionSource.Unknown;
            if (self.Region != null)
            {
                string regionSysName = string.Empty;
                if (self.Region is PSObject)
                {
                    PSObject paramObject = self.Region as PSObject;
                    if (paramObject.BaseObject is AWSRegion)
                        regionSysName = (paramObject.BaseObject as AWSRegion).Region;
                    else
                        regionSysName = paramObject.BaseObject as string;
                }
                else if (self.Region is string)
                    regionSysName = self.Region as string;

                if (string.IsNullOrEmpty(regionSysName))
                    throw new ArgumentException("Unsupported parameter type; Region must be a string containing the system name for a region, or an AWSRegion instance");

                try
                {
                    region = RegionEndpoint.GetBySystemName(regionSysName);
                    source = RegionSource.String;
                }
                catch (Exception)
                {
                    // be nice and informative :-)
                    StringBuilder sb = new StringBuilder("Unsupported Region value. Supported values: ");
                    var regions = RegionEndpoint.EnumerableAllRegions;
                    for (int i = 0; i < regions.Count<RegionEndpoint>(); i++)
                    {
                        if (i > 0) sb.Append(",");
                        sb.Append(regions.ElementAt<RegionEndpoint>(i).SystemName);
                    }
                    throw new ArgumentOutOfRangeException(sb.ToString());
                }
            }
            if (region == null && self.SessionState != null)
            {
                object variableValue = self.SessionState.PSVariable.GetValue(SessionKeys.AWSRegionVariableName);
                if (variableValue is string)
                {
                    region = RegionEndpoint.GetBySystemName(variableValue as string);
                    source = RegionSource.Session;
                }
            }

            // load region from default settings store
            if (region == null)
            {
                if (!TryLoad(SettingsStore.PSDefaultSettingName, ref region, ref source))
                    TryLoad(SettingsStore.PSLegacyDefaultSettingName, ref region, ref source);
            }

            return (region != null && source != RegionSource.Unknown);
        }

        private static bool TryLoad(string name, ref RegionEndpoint region, ref RegionSource source)
        {
            var settings = SettingsStore.Load(name);
            var defaultRegion = settings == null ? null : settings.Region;
            if (defaultRegion != null)
            {
                region = defaultRegion;
                source = RegionSource.Saved;
                return true;
            }
            return false;
        }

        public static RegionEndpoint GetRegion(this IAWSRegionArguments self)
        {
            RegionEndpoint region;
            RegionSource source;
            if (!TryGetRegion(self, out region, out source))
                region = null;
            return region;
        }
    }

    #endregion


    #region Common arguments

    internal interface IAWSCommonArguments : IAWSRegionArguments, IAWSCredentialsArguments
    {
    }

    #endregion


    #region Concrete classes

    internal class AWSCredentialsArguments : IAWSCredentialsArguments
    {
        public SessionState SessionState { get; private set; }

        /// <summary>
        /// The AWS access key for the user account
        /// </summary>
        [Alias("AK")]
        [Parameter]
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS secret key for the user account
        /// </summary>
        [Alias("SK")]
        [Parameter]
        public string SecretKey { get; set; }

        /// <summary>
        /// Session Token
        /// </summary>
        [Alias("ST")]
        [Parameter]
        public string SessionToken { get; set; }

        /// <summary>
        /// Retrieves credentials associated with the specified name from local storage
        /// </summary>
        [Parameter(Position = 200)]
        [Alias("StoredCredentials", "AWSProfileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Location of the credentials file to use.
        /// </summary>
        [Parameter(Position = 201)]
        [Alias("AWSProfilesLocation")]
        public string ProfilesLocation { get; set; }

        /// <summary>
        /// AWSCredentials object instance containing key information for the user account
        /// </summary>
        [Parameter]
        public AWSCredentials Credential { get; set; }

        public AWSCredentialsArguments(SessionState sessionState)
        {
            SessionState = sessionState;
        }
    }

    internal class AWSRegionArguments : IAWSRegionArguments
    {
        public SessionState SessionState { get; private set; }

        /// <summary>
        /// Region for the command; the system name of the region or an AWSRegion instance
        /// </summary>
        [Parameter(Mandatory = false, 
                    Position = 210, 
                    ValueFromPipeline=true,
                    ValueFromPipelineByPropertyName=true)]
        public object Region { get; set; }

        public AWSRegionArguments(SessionState sessionState)
        {
            SessionState = sessionState;
        }
    }

    internal class AWSCommonArguments : IAWSCommonArguments
    {
        /// <summary>
        /// Region for the command; the system name of the region or an AWSRegion instance
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public object Region { get; set; }

        public SessionState SessionState { get; private set; }

        /// <summary>
        /// The AWS access key for the user account
        /// </summary>
        [Alias("AK")]
        [Parameter]
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS secret key for the user account
        /// </summary>
        [Alias("SK")]
        [Parameter]
        public string SecretKey { get; set; }

        /// <summary>
        /// Session Token
        /// </summary>
        [Alias("ST")]
        [Parameter]
        public string SessionToken { get; set; }

        /// <summary>
        /// Retrieves credentials associated with the specified name from local storage
        /// </summary>
        [Parameter]
        [Alias("StoredCredentials", "AWSProfileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Location of the credentials file to use.
        /// </summary>
        [Parameter]
        [Alias("AWSProfilesLocation")]
        public string ProfilesLocation { get; set; }

        /// <summary>
        /// AWSCredentials object instance containing key information for the user account
        /// </summary>
        [Parameter]
        public AWSCredentials Credential { get; set; }

        public AWSCommonArguments(SessionState sessionState)
        {
            SessionState = sessionState;
        }
    }

    #endregion


    #region Helper utils

    internal static class SettingsStore
    {
        public class Settings
        {
            public AWSCredentials Credentials { get; set; }
            public RegionEndpoint Region { get; set; }
            public string Name { get; set; }
            public SettingsCollection.ObjectSettings RawSettings { get; set; }
        }

        public const string PSDefaultSettingName = "default";
        public const string PSLegacyDefaultSettingName = "AWS PS Default";
        private const string CredentialsTypeField = "CredentialsType";
        private const string RegionField = "Region";

        public static List<string> GetDisplayNames()
        {
            var settings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            if (settings == null) return null;

            return settings.Select(s => s[SettingsConstants.DisplayNameField]).OrderBy(n => n).ToList();
        }
        public static Settings Load(string name)
        {
            var settings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            if (settings == null) return null;

            var setting = FindSetting(settings, name);
            if (setting == null) return null;

            Settings result = new Settings
            {
                Name = name, RawSettings = setting
            };

            AWSCredentials credentials = null;
            string credentialsTypeString = setting[CredentialsTypeField];
            Type credentialsType = string.IsNullOrEmpty(credentialsTypeString) ? null : typeof(AWSCredentials).Assembly.GetType(credentialsTypeString);
            if (credentialsType == null || credentialsType == typeof(BasicAWSCredentials))
            {
                credentials = new BasicAWSCredentials(setting[SettingsConstants.AccessKeyField], setting[SettingsConstants.SecretKeyField]);
            }
            else if (credentialsType == typeof(InstanceProfileAWSCredentials))
            {
                credentials = new InstanceProfileAWSCredentials();
            }

            RegionEndpoint region = null;
            string regionString = setting[RegionField];
            if (!string.IsNullOrEmpty(regionString))
            {
                region = RegionEndpoint.GetBySystemName(regionString);
            }
                
            result.Credentials = credentials;
            result.Region = region;
            return result;
        }

        public static void Save(string name, AWSCredentials credentials, RegionEndpoint region)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (credentials == null) throw new ArgumentNullException("credentials");
            //if (region == null) throw new ArgumentNullException("region");

            var settings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            if (settings == null)
            {
                settings = new SettingsCollection();
            }

            var os = FindSetting(settings, name);
            if (os == null)
            {
                var uniqueKey = Guid.NewGuid();
                os = settings.NewObjectSettings(uniqueKey.ToString());
                os[SettingsConstants.DisplayNameField] = name;
            }

            SetCredentials(os, credentials);
            if (region != null)
            {
                os[RegionField] = region.SystemName;
            }

            PersistenceManager.Instance.SaveSettings(SettingsConstants.RegisteredProfiles, settings);
        }

        private static void SetCredentials(SettingsCollection.ObjectSettings os, AWSCredentials credentials)
        {
            os[CredentialsTypeField] = credentials.GetType().FullName;

            if (credentials is BasicAWSCredentials)
            {
                ImmutableCredentials creds = credentials.GetCredentials();
                os[SettingsConstants.AccessKeyField] = creds.AccessKey;
                os[SettingsConstants.SecretKeyField] = creds.SecretKey;
            }
            else if (credentials is InstanceProfileAWSCredentials)
            { }
            else if (credentials is SessionAWSCredentials)
            {
                throw new InvalidOperationException("Cannot save session credentials");
            }
            else if (credentials is EnvironmentAWSCredentials)
            {
                throw new InvalidOperationException("Cannot save environmental credentials");
            }
            else
            {
                throw new InvalidOperationException("Unrecognized credentials type");
            }
        }
        public static void Delete(string name)
        {
            var settings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            if (settings == null) return;

            var setting = FindSetting(settings, name);
            if (setting == null) return;
            settings.Remove(setting.UniqueKey);
            PersistenceManager.Instance.SaveSettings(SettingsConstants.RegisteredProfiles, settings);
        }

        private static SettingsCollection.ObjectSettings FindSetting(SettingsCollection settings, string name)
        {
            var setting = settings.FirstOrDefault(s =>
            {
                if (s == null) return false;

                string displayName = s[SettingsConstants.DisplayNameField];
                return (string.Equals(displayName, name, StringComparison.OrdinalIgnoreCase));
            });
            return setting;
        }
        private static string GetClearSecretKey(SecureString secureSecretKey)
        {
            if (secureSecretKey == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureSecretKey);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    internal static class SessionKeys
    {
        public const string AWSCredentialsVariableName = "StoredAWSCredentials";
        public const string AWSRegionVariableName = "StoredAWSRegion";
        public const string AWSCallHistoryName = "AWSHistory";
        public const string AWSProxyVariableName = "AWSProxy";
    }

    #endregion
}
