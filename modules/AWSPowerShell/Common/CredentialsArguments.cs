/*******************************************************************************
 *  Copyright 2012-2016 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Management.Automation.Host;

using Amazon.Runtime;
using Amazon.Runtime.Internal.Settings;
using Amazon.PowerShell.Utils;
using Amazon.Util;
using ThirdParty.Json.LitJson;
using Amazon.Util.Internal;
using Amazon.Runtime.Internal.Auth;
using System.IO;

namespace Amazon.PowerShell.Common
{
    #region Credentials arguments

    public enum CredentialsSource
    {
        Strings, Profile, CredentialsObject, Session, Environment, Container, InstanceProfile, Unknown
    }

    internal interface IAWSCredentialsArguments
    {
        SessionState SessionState { get; }

        string ProfileName { get; }
        string ProfilesLocation { get; }

        string AccessKey { get; }
        string SecretKey { get; }
        string SessionToken { get; }
        AWSCredentials Credential { get; }

        PSCredential NetworkCredential { get; }
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

    /// <summary>
    /// Performs a search amongst a chain of credential parameters and provider methods to
    /// arrive at at set of AWS credentials.
    /// </summary>
    internal static class ICredentialsArgumentsMethods
    {
        public static bool TryGetCredentials(this IAWSCredentialsArguments self, PSHost psHost, out AWSPSCredentials credentials)
        {
            if (self == null) throw new ArgumentNullException("self");

            credentials = null;
            AWSCredentials innerCredentials = null;
            string name = null;
            var source = CredentialsSource.Unknown;
            var userSpecifiedProfile = !string.IsNullOrEmpty(self.ProfileName) || !string.IsNullOrEmpty(self.ProfilesLocation);

            // we probe for credentials by first checking the bound parameters to see if explicit credentials 
            // were supplied (keys, profile name, credential object), overriding anything in the shell environment

            if (!string.IsNullOrEmpty(self.AccessKey) && !string.IsNullOrEmpty(self.SecretKey))
            {
                innerCredentials = string.IsNullOrEmpty(self.SessionToken) ?
                    new BasicAWSCredentials(self.AccessKey, self.SecretKey) :
                    new SessionAWSCredentials(self.AccessKey, self.SecretKey, self.SessionToken) as AWSCredentials;
                source = CredentialsSource.Strings;
                name = "Supplied Key Parameters";
            }

            // user gave us the profile name?
            if (innerCredentials == null && userSpecifiedProfile)
            {
                if (StoredProfileAWSCredentials.CanCreateFrom(self.ProfileName, self.ProfilesLocation))
                    LoadAWSCredentialProfile(self, userSpecifiedProfile, ref innerCredentials, ref name, ref source);
                else if (SAMLRoleProfile.CanCreateFrom(self.ProfileName))
                    LoadSAMLRoleProfile(self, userSpecifiedProfile, ref innerCredentials, ref name, ref source);

                // if the user gave us an explicit profile name (and optional location) it's an error if we
                // don't find it as otherwise we could drop through and pick up a 'default' profile that is
                // for a different account
                if (innerCredentials == null)
					return false;
           }

            // how about an aws credentials object?
            if (innerCredentials == null && self.Credential != null)
            {
                innerCredentials = self.Credential;
                source = CredentialsSource.CredentialsObject;
                name = "Credentials Object";
            }

            // shell session variable set (this allows override of machine-wide environment variables)
            if (innerCredentials == null && self.SessionState != null)
            {
                var variableValue = self.SessionState.PSVariable.GetValue(SessionKeys.AWSCredentialsVariableName);
                if (variableValue is AWSPSCredentials)
                {
                    credentials = variableValue as AWSPSCredentials;
                    source = CredentialsSource.Session;
                    innerCredentials = credentials.Credentials; // so remaining probes are skipped
                }
            }

            // no explicit command-level or shell instance override set, start to inspect the environment
            // starting environment variables
            if (innerCredentials == null)
            {
                try
                {
                    var environmentCredentials = new EnvironmentVariablesAWSCredentials();
                    innerCredentials = environmentCredentials;
                    source = CredentialsSource.Environment;
                    name = "Environment Variables";
                }
                catch { }
            }

            // get credentials from a 'default' profile?
            if (innerCredentials == null && !userSpecifiedProfile)
            {
                if (StoredProfileAWSCredentials.IsProfileKnown(SettingsStore.PSDefaultSettingName, self.ProfilesLocation))
                {
                    if (StoredProfileAWSCredentials.CanCreateFrom(SettingsStore.PSDefaultSettingName, self.ProfilesLocation))
                        LoadAWSCredentialProfile(self, false, ref innerCredentials, ref name, ref source);
                    else if (SAMLRoleProfile.CanCreateFrom(SettingsStore.PSDefaultSettingName))
                        LoadSAMLRoleProfile(self, false, ref innerCredentials, ref name, ref source);
                }
            }

            // get credentials from a legacy default profile name?
            if (innerCredentials == null)
            {
                try
                {
                    var storedCredentials = new StoredProfileAWSCredentials(SettingsStore.PSLegacyDefaultSettingName);
                    innerCredentials = storedCredentials.ToKeyedCredentials();
                    source = CredentialsSource.Profile;
                    name = SettingsStore.PSLegacyDefaultSettingName;
                }
                catch { }
            }

            if (innerCredentials == null)
            {
                // try and load credentials from ECS endpoint (if the relevant environment variable is set)
                // or EC2 Instance Profile as a last resort
                try
                {
                    string uri = System.Environment.GetEnvironmentVariable(ECSTaskCredentials.ContainerCredentialsURIEnvVariable);
                    if (!string.IsNullOrEmpty(uri))
                    {
                        innerCredentials = new ECSTaskCredentials();
                        source = CredentialsSource.Container;
                        name = "Container";
                    }
                    else
                    {
                        innerCredentials = new InstanceProfileAWSCredentials();
                        source = CredentialsSource.InstanceProfile;
                        name = "Instance Profile";
                    }
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

            if (credentials != null)
            {
#if DESKTOP
                // if we have picked up a SAML-based credentials profile, make sure the callback
                // to authenticate the user is set. The underlying SDK will then call us back
                // if it needs to (we could skip setting if the profile indicates its for the
                // default identity, but it's simpler to just set up anyway)
                var samlCredentials = credentials.Credentials as StoredProfileFederatedCredentials;
                if (samlCredentials != null)
                {
                    var state = new SAMLCredentialCallbackState
                    {
                        Host = psHost,
                        CmdletNetworkCredentialParameter = self.NetworkCredential
                    };

                    samlCredentials.SetCredentialCallbackData(UserCredentialCallbackHandler, state);
                }
#endif
            }

            return (credentials != null);
        }

        private static void LoadAWSCredentialProfile(IAWSCredentialsArguments self,
                                                     bool userSpecifiedProfile, 
                                                     ref AWSCredentials innerCredentials, 
                                                     ref string name, 
                                                     ref CredentialsSource source)
        {
            var profileName = userSpecifiedProfile ? self.ProfileName : SettingsStore.PSDefaultSettingName;
            try
            {
                var storedCredentials = new StoredProfileAWSCredentials(profileName, self.ProfilesLocation);
                innerCredentials = storedCredentials.ToKeyedCredentials();
                source = CredentialsSource.Profile;
                name = profileName;
            }
#if DESKTOP
            catch (InvalidCredentialException)
            {
                throw;
            }
#endif
            catch (Exception e)
            {
                if (userSpecifiedProfile)
                {
                    var message = "Error loading stored credentials";
                    if (!string.IsNullOrEmpty(profileName))
                        message += " from profile '" + profileName + "'";
                    if (!string.IsNullOrEmpty(self.ProfilesLocation))
                        message += ", (profile location = '" + self.ProfilesLocation + "')";
                    message += ".\r\nError: " + e.Message;

                    throw new ArgumentException(message, e);
                }
            }
        }

        public static void LoadSAMLRoleProfile(IAWSCredentialsArguments self,
                                               bool userSpecifiedProfile,
                                               ref AWSCredentials innerCredentials,
                                               ref string name,
                                               ref CredentialsSource source)
        {
#if DESKTOP
            var profileName = userSpecifiedProfile ? self.ProfileName : SettingsStore.PSDefaultSettingName;
            try
            {
                // proxy data must be passed into the credential profile to use when making the HTTPS authentication
                // calls
                var proxySettings = ProxySettings.GetFromSettingsVariable(self.SessionState);
                var webProxy = proxySettings != null ? proxySettings.GetWebProxy() : null;
                var storedCredentials = new StoredProfileFederatedCredentials(profileName, self.ProfilesLocation, webProxy);
                innerCredentials = storedCredentials;
                source = CredentialsSource.Profile;
                name = profileName;
            }
            catch (Exception e)  // bad data of some form, or profile not found
            {
                if (userSpecifiedProfile)
                {
                    var message = "Unable to load stored role details in ";
                    if (!string.IsNullOrEmpty(profileName))
                        message += "profile = [" + profileName + "]";
                    if (!string.IsNullOrEmpty(self.ProfilesLocation))
                        message += ", profile location = [" + self.ProfilesLocation + "]";
                    throw new ArgumentException(message, e);
                }
            }
#else
            throw new InvalidOperationException("SAML-based credential profiles are not supported in this edition.");
#endif
        }

#if DESKTOP
        private static NetworkCredential UserCredentialCallbackHandler(CredentialRequestCallbackArgs args)
        {
            var callbackContext = args.CustomState as SAMLCredentialCallbackState;
            if (callbackContext == null) // not our callback, so don't attempt to handle
                return null;

            // if we are not retrying due to auth failure, did the user pre-supply a credential
            // via the -NetworkCredential parameter to either the cmdlet or Set-AWSCredentials?
            PSCredential psCredential = null;
            string msgPrompt = null;
            if (!args.PreviousAuthenticationFailed)
            {
                if (callbackContext.CmdletNetworkCredentialParameter != null)
                {
                    psCredential = callbackContext.CmdletNetworkCredentialParameter;
                    callbackContext.CmdletNetworkCredentialParameter = null; // the cmdlet override is single use
                }
                else if (callbackContext.ShellNetworkCredentialParameter != null)
                    psCredential = callbackContext.ShellNetworkCredentialParameter;
                else
                    msgPrompt = string.Format("Enter your credentials to authenticate and obtain AWS role credentials for the profile '{0}'", args.ProfileName);
            }
            else
                msgPrompt = string.Format("Authentication failed. Enter the password for '{0}' to try again.", args.UserIdentity);

            if (psCredential == null)
                psCredential = callbackContext.Host.UI.PromptForCredential("Authenticating for AWS Role Credentials", msgPrompt, args.UserIdentity, "");

            return psCredential != null ? psCredential.GetNetworkCredential() : null;
        }
#endif
    }

#if DESKTOP
    /// <summary>
    /// Captures the PSHost and executing cmdlet state for use in our credential callback
    /// handler.
    /// </summary>
    internal class SAMLCredentialCallbackState
    {
        /// <summary>
        /// The execution host, used to display credential prompts
        /// </summary>
        public PSHost Host { get; set; }

        /// <summary>
        /// Any PSCredential argument supplied to the current cmdlet invocation.
        /// This overrides ShellNetworkCredentialParameter that may have been set 
        /// in the shell when Set-AWSCredentials was invoked. The value is cleared
        /// after use.
        /// </summary>
        public PSCredential CmdletNetworkCredentialParameter { get; set; }

        /// <summary>
        /// Null or the value of the NetworkCredential parameter that was supplied
        /// when the role profile was set active in the shell via Set-AWSCredentials.
        /// If set, this credential is used if a more local scope credential cannot
        /// be found in SelfNetworkCredentialParameter. This value is retained after 
        /// use.
        /// </summary>
        public PSCredential ShellNetworkCredentialParameter { get; set; }
    }
#endif

#endregion


#region Region arguments

    public enum RegionSource
    {
        String, Saved, RegionObject, Session, Environment, InstanceMetadata, Unknown
    }

    internal interface IAWSRegionArguments
    {
        SessionState SessionState { get; }
        object Region { get; }
    }

    internal static class IAWSRegionArgumentsMethods
    {
        public static bool TryGetRegion(this IAWSRegionArguments self, bool useInstanceMetadata, out RegionEndpoint region, out RegionSource source)
        {
            if (self == null) throw new ArgumentNullException("self");

            region = null;
            source = RegionSource.Unknown;

            // user gave a command-level region parameter override?
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

            // user pushed default shell variable? (this allows override of machine-wide environment setting)
            if (region == null && self.SessionState != null)
            {
                object variableValue = self.SessionState.PSVariable.GetValue(SessionKeys.AWSRegionVariableName);
                if (variableValue is string)
                {
                    region = RegionEndpoint.GetBySystemName(variableValue as string);
                    source = RegionSource.Session;
                }
            }

            // region set in profile store (including legacy key name)?
            if (region == null)
            {
                if (!TryLoad(SettingsStore.PSDefaultSettingName, ref region, ref source))
                    TryLoad(SettingsStore.PSLegacyDefaultSettingName, ref region, ref source);
            }

            // region set in environment variables?
            if (region == null)
            {
                try
                {
                    var environmentRegion = new EnvironmentVariableAWSRegion();
                    region = environmentRegion.Region;
                    source = RegionSource.Environment;
                }
                catch { }
            }

            // last chance, attempt load from EC2 instance metadata if allowed
            if (region == null && useInstanceMetadata)
            {
                try
                {
                    region = EC2InstanceMetadata.Region;
                    if (region != null)
                        source = RegionSource.InstanceMetadata;
                }
                catch { }
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

        public static RegionEndpoint GetRegion(this IAWSRegionArguments self, bool useSDKFallback)
        {
            RegionEndpoint region;
            RegionSource source;
            if (!TryGetRegion(self, useSDKFallback, out region, out source))
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
        /// The AWS access key for the user account. This can be a temporary access key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("AK")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS secret key for the user account. This can be a temporary secret key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("SK", "SecretAccessKey")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SecretKey { get; set; }

        /// <summary>
        /// The session token if the access and secret keys are temporary session-based
        /// credentials. Temporary session credentials can be set for the current shell 
        /// instance only and cannot be saved to the credential store file.
        /// </summary>
        [Alias("ST")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SessionToken { get; set; }

        /// <summary>
        /// The user-defined name of an AWS credentials or SAML-based role profile containing
        /// credential information. The profile is expected to be found in the secure credential
        /// file shared with the AWS SDK for .NET and AWS Toolkit for Visual Studio. You can also
        /// specify the name of a profile stored in the .ini-format credential file used with 
        /// the AWS CLI and other AWS SDKs.
        /// </summary>
        [Parameter(Position = 200)]
        [Alias("StoredCredentials", "AWSProfileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with 
        /// the AWS CLI and other AWS SDKs) when the file does not use the default name and/or 
        /// folder location.
        /// </para>
        /// <para>
        /// When the ini-format credential file uses the default filename ('credentials') and is 
        /// placed in the default search location ('.aws' folder in the current user's profile folder, 
        /// 'C:\Users\userid') this parameter is not required. This parameter is also not required 
        /// when the profile to be used is contained in the encrypted credential file shared with the 
        /// AWS SDK for .NET and AWS Toolkit for Visual Studio.
        /// </para>
        /// <para>
        /// As the current folder can vary in a shell or during script execution it is advised 
        /// that you use specify a fully qualified path instead of a relative path.
        /// </para>
        /// </summary>
        [Parameter(Position = 201)]
        [Alias("AWSProfilesLocation", "ProfileLocation")]
        public string ProfilesLocation { get; set; }

        /// <summary>
        /// An AWSCredentials object instance containing access and secret key information,
        /// and optionally a token for session-based credentials.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public AWSCredentials Credential { get; set; }

        /// <summary>
        /// Used with SAML-based authentication when ProfileName references a SAML role profile. 
        /// Contains the network credentials to be supplied during authentication with the 
        /// configured identity provider's endpoint. This parameter is not required if the
        /// user's default network identity can or should be used during authentication.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public PSCredential NetworkCredential { get; set; }

        public AWSCredentialsArguments(SessionState sessionState)
        {
            SessionState = sessionState;
        }
    }

    internal class AWSRegionArguments : IAWSRegionArguments
    {
        public SessionState SessionState { get; private set; }

        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the sendpoint that will be used when calling service operations. Note that 
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipeline=true, 
                   ValueFromPipelineByPropertyName=true, 
                   Position = 210)]
        public object Region { get; set; }

        public AWSRegionArguments(SessionState sessionState)
        {
            SessionState = sessionState;
        }
    }

    internal class AWSCommonArguments : IAWSCommonArguments
    {
        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the sendpoint that will be used when calling service operations. Note that 
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public object Region { get; set; }

        public SessionState SessionState { get; private set; }

        /// <summary>
        /// The AWS access key for the user account. This can be a temporary access key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("AK")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS secret key for the user account. This can be a temporary secret key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("SK", "SecretAccessKey")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SecretKey { get; set; }

        /// <summary>
        /// The session token if the access and secret keys are temporary session-based
        /// credentials. Temporary session credentials can be set for the current shell 
        /// instance only and cannot be saved to the credential store file.
        /// </summary>
        [Alias("ST")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SessionToken { get; set; }

        /// <summary>
        /// The user-defined name of an AWS credentials or SAML-based role profile containing
        /// credential information. The profile is expected to be found in the secure credential
        /// file shared with the AWS SDK for .NET and AWS Toolkit for Visual Studio. You can also
        /// specify the name of a profile stored in the .ini-format credential file used with 
        /// the AWS CLI and other AWS SDKs.
        /// </summary>
        [Parameter]
        [Alias("StoredCredentials", "AWSProfileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with 
        /// the AWS CLI and other AWS SDKs) when the file does not use the default name and/or 
        /// folder location.
        /// </para>
        /// <para>
        /// When the ini-format credential file uses the default filename ('credentials') and is 
        /// placed in the default search location ('.aws' folder in the current user's profile folder, 
        /// 'C:\Users\userid') this parameter is not required. This parameter is also not required 
        /// when the profile to be used is contained in the encrypted credential file shared with the 
        /// AWS SDK for .NET and AWS Toolkit for Visual Studio.
        /// </para>
        /// <para>
        /// As the current folder can vary in a shell or during script execution it is advised 
        /// that you use specify a fully qualified path instead of a relative path.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("AWSProfilesLocation", "ProfileLocation")]
        public string ProfilesLocation { get; set; }

        /// <summary>
        /// An AWSCredentials object instance containing access and secret key information,
        /// and optionally a token for session-based credentials.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public AWSCredentials Credential { get; set; }

        /// <summary>
        /// Used with SAML-based authentication when ProfileName references a SAML role profile. 
        /// Contains the network credentials to be supplied during authentication with the 
        /// configured identity provider's endpoint. This parameter is not required if the
        /// user's default network identity can or should be used during authentication.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public PSCredential NetworkCredential { get; set; }

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

        private static readonly string[] _awsProfileKeys =
        { 
            SettingsConstants.AccessKeyField, 
            SettingsConstants.SecretKeyField,
            SettingsConstants.AccountNumberField,
            SettingsConstants.Restrictions,
            CredentialsTypeField
        };

        private static readonly string[] _samlRoleProfileKeys =
        {
            SettingsConstants.UserIdentityField,
            SettingsConstants.RoleArnField,
            SettingsConstants.EndpointNameField
        };

        public static IEnumerable<string> GetDisplayNames()
        {
            return ProfileManager.ListProfileNames();
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
            Type credentialsType = string.IsNullOrEmpty(credentialsTypeString) 
                ? null 
                : TypeFactory.GetTypeInfo(typeof(AWSCredentials)).Assembly.GetType(credentialsTypeString);
            if (credentialsType == typeof(InstanceProfileAWSCredentials))
                credentials = new InstanceProfileAWSCredentials();
            else
            {
#if DESKTOP
                // could be SAML role data or AWS keys
                if (SAMLRoleProfile.CanCreateFrom(setting))
                    credentials = new StoredProfileFederatedCredentials(name, null);
                else
#endif
                    credentials = new BasicAWSCredentials(setting[SettingsConstants.AccessKeyField], setting[SettingsConstants.SecretKeyField]);
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

        /// <summary>
        /// Copies settings from one profile to another. The profile manager automatically erases
        /// any settings for the destination profile if it exists.
        /// </summary>
        /// <param name="sourceProfileName">The name of the profile to copy from</param>
        /// <param name="destinationProfileName">The name of the profile to create or overwrite</param>
        /// <param name="region">Optional region data to also save in the destination profile</param>
        public static void SaveFromProfile(string sourceProfileName, string destinationProfileName, RegionEndpoint region)
        {
            ProfileManager.CopyProfileSettings(sourceProfileName, destinationProfileName);
            if (region != null)
                SetProfileRegion(destinationProfileName, region.SystemName);
        }

        /// <summary>
        /// Creates or updates a profile to hold AWS credentials. As a precaution against mixing
        /// profile data, this routine erases any pre-existing SAML credential data that may exist in
        /// the updated now-AWS-credentials profile.
        /// </summary>
        /// <param name="credentials">The access and secret key data to store in the profile</param>
        /// <param name="name">The name of the profile to create/update</param>
        /// <param name="profilesLocation">
        /// Optional location to shared credentials file to update. If not specified:
        /// * if we are running on Windows we update the SDK credential store
        /// * if we are running on a non-Windows platform we update the default shared credentials file
        ///   stored in ~/.aws/credentials.
        /// </param>
        /// <param name="region">Optional region data to also store in the profile</param>
        /// <returns>
        /// The location of the updated credential file. If null, this can be interpreted as meaning the encrypted sdk store file was updated.
        /// </returns>
        internal static string SaveAWSCredentialProfile(AWSCredentials credentials, string name, string profilesLocation, RegionEndpoint region)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            // if we're not on Windows, or we're on Windows and the credential store apis are not available (eg Nano),
            // or the user has given us a specific credentials file, honor it.
            string credentialsFileLocation = profilesLocation;
            if (string.IsNullOrEmpty(credentialsFileLocation) && !ProfileManager.IsAvailable)
            {
                credentialsFileLocation = GetCredentialsFilePath();
            }

            if (string.IsNullOrEmpty(credentialsFileLocation))
            {
                var profileExisted = ProfileManager.IsProfileKnown(name);
                var credentialKeys = ExtractCredentialKeys(credentials);  // throws if incompatible

                if (credentialKeys != null) // if instance profile, no keys to register
                    ProfileManager.RegisterProfile(name, credentialKeys.AccessKey, credentialKeys.SecretKey);

                if (region != null)
                    SetProfileRegion(name, region.SystemName);

                // if we just overwrote a SAML credential profile, remove any SAML-related keys that may be
                // present so we avoid mixed data
                if (profileExisted)
                    CleanKeys(name, _samlRoleProfileKeys);
            }
            else
            {
                try
                {
                    var filePath = Path.GetDirectoryName(credentialsFileLocation);
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    var credentialsFile = new SharedCredentialsFile(credentialsFileLocation);
                    var credentialKeys = credentials.GetCredentials();
                    credentialsFile.AddOrUpdateCredentials(name, credentialKeys.AccessKey, credentialKeys.SecretKey, credentialKeys.Token);
                    credentialsFile.Persist();
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Failed to update credentials file '{0}', exception '{1}'", credentialsFileLocation, e.Message),
                                        e);
                }
            }

            return credentialsFileLocation;
        }

        internal static string GetCredentialsFilePath()
        {
            // NanoServer doesn't have HOME set
            var homePath = Environment.GetEnvironmentVariable("HOME");

            if (string.IsNullOrEmpty(homePath))
                homePath = Environment.GetEnvironmentVariable("USERPROFILE");

            // so we save somewhere predictable, assuming write access
            if (string.IsNullOrEmpty(homePath))
                homePath = Directory.GetCurrentDirectory();

            return Path.Combine(homePath, StoredProfileCredentials.DefaultSharedCredentialLocation);
        }

        /// <summary>
        /// Creates or updates a SAML role profile.
        /// </summary>
        /// <param name="name">The name for the role profile</param>
        /// <param name="endpointName">
        /// The name of an existing endpoint settings collection containing the endpoint details.
        /// </param>
        /// <param name="roleArn">
        /// The arn of the role that should be assumed when this profile is used
        /// </param>
        /// <param name="userIdentity">
        /// Optional. Used if non-default network credentials should be used during authentication
        /// </param>
        /// <param name="region">A default region to assume</param>
        public static void SaveSAMLRoleProfile(string name, 
                                               string endpointName, 
                                               string roleArn,
                                               string userIdentity,
                                               RegionEndpoint region)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(endpointName)) throw new ArgumentNullException("endpointName");
            if (string.IsNullOrEmpty(roleArn)) throw new ArgumentNullException("roleArn");

            var profileExisted = ProfileManager.IsProfileKnown(name);
            ProfileManager.RegisterSAMLRoleProfile(name, endpointName, roleArn, userIdentity, region.SystemName);

            // if we just overwrote an AWS credential profile, remove any AWS-related keys that may be
            // present so we avoid mixed data
            if (profileExisted)
                CleanKeys(name, _awsProfileKeys);
        }

        /// <summary>
        /// Removes one or more keys from a profile. Used on store of credentials to ensure if we wrote one
        /// profile type over another we don't end up with a mixed bag of data. If we stored data that was
        /// originally from a profile, the copy functions on the ProfileManager can be used to effect a
        /// clean profile instance.
        /// </summary>
        /// <param name="profileName">The name of the profile to clean</param>
        /// <param name="keysToRemove">The key(s) to remove</param>
        private static void CleanKeys(string profileName, IEnumerable<string> keysToRemove)
        {
            var allSettings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            var os = FindSetting(allSettings, profileName);
            if (os == null)
                return;

            foreach (var k in keysToRemove)
            {
                os.Remove(k);
            }

            PersistenceManager.Instance.SaveSettings(SettingsConstants.RegisteredProfiles, allSettings);
        }

        /// <summary>
        /// Pokes default region setting into a profile (direct access to the object settings is not
        /// supported by the ProfileManager).
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="region"></param>
        private static void SetProfileRegion(string profileName, string region)
        {
            var allProfiles = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            var os = FindSetting(allProfiles, profileName);
            if (os == null)
            {
                os = allProfiles.NewObjectSettings(Guid.NewGuid().ToString());
                os[SettingsConstants.DisplayNameField] = profileName;
            }

            os[RegionField] = region;
            PersistenceManager.Instance.SaveSettings(SettingsConstants.RegisteredProfiles, allProfiles);
        }

        private static ImmutableCredentials ExtractCredentialKeys(AWSCredentials credentials)
        {
            if (credentials is BasicAWSCredentials)
                return credentials.GetCredentials();

            if (credentials is InstanceProfileAWSCredentials)
                return null;

#if DESKTOP
            if (credentials is StoredProfileFederatedCredentials)
                return null;
#endif

            if (credentials is SessionAWSCredentials)
                throw new InvalidOperationException("Cannot save session credentials");
#if DESKTOP
            else if (credentials is EnvironmentAWSCredentials)
                throw new InvalidOperationException("Cannot save environmental credentials");
            else
#endif
                throw new InvalidOperationException("Unrecognized credentials type");
        }

        public static void Delete(string name)
        {
            ProfileManager.UnregisterProfile(name);
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
