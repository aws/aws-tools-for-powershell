/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Runtime;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Amazon.Util.Internal;
using Amazon.Runtime.CredentialManagement;
using System.Reflection;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Creates or updates the credential profile named 'default' and sets the profile, and optionally a region, 
    /// as active in the current shell. The credential data to be stored in the 'default' profile can be provided 
    /// from:
    /// <ul>
    /// <li>Supplied access and secret key parameters for AWS credentials</li>
    /// <li>A pre-existing profile</li>
    /// <li>A credentials object</li>
    /// <li>Active credentials in the current shell (in the variable $StoredAWSCredentials)</li>
    /// <li>EC2 role metadata (for instances launched with instance profiles)</li>
    /// </ul>
    /// A default region to assume when the default profile is active is also set using the -Region parameter,  
    /// from a default region already set in the current shell or, if the cmdlet is executing on an EC2 instance,
    /// from the instance metadata. If a region setting cannot be determined from a parameter or the shell you are 
    /// prompted to select one.
    /// </para>
    /// <para>
    /// Note that if run on an EC2 instance and you want to select a region other than the region containing the
    /// instance you should supply the -Region parameter so that the cmdlet does not inspect EC2 instance metadata
    /// to auto-discover the region.
    /// </para>
    /// <para>
    /// In all cases a profile named 'default' will be created or updated to contain the specified credential and
    /// region data. Note that if the credential source is another profile this cmdlet effectively copies the 
    /// credential data from the source profile to the 'default' profile.
    /// </para>
    /// <para>
    /// When the cmdlet exits the active credentials can be accessed in the shell via a variable named $StoredAWSCredentials. 
    /// The active region can be found in the variable $StoredAWSRegion.
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Initialize-AWSDefaults</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Initialize", "AWSDefaultConfiguration", DefaultParameterSetName = InitializeDefaultConfigurationCmdletParametersCmdlet.InstanceProfileSet)]
    [AWSCmdlet("Creates or updates the credential profile named 'default' using supplied keys, existing credentials or profile,"
                + " or EC2 metadata. The profile and a default region is then set active in the current shell.", LegacyAlias = "Initialize-AWSDefaults")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InitializeDefaultConfigurationCmdlet : InitializeDefaultConfigurationCmdletParametersCmdlet
    {
        public const string CredentialsPrompt = "Please choose one of the following stored credentials to use";
        public const string RegionPrompt = "Please choose one of the following regions to use or specify one by system name";
        public const string AccessKeyFieldName = "AWS Access Key";
        public const string SecretKeyFieldName = "AWS Secret Key";
        public const string RegionFieldName = "Region System Name";

        const string CredentialsSourceMsg = "Credentials loaded from {0}.";

        internal static string CredentialsSourceMessage(AWSPSCredentials creds)
        {
            return string.Format(CredentialsSourceMsg, ServiceCmdlet.FormatCredentialSourceForDisplay(creds));
        }

        protected override void ProcessRecord()
        {
            AWSPSCredentials awsPSCredentialsFromCommandLine;
            RegionEndpoint regionFromCommandLine;
            AWSPSCredentials awsPSCredentialsFromDefaultProfile;
            RegionEndpoint regionFromDefaultProfile;
            AWSPSCredentials awsPSCredentialsFromPromptingUser = null;
            RegionEndpoint regionFromPromptingUser = null;

            // get what was passed in on the command line, and what's already in defaults
            GetFromCommandLine(out awsPSCredentialsFromCommandLine, out regionFromCommandLine);
            GetFromDefaultProfile(out awsPSCredentialsFromDefaultProfile, out regionFromDefaultProfile);

            // if the command line and defaults don't provide us what we need then prompt the user
            if (awsPSCredentialsFromCommandLine == null && awsPSCredentialsFromDefaultProfile == null)
                awsPSCredentialsFromPromptingUser = PromptUserForCredentials();

            if (regionFromCommandLine == null && regionFromDefaultProfile == null)
                regionFromPromptingUser = PromptUserForRegion();

            // figure out what needs to be saved to disk and what needs to get put in session
            var awsPSCredentialsToPersist = awsPSCredentialsFromCommandLine == null ? awsPSCredentialsFromPromptingUser : awsPSCredentialsFromCommandLine;
            var awsPSCredentialsToPutInSession = awsPSCredentialsToPersist == null ? awsPSCredentialsFromDefaultProfile : awsPSCredentialsToPersist;

            var regionToPersist = regionFromCommandLine == null ? regionFromPromptingUser : regionFromCommandLine;
            var regionToPutInSession = regionToPersist == null ? regionFromDefaultProfile : regionToPersist;

            // save credentials and region to disk if necessary
            if (awsPSCredentialsToPersist != null || regionToPersist != null)
            {
                if (string.Equals(AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet, ParameterSetName, StringComparison.Ordinal))
                {
                    // We're storing from the -Credential parameter to a credentials file.
                    // Only some types of AWSCredentials are supported.
                    var options = CredentialProfileOptionsExtractor.ExtractProfileOptions(awsPSCredentialsToPersist.Credentials);
                    if (options != null)
                        SettingsStore.RegisterProfile(options, SettingsStore.PSDefaultSettingName, ProfileLocation, regionToPersist);
                }
                else
                {
                    if (string.Equals(AWSCredentialsArgumentsFullCmdlet.StoredProfileSet, ParameterSetName, StringComparison.Ordinal))
                    {
                        // We're copying from one profile to another.
                        var chain = new CredentialProfileStoreChain(ProfileLocation);
                        CredentialProfile profile;
                        if (chain.TryGetProfile(ProfileName, out profile))
                        {
                            profile.CredentialProfileStore.CopyProfile(ProfileName, SettingsStore.PSDefaultSettingName, true);
                            SettingsStore.RegisterProfile(new CredentialProfileOptions(), SettingsStore.PSDefaultSettingName, ProfileLocation, regionToPersist);
                        }
                        else
                            // Parameters.TryGetCredentials has already tested for this but...
                            this.ThrowTerminatingError(new ErrorRecord(
                                new ArgumentException("Cannot determine credentials from supplied parameters"),
                                "ArgumentException", ErrorCategory.InvalidArgument, this));
                    }
                    else
                    {
                        // We're storing from individual command line values to the default profile.
                        SettingsStore.RegisterProfile(GetCredentialProfileOptions(), SettingsStore.PSDefaultSettingName, ProfileLocation, regionToPersist);
                    }
                }

                if (string.IsNullOrEmpty(ProfileLocation))
                {
                    WriteVerbose("Updated SDK profile store.");
                }
                else
                {
                    WriteVerbose("Updated credential file at " + ProfileLocation);
                }
                WriteVerbose(string.Format("Default credentials and/or region have been stored to credentials profile '{0}' and set active for this shell.", SettingsStore.PSDefaultSettingName));
            }

            string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";

            // put credentials and region in session
            this.SessionState.PSVariable.Set(scope + SessionKeys.AWSCredentialsVariableName, awsPSCredentialsToPutInSession);
            this.SessionState.PSVariable.Set(scope + SessionKeys.AWSRegionVariableName, regionToPutInSession.SystemName);
        }

        private void GetFromDefaultProfile(out AWSPSCredentials awsPSCredentialsFromDefaultProfile, out RegionEndpoint regionFromDefaultProfile)
        {
            CredentialProfile profile;
            if (SettingsStore.TryGetProfile(SettingsStore.PSDefaultSettingName, ProfileLocation, out profile))
            {
                AWSCredentials defaultAWSCredentials;
                if (SettingsStore.TryGetAWSCredentials(SettingsStore.PSDefaultSettingName, ProfileLocation, out defaultAWSCredentials))
                    awsPSCredentialsFromDefaultProfile = new AWSPSCredentials(defaultAWSCredentials, SettingsStore.PSDefaultSettingName, CredentialsSource.Profile);
                else
                    awsPSCredentialsFromDefaultProfile = null;

                regionFromDefaultProfile = profile.Region;
            }
            else
            {
                awsPSCredentialsFromDefaultProfile = null;
                regionFromDefaultProfile = null;
            }
        }

        private void GetFromCommandLine(out AWSPSCredentials awsPSCredentialsFromCommandLine, out RegionEndpoint regionFromCommandLine)
        {
            // Retrieve credentials if passed in (or from Instance Profile)
            if (this.TryGetCredentials(Host, out awsPSCredentialsFromCommandLine, SessionState))
            {
                WriteVerbose(string.Format("{0}: Credentials for this shell were set from {1}",
                                            MyInvocation.MyCommand.Name,
                                            ServiceCmdlet.FormatCredentialSourceForDisplay(awsPSCredentialsFromCommandLine)));
            }

            RegionSource regionSource;
            if (this.TryGetRegion(true, out regionFromCommandLine, out regionSource, SessionState))
            {
                WriteVerbose(string.Format("{0}: Region '{1}' was set for this shell from {2}",
                                            MyInvocation.MyCommand.Name,
                                            regionFromCommandLine.SystemName,
                                            ServiceCmdlet.FormatRegionSourceForDisplay(regionSource)));
            }
        }

        private RegionEndpoint PromptUserForRegion()
        {
            var choices = new Collection<ChoiceDescription>();
            choices.Add(new ChoiceDescription("<Specify a different region>"));
            foreach (var reg in RegionEndpoint.EnumerableAllRegions)
            {
                choices.Add(new ChoiceDescription(reg.SystemName, reg.DisplayName));
            }

            var choice = Host.UI.PromptForChoice("Specify region", RegionPrompt, choices, 0);
            if (choice != 0)
            {
                var chosenRegion = choices[choice];
                return RegionEndpoint.GetBySystemName(chosenRegion.Label);
            }

            var descriptions = new Collection<FieldDescription>();
            descriptions.Add(new FieldDescription(RegionFieldName));
            var response = Host.UI.Prompt("Region", "Please enter a region to set", descriptions);

            var regionSystemName = response[RegionFieldName].BaseObject as string;

            if (string.IsNullOrEmpty(regionSystemName)) throw new ArgumentOutOfRangeException(RegionFieldName + " is not set");
            return RegionEndpoint.GetBySystemName(regionSystemName);
        }

        private AWSPSCredentials PromptUserForCredentials()
        {
            var storedCredentials = SettingsStore.GetProfileInfo(ProfileLocation);
            if (storedCredentials.Any())
            {
                // If there are stored credentials, ask user which ones to use, or enter new ones
                var choices = new Collection<ChoiceDescription>();
                choices.Add(new ChoiceDescription("<Create new credentials set>"));
                foreach (var profileInfo in storedCredentials)
                {
                    // help message cannot be null
                    var helpMessage = profileInfo.ProfileLocation == null ? profileInfo.StoreTypeName : profileInfo.ProfileLocation;
                    choices.Add(new ChoiceDescription(profileInfo.ProfileName, helpMessage));
                }

                var choice = Host.UI.PromptForChoice("Saved credentials found", CredentialsPrompt, choices, 0);
                if (choice != 0)
                {
                    var chosenCredentials = choices[choice];
                    AWSCredentials awsCredentials;
                    if (SettingsStore.TryGetAWSCredentials(chosenCredentials.Label, ProfileLocation, out awsCredentials))
                    {
                        return new AWSPSCredentials(awsCredentials, chosenCredentials.Label, CredentialsSource.Profile);
                    }
                }
            }

            var descriptions = new Collection<FieldDescription>();
            descriptions.Add(new FieldDescription(AccessKeyFieldName));
            descriptions.Add(new FieldDescription(SecretKeyFieldName));
            var response = Host.UI.Prompt("Credentials", "Please enter your AWS Access and Secret Keys", descriptions);

            var accessKey = response[AccessKeyFieldName].BaseObject as string;
            var secretKey = response[SecretKeyFieldName].BaseObject as string;

            if (string.IsNullOrEmpty(accessKey)) throw new ArgumentOutOfRangeException(AccessKeyFieldName + " is not set");
            if (string.IsNullOrEmpty(secretKey)) throw new ArgumentOutOfRangeException(SecretKeyFieldName + " is not set");

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            // this set will be saved as our default name
            return new AWSPSCredentials(credentials, SettingsStore.PSDefaultSettingName, CredentialsSource.Profile);
        }
    }

    public class InitializeDefaultConfigurationCmdletParametersCmdlet : AWSCredentialsArgumentsFullCmdlet, IAWSCommonArgumentsFull
    {
        public const string InstanceProfileSet = "InstanceProfile";
        public const string RegionOnlySet = "RegionOnly";

        #region Parameter Region
        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the endpoint that will be used when calling service operations. Note that
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 210, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 210, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 210, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 210, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.StoredProfileSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, Position = 210, ParameterSetName = InitializeDefaultConfigurationCmdletParametersCmdlet.RegionOnlySet)]
        [Alias(AWSRegionArgumentsCmdlet.RegionParameterAlias)]
        public object Region { get; set; }
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
        /// <remarks>
        /// Note that the encrypted credential file is not supported on all platforms.
        /// It will be skipped when searching for profiles on Windows Nano Server, Mac, and Linux platforms.
        /// </remarks>
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.StoredProfileSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = InitializeDefaultConfigurationCmdletParametersCmdlet.RegionOnlySet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = InitializeDefaultConfigurationCmdletParametersCmdlet.InstanceProfileSet)]
        public override string ProfileLocation { get; set; }
#endregion

#region Parameter Scope
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the shell variables set by this cmdlet.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }
#endregion
    }


    /// <summary>
    /// <para>
    /// Clears the persisted credentials associated with the credential profile names 'default' and 'AWS PS Default', plus any 
    /// credentials and region data currently set in the session's shell variables. To clear the stored default credentials only, 
    /// use the -SkipShell parameter. To affect the current shell only, use the -SkipProfileStore parameter.
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Clear-AWSDefaults</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Clear", "AWSDefaultConfiguration")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [AWSCmdlet("Clears the persisted credentials associated with the credential profile names 'default' and 'AWS PS Default', "
                  + "plus any credentials and region data currently set in the session's shell variables. To clear the stored "
                  + "default credentials only, use the -SkipShell parameter. To affect the current shell only, use the -SkipProfileStore parameter.",
                  LegacyAlias = "Clear-AWSDefaults")]
    public class ClearDefaultConfigurationCmdlet : PSCmdlet
    {
#region Parameter SkipShell
        /// <summary>
        /// If set, the cmdlet will not clear the current shell state.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter SkipShell { get; set; }
#endregion

#region Parameter SkipProfileStore
        /// <summary>
        /// If set, the cmdlet will not clear the 'default' and 'AWS PS Default' profiles held in the credentials store.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter SkipProfileStore { get; set; }
#endregion

#region Parameter ProfileLocation
        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with
        /// the AWS CLI and other AWS SDKs)
        /// </para>
        /// <para>
        /// If this optional parameter is omitted this cmdlet will search the encrypted credential
        /// file used by the AWS SDK for .NET and AWS Toolkit for Visual Studio for the
        /// 'default' and 'AWS PS Default' profiles. If the profiles are not found then the
        /// cmdlet will search in the ini-format credential file at the default location: (user's home directory)\.aws\credentials.
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
        /// <remarks>
        /// Note that the encrypted credential file is not supported on all platforms.
        /// It will be skipped when searching for profiles on Windows Nano Server, Mac, and Linux platforms.
        /// </remarks>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }
#endregion

#region Parameter Scope
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the shell variables to clear.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// This parameter cannot be used when SkipShell is specified.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            if (!SkipProfileStore.IsPresent)
            {
                WriteWarning("Please use the Remove-AWSCredentialProfile cmdlet to delete the default profile.  This functionality will be removed from this cmdlet in a future release.");

                // Remove stored credentials
                SettingsStore.UnregisterProfile(SettingsStore.PSDefaultSettingName, ProfileLocation);

                // Remove stored legacy credentials
                SettingsStore.UnregisterProfile(SettingsStore.PSLegacyDefaultSettingName, ProfileLocation);
            }

            if (!SkipShell.IsPresent)
            {
                string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";

                // Clear credentials from shell
                this.SessionState.PSVariable.Set(scope + SessionKeys.AWSCredentialsVariableName, null);

                // Clear region from shell
                this.SessionState.PSVariable.Set(scope + SessionKeys.AWSRegionVariableName, null);
            }
            else if (MyInvocation.BoundParameters.ContainsKey("Scope"))
            {
                this.ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("Parameters Scope and SkipShell cannot be used together."),
                    "ArgumentException", ErrorCategory.InvalidArgument, this));
            }

        }
    }

    /// <summary>
    /// Writes version and copyright information for the AWSPowerShell integration to the shell. If the ListServices switch is specified
    /// the services and their API versions supported by this module are also displayed.
    /// </summary>
    [Cmdlet("Get", "AWSPowerShellVersion")]
    [AWSCmdlet("Displays version and copyright information for the AWS Tools for Windows PowerShell to the shell. If the ListServiceVersionInfo switch is specified"
                + "the services and their API versions supported by this module are also displayed.")]
    [OutputType("String")]
    [AWSCmdletOutput("String", "Version information for the tools and optionally supported services.")]
    public class GetAWSPowerShellVersionCmdlet : PSCmdlet
    {
#region Parameter ListServiceVersionInfo
        /// <summary>
        /// If specified the cmdlet also lists all supported AWS services and their versions.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListServices")]
        public SwitchParameter ListServiceVersionInfo { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var powershellAssembly = TypeFactory.GetTypeInfo(typeof(BaseCmdlet)).Assembly;

            using (var sw = new StringWriter())
            {
                var powershellInfo = FileVersionInfo.GetVersionInfo(powershellAssembly.Location);
                sw.WriteLine();
                sw.WriteLine(powershellInfo.ProductName);
                sw.WriteLine("Version {0}", powershellInfo.FileVersion);
                sw.WriteLine(powershellInfo.LegalCopyright);

                var sdkAssembly = TypeFactory.GetTypeInfo(typeof(AWSCredentials)).Assembly;
                var sdkInfo = FileVersionInfo.GetVersionInfo(sdkAssembly.Location);
                sw.WriteLine();
                sw.WriteLine(sdkInfo.ProductName);
                sw.WriteLine("Core Runtime Version {0}", sdkInfo.FileVersion);
                sw.WriteLine(sdkInfo.LegalCopyright);
                sw.WriteLine();

                sw.WriteLine("Release notes: {0}", "https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md");
                sw.WriteLine();

                // recognise 3rd party libraries
                sw.WriteLine("This software includes third party software subject to the following copyrights:");
                sw.WriteLine("- Logging from log4net, Apache License"); 
                sw.WriteLine("[http://logging.apache.org/log4net/license.html]");

                WriteObject(sw.ToString());
            }

            if (ListServiceVersionInfo.IsPresent)
            {
                var services = GetAWSServiceCmdlet.GetServices();

                foreach (var service in services.OrderBy(service => service.Name))
                {
                    var result = new PSObject();
                    result.Properties.Add(new PSNoteProperty("Service", service.Description));
                    result.Properties.Add(new PSNoteProperty("Noun Prefix", service.CmdletNounPrefix));
#if MODULAR
                    result.Properties.Add(new PSNoteProperty("Module Name", service.ModuleName));
#endif
                    result.Properties.Add(new PSNoteProperty("SDK Assembly Version", service.SDKAssemblyVersion));

                    WriteObject(result);
                }
            }
        }
    }
}
