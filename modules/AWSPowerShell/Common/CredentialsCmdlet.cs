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
using System.Net;
using System.Collections.Generic;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;

using Amazon.Runtime;
using Amazon.Util;
using Amazon.SecurityToken.SAML;

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
                if (!commonArguments.TryGetCredentials(Host, out currentCredentials))
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
        /// <para>
        /// The name to be used to identity the credentials in local storage. Use this with the -ProfileName parameter
        /// on cmdlets to load the stored credentials.
        /// </para>
        /// <para>
        /// Temporary session credentials, identified by use of the -SessionToken parameter, cannot be stored. 
        /// Specifying this parameter in addition to -SessionToken will result in an error message.
        /// </para>
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
                if (!commonArguments.TryGetCredentials(Host, out currentCredentials))
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
                var samlCredentials = currentCredentials.Credentials as StoredProfileSAMLCredentials;
                if (samlCredentials != null && samlCredentials.RequestUserCredentialCallback != null)
                {
                    // update the custom state we have applied (if the callback is ours) to hold the host 
                    // and any network credential the user has supplied to us as a shell default to fall 
                    // back on if we get called to show the password dialog
                    var callbackState = samlCredentials.CustomCallbackState as SAMLCredentialCallbackState;
                    if (callbackState != null) // is our callback that's attached
                    {
                        callbackState.ShellNetworkCredentialParameter 
                            = commonArguments != null ? commonArguments.NetworkCredential : null;
                    }
                }

                if (string.IsNullOrEmpty(StoreAs))
                    this.SessionState.PSVariable.Set(SessionKeys.AWSCredentialsVariableName, currentCredentials);
                else
                    SettingsStore.SaveAWSCredentialProfile(StoreAs, currentCredentials.Credentials, null);
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

    /// <summary>
    /// Creates or updates an endpoint settings definition for use with SAML role profiles. The name of
    /// the endpoint settings is used with the Set-AWSSamlRoleProfile cmdlet to associate one or more
    /// role profiles to a shared endpoint definition.
    /// </summary>
    [Cmdlet("Set", "AWSSamlEndpoint")]
    [OutputType(typeof(string))]
    [AWSCmdletOutput("System.String", "The cmdlet returns the name assigned to the endpoint settings to the pipeline.")]
    [AWSCmdlet("Creates or updates an endpoint settings definition for use with SAML role profiles.")]
    public class SetSamlEndpointProfileCmdlet : BaseCmdlet
    {
        /// <summary>
        /// The endpoint to be used when authenticating users prior to requesting temporary role-
        /// based AWS credentials. The full endpoint of the identity provider must be specified and
        /// it must be a HTTPS-scheme URL.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Uri Endpoint { get; set; }

        /// <summary>
        /// The user-defined name to assign to the endpoint settings. This name will be used when creating or
        /// accessing role profiles with the Set-AWSSamlRoleProfile cmdlet to set up and use role-based
        /// credential profiles that use the endpoint to authenticate the user.
        /// </summary>
        [Parameter(Mandatory = true)]
        [Alias("EndpointName")]
        public string StoreAs { get; set; }

        /// <summary>
        /// The authentication type (or protocol type) used when communicating with the endpoint.
        /// If not configured for an endpoint 'Kerberos' is assumed.
        /// </summary>
        [Parameter]
        [ValidateSet("NTLM", "Digest", "Basic", "Kerberos", "Negotiate")]
        public string AuthenticationType { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ProfileManager.RegisterSAMLEndpoint(StoreAs, 
                                                Endpoint,
                                                ParameterWasBound("AuthenticationType") ? AuthenticationType : null);
            WriteObject(StoreAs);
        }
    }

    /// <summary>
    /// <para>
    /// Creates or updates role profiles for use with a SAML federated identity provider to obtain temporary
    /// AWS credentials for roles the user is authorized to assume. The endpoint for authentication should have
    /// been configured previously using Set-AWSSamlEndpoint. Once created the role profiles can be used to obtain 
    /// time-limited temporary AWS credentials by specifying the name of the role profile to the -ProfileName 
    /// parameter of the Set-AWSCredentials cmdlet or any cmdlet that makes calls to AWS service operations. 
    /// </para>
    /// <para><br/><br/></para>
    /// <para>
    /// User authentication is not performed until AWS credentials are required, i.e. just prior to a service
    /// operation call. Additionally if the credentials expire then the tools will automatically attempt to 
    /// re-authenticate the user to obtain fresh credentials. When a role profile is configured to use the
    /// default logged-in user identity then this process happens silently. If a role profile is configured
    /// to use an alternate identity (by specifying the -NetworkCredential parameter) the user is prompted to
    /// re-enter their credentials prior to re-authentication.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "AWSSamlRoleProfile", DefaultParameterSetName = StoreOneRoleParameterSet)]
    [AWSCmdlet("Creates or updates one or more role profiles for use with authentication against a SAML-based federated identity provider to obtain temporary role-based AWS credentials.")]
    [OutputType(typeof(string))]
    [AWSCmdletOutput("System.String", "This cmdlet returns the name of the role profile to the pipeline. If the -StoreAllRoles switch is used the names of all created or updated profiles are output.")]
    public class SetSamlRoleProfileCmdlet : BaseCmdlet
    {
        public const string RolePrompt = "Select the role to be assumed when this profile is active";

        private const string StoreAllRolesParameterSet = "StoreAllRolesSet";
        private const string StoreOneRoleParameterSet = "StoreOneRoleSet";

        /// <summary>
        /// The name assigned to the endpoint definition that was previously registered using Set-AWSSamlEndpoint. 
        /// The endpoint definition contains the URL of the endpoint to be used to authenticate users prior to
        /// vending temporary AWS credentials.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string EndpointName { get; set; }

        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the principal holding the role to be assumed when credentials are 
        /// requested following successful authentication. If specified the RoleARN parameter must also 
        /// be specified.
        /// </para>
        /// <para><br/><br/></para>
        /// <para>
        /// If neither of the PrincipalARN and RoleARN parameters are supplied and the user is authorized
        /// to assume multiple roles the cmdlet will prompt to select the role that should be referenced 
        /// by the profile. The user is also prompted if ARNs are specified but cannot be found in the data
        /// returned on successful authentication.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = StoreOneRoleParameterSet)]
        public string PrincipalARN { get; set; }

        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the role to be assumed when credentials are requested following 
        /// successful authentication. If specified the PrincipalARN parameter must also be specified.
        /// </para>
        /// <para><br/><br/></para>
        /// <para>
        /// If neither of the PrincipalARN and RoleARN parameters are supplied and the user is authorized
        /// to assume multiple roles the cmdlet will prompt to select the role that should be referenced 
        /// by the profile. The user is also prompted if ARNs are specified but cannot be found in the data
        /// returned on successful authentication.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = StoreOneRoleParameterSet)]
        public string RoleARN { get; set; }

        /// <summary>
        /// <para>
        /// Optional. Supply a value only if an identity different to the user's default Windows identity
        /// should be used during authentication.
        /// </para>
        /// <para><br/><br/></para>
        /// <para>
        /// If an alternate credential is specified then when the tools need to re-authenticate the user
        /// to obtain fresh credentials following expiry the user is prompted to re-enter the password
        /// for the user account before re-authentication can be performed. When the default user identity
        /// is configured for use (-NetworkCredential not specified) re-authentication occurs silently.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("Credential", "UserCredential")]
        public PSCredential NetworkCredential { get; set; }

        /// <summary>
        /// The name to associate with the role data. This name will be used with the -ProfileName parameter 
        /// to Set-AWSCredentials cmdlet and AWS service cmdlets to load the profile and obtain temporary 
        /// AWS credentials based on the role and other data held in the profile.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = StoreOneRoleParameterSet)]
        public string StoreAs { get; set; }

        /// <summary>
        /// If set all roles available to the user are evaluated following authentication and one
        /// role profile per role will be created. The name of each role will be used for each
        /// corresponding profile that is created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = StoreAllRolesParameterSet)]
        public SwitchParameter StoreAllRoles { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                SAMLEndpointSettings endpointSettings;
                string selectedRoleARN = null;
                NetworkCredential networkCredential = null;
                if (this.NetworkCredential != null)
                    networkCredential = this.NetworkCredential.GetNetworkCredential();

                var havePrincipal = ParameterWasBound("PrincipalARN");
                var haveRole = ParameterWasBound("RoleARN");
                if (havePrincipal != haveRole)
                    ThrowExecutionError("RoleARN must be specified with PrincipalARN.", this);

                if (havePrincipal && haveRole)
                    selectedRoleARN = string.Concat(PrincipalARN, ",", RoleARN);

                WriteVerbose("Authenticating with endpoint to verify role data...");
                endpointSettings = ProfileManager.GetSAMLEndpoint(EndpointName);

                var authenticationController = new SAMLAuthenticationController();

                var samlAssertion = authenticationController.GetSAMLAssertion(endpointSettings.Endpoint, networkCredential, endpointSettings.AuthenticationType);

                if (StoreAllRoles)
                {
                    string domainUser = null;
                    if (networkCredential != null)
                        domainUser = string.Format(@"{0}\{1}", networkCredential.Domain, networkCredential.UserName);

                    var availableRoles = samlAssertion.RoleSet;
                    foreach (var roleName in availableRoles.Keys)
                    {
                        selectedRoleARN = availableRoles[roleName];
                        WriteVerbose(string.Format("Saving role '{0}' to profile '{1}'.", selectedRoleARN, roleName));

                        SettingsStore.SaveSAMLRoleProfile(roleName, EndpointName, selectedRoleARN, domainUser, null);

                        WriteObject(roleName);
                    }
                }
                else
                {
                    var profileName = SelectAndStoreProfileForRole(samlAssertion.RoleSet, selectedRoleARN, networkCredential);
                    WriteObject(profileName);
                }
            }
            catch (Exception e)
            {
                this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Unable to set credentials: " + e.Message, e),
                                                            "ArgumentException",
                                                            ErrorCategory.InvalidArgument,
                                                            this));
            }
        }

        private PSCredential RequestPasswordFromUser(string domainUser)
        {
            return Host.UI.PromptForCredential("Password Required", 
                                               "Please enter the password for " + domainUser, 
                                               domainUser, 
                                               "");
        }

        private bool TestPreselectedRoleAvailable(string targetPrincipalAndRoleARNs, ICollection<string> roleARNs)
        {
            foreach (var r in roleARNs)
            {
                if (r.Equals(targetPrincipalAndRoleARNs, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            WriteVerbose(string.Format("The specified principal and role ARNs, {0}, could not be found in the SAML response.", targetPrincipalAndRoleARNs));
            return false;
        }

        private string SelectAndStoreProfileForRole(IDictionary<string, string> availableRoles, string preselectedRoleARN, NetworkCredential networkCredential)
        {
            var selectedRoleARN = preselectedRoleARN;
            var roleSelectionNeeded = true;
            if (!string.IsNullOrEmpty(selectedRoleARN))
                roleSelectionNeeded = !TestPreselectedRoleAvailable(selectedRoleARN, availableRoles.Values);

            if (roleSelectionNeeded)
            {
                // if only one role, preselect
                if (availableRoles.Count == 1)
                {
                    selectedRoleARN = availableRoles.Values.First();
                    WriteVerbose(string.Format("Only one role available, pre-selecting role ARN {0}", preselectedRoleARN));
                }
                else
                {
                    var choices = new Collection<ChoiceDescription>();

                    // PowerShell labelling doesn't work if the shortcut is not in the label text (it
                    // adds it as extra text, which looks odd). Trying to select characters in the names
                    // can also be funky so the simplest approach is to manually prefix each role with an
                    // index number that is the shortcut. We used 1..9 on initial launch of this feature, then
                    // found a user with more than 10 roles so switched to alpha.
                    var shortcut = 'A';
                    foreach (var r in availableRoles.Keys)
                    {
                        string label = null;
                        if (shortcut <= 'Z')
                            label = string.Concat("&", shortcut++, " - ", r);
                        else
                            label = r;

                        choices.Add(new ChoiceDescription(label, availableRoles[r]));
                    }

                    var choice = Host.UI.PromptForChoice("Select Role", RolePrompt, choices, 0);
                    selectedRoleARN = choices[choice].HelpMessage;
                }
            }

            if (string.IsNullOrEmpty(selectedRoleARN))
                ThrowExecutionError("A role is required before the profile can be stored.", this);

            WriteVerbose(string.Format("Saving to profile '{0}'.\r\nUse 'Set-AWSCredentials -ProfileName {0}' to load this profile and obtain temporary AWS credentials.", StoreAs));

            string domainUser = null;
            if (networkCredential != null)
                domainUser = string.Concat(networkCredential.Domain, "\\", networkCredential.UserName);
            SettingsStore.SaveSAMLRoleProfile(StoreAs, EndpointName, selectedRoleARN, domainUser, null);

            return StoreAs;
        }
    }
}
