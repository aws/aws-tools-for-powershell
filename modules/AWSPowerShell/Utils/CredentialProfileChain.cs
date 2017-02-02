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
using System.IO;
using System.Management.Automation;
using System.Reflection;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.Util.Internal;
using Amazon.Runtime.Internal.Settings;
using Amazon.Runtime.Internal;
using System.Linq;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.CredentialManagement.Internal;
#if CORECLR
using System.Runtime.InteropServices;
#endif

namespace Amazon.PowerShell.Utils
{
    /// <summary>
    /// Class to abstract the combined use of NetSDKCredentialsFile and SharedCredentialsFile where possible.
    /// </summary>
    /// <returns></returns>
    internal class CredentialProfileChain : ICredentialProfileSource
    {
        public string ProfilesLocation { get; set; }
        public CredentialProfileChain(string profilesLocation)
        {
            ProfilesLocation = profilesLocation;
        }

        /// <summary>
        /// Tries to get a profile based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             search sdk credentials file then shared credentials file in default location
        /// null or empty               no                              search shared credentials file in the default location
        /// non-null and non-empty      yes                             search shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              search shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        public bool TryGetProfile(string profileName, out CredentialProfile profile)
        {
            PersistedCredentialProfile persistedProfile;
            if (TryGetPersistedProfile(profileName, out persistedProfile))
            {
                profile = persistedProfile.Profile;
                return true;
            }
            else
            {
                profile = null;
                return false;
            }
        }

        /// <summary>
        /// Tries to get a persisted profile based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             search sdk credentials file then shared credentials file in default location
        /// null or empty               no                              search shared credentials file in the default location
        /// non-null and non-empty      yes                             search shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              search shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="persistedProfile"></param>
        /// <returns></returns>
        public bool TryGetPersistedProfile(string profileName, out PersistedCredentialProfile persistedProfile)
        {
            if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable)
            {
                var netCredentialsFile = new NetSDKCredentialsFile();
                CredentialProfile netProfile;
                if (netCredentialsFile.TryGetProfile(profileName, out netProfile))
                {
                    persistedProfile = new PersistedCredentialProfile(netProfile, netCredentialsFile);
                    return true;
                }
            }

            var sharedCredentialsFile = new SharedCredentialsFile(ProfilesLocation);
            CredentialProfile sharedProfile;
            if (sharedCredentialsFile.TryGetProfile(profileName, out sharedProfile))
            {
                persistedProfile = new PersistedCredentialProfile(sharedProfile, sharedCredentialsFile);
                return true;
            }

            persistedProfile = null;
            return false;
        }

        /// <summary>
        /// List profile names based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             include profiles from sdk credentials file and shared credentials file in default location
        /// null or empty               no                              include profiles from shared credentials file in the default location
        /// non-null and non-empty      yes                             include profiles from shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              include profiles from shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <returns></returns>
        public List<string> ListProfileNames()
        {
            return new List<string>(ListPersistedProfiles().Select(p => p.Profile.Name));
        }

        /// <summary>
        /// List profiles based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             include profiles from sdk credentials file and shared credentials file in default location
        /// null or empty               no                              include profiles from shared credentials file in the default location
        /// non-null and non-empty      yes                             include profiles from shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              include profiles from shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <returns></returns>
        public List<PersistedCredentialProfile> ListPersistedProfiles()
        {
            var profiles = new List<PersistedCredentialProfile>();

            if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable)
            {
                var netSdkFile = new NetSDKCredentialsFile();
                profiles.AddRange(netSdkFile.ListProfiles().Select(p => new PersistedCredentialProfile(p, netSdkFile)));
            }
            var sharedFile = new SharedCredentialsFile(ProfilesLocation);
            profiles.AddRange(sharedFile.ListProfiles().Select(p => new PersistedCredentialProfile(p, sharedFile)));

            return profiles;
        }

        /// <summary>
        /// Unregister a profile based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             unregister from sdk credentials file, if not there unregister from shared credentials file in default location
        /// null or empty               no                              unregister from shared credentials file in the default location
        /// non-null and non-empty      yes                             unregister from shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              unregister from shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <returns></returns>
        public void UnregisterProfile(string profileName)
        {
            PersistedCredentialProfile persistedProfile;
            if (TryGetPersistedProfile(profileName, out persistedProfile))
            {
                persistedProfile.Store.UnregisterProfile(profileName);
            }
        }

        /// <summary>
        /// Register a profile based on the rules of the CredentialProfileChain.
        ///
        /// profilesLocation:           platform supports UserCrypto:   action:
        /// null or empty               yes                             register in sdk credentials file
        /// null or empty               no                              register in shared credentials file in the default location
        /// non-null and non-empty      yes                             register in shared credentials file at disk path: profilesLocation
        /// non-null and non-empty      no                              register in shared credentials file at disk path: profilesLocation
        /// </summary>
        /// <returns></returns>
        public void RegisterProfile(CredentialProfile profile)
        {
            if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable)
            {
                new NetSDKCredentialsFile().RegisterProfile(profile);
            }
            else
            {
                new SharedCredentialsFile(ProfilesLocation).RegisterProfile(profile);
            }
        }
    }

    /// <summary>
    /// Represents a CredentialProfile that's been persisted to an <see cref="ICredentialProfileStore"/>
    /// </summary>
    internal class PersistedCredentialProfile
    {
        private const string CredentialsTypeField = "CredentialsType";

        public CredentialProfile Profile { get; private set; }
        public ICredentialProfileStore Store { get; private set; }

        public PersistedCredentialProfile(CredentialProfile profile, ICredentialProfileStore store)
        {
            Profile = profile;
            Store = store;
        }

        public bool TryGetAWSCredentials(out AWSCredentials credentials)
        {
            if (Profile.CanCreateAWSCredentials)
            {
                credentials = AWSCredentialsFactory.GetAWSCredentials(Profile, Store);
                return true;
            }
            else
            {
                //might be a legacy profile with nothing but a CredentialsTypeField property and a region
                var credentialsTypeString = CredentialProfileUtils.GetProperty(Profile, CredentialsTypeField);
                var type = credentialsTypeString == null ? null : TypeFactory.GetTypeInfo(typeof(AWSCredentials)).Assembly.GetType(credentialsTypeString);
                if (type == typeof(InstanceProfileAWSCredentials))
                {
                    credentials = new InstanceProfileAWSCredentials();
                    return true;
                }
            }
            credentials = null;
            return false;
        }
    }
}
