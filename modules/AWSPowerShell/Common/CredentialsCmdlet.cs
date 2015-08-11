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
using System.Linq;
using System.Management.Automation;

using Amazon.Runtime;
using Microsoft.PowerShell.Commands;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Creates and returns an AWSCredentials object
    /// </summary>
    [Cmdlet("New", "AWSCredentials")]
    [OutputType(typeof(AWSCredentials))]
    [AWSCmdlet("Returns a populated AWSCredentials instance.")]
    [AWSCmdletOutput("AWSCredentials", "AWSCredentials instance containing AWS credentials data.")]
    public class NewCredentialsCmdlet : PSCmdlet, IDynamicParameters
    {
        private object Parameters { get; set; }

        protected override void ProcessRecord()
        {
            AWSPSCredentials currentCredentials = null;
            var commonArguments = Parameters as IAWSCredentialsArguments;
            if (commonArguments != null)
            {
                if (!commonArguments.TryGetCredentials(out currentCredentials))
                {
                    this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Cannot determine credentials from supplied parameters"),
                                                                "ArgumentException",
                                                                ErrorCategory.InvalidArgument,
                                                                this));
                }
                else
                {
                    // used to be equivalent of write-host but got customer feedback that the inability to
                    // suppress it interfered with console output (https://forums.aws.amazon.com/thread.jspa?threadID=211600&tstart=0).
                    WriteVerbose(InitializeDefaultsCmdlet.CredentialsSourceMessage(currentCredentials));
                }
            }
            else
            {
                this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Unrecognized arguments"),
                                                            "ArgumentException",
                                                            ErrorCategory.InvalidArgument,
                                                            this));
            }
                        
            if (currentCredentials != null)
                WriteObject(currentCredentials.Credentials);
        }

        #region IDynamicParameters Members

        public object GetDynamicParameters()
        {
            Parameters = new AWSCredentialsArguments(this.SessionState);

            return Parameters;
        }

        #endregion
    }

    /// <summary>
    /// Saves AWS credentials to persistent store (-StoreAs) or temporarily for the shell using shell variable $StoredAWSCredentials.
    /// </summary>
    [Cmdlet("Set", "AWSCredentials")]
    [AWSCmdlet("Saves AWS credentials to persistent store (-StoreAs) or temporarily for the shell using shell variable $StoredAWSCredentials.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetCredentialsCmdlet : PSCmdlet, IDynamicParameters
    {
        /// <summary>
        /// The name to give to the credentials in local storage that can be used to retrieve those credentials when needed with
        /// the -ProfileName parameter on cmdlets.
        /// </summary>
        [Parameter]
        public string StoreAs { get; set; }

        private object Parameters { get; set; }

        protected override void ProcessRecord()
        {
            AWSPSCredentials currentCredentials = null;
            var commonArguments = Parameters as IAWSCredentialsArguments;
            if (commonArguments != null)
            {
                if (!commonArguments.TryGetCredentials(out currentCredentials))
                {
                    this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Cannot determine credentials from supplied parameters"),
                                                                "ArgumentException",
                                                                ErrorCategory.InvalidArgument,
                                                                this));
                }
                else
                    WriteVerbose(InitializeDefaultsCmdlet.CredentialsSourceMessage(currentCredentials));
            }
            else
            {
                this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Unrecognized arguments"),
                                                            "ArgumentException",
                                                            ErrorCategory.InvalidArgument,
                                                            this));
            }

            if (currentCredentials != null)
            {
                if (string.IsNullOrEmpty(StoreAs))
                    this.SessionState.PSVariable.Set(SessionKeys.AWSCredentialsVariableName, currentCredentials);
                else
                    SettingsStore.Save(StoreAs, currentCredentials.Credentials, null);
            }
        }

        #region IDynamicParameters Members

        public object GetDynamicParameters()
        {
            Parameters = new AWSCredentialsArguments(this.SessionState);

            return Parameters;
        }

        #endregion
    }

    /// <summary>
    /// Clears the set of AWS credentials currently set as default in the shell or, if supplied with a name, deletes the set of credentials associated with the supplied name from the local credentials store.
    /// </summary>
    [OutputType("None")]
    [AWSCmdlet("Clears the set of AWS credentials currently set as default in the shell or, if supplied with a name, deletes the set of credentials associated with the supplied name from the local credentials store.")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [Cmdlet("Clear", "AWSCredentials")]
    public class ClearCredentialsCmdlet : PSCmdlet
    {
        /// <summary>
        /// The name associated with a set of credentials in the local store that are to be deleted. If not specified,
        /// the default credentials in the shell are cleared.
        /// </summary>
        [Parameter]
        [Alias("StoredCredentials")]
        public string ProfileName { get; set; }

        protected override void ProcessRecord()
        {
            if (string.IsNullOrEmpty(ProfileName))
            {
                // clear credentials from shell
                this.SessionState.PSVariable.Set(SessionKeys.AWSCredentialsVariableName, null);
            }
            else
            {
                // clear credentials from credentials store
                SettingsStore.Delete(ProfileName);
            }
        }
    }

    /// <summary>
    /// Returns an AWSCredentials object initialized with from either credentials currently set as default in the shell or saved and associated with the supplied name from the local credential store.
    /// Optionally the cmdlet can list the names of all sets of credentials held in the store.
    /// </summary>
    [Cmdlet("Get", "AWSCredentials")]
    [OutputType("Amazon.Runtime.AWSCredentials")]
    [OutputType("String")]
    [AWSCmdletOutput("Amazon.Runtime.AWSCredentials", "Object containing a set of AWS credentials.")]
    [AWSCmdletOutput("String", "The set of names associated with saved credentials in the local store.")]
    [AWSCmdlet("Returns an AWSCredentials object initialized with from either credentials currently set as default in the shell or saved and associated with the supplied name from the local credential store. Optionally the cmdlet can list the names of all sets of credentials held in the store.")]
    public class GetCredentialsCmdlet : PSCmdlet
    {
        /// <summary>
        /// The name associated with the credentials in local storage
        /// </summary>
        [Parameter(Position = 1)]
        [Alias("StoredCredentials")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Lists the names of all credentials data sets saved in local storage
        /// </summary>
        [Parameter(Position = 2)]
        [Alias("ListStoredCredentials")]
        public SwitchParameter ListProfiles { get; set; }

        protected override void ProcessRecord()
        {                
            if (ListProfiles.IsPresent)
            {
                var names = SettingsStore.GetDisplayNames();
                if (names != null)
                    WriteObject(names);
                return;
            }

            if (string.IsNullOrEmpty(ProfileName))
            {
                var creds = this.SessionState.PSVariable.Get(SessionKeys.AWSCredentialsVariableName);
                if (creds != null && creds.Value != null && creds.Value is AWSPSCredentials)
                    WriteObject((creds.Value as AWSPSCredentials).Credentials);
            }
            else
            {
                var creds = SettingsStore.Load(ProfileName).Credentials;
                if (creds != null)
                    WriteObject(creds);
            }
        }
    }
}
