/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Runtime.CredentialManagement;
using Amazon.SecurityToken.SAML;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// <para>
    /// Creates and returns an AWSCredentials object
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>New-AWSCredentials</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AWSCredential")]
    [OutputType(typeof(AWSCredentials))]
    [AWSCmdlet("Returns a populated AWSCredentials instance.", LegacyAlias = "New-AWSCredentials")]
    [AWSCmdletOutput("AWSCredentials", "AWSCredentials instance containing AWS credentials data.")]
    public class NewCredentialCmdlet : AWSCredentialsArgumentsFullCmdlet
    {
        protected override void ProcessRecord()
        {
            AWSPSCredentials currentCredentials = null;
            if (this.TryGetCredentials(Host, out currentCredentials, SessionState))
            {
                // used to be equivalent of write-host but got customer feedback that the inability to
                // suppress it interfered with console output (https://forums.aws.amazon.com/thread.jspa?threadID=211600&tstart=0).
                WriteVerbose(InitializeDefaultConfigurationCmdlet.CredentialsSourceMessage(currentCredentials));
            }
            else
            {
                this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Cannot determine credentials from supplied parameters"),
                    "ArgumentException", ErrorCategory.InvalidArgument, this));
            }

            if (currentCredentials != null)
            {
                if (currentCredentials.Credentials is SSOAWSCredentials ssoAWSCredentials)
                {
                    // Setting SupportsGettingNewToken to false ensures that the sso login flow is not initiated when
                    // sso token has expired.
                    ssoAWSCredentials.Options.SupportsGettingNewToken = false;
                }
                WriteObject(currentCredentials.Credentials);
            }
        }
    }

    /// <summary>
    /// <para>
    /// This enumerable represents PowerShell variables scopes as described in https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
    /// </para>
    /// </summary>
    public enum VariableScope
    {
        Global = -1,
        Local = -2,
        Script = -3,
        Private = -4
    }

    /// <summary>
    /// <para>
    /// Saves AWS credentials to persistent store (-StoreAs) or temporarily for the shell using shell variable $StoredAWSCredentials.
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Set-AWSCredentials</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "AWSCredential")]
    [AWSCmdlet("Saves AWS credentials to persistent store (-StoreAs) or temporarily for the shell using shell variable $StoredAWSCredentials."
                + "Note that temporary session-based credentials cannot be saved to the persistent store.",
                LegacyAlias = "Set-AWSCredentials")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetCredentialCmdlet : SetCredentialsParametersCmdlet
    {
        protected override void ProcessRecord()
        {
            AWSPSCredentials currentCredentials = null;

            if (this.TryGetCredentials(Host, out currentCredentials, SessionState))
            {
                WriteVerbose(InitializeDefaultConfigurationCmdlet.CredentialsSourceMessage(currentCredentials));

                if (string.IsNullOrEmpty(StoreAs))
                {
                    SetUpIfFederatedCredentials(currentCredentials);
                    string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";
                    this.SessionState.PSVariable.Set(scope + SessionKeys.AWSCredentialsVariableName, currentCredentials);
                }
                else
                {
                    if (MyInvocation.BoundParameters.ContainsKey("Scope"))
                    {
                        this.ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException("Parameters Scope and StoreAs cannot be used together."),
                            "ArgumentException", ErrorCategory.InvalidArgument, this));
                    }

                    if (string.Equals(AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet, ParameterSetName, StringComparison.Ordinal))
                    {
                        // We're storing from the -Credential parameter to a credentials file.
                        // Only some types of AWSCredentials are supported.
                        var options = CredentialProfileOptionsExtractor.ExtractProfileOptions(currentCredentials.Credentials);
                        if (options != null)
                        {
                            SettingsStore.RegisterProfile(options, StoreAs, ProfileLocation, null);
                        }
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
                                profile.CredentialProfileStore.CopyProfile(ProfileName, StoreAs, true);
                            }
                            else
                                // Parameters.TryGetCredentials has already tested for this but...
                                this.ThrowTerminatingError(new ErrorRecord(
                                    new ArgumentException("Cannot determine credentials from supplied parameters"),
                                    "ArgumentException", ErrorCategory.InvalidArgument, this));
                        }
                        else
                        {
                            // We're storing from individual command line values to a credentials file.
                            SettingsStore.RegisterProfile(GetCredentialProfileOptions(), StoreAs, ProfileLocation, null);
                        }
                    }

                    if (string.IsNullOrEmpty(ProfileLocation))
                    {
                        WriteVerbose("Updated .NET credentials file.");
                    }
                    else
                    {
                        WriteVerbose("Updated shared credentials file at " + ProfileLocation);
                    }
                }
            }
            else
            {
                this.ThrowTerminatingError(new ErrorRecord(new ArgumentException("Cannot determine credentials from supplied parameters"),
                                                            "ArgumentException",
                                                            ErrorCategory.InvalidArgument,
                                                            this));
            }
        }

        /// <summary>
        /// update the custom state we have applied to hold the host and any network credential
        /// the user has supplied to us as a shell default to fall back on if we get called to
        /// show the password dialog
        /// </summary>
        /// <param name="currentCredentials"></param>
        private void SetUpIfFederatedCredentials(AWSPSCredentials currentCredentials)
        {
            var callbackState = (currentCredentials.Credentials as FederatedAWSCredentials)?.Options.CustomCallbackState as SAMLCredentialCallbackState;

            if (callbackState != null) // is our callback that's attached
            {
                callbackState.ShellNetworkCredentialParameter = NetworkCredential;
            }
        }
    }

    public class SetCredentialsParametersCmdlet : AWSCredentialsArgumentsFullCmdlet
    {
#region Parameter StoreAs
        /// <summary>
        /// <para>
        /// The name to be used to identity the credentials in local storage. Use this with the -ProfileName parameter
        /// on cmdlets to load the stored credentials.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.StoredProfileSet)]
        public string StoreAs { get; set; }
#endregion

#region Parameter Scope
        /// <summary>
        /// <para>
        /// When saving AWS credentials to the shell variable $StoredAWSCredentials, this parameter allows to specify the scope of the variable.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// This parameter cannot be used when StoreAs is specified.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.AWSCredentialsObjectSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFullCmdlet.StoredProfileSet)]
        public VariableScope Scope { get; set; }
#endregion
    }


    /// <summary>
    /// <para>
    /// Clears the set of AWS credentials currently set as default in the shell
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Clear-AWSCredentials</i>.
    /// </para>
    /// </summary>
    [OutputType("None")]
    [AWSCmdlet("Clears the set of AWS credentials currently set as default in the shell or, if supplied with a name, deletes the set of credentials "
               + "associated with the supplied name from the local credentials store.",
               LegacyAlias = "Clear-AWSCredentials")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    [Cmdlet("Clear", "AWSCredential")]
    public class ClearCredentialCmdlet : PSCmdlet
    {
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
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }
#endregion

#region Parameter Scope
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the variable $StoredAWSCredentials to clear.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// This parameter cannot be used when ProfileName is specified.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            string scope = MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope.ToString() + ":" : "";
            // clear credentials from shell
            this.SessionState.PSVariable.Set(scope + SessionKeys.AWSCredentialsVariableName, null);
        }
    }

    /// <summary>
    /// <para>
    /// Returns an AWSCredentials object initialized with from either credentials currently set as default in the shell or saved and associated with the supplied name from the local credential store.
    /// Optionally the cmdlet can list the names, types, and locations of all sets of credentials held in local stores.
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Get-AWSCredentials</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSCredential", DefaultParameterSetName ="Shell")]
    [OutputType("Amazon.Runtime.AWSCredentials")]
    [OutputType("String")]
    [AWSCmdletOutput("Amazon.Runtime.AWSCredentials", "Object containing a set of AWS credentials.")]
    [AWSCmdletOutput("String", "The set of names associated with saved credentials in local stores.")]
    [AWSCmdletOutput("Amazon.Powershell.Common.ProfileInfo", "The set of names, types, and locations associated with saved credentials in local stores.")]
    [AWSCmdlet("Returns an AWSCredentials object initialized with from either credentials currently set as default in the shell or saved and "
               + "associated with the supplied name from a local credential store. Optionally the cmdlet can list the names, types, and locations "
               + "of all sets of credentials held in the store.",
               LegacyAlias = "Get-AWSCredentials")]
    public class GetCredentialCmdlet : PSCmdlet
    {
#region Parameter ProfileName
        /// <summary>
        /// The name associated with the credentials in local storage
        /// </summary>
        [Parameter(Position = 1, ParameterSetName="SingleProfile", ValueFromPipelineByPropertyName = true)]
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
        [Parameter(ParameterSetName = "SingleProfile", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "ListName", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "ListDetail", ValueFromPipelineByPropertyName = true)]
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        public string ProfileLocation { get; set; }
#endregion

#region Parameter ListProfile
        /// <summary>
        /// Lists the names of all CredentialProfiles saved in local storage
        /// </summary>
        [Parameter(ParameterSetName = "ListName", ValueFromPipelineByPropertyName = true)]
        [Alias("ListStoredCredentials", "ListProfiles")]
        public SwitchParameter ListProfile { get; set; }
#endregion

#region Parameter ListProfileDetail
        /// <summary>
        /// List the name, type, and location of all CredentialProfiles saved in local storage
        /// </summary>
        [Parameter(ParameterSetName = "ListDetail", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ListProfileDetail { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            if (ListProfile.IsPresent)
            {
                WriteWarning("The ListProfile switch is deprecated and will be removed from a future release.  Please use ListProfileDetail instead.");
                WriteObject(SettingsStore.GetProfileInfo(ProfileLocation).Select(pi => pi.ProfileName), true);
                return;
            }
            else if (ListProfileDetail.IsPresent)
            {
                WriteObject(SettingsStore.GetProfileInfo(ProfileLocation), true);
                return;
            }

            if (string.IsNullOrEmpty(ProfileName))
            {
                // Setting SupportsGettingNewToken to false ensures that the sso login flow is not initiated when
                // sso token has expired.

                var creds = this.SessionState.PSVariable.Get(SessionKeys.AWSCredentialsVariableName);
                if (creds != null && creds.Value != null && creds.Value is AWSPSCredentials)
                {
                    if (creds.Value is SSOAWSCredentials ssoAWSCredentials)
                    {
                        ssoAWSCredentials.Options.SupportsGettingNewToken = false;
                    }

                    WriteObject((creds.Value as AWSPSCredentials).Credentials);
                }
            }
            else
            {
                CredentialProfile profile;
                if (SettingsStore.TryGetProfile(ProfileName, ProfileLocation, out profile))
                {
                    var profileCreds = profile.GetAWSCredentials(profile.CredentialProfileStore);
                    if (profileCreds is SSOAWSCredentials ssoAWSCredentials)
                    {
                        ssoAWSCredentials.Options.SupportsGettingNewToken = false;
                    }
                    WriteObject(profileCreds);
                }
            }
        }
    }

    /// <summary>
    /// Creates or updates an endpoint settings definition for use with SAML role profiles. The name of
    /// the endpoint settings is used with the Set-AWSSamlRoleProfile and Set-AWSCredentials cmdlets to associate one or more
    /// role profiles to a shared endpoint definition.
    /// </summary>
    [Cmdlet("Set", "AWSSamlEndpoint")]
    [OutputType(typeof(string))]
    [AWSCmdletOutput("System.String", "The cmdlet returns the name assigned to the endpoint settings to the pipeline.")]
    [AWSCmdlet("Creates or updates an endpoint settings definition for use with SAML role profiles.")]
    public class SetSamlEndpointProfileCmdlet : BaseCmdlet
    {
#region Parameter Endpoint
        /// <summary>
        /// The endpoint to be used when authenticating users prior to requesting temporary role-
        /// based AWS credentials. The full endpoint of the identity provider must be specified and
        /// it must be a HTTPS-scheme URL.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public Uri Endpoint { get; set; }
#endregion

#region Parameter StoreAs
        /// <summary>
        /// The user-defined name to assign to the endpoint settings. This name will be used when creating or
        /// accessing role profiles with the Set-AWSSamlRoleProfile cmdlet to set up and use role-based
        /// credential profiles that use the endpoint to authenticate the user.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointName")]
        public string StoreAs { get; set; }
#endregion

#region Parameter AuthenticationType
        /// <summary>
        /// The authentication type (or protocol type) used when communicating with the endpoint.
        /// If not configured for an endpoint 'Kerberos' is assumed.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateSet("NTLM", "Digest", "Kerberos", "Negotiate")]
        public string AuthenticationType { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var samlEndpointManager = new SAMLEndpointManager();
            SAMLEndpoint samlEndpoint;
            if (ParameterWasBound("AuthenticationType"))
            {
                var authenticationType = (SAMLAuthenticationType)(Enum.Parse(typeof(SAMLAuthenticationType), AuthenticationType));
                samlEndpoint = new SAMLEndpoint(StoreAs, Endpoint, authenticationType);
            }
            else
            {
                samlEndpoint = new SAMLEndpoint(StoreAs, Endpoint);
            }

            samlEndpointManager.RegisterEndpoint(samlEndpoint);

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

        private const string StoreAllRolesParameterSet = "StoreAllRoles";
        private const string StoreOneRoleParameterSet = "StoreOneRole";

#region Parameter EndpointName
        /// <summary>
        /// The name assigned to the endpoint definition that was previously registered using Set-AWSSamlEndpoint.
        /// The endpoint definition contains the URL of the endpoint to be used to authenticate users prior to
        /// vending temporary AWS credentials.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string EndpointName { get; set; }
#endregion

#region Parameter PrincipalARN
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
        [Parameter(ParameterSetName = StoreOneRoleParameterSet, ValueFromPipelineByPropertyName = true)]
        public string PrincipalARN { get; set; }
#endregion

#region Parameter RoleARN
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
        [Parameter(ParameterSetName = StoreOneRoleParameterSet, ValueFromPipelineByPropertyName = true)]
        public string RoleARN { get; set; }
#endregion

#region Parameter NetworkCredential
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
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credential", "UserCredential")]
        public PSCredential NetworkCredential { get; set; }
#endregion

#region Parameter StoreAs
        /// <summary>
        /// The name to associate with the role data. This name will be used with the -ProfileName parameter
        /// to Set-AWSCredentials cmdlet and AWS service cmdlets to load the profile and obtain temporary
        /// AWS credentials based on the role and other data held in the profile.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = StoreOneRoleParameterSet, ValueFromPipelineByPropertyName = true)]
        public string StoreAs { get; set; }
#endregion

#region Parameter StoreAllRoles
        /// <summary>
        /// If set all roles available to the user are evaluated following authentication and one
        /// role profile per role will be created. The name of each role will be used for each
        /// corresponding profile that is created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = StoreAllRolesParameterSet, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter StoreAllRoles { get; set; }
#endregion

#region Parameter STSEndpointRegion
        /// <summary>
        /// <para>
        /// Specifies the region to be used when making calls to STS to obtain temporary credentials
        /// after successful authentication. 
        /// </para>
        /// <para>
        /// This parameter is only needed in regions where a specific regional endpoint for STS must 
        /// be used (eg cn-north-1). In all regions where the global sts.amazonaws.com endpoint can be 
        /// used this parameter should not be specified.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string STSEndpointRegion { get; set; }
#endregion

        protected override void ProcessRecord()
        {
            try
            {
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
                var samlEndpoint = (new SAMLEndpointManager()).GetEndpoint(EndpointName);

                var authenticationController = new SAMLAuthenticationController();

                var samlAssertion = authenticationController.GetSAMLAssertion(samlEndpoint.EndpointUri.ToString(),
                    networkCredential, samlEndpoint.AuthenticationType.ToString());

                RegionEndpoint stsRegionEndpoint = null;
                if (!string.IsNullOrEmpty(STSEndpointRegion))
                    stsRegionEndpoint = RegionEndpoint.GetBySystemName(STSEndpointRegion);

                if (StoreAllRoles)
                {
                    string domainUser = null;
                    if (networkCredential != null)
                    {
                        // some credentials are entered in email format, so do not assume a domain
                        // was present
                        if (string.IsNullOrEmpty(networkCredential.Domain))
                            domainUser = networkCredential.UserName;
                        else
                            domainUser = string.Format(@"{0}\{1}", networkCredential.Domain, networkCredential.UserName);
                    }

                    var availableRoles = samlAssertion.RoleSet;
                    foreach (var roleName in availableRoles.Keys)
                    {
                        selectedRoleARN = availableRoles[roleName];
                        WriteVerbose(string.Format("Saving role '{0}' to profile '{1}'.", selectedRoleARN, roleName));

                        var options = new CredentialProfileOptions()
                        {
                            EndpointName = EndpointName,
                            RoleArn = selectedRoleARN,
                            UserIdentity = domainUser
                        };
                        SettingsStore.RegisterProfile(options, roleName, null, stsRegionEndpoint);

                        WriteObject(roleName);
                    }
                }
                else
                {
                    var profileName = SelectAndStoreProfileForRole(samlAssertion.RoleSet, selectedRoleARN, networkCredential, stsRegionEndpoint);
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

        private string SelectAndStoreProfileForRole(IDictionary<string, string> availableRoles,
                                                    string preselectedRoleARN,
                                                    NetworkCredential networkCredential,
                                                    RegionEndpoint stsEndpointRegion)
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
            {
                // user identity can be expressed in domain\user or email@domain formats - so don't auto-format
                // to domain\user unless a domain is actually present (if we do, profile ends up with \user@domain
                // and the user needs to strip it out each time we demand the password)
                domainUser = string.IsNullOrEmpty(networkCredential.Domain)
                    ? networkCredential.UserName
                    : string.Concat(networkCredential.Domain, "\\", networkCredential.UserName);
            }

            var options = new CredentialProfileOptions()
            {
                EndpointName = EndpointName,
                RoleArn = selectedRoleARN,
                UserIdentity = domainUser
            };
            SettingsStore.RegisterProfile(options, StoreAs, null, stsEndpointRegion);

            return StoreAs;
        }
    }
}
