/*******************************************************************************
 *  Copyright 2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.CredentialManagement.Internal;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Amazon.PowerShell.Common
{
    [OutputType("None")]
    [AWSCmdlet("Removes the credential profile with the supplied name from one of the local credential stores.")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [Cmdlet("Remove", "AWSCredentialProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAWSCredentialProfileCmdlet : BaseCmdlet
    {
        #region Parameter ProfileName
        /// <summary>
        /// The name associated with the credential profile that is to be deleted.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("StoredCredentials")]
        public string ProfileName { get; set; }
        #endregion

        #region Parameter ProfileLocation
        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with
        /// the AWS CLI and other AWS SDKs)
        /// </para>
        /// <para>
        /// If this optional parameter is omitted this cmdlet will search the encrypted credential
        /// file used by the AWS SDK for .NET and AWS Toolkit for Visual Studio first.
        /// If the profile is not found then the cmdlet will search in the ini-format credential
        /// file at the default location: (user's home directory)\.aws\credentials.
        /// </para>
        /// <para>
        /// If this parameter is specified then this cmdlet will only search the ini-format credential
        /// file at the location given.
        /// </para>
        /// <para>
        /// As the current folder can vary in a shell or during script execution it is advised
        /// that you use specify a fully qualified path instead of a relative path.
        /// </para>
        /// </summary>
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// Suppresses prompts for confirmation before proceeding to remove the specified credential profile.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (SettingsStore.ProfileExists(ProfileName, ProfileLocation))
            {
                if (!ConfirmShouldProceed(Force.IsPresent, ProfileName, "Remove-AWSCredentialProfile"))
                    return;

                // clear credentials from credentials store
                SettingsStore.UnregisterProfile(ProfileName, ProfileLocation);

                // find profiles with the same name in .NET and default shared files
                var leftoverProfiles = SettingsStore.GetProfileInfo(null).Where(pi => string.Equals(pi.ProfileName, ProfileName, StringComparison.Ordinal));

                // issue warnings for those profiles
                foreach(var profileProperties in leftoverProfiles)
                {
                    if (string.Equals(profileProperties.StoreTypeName, typeof(SharedCredentialsFile).Name, StringComparison.Ordinal))
                    {
                        WriteWarning("Remove succeeded, but there is still a profile named '" + ProfileName + "' in the shared credentials file at " +
                            profileProperties.ProfileLocation + ".");
                    }
                    else if (string.Equals(profileProperties.StoreTypeName, typeof(NetSDKCredentialsFile).Name, StringComparison.Ordinal))
                    {
                        WriteWarning("Remove succeeded, but there is still a profile named '" + ProfileName + "' in the .NET credentials file.");
                    }
                }
            }
            else
            {
                ThrowTerminatingError(new ErrorRecord(new ArgumentException("The CredentialProfile '" + ProfileName + "' does not exist."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this));
            }
        }
    }

}
