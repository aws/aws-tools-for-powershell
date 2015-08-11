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
using System.Runtime.CompilerServices;
using System.Text;
using System.Management.Automation;
using Amazon.Runtime;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Sets AWS default credentials and region for the shell if previously persisted. If not previously persisted,
    /// requests the data from the interactive user. Persisted credentials are given the display/access name 'AWS PS Default'.
    /// On exit, the defaults can be found in the $StoredAWSCredentials and $StoredAWSRegion shell variables.
    /// </summary>
    [Cmdlet("Initialize", "AWSDefaults")]
    [AWSCmdlet("Sets AWS default credentials and region for the shell if previously persisted. If not previously persisted, requests the data "
                + "from the interactive user. Persisted credentials are given the display/access name 'AWS PS Default'. On exit, the defaults "
                + "can be found in the $StoredAWSCredentials and $StoredAWSRegion shell variables.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class InitializeDefaultsCmdlet : PSCmdlet, IDynamicParameters
    {
        private object Parameters { get; set; }

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
            // Retrieve credentials if passed in (or from Instance Profile)
            RegionEndpoint passedRegion = null;
            AWSPSCredentials passedCredentials = null;
            var commonArguments = Parameters as IAWSCommonArguments;
            if (commonArguments != null)
            {
                if (commonArguments.TryGetCredentials(out passedCredentials))
                {
                    WriteVerbose(string.Format("{0}: Credentials for this shell were set using {1}",
                                               MyInvocation.MyCommand.Name,
                                               ServiceCmdlet.FormatCredentialSourceForDisplay(passedCredentials)));
                }

                RegionSource regionSource;
                if (commonArguments.TryGetRegion(out passedRegion, out regionSource))
                {
                    WriteVerbose(string.Format("{0}: Region '{1}' was set for this shell using {2}",
                                               MyInvocation.MyCommand.Name, 
                                               passedRegion.SystemName,
                                               ServiceCmdlet.FormatRegionSourceForDisplay(regionSource)));
                }
            }

            var defaultSettings = SettingsStore.Load(SettingsStore.PSDefaultSettingName);

            var defaultCredentials 
                = defaultSettings == null ? null 
                                          : new AWSPSCredentials(defaultSettings.Credentials, 
                                                                 SettingsStore.PSDefaultSettingName, 
                                                                 CredentialsSource.Saved);
            var shouldSaveCredentials = GetCredentials(passedCredentials, ref defaultCredentials);

            var region = defaultSettings == null ? null : defaultSettings.Region;
            var shouldSaveRegion = GetRegion(passedRegion, ref region);

            if (shouldSaveCredentials || shouldSaveRegion)
            {
                SettingsStore.Save(SettingsStore.PSDefaultSettingName, defaultCredentials.Credentials, region);
                WriteVerbose(string.Format("Default credentials and/or region have been stored to credentials profile '{0}' and set active for this shell.", SettingsStore.PSDefaultSettingName));
            }

            this.SessionState.PSVariable.Set(SessionKeys.AWSCredentialsVariableName, defaultCredentials);
            this.SessionState.PSVariable.Set(SessionKeys.AWSRegionVariableName, region.SystemName);
        }

        private bool GetRegion(RegionEndpoint passedRegion, ref RegionEndpoint region)
        {
            if (region != null && passedRegion == null)
            {
                WriteVerbose("Default region already set, skipping");
                return false;
            }

            if (passedRegion != null)
            {
                region = passedRegion;
            }
            else
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
                    region = RegionEndpoint.GetBySystemName(chosenRegion.Label);
                }

                if (region == null)
                {
                    var descriptions = new Collection<FieldDescription>();
                    descriptions.Add(new FieldDescription(RegionFieldName));
                    var response = Host.UI.Prompt("Region", "Please enter a region to set", descriptions);

                    var regionSystemName = response[RegionFieldName].BaseObject as string;

                    if (string.IsNullOrEmpty(regionSystemName)) throw new ArgumentOutOfRangeException(RegionFieldName + " is not set");
                    region = RegionEndpoint.GetBySystemName(regionSystemName);
                }
            }

            return true;
        }

        private bool GetCredentials(AWSPSCredentials passedCredentials, ref AWSPSCredentials credentialsToUse)
        {
            // If default is already set and no credentials are passed in, exit
            if (credentialsToUse != null && passedCredentials == null)
            {
                WriteVerbose("Default credentials already set, skipping.");
                return false;
            }

            if (passedCredentials != null)
            {
                // If credentials were passed in, push those into default storage
                credentialsToUse = passedCredentials;
            }
            else
            {
                var storedCredentials = SettingsStore.GetDisplayNames();
                if (storedCredentials.Count > 0)
                {
                    // If there are stored credentials, ask user which ones to use, or enter new ones
                    var choices = new Collection<ChoiceDescription>();
                    choices.Add(new ChoiceDescription("<Create new credentials set>"));
                    foreach (var cred in storedCredentials)
                    {
                        choices.Add(new ChoiceDescription(cred));
                    }

                    var choice = Host.UI.PromptForChoice("Saved credentials found", CredentialsPrompt, choices, 0);
                    if (choice != 0)
                    {
                        var chosenCredentials = choices[choice];
                        var credentials = SettingsStore.Load(chosenCredentials.Label).Credentials;
                        credentialsToUse = new AWSPSCredentials(credentials, chosenCredentials.Label, CredentialsSource.Saved);
                    }
                }

                // If credentials aren't found yet, ask user to enter new ones
                if (credentialsToUse == null)
                {
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
                    credentialsToUse = new AWSPSCredentials(credentials, SettingsStore.PSDefaultSettingName, CredentialsSource.Saved);
                }
            }

            return true;
        }

        #region IDynamicParameters Members

        public object GetDynamicParameters()
        {
            Parameters = new AWSCommonArguments(this.SessionState);

            return Parameters;
        }

        #endregion
    }

    /// <summary>
    /// Clears the persisted credentials associated with the credential profile names 'default' and 'AWS PS Default', plus any credentials and region data currently set in the session's shell variables. To clear the stored default credentials only, use the -SkipShell parameter. To affect the current shell only, use the -SkipProfileStore parameter.
    /// </summary>
    [Cmdlet("Clear", "AWSDefaults")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [AWSCmdlet("Clears the persisted credentials associated with the credential profile names 'default' and 'AWS PS Default', plus any credentials and region data currently set in the session's shell variables. To clear the stored default credentials only, use the -SkipShell parameter. To affect the current shell only, use the -SkipProfileStore parameter.")]
    public class ClearDefaultsCmdlet : PSCmdlet
    {
        /// <summary>
        /// If set, the cmdlet will not clear the current shell state.
        /// </summary>
        [Parameter]
        public SwitchParameter SkipShell { get; set; }

        /// <summary>
        /// If set, the cmdlet will not clear the 'default' and 'AWS PS Default' profiles held in the credentials store.
        /// </summary>
        [Parameter]
        public SwitchParameter SkipProfileStore { get; set; }

        protected override void ProcessRecord()
        {
            if (!SkipProfileStore.IsPresent)
            {
                // Remove stored credentials
                SettingsStore.Delete(SettingsStore.PSDefaultSettingName);

                // Remove stored legacy credentials
                SettingsStore.Delete(SettingsStore.PSLegacyDefaultSettingName);
            }

            if (!SkipShell.IsPresent)
            {
                // Clear credentials from shell
                this.SessionState.PSVariable.Set(SessionKeys.AWSCredentialsVariableName, null);

                // Clear region from shell
                this.SessionState.PSVariable.Set(SessionKeys.AWSRegionVariableName, null);
            }
        }
    }

    /// <summary>
    /// Writes version and copyright information for the AWSPowerShell integration to the shell. If the ListServices switch is specified
    /// the services and their API versions supported by this module are also displayed.
    /// </summary>
    [Cmdlet("Get", "AWSPowerShellVersion")]
    [AWSCmdlet("Displays version and copyright information for the AWS Tools for Windows PowerShell to the shell. If the ListServices switch is specified"
                + "the services and their API versions supported by this module are also displayed.")]
    [OutputType("String")]
    [AWSCmdletOutput("String", "Version information for the tools and optionally supported services.")]
    public class GetAWSPowerShellVersionCmdlet : PSCmdlet
    {
        /// <summary>
        /// If specified the cmdlet also lists all supported AWS services and their versions.
        /// </summary>
        [Parameter]
        [Alias("ListServices")]
        public SwitchParameter ListServiceVersionInfo { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            using (var sw = new StringWriter())
            {
                var powershellAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var powershellInfo = FileVersionInfo.GetVersionInfo(powershellAssembly.Location);
                sw.WriteLine();
                sw.WriteLine(powershellInfo.ProductName);
                sw.WriteLine("Version {0}", powershellInfo.FileVersion);
                sw.WriteLine(powershellInfo.LegalCopyright);

                var sdkAssembly = typeof(AWSCredentials).Assembly;
                var sdkInfo = FileVersionInfo.GetVersionInfo(sdkAssembly.Location);
                sw.WriteLine();
                sw.WriteLine(sdkInfo.ProductName);
                sw.WriteLine("Version {0}", sdkInfo.FileVersion);
                sw.WriteLine(sdkInfo.LegalCopyright);
                sw.WriteLine();

                sw.WriteLine("Release notes: {0}", "https://aws.amazon.com/releasenotes/PowerShell");
                sw.WriteLine();

                // recognise 3rd party libraries
                sw.WriteLine("This software includes third party software subject to the following copyrights:");
                sw.WriteLine("- Logging from log4net, Apache License"); 
                sw.WriteLine("[http://logging.apache.org/log4net/license.html]");
                /*
                sw.WriteLine("- NGit for AWS Elastic Beanstalk incremental push");
                sw.WriteLine("[https://github.com/mono/ngit/blob/master/NGit.license.txt]");
                sw.WriteLine("- NSch dependency for NGit");
                sw.WriteLine("[https://github.com/mono/ngit/blob/master/NSch.license.txt]");
                sw.WriteLine("- Sharpen dependency for NGit");
                sw.WriteLine("[https://github.com/mono/ngit/blob/master/Sharpen/AssemblyInfo.cs]");
                sw.WriteLine("- ICSharpCode.SharpZipLib dependency for NGit");
                sw.WriteLine("[http://www.icsharpcode.net/opensource/sharpziplib/]");
                sw.WriteLine("- Mono.Posix.dll and Mono.Security.dll dependencies for NGit");
                sw.WriteLine("[http://mono-project.com/FAQ:_Licensing#Licensing]");
                sw.WriteLine();
                */
                WriteObject(sw.ToString());
            }

            if (ListServiceVersionInfo.IsPresent)
            {
                var clients = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.IsAbstract && typeof(ServiceCmdlet).IsAssignableFrom(t))
                    .OrderBy(t => t.FullName)
                    .ToList();
                foreach (var client in clients)
                {
                    var clientAttribute = client.GetCustomAttributes(typeof(AWSClientCmdletAttribute), false).FirstOrDefault() as AWSClientCmdletAttribute;
                    if (clientAttribute != null)
                    {
                        var attribute = new PSObject();
                        attribute.Properties.Add(new PSNoteProperty("Service", clientAttribute.ServiceName));
                        attribute.Properties.Add(new PSNoteProperty("Noun Prefix", clientAttribute.ServicePrefix));
                        attribute.Properties.Add(new PSNoteProperty("Version", clientAttribute.Version));
                        WriteObject(attribute);
                    }
                }
            }
        }
    }
}
