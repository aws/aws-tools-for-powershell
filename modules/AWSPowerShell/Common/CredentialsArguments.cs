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
using Amazon.Runtime.Internal;
using System.Globalization;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.CredentialManagement.Internal;

namespace Amazon.PowerShell.Common
{
    #region ProfileLocation argument
    internal interface IAWSProfileLocationArgument
    {
        string ProfileLocation { get; }
    }
    #endregion

    #region Credentials arguments

    public enum CredentialsSource
    {
        Strings, Profile, CredentialsObject, Session, Environment, Container, InstanceProfile, Unknown
    }

    internal interface IAWSCredentialsArguments : IAWSProfileLocationArgument
    {
        SessionState SessionState { get; }

        string ProfileName { get; }

        string AccessKey { get; }
        string SecretKey { get; }
        string SessionToken { get; }
        AWSCredentials Credential { get; }

        PSCredential NetworkCredential { get; }

        CredentialProfileOptions GetCredentialProfileOptions();
    }

    internal interface IAWSCredentialsArgumentsFull : IAWSCredentialsArguments
    {
        string ExternalID { get; }
        string MfaSerial { get; }
        string RoleArn { get; }
        string SourceProfile { get; }
#if DESKTOP
        string EndpointName { get; }
        string UserIdentity { get; }
#endif
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
            var userSpecifiedProfile = !string.IsNullOrEmpty(self.ProfileName);

            var profileChain = new CredentialProfileStoreChain(self.ProfileLocation);

            // we probe for credentials by first checking the bound parameters to see if explicit credentials 
            // were supplied (keys, profile name, credential object), overriding anything in the shell environment
            if (AWSCredentialsFactory.TryGetAWSCredentials(self.GetCredentialProfileOptions(), profileChain, out innerCredentials))
            {
                source = CredentialsSource.Strings;
                name = "Supplied Key Parameters";
                SetProxyAndCallbackIfNecessary(innerCredentials, self, psHost);
            }

            // user gave us the profile name?
            if (innerCredentials == null && userSpecifiedProfile)
            {
                CredentialProfile credentialProfile;
                if (profileChain.TryGetProfile(self.ProfileName, out credentialProfile))
                {
                    innerCredentials = AWSCredentialsFactory.GetAWSCredentials(credentialProfile, profileChain);
                    source = CredentialsSource.Profile;
                    name = self.ProfileName;
                    SetProxyAndCallbackIfNecessary(innerCredentials, self, psHost);
                }
                else
                {
                    // if the user gave us an explicit profile name (and optional location) it's an error if we
                    // don't find it as otherwise we could drop through and pick up a 'default' profile that is
                    // for a different account
                    return false;
                }
           }

            // how about an aws credentials object?
            if (innerCredentials == null && self.Credential != null)
            {
                innerCredentials = self.Credential;
                source = CredentialsSource.CredentialsObject;
                name = "Credentials Object";
                // don't set proxy and callback, use self.Credential as-is
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
                    // don't set proxy and callback, use credentials.Credentials as-is
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
                    // no need to set proxy and callback - only basic or session credentials
                }
                catch { }
            }

            // get credentials from a 'default' profile?
            if (innerCredentials == null && !userSpecifiedProfile)
            {
                CredentialProfile credentialProfile;
                if (profileChain.TryGetProfile(SettingsStore.PSDefaultSettingName, out credentialProfile) &&
                    credentialProfile.CanCreateAWSCredentials)
                {
                    innerCredentials = AWSCredentialsFactory.GetAWSCredentials(credentialProfile, profileChain);
                    source = CredentialsSource.Profile;
                    name = SettingsStore.PSDefaultSettingName;
                    SetProxyAndCallbackIfNecessary(innerCredentials, self, psHost);
                }
            }

            // get credentials from a legacy default profile name?
            if (innerCredentials == null)
            {
                CredentialProfile credentialProfile;
                if (profileChain.TryGetProfile(SettingsStore.PSLegacyDefaultSettingName, out credentialProfile) &&
                    credentialProfile.CanCreateAWSCredentials)
                {
                    if (AWSCredentialsFactory.TryGetAWSCredentials(credentialProfile, profileChain, out innerCredentials))
                    {
                        source = CredentialsSource.Profile;
                        name = SettingsStore.PSLegacyDefaultSettingName;
                        SetProxyAndCallbackIfNecessary(innerCredentials, self, psHost);
                    }
                }
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
                        // no need to set proxy and callback
                    }
                    else
                    {
                        innerCredentials = new InstanceProfileAWSCredentials();
                        source = CredentialsSource.InstanceProfile;
                        name = "Instance Profile";
                        // no need to set proxy and callback
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

            return (credentials != null);
        }

        private static void SetProxyAndCallbackIfNecessary(AWSCredentials innerCredentials, IAWSCredentialsArguments self, PSHost psHost)
        {
#if DESKTOP
            SetupIfFederatedCredentials(innerCredentials, psHost, self);
#endif
            SetupIfAssumeRoleCredentials(innerCredentials, self);
        }

#if DESKTOP
        private static WebProxy GetWebProxy(IAWSCredentialsArguments self)
        {
            var proxySettings = ProxySettings.GetFromSettingsVariable(self.SessionState);
            return proxySettings != null ? proxySettings.GetWebProxy() : null;
        }

        private static void SetupIfFederatedCredentials(AWSCredentials credentials, PSHost psHost, IAWSCredentialsArguments self)
        {
            // if we have picked up a SAML-based credentials profile, make sure the callback
            // to authenticate the user is set. The underlying SDK will then call us back
            // if it needs to (we could skip setting if the profile indicates its for the
            // default identity, but it's simpler to just set up anyway)
            var samlCredentials = credentials as FederatedAWSCredentials;
            if (samlCredentials != null)
            {
                // set up callback
                var state = new SAMLCredentialCallbackState
                {
                    Host = psHost,
                    CmdletNetworkCredentialParameter = self.NetworkCredential
                };
                samlCredentials.Options.CredentialRequestCallback = UserCredentialCallbackHandler;
                samlCredentials.Options.CustomCallbackState = state;

                //set up proxy
                samlCredentials.Options.ProxySettings = GetWebProxy(self);
            }
    }
#endif

        private static void SetupIfAssumeRoleCredentials(AWSCredentials credentials, IAWSCredentialsArguments self)
        {
            var assumeRoleCredentials = credentials as AssumeRoleAWSCredentials;
            if (assumeRoleCredentials != null)
            {
                // set up callback
                assumeRoleCredentials.Options.MfaTokenCodeCallback = ReadMFACode;
#if DESKTOP
                // set up proxy
                assumeRoleCredentials.Options.ProxySettings = GetWebProxy(self);
#endif
            }
        }

        private static String ReadMFACode()
        {
            Console.Write("Enter MFA code:");

            String mfaCode = "";
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (mfaCode.Length > 0)
                    {
                        // remove the character from the string
                        mfaCode = mfaCode.Remove(mfaCode.Length - 1);

                        // remove the * from the console
                        var position = Console.CursorLeft - 1;
                        Console.SetCursorPosition(position, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(position, Console.CursorTop);
                    }
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    mfaCode += info.KeyChar;
                    Console.Write("*");
                }
            }
            return mfaCode;
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

    internal interface IAWSRegionArguments : IAWSProfileLocationArgument
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
                if (!TryLoad(SettingsStore.PSDefaultSettingName, self.ProfileLocation, ref region, ref source))
                    TryLoad(SettingsStore.PSLegacyDefaultSettingName, self.ProfileLocation, ref region, ref source);
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

        private static bool TryLoad(string name, string profileLocation, ref RegionEndpoint region, ref RegionSource source)
        {
            PersistedCredentialProfile persistedProfile;
            if (SettingsStore.TryGetPersistedProfile(name, profileLocation, out persistedProfile) &&
                persistedProfile.Profile.Region != null)
            {
                region = persistedProfile.Profile.Region;
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

    internal interface IAWSCommonArguments : IAWSRegionArguments, IAWSCredentialsArguments, IAWSProfileLocationArgument
    {
    }

    internal interface IAWSCommonArgumentsFull : IAWSCommonArguments, IAWSCredentialsArgumentsFull
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
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }

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

        public CredentialProfileOptions GetCredentialProfileOptions()
        {
            return new CredentialProfileOptions
            {
                AccessKey = AccessKey,
                SecretKey = SecretKey,
                Token = SessionToken,
            };
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
        [Parameter(Position = 211)]
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public String ProfileLocation { get; set; }

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
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }

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

        public CredentialProfileOptions GetCredentialProfileOptions()
        {
            return new CredentialProfileOptions
            {
                AccessKey = AccessKey,
                SecretKey = SecretKey,
                Token = SessionToken,
            };
        }
    }

#endregion


#region Helper utils

    internal static class SettingsStore
    {
        public const string PSDefaultSettingName = "default";
        public const string PSLegacyDefaultSettingName = "AWS PS Default";

        public static List<ProfileInfo> GetProfileInfo(string profileLocation)
        {
            var persistedProfiles = (new CredentialProfileStoreChain(profileLocation)).ListPersistedProfiles();
            var result = new List<ProfileInfo>();
            foreach (var persistedProfile in persistedProfiles)
            {
                string location = null;
                var sharedCredentialsFile = persistedProfile.Store as SharedCredentialsFile;
                if (sharedCredentialsFile == null)
                {
                    var netsSDKCredentialsFile = persistedProfile.Store as NetSDKCredentialsFile;
                    if (netsSDKCredentialsFile != null)
                    {
                        location = null;
                    }
                }
                else
                {
                    location = sharedCredentialsFile.FilePath;
                }
                result.Add(new ProfileInfo
                {
                    ProfileLocation = location,
                    ProfileName = persistedProfile.Profile.Name,
                    StoreTypeName = persistedProfile.Store.GetType().Name
                });
            }
            return result;
        }

        public static bool TryGetPersistedProfile(string name, string profileLocation, out PersistedCredentialProfile persistedProfile)
        {
            return new CredentialProfileStoreChain(profileLocation).TryGetPersistedProfile(name, out persistedProfile);
        }

        public static IEnumerable<PersistedCredentialProfile> ListPersistedProfiles(string profileLocation)
        {
            return new CredentialProfileStoreChain(profileLocation).ListPersistedProfiles();
        }

        internal static void RegisterProfile(CredentialProfileOptions profileOptions, string name, string profileLocation, RegionEndpoint region)
        {
            var profile = new CredentialProfile(name, profileOptions);
            profile.Region = region;
            new CredentialProfileStoreChain(profileLocation).RegisterProfile(profile);
        }

        public static void UnregisterProfile(string name, string profileLocation)
        {
            new CredentialProfileStoreChain(profileLocation).UnregisterProfile(name);
        }
    }

    internal static class SessionKeys
    {
        public const string AWSCredentialsVariableName = "StoredAWSCredentials";
        public const string AWSRegionVariableName = "StoredAWSRegion";
        public const string AWSCallHistoryName = "AWSHistory";
        public const string AWSProxyVariableName = "AWSProxy";
    }

    internal static class CredentialProfileOptionsExtractor
    {
        private static HashSet<Type> PassThroughExtractTypes = new HashSet<Type>
        {
            typeof(InstanceProfileAWSCredentials),
#if DESKTOP
            typeof(StoredProfileFederatedCredentials),
            typeof(FederatedAWSCredentials),
#endif
        };

        private static HashSet<Type> ThrowExtractTypes = new HashSet<Type>
        {
            typeof(AssumeRoleAWSCredentials),
            typeof(URIBasedRefreshingCredentialHelper),
            typeof(AnonymousAWSCredentials),
            typeof(ECSTaskCredentials),
            typeof(EnvironmentVariablesAWSCredentials),
            typeof(StoredProfileAWSCredentials),
#if DESKTOP
            typeof(EnvironmentAWSCredentials),
            typeof(EnvironmentVariablesAWSCredentials)
#endif
        };

        public static CredentialProfileOptions ExtractProfileOptions(AWSCredentials credentials)
        {
            var type = credentials.GetType();
            if (type == typeof(BasicAWSCredentials) || type == typeof(SessionAWSCredentials))
            {
                var immutableCredentials = credentials.GetCredentials();
                return new CredentialProfileOptions
                {
                    AccessKey = immutableCredentials.AccessKey,
                    SecretKey = immutableCredentials.SecretKey,
                    Token = immutableCredentials.Token
                };
            }
            else if (PassThroughExtractTypes.Contains(type))
                return null;
            else if (ThrowExtractTypes.Contains(type))
                throw new InvalidOperationException("Cannot save credentials of type " + type.Name);
            else
                throw new InvalidOperationException("Unrecognized credentials type: " + type.Name);
        }
    }

    internal class ProfileInfo
    {
        public string ProfileName { get; set; }
        public string StoreTypeName { get; set; }
        public string ProfileLocation { get; set; }
    }
    #endregion
}
