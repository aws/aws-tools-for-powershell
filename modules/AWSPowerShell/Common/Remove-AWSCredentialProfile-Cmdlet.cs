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
using System.Management.Automation;

namespace Amazon.PowerShell.Common
{
    [OutputType("None")]
    [AWSCmdlet("Removes the credential profile with the supplied name from one of the local credential stores.")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [Cmdlet("Remove", "AWSCredentialProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAWSCredentialProfileCmdlet : BaseCmdlet
    {
        /// <summary>
        /// The name associated with the credential profile that is to be deleted.
        /// </summary>
        [Parameter(Mandatory =true)]
        [Alias("StoredCredentials")]
        public string ProfileName { get; set; }

        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with
        /// the AWS CLI and other AWS SDKs)
        /// </para>
        /// <para>
        /// When the ini-format credential file uses the default filename ('credentials') and is
        /// placed in the default search location ('.aws' folder in the current user's profile folder,
        /// 'C:\Users\userid') this parameter is not required. This parameter is also not required
        /// when the profile to be used is contained in the encrypted credential file used by the
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
        /// Suppresses prompts for confirmation before proceeding to remove the specified credential profile.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (!ConfirmShouldProceed(Force.IsPresent, ProfileName, "Remove-AWSCredentialProfile"))
                return;

            // clear credentials from credentials store
            SettingsStore.UnregisterProfile(ProfileName, ProfileLocation);
        }
    }

}
